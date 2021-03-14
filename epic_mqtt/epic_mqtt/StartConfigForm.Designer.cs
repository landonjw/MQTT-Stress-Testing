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
            this.defaultSettingsButton = new MetroFramework.Controls.MetroButton();
            this.applyAllButton = new MetroFramework.Controls.MetroButton();
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
            this.updateMessage = new MetroFramework.Controls.MetroLabel();
            this.loadConfig = new MetroFramework.Controls.MetroButton();
            this.saveConfig = new MetroFramework.Controls.MetroButton();
            this.gracePeriodLbl = new MetroFramework.Controls.MetroLabel();
            this.gracePeriod = new System.Windows.Forms.NumericUpDown();
            this.clientConfigGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).BeginInit();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gracePeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // brokerIpAddrInput
            // 
            this.brokerIpAddrInput.Location = new System.Drawing.Point(21, 110);
            this.brokerIpAddrInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brokerIpAddrInput.Name = "brokerIpAddrInput";
            this.brokerIpAddrInput.Size = new System.Drawing.Size(217, 25);
            this.brokerIpAddrInput.TabIndex = 2;
            this.brokerIpAddrInput.Text = "127.0.0.1";
            // 
            // ipAdressLabel
            // 
            this.ipAdressLabel.AutoSize = true;
            this.ipAdressLabel.Location = new System.Drawing.Point(21, 84);
            this.ipAdressLabel.Name = "ipAdressLabel";
            this.ipAdressLabel.Size = new System.Drawing.Size(119, 20);
            this.ipAdressLabel.TabIndex = 6;
            this.ipAdressLabel.Text = "Broker IP Address";
            // 
            // brokerPortInput
            // 
            this.brokerPortInput.Location = new System.Drawing.Point(259, 110);
            this.brokerPortInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brokerPortInput.Name = "brokerPortInput";
            this.brokerPortInput.Size = new System.Drawing.Size(139, 25);
            this.brokerPortInput.TabIndex = 7;
            this.brokerPortInput.Text = "11883";
            // 
            // brokerPortLabel
            // 
            this.brokerPortLabel.AutoSize = true;
            this.brokerPortLabel.Location = new System.Drawing.Point(259, 84);
            this.brokerPortLabel.Name = "brokerPortLabel";
            this.brokerPortLabel.Size = new System.Drawing.Size(79, 20);
            this.brokerPortLabel.TabIndex = 8;
            this.brokerPortLabel.Text = "Broker Port";
            // 
            // packetIntervalLabel
            // 
            this.packetIntervalLabel.AutoSize = true;
            this.packetIntervalLabel.Location = new System.Drawing.Point(8, 27);
            this.packetIntervalLabel.Name = "packetIntervalLabel";
            this.packetIntervalLabel.Size = new System.Drawing.Size(135, 20);
            this.packetIntervalLabel.TabIndex = 13;
            this.packetIntervalLabel.Text = "Packets Interval (ms)";
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(8, 107);
            this.duration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(361, 25);
            this.duration.TabIndex = 14;
            this.duration.Text = "15";
            this.duration.Leave += new System.EventHandler(this.duration_Leave);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(8, 85);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(80, 20);
            this.durationLabel.TabIndex = 15;
            this.durationLabel.Text = "Duration (s)";
            // 
            // qosLabel
            // 
            this.qosLabel.AutoSize = true;
            this.qosLabel.Location = new System.Drawing.Point(8, 196);
            this.qosLabel.Name = "qosLabel";
            this.qosLabel.Size = new System.Drawing.Size(72, 20);
            this.qosLabel.TabIndex = 18;
            this.qosLabel.Text = "QoS Level";
            // 
            // startStressTest
            // 
            this.startStressTest.Location = new System.Drawing.Point(21, 672);
            this.startStressTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startStressTest.Name = "startStressTest";
            this.startStressTest.Size = new System.Drawing.Size(373, 44);
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
            this.clientConfigGroupBox.Location = new System.Drawing.Point(21, 287);
            this.clientConfigGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clientConfigGroupBox.Name = "clientConfigGroupBox";
            this.clientConfigGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clientConfigGroupBox.Size = new System.Drawing.Size(375, 324);
            this.clientConfigGroupBox.TabIndex = 23;
            this.clientConfigGroupBox.TabStop = false;
            this.clientConfigGroupBox.Text = "Client Configuration";
            // 
            // defaultSettingsButton
            // 
            this.defaultSettingsButton.Location = new System.Drawing.Point(7, 266);
            this.defaultSettingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.defaultSettingsButton.Name = "defaultSettingsButton";
            this.defaultSettingsButton.Size = new System.Drawing.Size(179, 41);
            this.defaultSettingsButton.TabIndex = 30;
            this.defaultSettingsButton.Text = "Set to Default";
            this.defaultSettingsButton.Click += new System.EventHandler(this.defaultSettingsButton_Click);
            // 
            // applyAllButton
            // 
            this.applyAllButton.Location = new System.Drawing.Point(193, 266);
            this.applyAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.applyAllButton.Name = "applyAllButton";
            this.applyAllButton.Size = new System.Drawing.Size(175, 41);
            this.applyAllButton.TabIndex = 29;
            this.applyAllButton.Text = "Apply to All Clients";
            this.applyAllButton.Click += new System.EventHandler(this.applyAllButton_Click);
            // 
            // qosLevel
            // 
            this.qosLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qosLevel.FormattingEnabled = true;
            this.qosLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.qosLevel.Location = new System.Drawing.Point(8, 222);
            this.qosLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.qosLevel.Name = "qosLevel";
            this.qosLevel.Size = new System.Drawing.Size(360, 24);
            this.qosLevel.TabIndex = 28;
            this.qosLevel.SelectedIndexChanged += new System.EventHandler(this.qosLevel_SelectedIndexChanged);
            // 
            // packetSize
            // 
            this.packetSize.Location = new System.Drawing.Point(8, 164);
            this.packetSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetSize.Name = "packetSize";
            this.packetSize.Size = new System.Drawing.Size(361, 25);
            this.packetSize.TabIndex = 27;
            this.packetSize.Text = "100";
            this.packetSize.Leave += new System.EventHandler(this.packetSize_Leave);
            // 
            // packetInterval
            // 
            this.packetInterval.Location = new System.Drawing.Point(8, 50);
            this.packetInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetInterval.Name = "packetInterval";
            this.packetInterval.Size = new System.Drawing.Size(361, 25);
            this.packetInterval.TabIndex = 26;
            this.packetInterval.Text = "15";
            this.packetInterval.Leave += new System.EventHandler(this.packetInterval_Leave);
            // 
            // packetSizeLabel
            // 
            this.packetSizeLabel.AutoSize = true;
            this.packetSizeLabel.Location = new System.Drawing.Point(8, 140);
            this.packetSizeLabel.Name = "packetSizeLabel";
            this.packetSizeLabel.Size = new System.Drawing.Size(122, 20);
            this.packetSizeLabel.TabIndex = 25;
            this.packetSizeLabel.Text = "Packet size (bytes)";
            // 
            // numClientsLabel
            // 
            this.numClientsLabel.AutoSize = true;
            this.numClientsLabel.Location = new System.Drawing.Point(21, 138);
            this.numClientsLabel.Name = "numClientsLabel";
            this.numClientsLabel.Size = new System.Drawing.Size(122, 20);
            this.numClientsLabel.TabIndex = 25;
            this.numClientsLabel.Text = "Number of Clients";
            // 
            // numClients
            // 
            this.numClients.Location = new System.Drawing.Point(23, 166);
            this.numClients.Margin = new System.Windows.Forms.Padding(4);
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
            this.numClients.Size = new System.Drawing.Size(216, 22);
            this.numClients.TabIndex = 26;
            this.numClients.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updateNumClients
            // 
            this.updateNumClients.Location = new System.Drawing.Point(259, 166);
            this.updateNumClients.Margin = new System.Windows.Forms.Padding(4);
            this.updateNumClients.Name = "updateNumClients";
            this.updateNumClients.Size = new System.Drawing.Size(136, 28);
            this.updateNumClients.TabIndex = 27;
            this.updateNumClients.Text = "Update";
            this.updateNumClients.Click += new System.EventHandler(this.updateNumClients_Click);
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(19, 22);
            this.progressSpinner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(283, 292);
            this.progressSpinner.TabIndex = 29;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(63, 322);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(178, 20);
            this.progressLabel.TabIndex = 30;
            this.progressLabel.Text = "Running Tests. Please wait...";
            // 
            // timeOngoing
            // 
            this.timeOngoing.AutoSize = true;
            this.timeOngoing.Location = new System.Drawing.Point(123, 347);
            this.timeOngoing.Name = "timeOngoing";
            this.timeOngoing.Size = new System.Drawing.Size(63, 20);
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
            this.loadingPanel.HorizontalScrollbarSize = 10;
            this.loadingPanel.Location = new System.Drawing.Point(49, 108);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(320, 389);
            this.loadingPanel.TabIndex = 30;
            this.loadingPanel.VerticalScrollbarBarColor = true;
            this.loadingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.loadingPanel.VerticalScrollbarSize = 11;
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
            this.clientSelection.Location = new System.Drawing.Point(21, 254);
            this.clientSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clientSelection.Name = "clientSelection";
            this.clientSelection.Size = new System.Drawing.Size(375, 24);
            this.clientSelection.TabIndex = 31;
            this.clientSelection.SelectedIndexChanged += new System.EventHandler(this.clientSelection_SelectedIndexChanged);
            // 
            // updateMessage
            // 
            this.updateMessage.AutoSize = true;
            this.updateMessage.Location = new System.Drawing.Point(21, 724);
            this.updateMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateMessage.Name = "updateMessage";
            this.updateMessage.Size = new System.Drawing.Size(107, 20);
            this.updateMessage.TabIndex = 32;
            this.updateMessage.Text = "updateMessage";
            // 
            // loadConfig
            // 
            this.loadConfig.Location = new System.Drawing.Point(21, 618);
            this.loadConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadConfig.Name = "loadConfig";
            this.loadConfig.Size = new System.Drawing.Size(186, 44);
            this.loadConfig.TabIndex = 33;
            this.loadConfig.Text = "LOAD CONFIGURATION";
            this.loadConfig.Click += new System.EventHandler(this.loadConfig_Click);
            // 
            // saveConfig
            // 
            this.saveConfig.Location = new System.Drawing.Point(214, 618);
            this.saveConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(180, 44);
            this.saveConfig.TabIndex = 34;
            this.saveConfig.Text = "SAVE CONFIGURATION";
            this.saveConfig.Click += new System.EventHandler(this.saveConfig_Click);
            // 
            // gracePeriodLbl
            // 
            this.gracePeriodLbl.AutoSize = true;
            this.gracePeriodLbl.Location = new System.Drawing.Point(21, 197);
            this.gracePeriodLbl.Name = "gracePeriodLbl";
            this.gracePeriodLbl.Size = new System.Drawing.Size(152, 20);
            this.gracePeriodLbl.TabIndex = 36;
            this.gracePeriodLbl.Text = "Grace Period (seconds)";
            // 
            // gracePeriod
            // 
            this.gracePeriod.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gracePeriod.Location = new System.Drawing.Point(21, 221);
            this.gracePeriod.Margin = new System.Windows.Forms.Padding(4);
            this.gracePeriod.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.gracePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gracePeriod.Name = "gracePeriod";
            this.gracePeriod.Size = new System.Drawing.Size(377, 22);
            this.gracePeriod.TabIndex = 37;
            this.gracePeriod.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gracePeriod.ValueChanged += new System.EventHandler(this.gracePeriod_ValueChanged);
            // 
            // StartConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 758);
            this.Controls.Add(this.gracePeriod);
            this.Controls.Add(this.gracePeriodLbl);
            this.Controls.Add(this.saveConfig);
            this.Controls.Add(this.loadConfig);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StartConfigForm";
            this.Padding = new System.Windows.Forms.Padding(19, 74, 19, 16);
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "MQTT Stress Tester";
            this.Load += new System.EventHandler(this.StartConfigForm_Load);
            this.clientConfigGroupBox.ResumeLayout(false);
            this.clientConfigGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).EndInit();
            this.loadingPanel.ResumeLayout(false);
            this.loadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gracePeriod)).EndInit();
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
        private MetroFramework.Controls.MetroButton loadConfig;
        private MetroFramework.Controls.MetroButton saveConfig;
        private MetroFramework.Controls.MetroLabel gracePeriodLbl;
        private System.Windows.Forms.NumericUpDown gracePeriod;
    }
}

