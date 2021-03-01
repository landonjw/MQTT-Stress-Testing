import time
import json
import paho.mqtt.client as mqtt
import stress_test_client
import task_manager

publishers = []

broker_ip = "192.168.2.44"
broker_port = 1883
master_topic = 'stress_test/master'

def create_publisher(id, packet_interval_ms, duration_seconds, qos_level, packet_size_min_bytes, packet_size_max_bytes):
    client = stress_test_client.StressTestClient(id, packet_interval_ms, duration_seconds, qos_level, packet_size_min_bytes, packet_size_max_bytes)
    client.initialize_client(broker_ip, broker_port)
    publishers.append(client)

def create_master_client():
    client = mqtt.Client(client_id = 'Stress Test Master')
    client.on_message = on_master_receive_message
    client.connect(broker_ip, broker_port, 60)
    client.subscribe(master_topic, 1)
    client.loop_start()
    time.sleep(3)

    message = {
        "clients": [
            {
                "packet_interval_ms": 50,
                "qos_level": 1,
                "duration_seconds": 60,
                "packet_size_min_bytes": -1,
                "packet_size_max_bytes": -1 
            },
            {
                "packet_interval_ms": 25,
                "qos_level": 0,
                "duration_seconds": 30,
                "packet_size_min_bytes": -1,
                "packet_size_max_bytes": -1 
            }
        ]
    }
    client.publish(master_topic, json.dumps(message))

def on_master_receive_message(client, userdata, msg):
    print(msg.payload)
    packet = json.loads(msg.payload)
    for i in range(0, len(packet["clients"])):
        client = packet["clients"][i]
        create_publisher(i, client["packet_interval_ms"], client["duration_seconds"], client["qos_level"], client["packet_size_min_bytes"], client["packet_size_max_bytes"])
    start_publishing()

def start_publishing():
    for publisher in publishers:
        packet_interval_ticks = task_manager.convertMsToTicks(publisher.packet_interval_ms)
        print(packet_interval_ticks)
        task = task_manager.Task(publisher.publish_message, packet_interval_ticks, publisher.total_packets_to_send)
        task_manager.add_task(task)
    task_manager.start(gather_results)

def gather_results():
    print('Gathering results')

print('Creating master client')
create_master_client()
while True:
    time.sleep(0.25)