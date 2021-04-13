def debug(message):
    """
    Prints a message to console if debug mode is on.

    Arguments
    ---------
    message: String
        The message to send to console
    """
    if debug == True:
        print(message)