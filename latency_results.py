class LatencyResultsProcessor:
    def __init__(self, total_packets):
        self.packet_data = []
        self.offset = []
        self.total_packets = total_packets
        for i in range(0, total_packets):
            self.packet_data.append(None)
            self.offset.append(None)
        
    def add_latency_info(self, packet_num, latency):
        if self.offset[packet_num] != None:
            self.packet_data[packet_num] = max(latency - self.offset[packet_num], 1)
        else:
            self.packet_data[packet_num] = latency

    def add_offset(self, packet_num, offset):
        if self.packet_data[packet_num] != None:
            self.packet_data[packet_num] = max(self.packet_data[packet_num] - offset, 1)
        else:
            self.offset[packet_num] = offset
    
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

def get_total_average_latency(results_processors):
    sum = 0
    for processor in results_processors:
        sum = sum + processor.get_average_latency()
    return sum / len(results_processors)

def get_total_max_latency(results_processors):
    max = -1
    for processor in results_processors:
        processor_max = processor.get_max_latency()
        if processor_max > max:
            max = processor_max
    return max

def get_total_min_latency(results_processors):
    min = -1
    for processor in results_processors:
        processor_min = processor.get_min_latency()
        if processor_min < min or min == -1:
            min = processor_min
    return min

def get_total_packets_lost(results_processors):
    sum = 0
    for processor in results_processors:
        sum = sum + processor.get_packets_lost()
    return sum