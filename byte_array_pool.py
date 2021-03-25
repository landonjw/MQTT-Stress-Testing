pool = []

def get_or_create_byte_array(client):
    packet_size = client.packet_size_bytes
    for byte_arr in pool:
        if len(byte_arr) == packet_size + 100:
            return byte_arr
    new_byte_arr = bytearray(packet_size + 100)
    pool.append(new_byte_arr)
    return new_byte_arr

