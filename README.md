# MQTT-Stress-Testing

Tool for simulating clients on an MQTT network with the ability to collect latency results.

## Installation
This installation guide assumes no previous knowledge and uses version 2.0.9 of the (Mosquitto)[https://mosquitto.org/download/] broker.  
If you are using a different broker, version, or configuration, results may differ and require you to consult their documentation.  
All configuration settings we use will be explained in their role. Some may not be necessary depending on your testing conditions.

### Instructions
1. Download and install the (Mosquitto)[https://mosquitto.org/download/] broker.
2. In the root folder for Mosquitto, copy the `mosquitto.conf` file into a new file called `testing.conf`.
3. Open `testing.conf` in your preferred text editor.
4. Go to line 215, remove the text on the line, and add the text `listener [port] [hostname]`
    - This defines where the broker should be listening for client messages.
    - These should be the port and hostname of the computer the broker is installed on.
    - If you are running the stress tester and broker locally, you can use 127.0.0.1 for local loopback.
    - If you want to listen at several locations, you can define more than one listener by adding more lines.
5. Go to line 512, remove the text on the line, and add the text `allow_anonymous true`
    - This allows the stress testing clients to connect to the broker without requiring a username and password.
6. Open command prompt, navigate to the root folder of the Mosquitto broker.
7. Execute the command `mosquitto -c testing.conf`
    - `-c` argument specifies that the configuration used by Mosquitto is `testing.conf`
    - `-v` argument can also be added to tell Mosquitto to run in verbose mode. This will allow you to see incoming and outgoing messages from the broker.
8. Modify the `broker_ip` and `broker_port` variables in `stress_test.py`
9. Run `stress_test.py`.
    - If connection to the broker is successful, you should see `Connected to broker...`