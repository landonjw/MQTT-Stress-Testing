import latency_results
import math
import paho.mqtt.client as mqtt
import json
import time
import sys

class StressTestClient:
    def __init__(self, id, packet_interval_ms, duration_seconds, qos_level, min_packet_size_bytes, max_packet_size_bytes):
        self.id = id
        self.topic = f'stress_test/publisher/{id}';
        self.packet_interval_ms = packet_interval_ms
        self.total_packets_to_send = math.floor((1000 / packet_interval_ms) * duration_seconds)
        print(self.total_packets_to_send)
        self.qos_level = qos_level
        self.current_packet = 0
        self.results = latency_results.LatencyResultsProcessor(self.total_packets_to_send)

    def initialize_client(self, broker_ip, broker_port):
        self.client = mqtt.Client(client_id = f'Stress Test Publisher {self.id}')
        self.client.on_message = self.on_receive_message

        self.client.connect(broker_ip, broker_port, 60)
        self.client.subscribe(self.topic, self.qos_level)
        self.client.loop_start()

    def publish_message(self):
        time_in_milliseconds = time.time_ns() // 1_000_000
        message = {
            "client_id": self.id,
            "packet_num": self.current_packet,
            "time_sent": time_in_milliseconds
        };
        
        self.client.publish(self.topic, json.dumps(message))
        self.current_packet = self.current_packet + 1

    """Modifies the size of a given payload so that it will fit to a given size.
    
    This is done by appending a bunch of garbage bytes (of value 0) to the payload until it fits the desired size.
    This can then be decoded later via decode_payload
    """
    def modify_packet_size(payload, new_size):
        payload_byte_arr = bytearray(payload.encode('utf-8')) # Creates a mutable byte array from the payload of the packet
        original_size = sys.getsizeof(payload_byte_arr)
        payload_byte_arr.extend(bytearray(new_size - original_size))
        return payload_byte_arr

    """Gets the true data from a packet payload that has been appended with garbage to increase size"""
    def decode_payload(self, payload):
         # Convert the payload from immutable bytes into a mutable byte array
        payload_byte_arr = bytearray(payload)
         # Filters all garbage values from the payload
        return bytearray(filter(lambda val: val != b'\x00', payload_byte_arr))

    def on_receive_message(self, client, userdata, msg):
        packet_data = json.loads(self.decode_payload(msg.payload))

        time_in_milliseconds = time.time_ns() // 1_000_000
        latency = time_in_milliseconds - packet_data["time_sent"]
        packet_num = packet_data["packet_num"]
        
        self.results.add_latency_info(packet_num, latency)