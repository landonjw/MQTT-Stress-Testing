class LatencyResultsProcessor:
    """
    Stores and calcualtes latency information from messages published by stress test clients.
    A processor instance should only be used by a single stress test client. 

    Attributes
    ----------
    total_packets: Integer
        The total number of packets that a stress test client is responsible for publishing.

    Methods
    -------
    add_latency_info(packet_num: Integer, latency: Integer)
        Adds the latency information for a given packet

    add_offset(packet_num: Integer, offset: Integer)
        Offsets the latency of a packet by the given offset value.
        This is used to ignore the duration it takes to publish the data on the client.

    get_average_latency(): Float
        Gets the average latency of packets received by the client in milliseconds.
        Running this before the client has published all packets may give inaccurate results.

    get_min_latency(): Integer
        Gets the minimum latency of packets received by the client in milliseconds.
        Running this before the client has published all packets may give inaccurate results.

    get_max_latency(): Integer
        Gets the maximum latency of packets received by the client in milliseconds.
        Running this before the client has published all packets may give inaccurate results.

    get_packets_lost(): Integer
        Gets the number of packets that never had their latency registered.
        Running this before the client has published all packets may give inaccurate results.
    """

    def __init__(self, total_packets):
        self._packet_data = [None] * total_packets
        self._offset = [None] * total_packets
        self.total_packets = total_packets
        
    def add_latency_info(self, packet_num, latency):
        """
        Adds latency information about a given packet.

        Arguments
        ---------
        packet_num: Integer
            The ID of the packet to add latency information for
        latency: Integer
            The latency in milliseconds
        """
        if self._offset[packet_num] != None:
            self._packet_data[packet_num] = max(latency - self._offset[packet_num], 1)
        else:
            self._packet_data[packet_num] = latency

    def add_offset(self, packet_num, offset):
        """
        Adds an offset for a given packet.
        This is used to deduct the time it takes to publish a message on the client from the latency.

        Arguments
        ---------
        packet_num: Integer
            The ID of the packet to add offset for
        offset: Integer
            The offset in milliseconds
        """
        if self._packet_data[packet_num] != None:
            self._packet_data[packet_num] = max(self._packet_data[packet_num] - offset, 1)
        else:
            self._offset[packet_num] = offset
    
    def get_average_latency(self):
        """
        Gets the average latency in milliseconds of the packets a client has published

        Returns
        -------
        Float
            The average latency in milliseconds of all packets published by the client
        """
        # Get sum of latency 
        total_latency = 0
        for latency in self._packet_data:
            if latency != None:
                total_latency = total_latency + latency
        packets_lost = self.get_packets_lost()
        # Handle the case where all packets are lost to prevent division by zero
        if packets_lost == self.total_packets:
            return -1
        else:
            return total_latency / self.total_packets - self.get_packets_lost()

    def get_max_latency(self):
        """
        Gets the maximum latency in milliseconds of the packets a client has published

        Returns
        -------
        Integer
            The maximum latency in milliseconds of all packets published by the client
        """
        max_latency = -1
        for latency in self._packet_data:
            if latency == None: # Handle lost packets
                continue
            else:
                if latency > max_latency:
                    max_latency = latency
        return max_latency

    def get_min_latency(self):
        """
        Gets the minimum latency in milliseconds of the packets a client has published

        Returns
        -------
        Integer
            The minimum latency in milliseconds of all packets published by the client
        """
        min_latency = -1
        for latency in self._packet_data:
            if latency == None: # Handle lost packets
                continue
            else:
                if latency < min_latency or min_latency == -1:
                    min_latency = latency
        return min_latency
    
    def get_packets_lost(self):
        """
        Gets the number of packets that were never received from the client

        Returns
        -------
        Integer
            The number of packets that were never received
        """
        lost_packets = 0
        for latency in self._packet_data:
            if latency == None:
                lost_packets = lost_packets + 1
        return lost_packets

def get_total_average_latency(results_processors):
    """
    Gets the average latency of all results

    Arguments
    ---------
    results_processors: List of LatencyResultsProcessor
        A list of results to get average latency from

    Returns
    -------
    Float
        The average latency from all latency results
    """
    sum = 0
    for processor in results_processors:
        sum = sum + processor.get_average_latency()
    return sum / len(results_processors)

def get_total_max_latency(results_processors):
    """
    Gets the maximum latency of all results

    Arguments
    ---------
    results_processors: List of LatencyResultsProcessor
        A list of results to get maximum latency from

    Returns
    -------
    Integer
        The maximum latency of all latency results
    """
    max = -1
    for processor in results_processors:
        processor_max = processor.get_max_latency()
        if processor_max > max:
            max = processor_max
    return max

def get_total_min_latency(results_processors):
    """
    Gets the minimum latency of all results

    Arguments
    ---------
    results_processors: List of LatencyResultsProcessor
        A list of results to get minumum latency from

    Returns
    -------
    Integer
        The minimum latency of all latency results
    """
    min = -1
    for processor in results_processors:
        processor_min = processor.get_min_latency()
        if processor_min < min or min == -1:
            min = processor_min
    return min

def get_total_packets_lost(results_processors):
    """
    Gets the total packets lost from all results

    Arguments
    ---------
    results_processors: List of LatencyResultsProcessor
        A list of results to get total packets lost from

    Returns
    -------
    Integer
        The number of packets lost from all results processors
    """
    sum = 0
    for processor in results_processors:
        sum = sum + processor.get_packets_lost()
    return sum