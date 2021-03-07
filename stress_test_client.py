import latency_results
import math
import paho.mqtt.client as mqtt
import json
import time
import sys
import random

class StressTestClient:
    def __init__(self, id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes):
        self.id = id
        self.topic = f'stress_test/publisher/{id}';
        self.packet_interval_ms = packet_interval_ms
        self.total_packets_to_send = math.floor((1000 / packet_interval_ms) * duration_seconds)
        self.qos_level = qos_level
        self.packet_size_bytes = packet_size_bytes
        self.packet_payload = bytearray(packet_size_bytes)
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

        payload_byte_arr = bytearray(json.dumps(message).encode('utf-8'))
        for i in range(0, len(payload_byte_arr)):
            self.packet_payload[i] = payload_byte_arr[i]
            
        self.client.publish(self.topic, self.packet_payload)

        for i in range(0, len(payload_byte_arr)):
            self.packet_payload[i] = 0

        self.current_packet = self.current_packet + 1

    def get_packet_size(self):
        if self.min_packet_size_bytes <= 0 or self.max_packet_size_bytes <= 0:
            return -1
        elif self.max_packet_size_bytes < self.min_packet_size_bytes:
            return -1
        else:
            return random.randint(self.min_packet_size_bytes, self.max_packet_size_bytes)

    """Gets the true data from a packet payload that has been appended with garbage to increase size"""
    def decode_payload(self, payload):
        # Convert the payload from immutable bytes into a mutable byte array
        payload_byte_arr = bytearray(payload)
        sanitized_payload_byte_arr = bytearray()
        for i in range(0, len(payload_byte_arr)):
            if payload_byte_arr[i] != 0:
                sanitized_payload_byte_arr.append(payload_byte_arr[i])
            else:
                break
        return sanitized_payload_byte_arr

    def on_receive_message(self, client, userdata, msg):
        packet_data = json.loads(self.decode_payload(msg.payload))

        time_in_milliseconds = time.time_ns() // 1_000_000
        latency = time_in_milliseconds - packet_data["time_sent"]
        packet_num = packet_data["packet_num"]
        
        self.results.add_latency_info(packet_num, latency)