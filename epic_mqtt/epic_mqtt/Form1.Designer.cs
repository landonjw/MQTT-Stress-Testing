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
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.numClientsInput = new MetroFramework.Controls.MetroTextBox();
            this.packetsPerSecondInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.durationInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.QOSLevelInput = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.startStressTest = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.progressStatus = new MetroFramework.Controls.MetroLabel();
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
            this.brokerPortInput.Size = new System.Drawing.Size(130, 24);
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
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(21, 146);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(122, 20);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Number of Clients";
            // 
            // numClientsInput
            // 
            this.numClientsInput.Location = new System.Drawing.Point(21, 171);
            this.numClientsInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numClientsInput.Name = "numClientsInput";
            this.numClientsInput.Size = new System.Drawing.Size(367, 24);
            this.numClientsInput.TabIndex = 11;
            this.numClientsInput.Text = "3";
            // 
            // packetsPerSecondInput
            // 
            this.packetsPerSecondInput.Location = new System.Drawing.Point(21, 235);
            this.packetsPerSecondInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetsPerSecondInput.Name = "packetsPerSecondInput";
            this.packetsPerSecondInput.Size = new System.Drawing.Size(156, 24);
            this.packetsPerSecondInput.TabIndex = 12;
            this.packetsPerSecondInput.Text = "10";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(21, 211);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(129, 20);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Packets Per Second";
            // 
            // durationInput
            // 
            this.durationInput.Location = new System.Drawing.Point(194, 235);
            this.durationInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.durationInput.Name = "durationInput";
            this.durationInput.Size = new System.Drawing.Size(194, 24);
            this.durationInput.TabIndex = 14;
            this.durationInput.Text = "15";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(194, 211);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(80, 20);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Duration (s)";
            // 
            // QOSLevelInput
            // 
            this.QOSLevelInput.FormattingEnabled = true;
            this.QOSLevelInput.ItemHeight = 24;
            this.QOSLevelInput.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.QOSLevelInput.Location = new System.Drawing.Point(21, 295);
            this.QOSLevelInput.Name = "QOSLevelInput";
            this.QOSLevelInput.Size = new System.Drawing.Size(374, 30);
            this.QOSLevelInput.TabIndex = 17;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(21, 269);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(72, 20);
            this.metroLabel7.TabIndex = 18;
            this.metroLabel7.Text = "QoS Level";
            // 
            // startStressTest
            // 
            this.startStressTest.Location = new System.Drawing.Point(21, 340);
            this.startStressTest.Name = "startStressTest";
            this.startStressTest.Size = new System.Drawing.Size(374, 44);
            this.startStressTest.TabIndex = 19;
            this.startStressTest.Text = "START STRESS TEST";
            this.startStressTest.Click += new System.EventHandler(this.startStressTest_Click);
            // 
            // progressBar
            // 
            this.progressBar.HideProgressText = false;
            this.progressBar.Location = new System.Drawing.Point(21, 397);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(374, 23);
            this.progressBar.TabIndex = 20;
            this.progressBar.Visible = false;
            // 
            // progressStatus
            // 
            this.progressStatus.AutoSize = true;
            this.progressStatus.FontSize = MetroFramework.MetroLabelSize.Small;
            this.progressStatus.Location = new System.Drawing.Point(21, 423);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(129, 25);
            this.progressStatus.TabIndex = 21;
            this.progressStatus.Text = "Progress Status";
            this.progressStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 451);
            this.Controls.Add(this.progressStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startStressTest);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.QOSLevelInput);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.durationInput);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.packetsPerSecondInput);
            this.Controls.Add(this.numClientsInput);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.brokerPortInput);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.brokerIpAddrInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(18, 60, 18, 16);
            this.Text = "MQTT Stress Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox brokerIpAddrInput;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox brokerPortInput;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox numClientsInput;
        private MetroFramework.Controls.MetroTextBox packetsPerSecondInput;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox durationInput;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox QOSLevelInput;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton startStressTest;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel progressStatus;
    }
}

