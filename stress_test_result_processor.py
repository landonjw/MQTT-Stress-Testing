"""
Used for processing the packet data sent during stress testing (ie. latency, packet loss, peak latency).
"""

import math

# Used for processing the results of a stress test.
class StressTestResultProcessor:
    def __init__(self, num_clients, packets_per_second, duration_seconds):
        self.num_clients = num_clients
        self.total_packets = math.floor(packets_per_second * duration_seconds)
        self.packet_data = []
        # Initialize a two dimensional array with None values to represent each stress test client's packet latencies.
        for client in range(0, num_clients):
            self.packet_data.append([])
            for packet in range(0, self.total_packets):
                self.packet_data[client].append(None)
                
    # Adds information about a given packet's latency.
    # Inserts the latency into the specified client's array.
    def add_latency_info(self, client_num, packet_num, latency):
        self.packet_data[client_num][packet_num] = latency

    # Gets the average latency of packets sent by a single client.
    def get_average_latency(self, client_num):
        total_latency = 0
        for latency in self.packet_data[client_num]:
            if(latency != None):
                total_latency = total_latency + latency
        if self.total_packets - self.get_packets_lost(client_num) == 0:
            return -1
        else:
            return total_latency / (self.total_packets - self.get_packets_lost(client_num))
    
    # Gets the average latency of all clients.
    def get_total_average_latency(self):
        total_avg_latency = 0
        for x in range(0, len(self.packet_data)):
            total_avg_latency = total_avg_latency + self.get_average_latency(x)
        return total_avg_latency / len(self.packet_data)

    # Gets the highest latency recorded from a packet received by the specified client.
    def get_max_latency(self, client_num):
        max_latency = -1
        for latency in self.packet_data[client_num]:
            if latency == None:
                continue
            else:
                if latency > max_latency:
                    max_latency = latency
        return max_latency
    
    # Gets the highest latency recorded from a packet received by any client.
    def get_total_max_latency(self):
        max_latency = -1
        for x in range(0, len(self.packet_data)):
            client_latency = self.get_max_latency(x)
            if client_latency > max_latency:
               max_latency = client_latency
        return max_latency
            
    # Gets the lowest latency recorded from a packet received by a specified client.
    def get_min_latency(self, client_num):
        min_latency = -1
        for latency in self.packet_data[client_num]:
            if latency == None:
                continue
            else:
                if latency < min_latency or min_latency == -1:
                    min_latency = latency
        return min_latency
               
    # Gets the lowest latency recorded from a packet received by any client.
    def get_total_min_latency(self):
        min_latency = -1
        for x in range(0, len(self.packet_data)):
            client_latency = self.get_min_latency(x)
            if client_latency < min_latency or min_latency == -1:
               min_latency = client_latency
        return min_latency

    # Gets the number of packets lost on a given client.
    def get_packets_lost(self, client_num):
        lost_packets = 0
        for i in range(0, self.total_packets):
            if(self.packet_data[client_num][i] == None):
                lost_packets = lost_packets + 1
        return lost_packets
               
    # Gets the number of packets lost on all clients.
    def get_total_packets_lost(self):
        lost_packets = 0
        for x in range(0, len(self.packet_data)):
            lost_packets = lost_packets + self.get_packets_lost(x)
        return lost_packets