namespace mqtt_stresstest
{
    partial class Form1
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
            this.brokerIpAddrInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.brokerPortInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.duration = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.qosLevel = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.startStressTest = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.progressStatus = new MetroFramework.Controls.MetroLabel();
            this.clientSelection = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.packetInterval = new MetroFramework.Controls.MetroTextBox();
            this.packetSize = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // brokerIpAddrInput
            // 
            this.brokerIpAddrInput.Location = new System.Drawing.Point(21, 109);
            this.brokerIpAddrInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brokerIpAddrInput.Name = "brokerIpAddrInput";
            this.brokerIpAddrInput.Size = new System.Drawing.Size(217, 24);
            this.brokerIpAddrInput.TabIndex = 2;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 84);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(119, 20);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Broker IP Address";
            // 
            // brokerPortInput
            // 
            this.brokerPortInput.Location = new System.Drawing.Point(258, 109);
            this.brokerPortInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brokerPortInput.Name = "brokerPortInput";
            this.brokerPortInput.Size = new System.Drawing.Size(138, 24);
            this.brokerPortInput.TabIndex = 7;
            this.brokerPortInput.Text = "1883";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(258, 84);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 20);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Broker Port";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(8, 27);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(169, 25);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Packets Interval (ms)";
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(8, 107);
            this.duration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(361, 24);
            this.duration.TabIndex = 14;
            this.duration.Text = "15";
            this.duration.Leave += new System.EventHandler(this.duration_Leave);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(8, 85);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(80, 20);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Duration (s)";
            // 
            // qosLevel
            // 
            this.qosLevel.FormattingEnabled = true;
            this.qosLevel.ItemHeight = 24;
            this.qosLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.qosLevel.Location = new System.Drawing.Point(8, 219);
            this.qosLevel.Name = "qosLevel";
            this.qosLevel.Size = new System.Drawing.Size(359, 30);
            this.qosLevel.TabIndex = 17;
            this.qosLevel.SelectedIndexChanged += new System.EventHandler(this.qosLevel_SelectedIndexChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(8, 196);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(72, 20);
            this.metroLabel7.TabIndex = 18;
            this.metroLabel7.Text = "QoS Level";
            // 
            // startStressTest
            // 
            this.startStressTest.Location = new System.Drawing.Point(21, 481);
            this.startStressTest.Name = "startStressTest";
            this.startStressTest.Size = new System.Drawing.Size(374, 44);
            this.startStressTest.TabIndex = 19;
            this.startStressTest.Text = "START STRESS TEST";
            this.startStressTest.Click += new System.EventHandler(this.startStressTest_Click);
            // 
            // progressBar
            // 
            this.progressBar.HideProgressText = false;
            this.progressBar.Location = new System.Drawing.Point(21, 538);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(374, 23);
            this.progressBar.TabIndex = 20;
            this.progressBar.Visible = false;
            // 
            // progressStatus
            // 
            this.progressStatus.AutoSize = true;
            this.progressStatus.FontSize = MetroFramework.MetroLabelSize.Small;
            this.progressStatus.Location = new System.Drawing.Point(21, 567);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(90, 17);
            this.progressStatus.TabIndex = 21;
            this.progressStatus.Text = "Progress Status";
            this.progressStatus.Visible = false;
            // 
            // clientSelection
            // 
            this.clientSelection.FormattingEnabled = true;
            this.clientSelection.ItemHeight = 24;
            this.clientSelection.Items.AddRange(new object[] {
            "Client 1",
            "Add new client..."});
            this.clientSelection.Location = new System.Drawing.Point(21, 152);
            this.clientSelection.Name = "clientSelection";
            this.clientSelection.Size = new System.Drawing.Size(375, 30);
            this.clientSelection.TabIndex = 22;
            this.clientSelection.SelectedIndexChanged += new System.EventHandler(this.clientSelection_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.packetSize);
            this.groupBox1.Controls.Add(this.packetInterval);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.qosLevel);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.duration);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Location = new System.Drawing.Point(21, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 264);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Configuration";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(8, 140);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(153, 25);
            this.metroLabel3.TabIndex = 25;
            this.metroLabel3.Text = "Packet size (bytes)";
            // 
            // packetInterval
            // 
            this.packetInterval.Location = new System.Drawing.Point(8, 51);
            this.packetInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetInterval.Name = "packetInterval";
            this.packetInterval.Size = new System.Drawing.Size(361, 24);
            this.packetInterval.TabIndex = 26;
            this.packetInterval.Text = "15";
            this.packetInterval.Leave += new System.EventHandler(this.packetInterval_Leave);
            // 
            // packetSize
            // 
            this.packetSize.Location = new System.Drawing.Point(8, 164);
            this.packetSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetSize.Name = "packetSize";
            this.packetSize.Size = new System.Drawing.Size(361, 24);
            this.packetSize.TabIndex = 27;
            this.packetSize.Text = "50";
            this.packetSize.Leave += new System.EventHandler(this.packetSize_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clientSelection);
            this.Controls.Add(this.progressStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startStressTest);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.brokerPortInput);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.brokerIpAddrInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(18, 60, 18, 16);
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "MQTT Stress Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox brokerIpAddrInput;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox brokerPortInput;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox duration;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox qosLevel;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton startStressTest;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel progressStatus;
        private MetroFramework.Controls.MetroComboBox clientSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox packetSize;
        private MetroFramework.Controls.MetroTextBox packetInterval;
    }
}

