debugMode = True # Determines of program should generate debug messages.

def debug(message):
    """
    Prints a message to console if debug mode is on.

    Arguments
    ---------
    message: String
        The message to send to console
    """
    if debugMode == True:
        print(message)