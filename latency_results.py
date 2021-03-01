class LatencyResultsProcessor:
    def __init__(self, total_packets):
        self.packet_data = []
        for i in range(0, total_packets):
            self.packet_data.append(None)
        
    def add_latency_info(self, packet_num, latency):
        self.packet_data[packet_num] = latency
    
    def get_average_latency(self):
        total_latency = 0
        for latency in self.packet_data:
            if latency != None:
                total_latency = total_latency + latency
        packets_lost = self.get_packets_lost()
        if packets_lost == self.total_packets:
            return -1
        else:
            return total_latency / self.total_packets - self.get_packets_lost()

    def get_max_latency(self):
        max_latency = -1
        for latency in self.packet_data:
            if latency == None:
                continue
            else:
                if latency > max_latency:
                    max_latency = latency
        return max_latency

    def get_min_latency(self):
        min_latency = -1
        for latency in self.packet_data:
            if latency == None:
                continue
            else:
                if latency < min_latency or min_latency == -1:
                    min_latency = latency
        return min_latency
    
    def get_packets_lost(self):
        lost_packets = 0
        for latency in self.packet_data:
            if latency == None:
                lost_packets = lost_packets + 1
        return lost_packets