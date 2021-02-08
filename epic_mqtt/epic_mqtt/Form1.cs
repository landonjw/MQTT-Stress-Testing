﻿
/* MQTT Project - Stress Testing Program
 * Software Engineering Project - COMP-CO867 / Winter 2021
 *
 * This is a continuation of an applied research project for assessing the MQTT protocol.
 * This program is intended to represent the UI portion of the stress testing program, allowing the user to schedule a stress test
 * and see the results.
*/

using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqtt_stresstest
{
    public partial class Form1 : MetroForm
    {
        MqttClient client;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the QoS combo box's default value to 0
            QOSLevelInput.SelectedIndex = 0;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
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
            catch(Exception)
            {
                MessageBox.Show("Invalid port number supplied. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                numberOfClients = Int32.Parse(numClientsInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid client amount supplied. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                packetsPerSecond = Int32.Parse(packetsPerSecondInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid packets per second value supplied. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                duration = Int32.Parse(durationInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid duration value supplied. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            qosLevel = Int32.Parse((string) QOSLevelInput.SelectedItem);

            // Establishes a new MQTT client on the given host name and port
            client = new MqttClient(brokerHost, brokerPort, false, null, null, MqttSslProtocols.None);
            string clientId = "UI";

            // Make the progress bar & status visible to give user some input on the application's life cycle
            progressBar.Visible = true;
            progressStatus.Visible = true;
            progressStatus.Text = "Connecting to broker...";

            try
            {
                client.Connect(clientId);
            }
            catch(Exception)
            {
                MessageBox.Show("Connection could not be established. Please check your inputs and try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar.Increment(2);
            progressStatus.Text = "Connection established. Sending stress test request...";

            // Send a packet to the broker supplying all the arguments for starting a stress test
            client.Publish("Start Stress Test", Encoding.UTF8.GetBytes($"[Number of Clients: {numberOfClients}] [Packets Per Second: {packetsPerSecond}] [Duration: {duration}] [QoS: {qosLevel}]"));
        }
    }
}