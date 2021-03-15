
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
using System.IO;
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
        private int gracePeriodSeconds = 5;
        private List<ClientConfiguration> clientConfigurations = new List<ClientConfiguration>();
        private int secondsElapsed = 0;
        private delegate void SafeCallDelegate(StressTestIncomingResults results, StressTestOutgoingConfiguration configuration, StressTestSettings settings);

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
            updateMessage.Text = "";
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

            StressTestOutgoingConfiguration config = new StressTestOutgoingConfiguration { GracePeriodSeconds = this.gracePeriodSeconds, Clients = this.clientConfigurations };
            string serializedConfiguration = JsonSerializer.Serialize(config);

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
            gracePeriod.Visible = false;
            gracePeriodLbl.Visible = false;
            updateMessage.Visible = false;
            loadConfig.Visible = false;
            saveConfig.Visible = false;
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

            updateMessage.Text = "Number of clients updated to " + numClients.Value + ".";
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
            StressTestSettings settings = new StressTestSettings();
            settings.BrokerHost = brokerIpAddrInput.Text;
            settings.BrokerPort = Int32.Parse(brokerPortInput.Text);
            settings.GracePeriod = (int)gracePeriod.Value;
            settings.NumClients = (int)numClients.Value;
            this.Invoke(new SafeCallDelegate(ShowResultsWindow), new object[]{ results, new StressTestOutgoingConfiguration { Clients = this.clientConfigurations }, settings });
        }

        private void ShowResultsWindow(StressTestIncomingResults results, StressTestOutgoingConfiguration configuration, StressTestSettings settings)
        {
            
            ResultsDisplayForm resultForm = new ResultsDisplayForm(results, configuration, settings);
            resultForm.Show();
            this.Hide();
        }

        private void defaultSettingsButton_Click(object sender, EventArgs e)
        {
            // Updates current label text values to be set to default
            packetInterval.Text = "25";
            duration.Text = "15";
            packetSize.Text = "100";
            qosLevel.SelectedIndex = 0;
            
            // Updates current clientConfiguration object in list to be the current default set of values
            clientConfigurations[clientSelection.SelectedIndex].PacketIntervalMS = Int32.Parse(packetInterval.Text);
            clientConfigurations[clientSelection.SelectedIndex].DurationSeconds = Int32.Parse(duration.Text);
            clientConfigurations[clientSelection.SelectedIndex].PacketSizeBytes = Int32.Parse(packetSize.Text);
            clientConfigurations[clientSelection.SelectedIndex].QOSLevel = qosLevel.SelectedIndex;

            updateMessage.Text = "Current client settings returned to default.";
        }

        private void applyAllButton_Click(object sender, EventArgs e)
        {
            // Loops through each client in clientConfigurations and sets their values to be equal to what's on screen.
            foreach (ClientConfiguration client in clientConfigurations)
            {
                client.PacketIntervalMS = Int32.Parse(packetInterval.Text);
                client.DurationSeconds = Int32.Parse(duration.Text);
                client.PacketSizeBytes = Int32.Parse(packetSize.Text);
                client.QOSLevel = qosLevel.SelectedIndex;
            }

            updateMessage.Text = "All clients updated with current settings.";
        }

        private void saveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Json files (*.json)|*.json";
            saveDialog.Title = "Save Configuration";
            saveDialog.ShowDialog();

            if(saveDialog.FileName != "")
            {
                FileStream fs = (FileStream) saveDialog.OpenFile();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                StressTestOutgoingConfiguration config = new StressTestOutgoingConfiguration { GracePeriodSeconds = this.gracePeriodSeconds, Clients = this.clientConfigurations };
                string serializedConfiguration = JsonSerializer.Serialize(config, options);
                byte[] bytes = Encoding.UTF8.GetBytes(serializedConfiguration);
                fs.Write(bytes, 0, bytes.Length);

                fs.Close();
            }
        }

        private void loadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Json files (*.json)|*.json";
            openDialog.Title = "Load Configuration";

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream stream;
                    if ((stream = openDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            StreamReader reader = new StreamReader(stream);
                            string line;
                            string totalJsonStr = "";
                            while((line = reader.ReadLine()) != null)
                            {
                                totalJsonStr += line;
                            }
                            Console.WriteLine(totalJsonStr);
                            StressTestOutgoingConfiguration config = JsonSerializer.Deserialize<StressTestOutgoingConfiguration>(totalJsonStr);
                            gracePeriodSeconds = config.GracePeriodSeconds;
                            clientConfigurations = config.Clients;
                            OnLoadConfigFile();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void OnLoadConfigFile()
        {
            clientSelection.Items.Clear();
            for(int i = 1; i <= clientConfigurations.Count; i++)
            {
                clientSelection.Items.Add($"Client {i}");
            }
            clientSelection.SelectedIndex = 0;
            LoadClientConfigIntoForm(0);
            numClients.Value = clientConfigurations.Count;
            gracePeriod.Value = gracePeriodSeconds;
        }

        private void gracePeriod_ValueChanged(object sender, EventArgs e)
        {
            gracePeriodSeconds = (int) gracePeriod.Value;
        }

        /// <summary>
        /// When returned to from the ResultsDisplayForm, populates the fields based off of the previously given data.
        /// </summary>
        /// <param name="settings">Base settings (i.e. broker IP, broker port, number of clients, grace period)</param>
        /// <param name="resultClientConfigurations">Client configurations (packet rate, duration, etc.)</param>
        public void GrabResultSettings(StressTestSettings settings, StressTestOutgoingConfiguration resultClientConfigurations)
        {
            // Sets field texts accordingly
            brokerIpAddrInput.Text = settings.BrokerHost;
            brokerPortInput.Text = settings.BrokerPort.ToString();
            numClients.Value = settings.NumClients;
            gracePeriod.Value = settings.GracePeriod;

            // Updates this clientConfigurations files with the clients from the ResultsDisplayForm

            clientConfigurations = resultClientConfigurations.Clients;

            // Clears out current comboBox
            clientSelection.Items.Clear();

            // Updates combobox values to be accurate to the newly populated clientConfigurations amounts
            for (int i = 1; i <= clientConfigurations.Count; i++)
            {
                clientSelection.Items.Add($"Client {i}");
            }
            
            // Sets default index to 0 for good measure.
            clientSelection.SelectedIndex = 0;

        }
    }
}