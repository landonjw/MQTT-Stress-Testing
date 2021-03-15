namespace mqtt_stresstest
{
    partial class ResultsDisplayForm
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
            this.packetIntervalLabel = new MetroFramework.Controls.MetroLabel();
            this.durationLabel = new MetroFramework.Controls.MetroLabel();
            this.qosLabel = new MetroFramework.Controls.MetroLabel();
            this.clientConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.qosLevel = new System.Windows.Forms.ComboBox();
            this.packetSize = new MetroFramework.Controls.MetroTextBox();
            this.packetInterval = new MetroFramework.Controls.MetroTextBox();
            this.packetSizeLabel = new MetroFramework.Controls.MetroLabel();
            this.duration = new MetroFramework.Controls.MetroTextBox();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.packetsLost = new MetroFramework.Controls.MetroLabel();
            this.minLatency = new MetroFramework.Controls.MetroLabel();
            this.maxLatency = new MetroFramework.Controls.MetroLabel();
            this.averageLatency = new MetroFramework.Controls.MetroLabel();
            this.saveResults = new MetroFramework.Controls.MetroButton();
            this.resultsSelection = new System.Windows.Forms.ComboBox();
            this.backButton = new MetroFramework.Controls.MetroButton();
            this.clientConfigGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
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
            // clientConfigGroupBox
            // 
            this.clientConfigGroupBox.Controls.Add(this.qosLevel);
            this.clientConfigGroupBox.Controls.Add(this.packetSize);
            this.clientConfigGroupBox.Controls.Add(this.packetInterval);
            this.clientConfigGroupBox.Controls.Add(this.packetSizeLabel);
            this.clientConfigGroupBox.Controls.Add(this.qosLabel);
            this.clientConfigGroupBox.Controls.Add(this.duration);
            this.clientConfigGroupBox.Controls.Add(this.durationLabel);
            this.clientConfigGroupBox.Controls.Add(this.packetIntervalLabel);
            this.clientConfigGroupBox.Location = new System.Drawing.Point(14, 214);
            this.clientConfigGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientConfigGroupBox.Name = "clientConfigGroupBox";
            this.clientConfigGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientConfigGroupBox.Size = new System.Drawing.Size(281, 214);
            this.clientConfigGroupBox.TabIndex = 23;
            this.clientConfigGroupBox.TabStop = false;
            this.clientConfigGroupBox.Text = "Client Configuration";
            // 
            // qosLevel
            // 
            this.qosLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qosLevel.Enabled = false;
            this.qosLevel.FormattingEnabled = true;
            this.qosLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.qosLevel.Location = new System.Drawing.Point(6, 182);
            this.qosLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.qosLevel.Name = "qosLevel";
            this.qosLevel.Size = new System.Drawing.Size(271, 21);
            this.qosLevel.TabIndex = 28;
            // 
            // packetSize
            // 
            this.packetSize.Enabled = false;
            this.packetSize.Location = new System.Drawing.Point(6, 133);
            this.packetSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.packetSize.Name = "packetSize";
            this.packetSize.Size = new System.Drawing.Size(271, 20);
            this.packetSize.TabIndex = 27;
            this.packetSize.Text = "100";
            // 
            // packetInterval
            // 
            this.packetInterval.Enabled = false;
            this.packetInterval.Location = new System.Drawing.Point(6, 41);
            this.packetInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.packetInterval.Name = "packetInterval";
            this.packetInterval.Size = new System.Drawing.Size(271, 20);
            this.packetInterval.TabIndex = 26;
            this.packetInterval.Text = "15";
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
            // duration
            // 
            this.duration.Enabled = false;
            this.duration.Location = new System.Drawing.Point(6, 87);
            this.duration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(271, 20);
            this.duration.TabIndex = 14;
            this.duration.Text = "15";
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Controls.Add(this.packetsLost);
            this.resultsGroupBox.Controls.Add(this.minLatency);
            this.resultsGroupBox.Controls.Add(this.maxLatency);
            this.resultsGroupBox.Controls.Add(this.averageLatency);
            this.resultsGroupBox.Location = new System.Drawing.Point(14, 98);
            this.resultsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultsGroupBox.Size = new System.Drawing.Size(281, 105);
            this.resultsGroupBox.TabIndex = 30;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results";
            // 
            // packetsLost
            // 
            this.packetsLost.AutoSize = true;
            this.packetsLost.Location = new System.Drawing.Point(6, 81);
            this.packetsLost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packetsLost.Name = "packetsLost";
            this.packetsLost.Size = new System.Drawing.Size(92, 19);
            this.packetsLost.TabIndex = 16;
            this.packetsLost.Text = "Packets Lost: 0";
            // 
            // minLatency
            // 
            this.minLatency.AutoSize = true;
            this.minLatency.Location = new System.Drawing.Point(6, 42);
            this.minLatency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minLatency.Name = "minLatency";
            this.minLatency.Size = new System.Drawing.Size(143, 19);
            this.minLatency.TabIndex = 15;
            this.minLatency.Text = "Minimum Latency: 0ms";
            // 
            // maxLatency
            // 
            this.maxLatency.AutoSize = true;
            this.maxLatency.Location = new System.Drawing.Point(6, 62);
            this.maxLatency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxLatency.Name = "maxLatency";
            this.maxLatency.Size = new System.Drawing.Size(146, 19);
            this.maxLatency.TabIndex = 14;
            this.maxLatency.Text = "Maximum Latency: 0ms";
            // 
            // averageLatency
            // 
            this.averageLatency.AutoSize = true;
            this.averageLatency.Location = new System.Drawing.Point(6, 22);
            this.averageLatency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.averageLatency.Name = "averageLatency";
            this.averageLatency.Size = new System.Drawing.Size(136, 19);
            this.averageLatency.TabIndex = 13;
            this.averageLatency.Text = "Average Latency: 0ms";
            // 
            // saveResults
            // 
            this.saveResults.Location = new System.Drawing.Point(158, 440);
            this.saveResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveResults.Name = "saveResults";
            this.saveResults.Size = new System.Drawing.Size(136, 36);
            this.saveResults.TabIndex = 31;
            this.saveResults.Text = "SAVE RESULTS";
            this.saveResults.Click += new System.EventHandler(this.saveResults_Click);
            // 
            // resultsSelection
            // 
            this.resultsSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resultsSelection.FormattingEnabled = true;
            this.resultsSelection.Items.AddRange(new object[] {
            "Total"});
            this.resultsSelection.Location = new System.Drawing.Point(14, 63);
            this.resultsSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultsSelection.Name = "resultsSelection";
            this.resultsSelection.Size = new System.Drawing.Size(281, 21);
            this.resultsSelection.TabIndex = 32;
            this.resultsSelection.SelectedIndexChanged += new System.EventHandler(this.resultsSelection_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(18, 440);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(136, 36);
            this.backButton.TabIndex = 33;
            this.backButton.Text = "BACK";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ResultsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 491);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.resultsSelection);
            this.Controls.Add(this.saveResults);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.clientConfigGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ResultsDisplayForm";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Stress Test Results";
            this.Load += new System.EventHandler(this.ResultsDisplayForm_Load);
            this.clientConfigGroupBox.ResumeLayout(false);
            this.clientConfigGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel packetIntervalLabel;
        private MetroFramework.Controls.MetroLabel durationLabel;
        private MetroFramework.Controls.MetroLabel qosLabel;
        private System.Windows.Forms.GroupBox clientConfigGroupBox;
        private MetroFramework.Controls.MetroLabel packetSizeLabel;
        private MetroFramework.Controls.MetroTextBox packetSize;
        private MetroFramework.Controls.MetroTextBox packetInterval;
        private MetroFramework.Controls.MetroTextBox duration;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private MetroFramework.Controls.MetroLabel averageLatency;
        private MetroFramework.Controls.MetroLabel packetsLost;
        private MetroFramework.Controls.MetroLabel minLatency;
        private MetroFramework.Controls.MetroLabel maxLatency;
        private MetroFramework.Controls.MetroButton saveResults;
        private System.Windows.Forms.ComboBox qosLevel;
        private System.Windows.Forms.ComboBox resultsSelection;
        private MetroFramework.Controls.MetroButton backButton;
    }
}

