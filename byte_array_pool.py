# Stores instances of bytearrays to share between stress test clients
__pool = []

def get_or_create_byte_array(size_bytes):
    """
    Gets a bytearray capable of containing a specified byte size.
    If there is no bytearray instance with that can contain that size, a new instance will be created and returned.
    This bytearray may be shared between different sources and should not be considered thread safe.

    Arguments
    ---------
    size_bytes: Integer
        The amount of bytes that the bytearray must be able to contain.

    Returns
    -------
    bytearray
        A bytearray instance that can store the requested amount of bytes.

    Raises
    ------
    ValueError
        If requested size is below or equal to 0
    """
    if size_bytes <= 0:
        raise ValueError("byte size must be above 0")
    for byte_arr in pool:
        if len(byte_arr) == size_bytes + 100:
            return byte_arr
    new_byte_arr = bytearray(size_bytes + 100)
    pool.append(new_byte_arr)
    return new_byte_arr

def reset_pool():
    """
    Resets the byte array pool.
    This should not be used while a stress test is ongoing.
    """
    __pool.clear()