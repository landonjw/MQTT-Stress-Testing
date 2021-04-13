import latency_results
import math
import shadow.paho.mqtt.modified_client as mqtt
import json
import time
import sys
import random
import byte_array_pool

class StressTestClient:
    """
    Represents an MQTT client with the purpose of stress testing the MQTT network.

    Attributes
    ---------
    id: Integer
        ID of the stress test client. This should be unique to a single client instance.
    topic: String
        The MQTT topic the client should send messages to.
    total_packets_to_send: Integer
        The number of packets the client should send over it's life.
    qos_level: Integer
        The quality of service level. Must be 0, 1, or 2.
    packet_size_bytes: Integer
        The size of the payload to generate per-message. Must be between 100 bytes to 256 megabytes.
    current_packet: Integer
        Tracks how many messages the client has sent.
        This value is liable to change whenever the client publishes a new packet.
    results: LatencyResultsProcessor
        The resulting latency of all published & received messages.

    Methods
    -------
    publish_message()
        Publishes a single message over the MQTT network.
    """

    def __init__(self, id, broker_host, broker_port, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes):
        self.__validate_client_props(id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes)

        # Only gets to this point of all inputs are valid
        self.id = id
        self.topic = f'stress_test/publisher/{id}';
        self.packet_interval_ms = packet_interval_ms
        # Calculates the total packets to send from the client from the duration and packet interval.
        self.total_packets_to_send = math.floor((1000 / packet_interval_ms) * duration_seconds)
        self.qos_level = qos_level
        self.packet_size_bytes = packet_size_bytes
        # Fetches or creates a byte array to generate payloads from.
        # This will be a byte array with size of max_packet_size and may be shared with other stress test clients.
        # Due to this shared aspect, we must be careful of unexpected mutations, particularly when publishing.
        # This is used to optimize space consumption when end users want to use 256MB packets.
        # (Why you would want to send 256MB payloads through an IoT device is beyond me)
        self.__packet_payload = byte_array_pool.get_or_create_byte_array(self.packet_size_bytes)
        # Keeps track of how many packets the client has already published.
        self.current_packet = 0
        # Stores and manipulates the resulting latency of packets for the client.
        self.results = latency_results.LatencyResultsProcessor(self.total_packets_to_send)
        self.__initialize_client(broker_host, broker_port)

    def __validate_client_props(self, id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes):
        """
        Validates the properties coming into the StressTestClient upon initialization.

        Arguments
        ---------
        id: Integer
            ID of the stress test client. This should be unique.
        packet_interval_ms: Integer
            The interval in milliseconds before the packet should send a packet. Must be above or equal to 25 and divisible by 25.
        duration_seconds: Integer
            How long the client should generate messages for. Must be above 0.
            It not necessarily accurate. Simply used in determining the number of packets the client should send over the network using packet_interval_ms.
        qos_level: Integer
            The quality of service level. Must be 0, 1, or 2.
        packet_size_bytes: Integer
            The size of the payload to generate per-message. Must be between 100 bytes to 256 megabytes.

        Raises
        ------
        ValueError
            If a value is illegal for the initialization of a stress test client
        """
        if packet_interval_ms < 25:
            raise ValueError("packet interval must be above or equal to 25ms")
        if packet_interval_ms % 25 != 0:
            raise ValueError("packet interval must be divisible by 25ms")
        if duration_seconds <= 0:
            raise ValueError("duration must be above 0")
        if qos_level < 0 or qos_level > 2:
            raise ValueError("quality of service must be between 0 and 2")
        if packet_size_bytes < 100 or packet_size_bytes > 268435456:
            raise ValueError("packet size must be between 100 bytes to 256 megabytes")

    def __initialize_client(self, broker_host, broker_port):
        """
        Creates an MQTT client using a modified version of the Paho-MQTT library and subscribes to it's unique publishing channel.

        Arguments
        ---------
        broker_host: String
            The hostname of the broker to connect to.
        broker_port: Integer
            The port of the broker to connect to.
        """
        self.client = mqtt.Client(client_id = f'Stress Test Publisher {self.id}')
        self.client.on_message = self.__on_receive_message
        self.client.connect(broker_host, broker_port, 60)
        self.client.subscribe(self.topic, self.qos_level)
        # Causes the client's message receival processing to handle on a different thread.
        self.client.loop_start()

    def publish_message(self):
        """
        Publishes a single packet to the broker.
        This will cause a round-trip, with the client receiving the message and processing the latency of the trip.
        This packet may be appended by garbage (bytes of value 0) to artificially increase the packet size for testing.
        """
        time_in_milliseconds = time.time_ns() // 1_000_000

        # packet number and time sent are added to the packet to process the results when received.
        message = {
            "client_id": self.id,
            "packet_num": self.current_packet,
            "time_sent": time_in_milliseconds
        };

        # Encodes the payload into a bytearray and inserts it into the beginning of the payload bytearray.
        payload_byte_arr = bytearray(json.dumps(message).encode('utf-8'))
        for i in range(0, len(payload_byte_arr)):
            self.__packet_payload[i + 100] = payload_byte_arr[i]
            
        # Publishes the message and stops the thread until it's finished publishing.
        # We stop the thread to prevent mutations of the shared payload array during publish.
        publish = self.client.publish(self.topic, self.__packet_payload)
        publish.wait_for_publish()

        # Clear the message data from the shared payload array to prepare for next publish.
        for i in range(0, 100 + len(payload_byte_arr)):
            self.__packet_payload[i] = 0

        # We record the time from when the client starting publishing until now in order to offset the latency.
        # This allows us to deduct the time it took to write to socket from the results.
        time_in_milliseconds_now = time.time_ns() // 1_000_000
        self.results.add_offset(self.current_packet, time_in_milliseconds_now - time_in_milliseconds)
        self.current_packet = self.current_packet + 1

    def __decode_payload(self, payload):
        """
        Decodes the payload bytearray, removing any garbage appended to it.

        Arguments
        ---------
        payload: bytearray
            The payload of an MQTT packet, sent by a stress test client.
            This payload may have garbage (bytes of 0 value) appended to it to artificially increase the packet size for testing.

        Returns
        -------
        bytearray
            The payload with all garbage removed, containing only the true json payload
        """
        # Convert the payload from immutable bytes into a mutable byte array
        sanitized_payload_byte_arr = bytearray()
        hit_message = False
        for i in range(0, len(payload)):
            if payload[i] != 0:
                hit_message = True
                sanitized_payload_byte_arr.append(payload[i])
            else:
                if hit_message == True :
                    break
        # print(f'Sanitized: {sanitized_payload_byte_arr}')
        return sanitized_payload_byte_arr

    def __on_receive_message(self, client, userdata, msg):
        """
        Invoked when a packet is received by the MQTT stress test client.
        These packets should only be packets published by the same client.

        Arguments
        ---------
        client: Not used
        userdata: Not used
        msg: MQTTMessage
            The message received. Contains a payload bytearray that we use to calculate latency.

        Raises
        ------
        ValueError
            If the client id in the payload is not the same as the client receiving the message
        """
        time_in_milliseconds = time.time_ns() // 1_000_000
        packet_data = json.loads(self.__decode_payload(msg.payload))
        
        # Deduct the epoch in packet by the time now in order to get latency of the trip
        latency = time_in_milliseconds - packet_data["time_sent"]
        packet_num = packet_data["packet_num"]

        if packet_data["client_id"] != self.id:
            raise ValueError("message received has invalid client id")
        
        self.results.add_latency_info(packet_num, latency)