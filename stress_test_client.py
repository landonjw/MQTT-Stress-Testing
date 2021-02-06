"""
MQTT Project - Stress Testing Program
Software Engineering Project - COMP-CO867 / Winter 2021

This is a continuation of an applied research project for assessing the MQTT protocol.
This program is intended to stress test a broker.
"""

import time
import paho.mqtt.client as mqtt
import os
from array import *

# Details for connecting to the broker. Adjust these for your own network.
broker_ip = "192.168.137.1"
broker_port = 1883

# Reference to the client that initializes the stress test. This will be alive throughout the entire lifecycle of the program.
# The ONLY resposibility of this client is for communication with the UI client. This does not partake in the stress testing.
master_client = None

# The list of clients that stress test the network. This will be populated when a stress test begins and be cleared when a stress test ends.
stress_testing_clients = []

# If a stress test is currently running
stress_test_running = False
# The number of requests each stress test client will send per second
requests_per_second = 50
# The number of seconds the stress test will run for
duration_seconds = 15

# Initializes  a specified number of stress test clients, giving them a unique ID and connecting them to the broker.
def initialize_stress_test_clients(num_clients = 10):
    for x in range(1, num_clients + 1):
        stress_test_client = mqtt.Client(client_id = f'Stress Test Client {x}')
        stress_test_client.connect(broker_ip, broker_port, 60)
        stress_testing_clients.append(stress_test_client)

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
    global stress_test_running
    stress_test_running = True
    initialize_stress_test_clients()

# Initializes the master client    
master_client = mqtt.Client(client_id = 'Master Client')
master_client.on_connect = on_master_connect
master_client.on_message = on_master_message

# Connects the master client to the broker
master_client.connect(broker_ip, broker_port, 60)
master_client.loop_start()

# Subscribes the master client to the channel that is used to request the start to a stress test.
master_client.subscribe('Start Stress Test')

# Loops infinitely to keep the script from terminating.
while True:
    if stress_test_running:

        # Get the total number of packet requests to be processed, and iterates over them all, making each stress test client
        # send a packet to the broker in their own unique channel.
        total_requests = requests_per_second * duration_seconds
        for current_request in range(1, total_requests + 1):
            for i in range(0, len(stress_testing_clients)):
                client = stress_testing_clients[i];
                client_id = f'Stress Test Client {i + 1}';
                time_in_milliseconds = time.time_ns() // 1_000_000 #Gets the epoch time in milliseconds. This will be used to process latency.
                client.publish(client_id, f'[{client_id}] [Packet#{current_request}] [{time_in_milliseconds}] Ping!')
            time.sleep(1 / requests_per_second) 
            client.loop() #Necessary to indicate to the client that it should process a new loop.
        # After all requests have been completed, disconnect each stress test client and clear the array so that a new stress test may be performed.
        for client in stress_testing_clients:
            client.disconnect()
        stress_testing_clients.clear()
    else:
        # If there isn't a stress test running, sleep for a second to save resources.
        time.sleep(1)