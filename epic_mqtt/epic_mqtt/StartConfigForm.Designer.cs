namespace mqtt_stresstest
{
    partial class StartConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.brokerIpAddrInput = new MetroFramework.Controls.MetroTextBox();
            this.ipAdressLabel = new MetroFramework.Controls.MetroLabel();
            this.brokerPortInput = new MetroFramework.Controls.MetroTextBox();
            this.brokerPortLabel = new MetroFramework.Controls.MetroLabel();
            this.packetIntervalLabel = new MetroFramework.Controls.MetroLabel();
            this.duration = new MetroFramework.Controls.MetroTextBox();
            this.durationLabel = new MetroFramework.Controls.MetroLabel();
            this.qosLabel = new MetroFramework.Controls.MetroLabel();
            this.startStressTest = new MetroFramework.Controls.MetroButton();
            this.clientConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.qosLevel = new System.Windows.Forms.ComboBox();
            this.packetSize = new MetroFramework.Controls.MetroTextBox();
            this.packetInterval = new MetroFramework.Controls.MetroTextBox();
            this.packetSizeLabel = new MetroFramework.Controls.MetroLabel();
            this.numClientsLabel = new MetroFramework.Controls.MetroLabel();
            this.numClients = new System.Windows.Forms.NumericUpDown();
            this.updateNumClients = new MetroFramework.Controls.MetroButton();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.progressLabel = new MetroFramework.Controls.MetroLabel();
            this.timeOngoing = new MetroFramework.Controls.MetroLabel();
            this.loadingPanel = new MetroFramework.Controls.MetroPanel();
            this.labelTimer = new System.Windows.Forms.Timer(this.components);
            this.clientSelection = new System.Windows.Forms.ComboBox();
            this.applyAllButton = new MetroFramework.Controls.MetroButton();
            this.defaultSettingsButton = new MetroFramework.Controls.MetroButton();
            this.updateMessage = new MetroFramework.Controls.MetroLabel();
            this.clientConfigGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).BeginInit();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // brokerIpAddrInput
            // 
            this.brokerIpAddrInput.Location = new System.Drawing.Point(16, 89);
            this.brokerIpAddrInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brokerIpAddrInput.Name = "brokerIpAddrInput";
            this.brokerIpAddrInput.Size = new System.Drawing.Size(163, 20);
            this.brokerIpAddrInput.TabIndex = 2;
            this.brokerIpAddrInput.Text = "192.168.2.44";
            // 
            // ipAdressLabel
            // 
            this.ipAdressLabel.AutoSize = true;
            this.ipAdressLabel.Location = new System.Drawing.Point(16, 68);
            this.ipAdressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAdressLabel.Name = "ipAdressLabel";
            this.ipAdressLabel.Size = new System.Drawing.Size(114, 19);
            this.ipAdressLabel.TabIndex = 6;
            this.ipAdressLabel.Text = "Broker IP Address";
            // 
            // brokerPortInput
            // 
            this.brokerPortInput.Location = new System.Drawing.Point(194, 89);
            this.brokerPortInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brokerPortInput.Name = "brokerPortInput";
            this.brokerPortInput.Size = new System.Drawing.Size(104, 20);
            this.brokerPortInput.TabIndex = 7;
            this.brokerPortInput.Text = "1883";
            // 
            // brokerPortLabel
            // 
            this.brokerPortLabel.AutoSize = true;
            this.brokerPortLabel.Location = new System.Drawing.Point(194, 68);
            this.brokerPortLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brokerPortLabel.Name = "brokerPortLabel";
            this.brokerPortLabel.Size = new System.Drawing.Size(77, 19);
            this.brokerPortLabel.TabIndex = 8;
            this.brokerPortLabel.Text = "Broker Port";
            // 
            // packetIntervalLabel
            // 
            this.packetIntervalLabel.AutoSize = true;
            this.packetIntervalLabel.Location = new System.Drawing.Point(6, 22);
            this.packetIntervalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packetIntervalLabel.Name = "packetIntervalLabel";
            this.packetIntervalLabel.Size = new System.Drawing.Size(127, 19);
            this.packetIntervalLabel.TabIndex = 13;
            this.packetIntervalLabel.Text = "Packets Interval (ms)";
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(6, 87);
            this.duration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(271, 20);
            this.duration.TabIndex = 14;
            this.duration.Text = "15";
            this.duration.Leave += new System.EventHandler(this.duration_Leave);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(6, 69);
            this.durationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(76, 19);
            this.durationLabel.TabIndex = 15;
            this.durationLabel.Text = "Duration (s)";
            // 
            // qosLabel
            // 
            this.qosLabel.AutoSize = true;
            this.qosLabel.Location = new System.Drawing.Point(6, 159);
            this.qosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qosLabel.Name = "qosLabel";
            this.qosLabel.Size = new System.Drawing.Size(68, 19);
            this.qosLabel.TabIndex = 18;
            this.qosLabel.Text = "QoS Level";
            // 
            // startStressTest
            // 
            this.startStressTest.Location = new System.Drawing.Point(16, 478);
            this.startStressTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startStressTest.Name = "startStressTest";
            this.startStressTest.Size = new System.Drawing.Size(280, 36);
            this.startStressTest.TabIndex = 19;
            this.startStressTest.Text = "START STRESS TEST";
            this.startStressTest.Click += new System.EventHandler(this.startStressTest_Click);
            // 
            // clientConfigGroupBox
            // 
            this.clientConfigGroupBox.Controls.Add(this.defaultSettingsButton);
            this.clientConfigGroupBox.Controls.Add(this.applyAllButton);
            this.clientConfigGroupBox.Controls.Add(this.qosLevel);
            this.clientConfigGroupBox.Controls.Add(this.packetSize);
            this.clientConfigGroupBox.Controls.Add(this.packetInterval);
            this.clientConfigGroupBox.Controls.Add(this.packetSizeLabel);
            this.clientConfigGroupBox.Controls.Add(this.qosLabel);
            this.clientConfigGroupBox.Controls.Add(this.duration);
            this.clientConfigGroupBox.Controls.Add(this.durationLabel);
            this.clientConfigGroupBox.Controls.Add(this.packetIntervalLabel);
            this.clientConfigGroupBox.Location = new System.Drawing.Point(16, 211);
            this.clientConfigGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientConfigGroupBox.Name = "clientConfigGroupBox";
            this.clientConfigGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientConfigGroupBox.Size = new System.Drawing.Size(281, 263);
            this.clientConfigGroupBox.TabIndex = 23;
            this.clientConfigGroupBox.TabStop = false;
            this.clientConfigGroupBox.Text = "Client Configuration";
            // 
            // qosLevel
            // 
            this.qosLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qosLevel.FormattingEnabled = true;
            this.qosLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.qosLevel.Location = new System.Drawing.Point(6, 180);
            this.qosLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.qosLevel.Name = "qosLevel";
            this.qosLevel.Size = new System.Drawing.Size(271, 21);
            this.qosLevel.TabIndex = 28;
            this.qosLevel.SelectedIndexChanged += new System.EventHandler(this.qosLevel_SelectedIndexChanged);
            // 
            // packetSize
            // 
            this.packetSize.Location = new System.Drawing.Point(6, 133);
            this.packetSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.packetSize.Name = "packetSize";
            this.packetSize.Size = new System.Drawing.Size(271, 20);
            this.packetSize.TabIndex = 27;
            this.packetSize.Text = "100";
            this.packetSize.Leave += new System.EventHandler(this.packetSize_Leave);
            // 
            // packetInterval
            // 
            this.packetInterval.Location = new System.Drawing.Point(6, 41);
            this.packetInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.packetInterval.Name = "packetInterval";
            this.packetInterval.Size = new System.Drawing.Size(271, 20);
            this.packetInterval.TabIndex = 26;
            this.packetInterval.Text = "15";
            this.packetInterval.Leave += new System.EventHandler(this.packetInterval_Leave);
            // 
            // packetSizeLabel
            // 
            this.packetSizeLabel.AutoSize = true;
            this.packetSizeLabel.Location = new System.Drawing.Point(6, 114);
            this.packetSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packetSizeLabel.Name = "packetSizeLabel";
            this.packetSizeLabel.Size = new System.Drawing.Size(113, 19);
            this.packetSizeLabel.TabIndex = 25;
            this.packetSizeLabel.Text = "Packet size (bytes)";
            // 
            // numClientsLabel
            // 
            this.numClientsLabel.AutoSize = true;
            this.numClientsLabel.Location = new System.Drawing.Point(16, 112);
            this.numClientsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numClientsLabel.Name = "numClientsLabel";
            this.numClientsLabel.Size = new System.Drawing.Size(116, 19);
            this.numClientsLabel.TabIndex = 25;
            this.numClientsLabel.Text = "Number of Clients";
            // 
            // numClients
            // 
            this.numClients.Location = new System.Drawing.Point(17, 135);
            this.numClients.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numClients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numClients.Name = "numClients";
            this.numClients.Size = new System.Drawing.Size(162, 20);
            this.numClients.TabIndex = 26;
            this.numClients.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updateNumClients
            // 
            this.updateNumClients.Location = new System.Drawing.Point(194, 135);
            this.updateNumClients.Name = "updateNumClients";
            this.updateNumClients.Size = new System.Drawing.Size(102, 23);
            this.updateNumClients.TabIndex = 27;
            this.updateNumClients.Text = "Update";
            this.updateNumClients.Click += new System.EventHandler(this.updateNumClients_Click);
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(14, 18);
            this.progressSpinner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(212, 237);
            this.progressSpinner.TabIndex = 29;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(47, 262);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(166, 19);
            this.progressLabel.TabIndex = 30;
            this.progressLabel.Text = "Running Tests. Please wait...";
            // 
            // timeOngoing
            // 
            this.timeOngoing.AutoSize = true;
            this.timeOngoing.Location = new System.Drawing.Point(92, 282);
            this.timeOngoing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeOngoing.Name = "timeOngoing";
            this.timeOngoing.Size = new System.Drawing.Size(57, 19);
            this.timeOngoing.TabIndex = 31;
            this.timeOngoing.Text = "00:00:00";
            // 
            // loadingPanel
            // 
            this.loadingPanel.Controls.Add(this.timeOngoing);
            this.loadingPanel.Controls.Add(this.progressLabel);
            this.loadingPanel.Controls.Add(this.progressSpinner);
            this.loadingPanel.HorizontalScrollbarBarColor = true;
            this.loadingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.loadingPanel.HorizontalScrollbarSize = 8;
            this.loadingPanel.Location = new System.Drawing.Point(36, 63);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(240, 316);
            this.loadingPanel.TabIndex = 30;
            this.loadingPanel.VerticalScrollbarBarColor = true;
            this.loadingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.loadingPanel.VerticalScrollbarSize = 8;
            this.loadingPanel.Visible = false;
            // 
            // labelTimer
            // 
            this.labelTimer.Interval = 1000;
            this.labelTimer.Tick += new System.EventHandler(this.labelTimer_Tick);
            // 
            // clientSelection
            // 
            this.clientSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientSelection.FormattingEnabled = true;
            this.clientSelection.Items.AddRange(new object[] {
            "Client 1"});
            this.clientSelection.Location = new System.Drawing.Point(16, 176);
            this.clientSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientSelection.Name = "clientSelection";
            this.clientSelection.Size = new System.Drawing.Size(282, 21);
            this.clientSelection.TabIndex = 31;
            this.clientSelection.SelectedIndexChanged += new System.EventHandler(this.clientSelection_SelectedIndexChanged);
            // 
            // applyAllButton
            // 
            this.applyAllButton.Location = new System.Drawing.Point(145, 216);
            this.applyAllButton.Name = "applyAllButton";
            this.applyAllButton.Size = new System.Drawing.Size(131, 33);
            this.applyAllButton.TabIndex = 29;
            this.applyAllButton.Text = "Apply to All Clients";
            this.applyAllButton.Click += new System.EventHandler(this.applyAllButton_Click);
            // 
            // defaultSettingsButton
            // 
            this.defaultSettingsButton.Location = new System.Drawing.Point(5, 216);
            this.defaultSettingsButton.Name = "defaultSettingsButton";
            this.defaultSettingsButton.Size = new System.Drawing.Size(134, 33);
            this.defaultSettingsButton.TabIndex = 30;
            this.defaultSettingsButton.Text = "Set to Default";
            this.defaultSettingsButton.Click += new System.EventHandler(this.defaultSettingsButton_Click);
            // 
            // updateMessage
            // 
            this.updateMessage.AutoSize = true;
            this.updateMessage.Location = new System.Drawing.Point(16, 520);
            this.updateMessage.Name = "updateMessage";
            this.updateMessage.Size = new System.Drawing.Size(101, 19);
            this.updateMessage.TabIndex = 32;
            this.updateMessage.Text = "updateMessage";
            // 
            // StartConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 552);
            this.Controls.Add(this.updateMessage);
            this.Controls.Add(this.clientSelection);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.updateNumClients);
            this.Controls.Add(this.brokerPortLabel);
            this.Controls.Add(this.numClients);
            this.Controls.Add(this.numClientsLabel);
            this.Controls.Add(this.clientConfigGroupBox);
            this.Controls.Add(this.startStressTest);
            this.Controls.Add(this.brokerPortInput);
            this.Controls.Add(this.ipAdressLabel);
            this.Controls.Add(this.brokerIpAddrInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartConfigForm";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "MQTT Stress Tester";
            this.Load += new System.EventHandler(this.StartConfigForm_Load);
            this.clientConfigGroupBox.ResumeLayout(false);
            this.clientConfigGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).EndInit();
            this.loadingPanel.ResumeLayout(false);
            this.loadingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox brokerIpAddrInput;
        private MetroFramework.Controls.MetroLabel ipAdressLabel;
        private MetroFramework.Controls.MetroTextBox brokerPortInput;
        private MetroFramework.Controls.MetroLabel brokerPortLabel;
        private MetroFramework.Controls.MetroLabel packetIntervalLabel;
        private MetroFramework.Controls.MetroTextBox duration;
        private MetroFramework.Controls.MetroLabel durationLabel;
        private MetroFramework.Controls.MetroLabel qosLabel;
        private MetroFramework.Controls.MetroButton startStressTest;
        private System.Windows.Forms.GroupBox clientConfigGroupBox;
        private MetroFramework.Controls.MetroLabel packetSizeLabel;
        private MetroFramework.Controls.MetroTextBox packetSize;
        private MetroFramework.Controls.MetroTextBox packetInterval;
        private MetroFramework.Controls.MetroLabel numClientsLabel;
        private System.Windows.Forms.NumericUpDown numClients;
        private MetroFramework.Controls.MetroButton updateNumClients;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private MetroFramework.Controls.MetroLabel timeOngoing;
        private MetroFramework.Controls.MetroLabel progressLabel;
        private MetroFramework.Controls.MetroPanel loadingPanel;
        private System.Windows.Forms.Timer labelTimer;
        private System.Windows.Forms.ComboBox qosLevel;
        private System.Windows.Forms.ComboBox clientSelection;
        private MetroFramework.Controls.MetroButton defaultSettingsButton;
        private MetroFramework.Controls.MetroButton applyAllButton;
        private MetroFramework.Controls.MetroLabel updateMessage;
    }
}

