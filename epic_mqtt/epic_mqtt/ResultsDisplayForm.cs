
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
    public partial class ResultsDisplayForm : MetroForm
    {
        private StressTestIncomingResults results;
        private StressTestOutgoingConfiguration clientConfigurations;
        private StressTestSettings settings;

        public ResultsDisplayForm(StressTestIncomingResults results, StressTestOutgoingConfiguration configurations, StressTestSettings settings)
        {
            this.results = results;
            this.clientConfigurations = configurations;
            this.settings = settings;
            InitializeComponent();
        }

        private void ResultsDisplayForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= this.results.ClientResults.Count; i++)
            {
                this.resultsSelection.Items.Add($"Client {i}");
            }
            resultsSelection.SelectedIndex = 0;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void resultsSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(resultsSelection.SelectedIndex == 0)
            {
                loadTotalResults();
                clientConfigGroupBox.Visible = false;
            }
            else
            {
                loadClientResults(resultsSelection.SelectedIndex - 1);
                loadClientConfiguration(resultsSelection.SelectedIndex - 1);
                clientConfigGroupBox.Visible = true;
            }
        }

        private void loadTotalResults()
        {
            averageLatency.Text = $"Average Latency: {results.TotalResults.AverageLatency}ms";
            minLatency.Text = $"Minimum Latency: {results.TotalResults.MinimumLatency}ms";
            maxLatency.Text = $"Maximum Latency: {results.TotalResults.MaximumLatency}ms";
            packetsLost.Text = $"Packets Lost: {results.TotalResults.PacketsLost}";
        }

        private void loadClientResults(int clientNum)
        {
            averageLatency.Text = $"Average Latency: {results.ClientResults[clientNum].AverageLatency}ms";
            minLatency.Text = $"Minimum Latency: {results.ClientResults[clientNum].MinimumLatency}ms";
            maxLatency.Text = $"Maximum Latency: {results.ClientResults[clientNum].MaximumLatency}ms";
            packetsLost.Text = $"Packets Lost: {results.ClientResults[clientNum].PacketsLost}";
        }

        private void loadClientConfiguration(int clientNum)
        {
            packetInterval.Text = clientConfigurations.Clients[clientNum].PacketIntervalMS.ToString();
            duration.Text = clientConfigurations.Clients[clientNum].DurationSeconds.ToString();
            packetSize.Text = clientConfigurations.Clients[clientNum].PacketSizeBytes.ToString();
            qosLevel.SelectedIndex = clientConfigurations.Clients[clientNum].QOSLevel;
        }

        private void saveResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV files (*.csv)|*.csv";
            saveDialog.Title = "Save Configuration";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveDialog.OpenFile();
                foreach(String line in results.ToCSV(clientConfigurations))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    fs.Write(bytes, 0, bytes.Length);
                }

                fs.Close();
            }
        }

        /// <summary>
        /// Returns to StartConfigForm
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default EventArgs</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            StartConfigForm startConfig = new StartConfigForm();
            // Uses the settings from here to populate the newly created startConfig
            startConfig.GrabResultSettings(settings, clientConfigurations);
            this.Hide();
            startConfig.Show();
        }
    }
}