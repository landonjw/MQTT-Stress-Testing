import time
import json
import shadow.paho.mqtt.modified_client as mqtt
import stress_test_client
import task_manager
import latency_results
from debug_logger import debug

publishers = [] # The simulated clients that are publishing data to the MQTT broker.

broker_host = "192.168.2.36" # IP of the broker to connect to.
broker_port = 1883 # Port of the broker to connect to

# Client responsible for initializing stress tests and returning results.
# This value will be null until the script successfully connects to the broker.
master_client = None

start_topic = 'stress_test/start' # Topic for the master client used to start the test is to subscribe to
results_topic = 'stress_test/results' # Topic to publish test results to

# Number of seconds to wait after all messages have been published to collect and publish test results.
# We do this so that we do not misinterpret lagging responses for lost packets.
# This value is received from the UI to allow control via from end users.
grace_period_seconds = 5

debug = False # Determines of program should generate debug messages.

def __create_publisher(id, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes):
    """
    Creates an MQTT client used for stress testing and connects it to the broker.

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
    """
    client = stress_test_client.StressTestClient(id, broker_host, broker_port, packet_interval_ms, duration_seconds, qos_level, packet_size_bytes)
    publishers.append(client)

def __create_master_client():
    """
    Initializes the client responsible for starting stress tests and publishing results to the broker.
    """
    global master_client
    master_client = mqtt.Client(client_id = 'Stress Test Master')
    master_client.on_message = on_master_receive_message
    print('Connecting to broker...')
    master_client.connect(broker_host, broker_port, 6000)
    master_client.subscribe(start_topic, 1)
    master_client.loop_start()
    print('Connected to broker.')

def __on_master_receive_message(client, userdata, msg):
    """
    Invoked when the master receives a message.
    This will assume that the message received contains data related to configuring a stress test.

    Arguments
    ---------
    client: Not used
    userdata: Not used
    msg: MQTTMessage
        The message received. Contains the payload used to interpret stress test start.
    """
    debug(msg.payload)
    packet = json.loads(msg.payload)
    debug(json.dumps(packet, indent = 4))
    global grace_period_seconds
    grace_period_seconds = packet["grace_period_seconds"]
    for i in range(0, len(packet["clients"])):
        client = packet["clients"][i]
        __create_publisher(i, client["packet_interval_ms"], client["duration_seconds"], client["qos_level"], client["packet_size_bytes"])
    __start_publishing()

def __start_publishing():
    """
    Starts the publishing process of stress test clients.
    """
    for publisher in publishers:
        # Creates a task for each client to start publishing.
        packet_interval_ticks = task_manager.convertMsToTicks(publisher.packet_interval_ms)
        task = task_manager.Task(publisher.publish_message, packet_interval_ticks, publisher.total_packets_to_send)
        task_manager.add_task(task)
    task_manager.start(gather_results)

def __gather_results():
    """
    Gathers the results from each client, processes the total results and publishes it to the broker.
    """
    # TODO: This might want to be moved to the UI in order to allow more dynamic result processing.
    #       Example of this would be UI displaying live results while the test is ongoing.

    # Sleep for duration of grace period to prevent misinterpreting lagging packets for packet loss
    time.sleep(grace_period_seconds)
    publisher_results = []
    for publisher in publishers:
        publisher_results.append(publisher.results)
    # Add total results to the results json
    results = {
        "total": {
            "latency_average": latency_results.get_total_average_latency(publisher_results),
            "latency_min": latency_results.get_total_min_latency(publisher_results),
            "latency_max": latency_results.get_total_max_latency(publisher_results),
            "packets_lost": latency_results.get_total_packets_lost(publisher_results)
        },
        "clients": []
    }
    # Add results for each client to the results client.
    for i in range(0, len(publisher_results)):
        results["clients"].append({
            "latency_average": publisher_results[i].get_average_latency(),
            "latency_min": publisher_results[i].get_min_latency(),
            "latency_max": publisher_results[i].get_max_latency(),
            "packets_lost": publisher_results[i].get_packets_lost()
        })
    debug(json.dumps(results, indent = 4))
    master_client.publish(results_topic, json.dumps(results))
    # Disconnect all publishers after the results are gathered.
    for publisher in publishers:
        publisher.client.disconnect()

# Entry point into the program.
create_master_client()
while True:
    time.sleep(0.0001)