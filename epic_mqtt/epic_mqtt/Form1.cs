
/* MQTT Project - Stress Testing Program
 * Software Engineering Project - COMP-CO867 / Winter 2021
 *
 * This is a continuation of an applied research project for assessing the MQTT protocol.
 * This program is intended to represent the UI portion of the stress testing program, allowing the user to schedule a stress test
 * and see the results.
*/

using epic_mqtt;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqtt_stresstest
{
    public partial class Form1 : MetroForm
    {
        MqttClient client;
        List<ClientConfiguration> clientConfigurations = new List<ClientConfiguration>();

        public Form1()
        {
            InitializeComponent();
            clientConfigurations.Add(new ClientConfiguration());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientSelection.SelectedIndex = 0;
            LoadClientConfigIntoForm(0);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void LoadClientConfigIntoForm(int index)
        {
            packetInterval.Text = clientConfigurations[index].PacketIntervalMS.ToString();
            duration.Text = clientConfigurations[index].DurationSeconds.ToString();
            packetSize.Text = clientConfigurations[index].PacketSizeBytes.ToString();
            qosLevel.SelectedIndex = clientConfigurations[index].QOSLevel;
        }

        // TODO: This validation could likely be heavily cleaned up, I'm just not very familiar with .NET and did this quickly...
        private void startStressTest_Click(object sender, EventArgs e)
        {
            // Fetches and validates each input in the form
            string brokerHost = brokerIpAddrInput.Text;
            int brokerPort;

            int numberOfClients;
            int packetsPerSecond;
            int duration;
            int qosLevel;

            try
            {
                brokerPort = Int32.Parse(brokerPortInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid port number supplied. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Establishes a new MQTT client on the given host name and port
            client = new MqttClient(brokerHost, brokerPort, false, null, null, MqttSslProtocols.None);
            string clientId = "stress_test/ui";

            // Make the progress bar & status visible to give user some input on the application's life cycle
            progressBar.Visible = true;
            progressStatus.Visible = true;
            progressStatus.Text = "Connecting to broker...";

            try
            {
                client.Connect(clientId);
            }
            catch (Exception)
            {
                MessageBox.Show("Connection could not be established. Please check your inputs and try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar.Increment(2);
            progressStatus.Text = "Connection established. Sending stress test request...";

            string serializedConfiguration = JsonSerializer.Serialize(new StressTestOutgoingConfiguration { Clients = this.clientConfigurations });

            // Send a packet to the broker supplying all the arguments for starting a stress test
            client.Publish("stress_test/master", Encoding.UTF8.GetBytes(serializedConfiguration));
        }

        private void clientSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClientConfigIntoForm(clientSelection.SelectedIndex);
        }

        private void AddNewClientConfig()
        {
            clientConfigurations.Add(new ClientConfiguration());
            clientSelection.Items.Add($"Client {clientConfigurations.Count}");
        }

        private void RemoveClientConfig()
        {
            clientConfigurations.RemoveAt(clientConfigurations.Count);
            clientSelection.Items.RemoveAt(clientSelection.Items.Count);
        }

        private void packetInterval_Leave(object sender, EventArgs e)
        {
            clientConfigurations[clientSelection.SelectedIndex].PacketIntervalMS = Int32.Parse(packetInterval.Text);
        }

        private void duration_Leave(object sender, EventArgs e)
        {
            clientConfigurations[clientSelection.SelectedIndex].DurationSeconds = Int32.Parse(duration.Text);
        }

        private void packetSize_Leave(object sender, EventArgs e)
        {
            clientConfigurations[clientSelection.SelectedIndex].PacketSizeBytes = Int32.Parse(packetSize.Text);
        }

        private void qosLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientConfigurations[clientSelection.SelectedIndex].QOSLevel = qosLevel.SelectedIndex;
        }

        private void updateNumClients_Click(object sender, EventArgs e)
        {
            while (numClients.Value > clientConfigurations.Count)
            {
                Console.WriteLine("Adding");
                AddNewClientConfig();
            }

            while (numClients.Value < clientConfigurations.Count)
            {
                Console.WriteLine("Removing");
                RemoveClientConfig();
            }
        }
    }
}