
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
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqtt_stresstest
{
    public partial class StartConfigForm : MetroForm
    {
        private MqttClient client;
        private List<ClientConfiguration> clientConfigurations = new List<ClientConfiguration>();
        private int secondsElapsed = 0;
        private delegate void SafeCallDelegate(StressTestIncomingResults results, StressTestOutgoingConfiguration configuration);

        public StartConfigForm()
        {
            InitializeComponent();
            clientConfigurations.Add(new ClientConfiguration());
        }

        private void StartConfigForm_Load(object sender, EventArgs e)
        {
            clientConfigGroupBox.Controls.Remove(timeOngoing);
            clientConfigGroupBox.Controls.Remove(progressLabel);
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

            try
            {
                client.Connect(clientId);
                client.MqttMsgPublishReceived += onMessageReceived;
                client.Subscribe(new string[]{ "stress_test/results" }, new byte[]{ MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            catch (Exception)
            {
                MessageBox.Show("Connection could not be established. Please check your inputs and try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string serializedConfiguration = JsonSerializer.Serialize(new StressTestOutgoingConfiguration { Clients = this.clientConfigurations });

            // Send a packet to the broker supplying all the arguments for starting a stress test
            client.Publish("stress_test/start", Encoding.UTF8.GetBytes(serializedConfiguration));

            HideAllControls();
            loadingPanel.Visible = true;
            StartLoadingTimer();
        }

        private void StartLoadingTimer()
        {
            labelTimer.Enabled = true;
        }

        private void HideAllControls()
        {
            ipAdressLabel.Visible = false;
            brokerIpAddrInput.Visible = false;
            brokerPortLabel.Visible = false;
            brokerPortInput.Visible = false;
            numClientsLabel.Visible = false;
            numClients.Visible = false;
            updateNumClients.Visible = false;
            clientSelection.Visible = false;
            clientConfigGroupBox.Visible = false;
            startStressTest.Visible = false;
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

        private void labelTimer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            TimeSpan t = TimeSpan.FromSeconds(secondsElapsed);

            string elapsed = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            timeOngoing.Text = elapsed;
        }

        private void onMessageReceived(object sender, MqttMsgPublishEventArgs getMsg)
        {
            string payload = Encoding.UTF8.GetString(getMsg.Message);
            StressTestIncomingResults results = JsonSerializer.Deserialize<StressTestIncomingResults>(payload);
            this.Invoke(new SafeCallDelegate(ShowResultsWindow), new object[]{ results, new StressTestOutgoingConfiguration { Clients = this.clientConfigurations } });
        }

        private void ShowResultsWindow(StressTestIncomingResults results, StressTestOutgoingConfiguration configuration)
        {
            ResultsDisplayForm resultForm = new ResultsDisplayForm(results, configuration);
            resultForm.Show();
            this.Hide();
        }
    }
}