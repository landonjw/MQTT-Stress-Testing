import time
import json
import paho.mqtt.client as mqtt
import stress_test_client
import task_manager
import latency_results

publishers = []

broker_ip = "192.168.2.44"
broker_port = 1883
start_topic = 'stress_test/start'
results_topic = 'stress_test/results'

def create_publisher(id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes):
    client = stress_test_client.StressTestClient(id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes)
    client.initialize_client(broker_ip, broker_port)
    publishers.append(client)

def create_master_client():
    client = mqtt.Client(client_id = 'Stress Test Master')
    client.on_message = on_master_receive_message
    client.connect(broker_ip, broker_port, 60)
    client.subscribe(start_topic, 1)
    client.loop_start()

def on_master_receive_message(client, userdata, msg):
    packet = json.loads(msg.payload)
    print(json.dumps(packet, indent=4))
    for i in range(0, len(packet["clients"])):
        client = packet["clients"][i]
        create_publisher(i, client["packet_interval_ms"], client["duration_seconds"], client["qos_level"], client["packet_size_bytes"])
    start_publishing()

def start_publishing():
    for publisher in publishers:
        packet_interval_ticks = task_manager.convertMsToTicks(publisher.packet_interval_ms)
        task = task_manager.Task(publisher.publish_message, packet_interval_ticks, publisher.total_packets_to_send)
        task_manager.add_task(task)
    task_manager.start(gather_results)

def gather_results():
    time.sleep(5)
    publisher_results = []
    for publisher in publishers:
        publisher_results.append(publisher.results)
    results = {
        "total": {
            "latency_average": latency_results.get_total_average_latency(publisher_results),
            "latency_min": latency_results.get_total_min_latency(publisher_results),
            "latency_max": latency_results.get_total_max_latency(publisher_results),
            "packets_lost": latency_results.get_total_packets_lost(publisher_results)
        },
        "clients": []
    }
    for i in range(0, len(publisher_results)):
        results["clients"].append({
            "latency_average": publisher_results[i].get_average_latency(),
            "latency_min": publisher_results[i].get_min_latency(),
            "latency_max": publisher_results[i].get_max_latency(),
            "packets_lost": publisher_results[i].get_packets_lost()
        })
    print(json.dumps(results, indent=4))

create_master_client()
while True:
    time.sleep(0.0001)