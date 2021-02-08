"""
MQTT Project - Stress Testing Program
Software Engineering Project - COMP-CO867 / Winter 2021

This is a continuation of an applied research project for assessing the MQTT protocol.
This program is intended to stress test a broker.
"""

import time
import paho.mqtt.client as mqtt
import os
import stress_test_result_processor as strp
from array import *
import math
import packet_data_parse_utils as parse_utils

# Details for connecting to the broker. Adjust these for your own network.
broker_ip = "192.168.137.1"
broker_port = 11883

# Reference to the client that initializes the stress test. This will be alive throughout the entire lifecycle of the program.
# The ONLY resposibility of this client is for communication with the UI client. This does not partake in the stress testing.
master_client = None

# The list of clients that stress test the network. This will be populated when a stress test begins and be cleared when a stress test ends.
stress_testing_clients = []

# If a stress test is currently running.
stress_test_running = False

# The number of clients to send requests during the stress test
num_clients = 3
# The number of requests each stress test client will send per second.
packets_per_second = 10
# The number of seconds the stress test will run for.
duration_seconds = 15
# The QoS level to make stress test clients abide to.
qos_level = 0

# Collects data for returned messages and processes the latency and packet loss. Created on stress test start and destroyed on stress test end.
result_processor = None

# Initializes a specified number of stress test clients, giving them a unique ID and connecting them to the broker.
def initialize_stress_test_clients(num_clients):
    for x in range(0, num_clients):
        client_id = f'Stress Test Client {x}'
        stress_test_client = mqtt.Client(client_id = client_id)
        stress_test_client.on_message = on_stress_test_client_message
        stress_test_client.connect(broker_ip, broker_port, 60)
        stress_test_client.subscribe(client_id, qos_level)
        stress_test_client.loop_start()

        stress_testing_clients.append(stress_test_client)

# Starts a stress test. This should not be invoked if a stress test is already ongoing.
def start_stress_test():
    global stress_test_running
    stress_test_running = True

    global result_processor
    result_processor = strp.StressTestResultProcessor(num_clients, packets_per_second, duration_seconds)
    initialize_stress_test_clients(num_clients)

# Stops a stress test and cleans up necessary variables for a potential new stress test.
def stop_stress_test():
    for client in stress_testing_clients:
        client.disconnect()
    stress_testing_clients.clear()
    global result_processor

    print(f'Average Latency: {result_processor.get_total_average_latency()}ms')
    print(f'Max Latency: {result_processor.get_total_max_latency()}ms')
    print(f'Min Latency: {result_processor.get_total_min_latency()}ms')
    print(f'Packets Lost: {result_processor.get_total_packets_lost()}')

    #TODO: Send data to broker supplying result set

    result_processor = None
    global stress_test_running
    stress_test_running = False

# Executed when the master client successfully connects to the broker.
def on_master_connect(client, userdata, flags, rc):
    if(rc == 0): # Code 0 means a successful connection.
        print(f'Connection to {broker_ip}:{broker_port} was successful.')
    else: # Any code other than 0 means the connection was not successful.
        print(f'Connection to {broker_ip}:{broker_port} was unsuccessful (Error Code {rc}).')

# Executed when the client receives a message from the broker.
# This will begin the stress test.
# TODO: Error handling for if a stress test is already ongoing.
# TODO: Get parameters from the message for stress test.
def on_master_message(client, userdata, msg):
    print('Request received! Starting stress test.')

    # Parse any arguments supplied from the message
    num_clients_param = parse_utils.get_test_num_clients(msg)
    if num_clients_param != None:
        global num_clients
        num_clients = int(num_clients_param)

    packets_per_second_param = parse_utils.get_test_packets_per_second(msg)
    if packets_per_second_param != None:
        global packets_per_second
        packets_per_second = int(packets_per_second_param)

    duration_param = parse_utils.get_test_duration(msg)
    if duration_param != None:
        global duration_seconds
        duration_seconds = int(duration_param)

    qos_level_param = parse_utils.get_test_qos_level(msg)
    if qos_level_param != None:
        global qos_level
        qos_level = int(qos_level_param)

    print('Request Parameters: ')
    print(f'Num Clients: {num_clients_param}')
    print(f'Packets Per Second: {packets_per_second_param}')
    print(f'Duration: {duration_param}')
    print(f'QoS Level: {qos_level_param}')

    start_stress_test()

# Gets the topic and payload contents of the message, and parses them for client number, packet number, and time difference in order
# to analyze latency and packet loss.
def on_stress_test_client_message(client, userdata, msg):
    current_time = time.time_ns() // 1_000_000 #Gets the epoch time in milliseconds. This will be used to process latency.

    # Parse data from the message regarding the packet
    client_id = parse_utils.get_client_id(msg)
    packet_num = parse_utils.get_packet_num(msg)
    packet_time = parse_utils.get_packet_time(msg)

    if client_id != None and packet_num != None and packet_time != None:
        latency = current_time - int(packet_time)
        # Supply the data to the result processor
        result_processor.add_latency_info(int(client_id), int(packet_num), latency)

# Initializes the master client  
def initialize_master_client():
    global master_client
    master_client = mqtt.Client(client_id = 'Master Client')
    master_client.on_connect = on_master_connect
    master_client.on_message = on_master_message

    # Connects the master client to the broker
    master_client.connect(broker_ip, broker_port, 60)
    master_client.loop_start()

    # Subscribes the master client to the channel that is used to request the start to a stress test.
    master_client.subscribe('Start Stress Test')


initialize_master_client()
# Loops infinitely to keep the script from terminating.
while True:
    if stress_test_running:
        # Get the total number of packets to be processed, and iterates over them all, making each stress test client
        # send a packet to the broker in their own unique channel.
        total_packets = math.floor(packets_per_second * duration_seconds)
        for current_packet in range(0, total_packets):
            for i in range(0, len(stress_testing_clients)):
                client = stress_testing_clients[i];
                client_id = f'Stress Test Client {i}';
                time_in_milliseconds = time.time_ns() // 1_000_000 #Gets the epoch time in milliseconds. This will be used to process latency.
                client.publish(client_id, f'[{client_id}] [Packet#{current_packet}] [{time_in_milliseconds}] Ping!', qos_level)
            time.sleep(1 / packets_per_second) 
        # Allow 5 seconds to pass before stopping the stress test for any high-latency packets to get collected.
        time.sleep(5)
        # After all requests have been completed, disconnect each stress test client and clear the array so that a new stress test may be performed.
        stop_stress_test()
    else:
        # If there isn't a stress test running, sleep for a second to save resources.
        time.sleep(5)