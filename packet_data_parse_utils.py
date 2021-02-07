import re

# Regex for getting values for each part of the stress test packet data.
client_id_regex = re.compile('(?<=Stress Test Client )[0-9]+')
packet_num_regex = re.compile('(?<=Packet#)[0-9]+')
packet_time_regex = re.compile('(?<=\[)[0-9]+(?=\])')

# Regex for getting values for each part of the stress test initialization packet data.
num_clients_regex = re.compile('(?<=Number of Clients: )[0-9]+')
packets_per_second_regex = re.compile('(?<=Packets Per Second: )[0-9]+')
duration_regex = re.compile('(?<=Duration: )[0-9]+')
qos_regex = re.compile('(?<=QoS: )[0-2]')

def get_first_group(data, regex):
    match = regex.search(data)
    if match != None:
        return match.group(0)
    else:
        return None

def get_client_id(message):
    topic = message.topic
    return get_first_group(topic, client_id_regex)

def get_packet_num(message):
    payload = str(message.payload)
    return get_first_group(payload, packet_num_regex)

def get_packet_time(message):
    payload = str(message.payload)
    return get_first_group(payload, packet_time_regex)

def get_test_num_clients(message):
    payload = str(message.payload)
    return get_first_group(payload, num_clients_regex)

def get_test_packets_per_second(message):
    payload = str(message.payload)
    return get_first_group(payload, packets_per_second_regex)

def get_test_duration(message):
    payload = str(message.payload)
    return get_first_group(payload, duration_regex)

def get_test_qos_level(message):
    payload = str(message.payload)
    return get_first_group(payload, qos_regex)
