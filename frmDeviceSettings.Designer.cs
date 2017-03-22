namespace uKNX_Configurator
{
    partial class frmDeviceSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.cbDhcpEnabled = new System.Windows.Forms.CheckBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbGatewayAddress = new System.Windows.Forms.TextBox();
            this.tbSubnetMask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbBroadcastKnxTraffic = new System.Windows.Forms.CheckBox();
            this.cbLocalServerEnabled = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbDns2 = new System.Windows.Forms.TextBox();
            this.tbDns1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(230, 92);
            this.tbIpAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(201, 29);
            this.tbIpAddress.TabIndex = 2;
            this.tbIpAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIpAddress_KeyDown);
            // 
            // cbDhcpEnabled
            // 
            this.cbDhcpEnabled.AutoSize = true;
            this.cbDhcpEnabled.Location = new System.Drawing.Point(29, 49);
            this.cbDhcpEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDhcpEnabled.Name = "cbDhcpEnabled";
            this.cbDhcpEnabled.Size = new System.Drawing.Size(129, 25);
            this.cbDhcpEnabled.TabIndex = 1;
            this.cbDhcpEnabled.Text = "DHCP Enabled";
            this.cbDhcpEnabled.UseVisualStyleBackColor = true;
            this.cbDhcpEnabled.CheckedChanged += new System.EventHandler(this.cbDhcpEnabled_CheckedChanged);
            this.cbDhcpEnabled.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDhcpEnabled_KeyDown);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(85, 530);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(149, 55);
            this.btnSaveSettings.TabIndex = 8;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDns2);
            this.groupBox1.Controls.Add(this.tbDns1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbGatewayAddress);
            this.groupBox1.Controls.Add(this.tbSubnetMask);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDhcpEnabled);
            this.groupBox1.Controls.Add(this.tbIpAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 332);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ethernet Network";
            // 
            // tbGatewayAddress
            // 
            this.tbGatewayAddress.Location = new System.Drawing.Point(230, 180);
            this.tbGatewayAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGatewayAddress.Name = "tbGatewayAddress";
            this.tbGatewayAddress.Size = new System.Drawing.Size(201, 29);
            this.tbGatewayAddress.TabIndex = 4;
            this.tbGatewayAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbGatewayAddress_KeyDown);
            // 
            // tbSubnetMask
            // 
            this.tbSubnetMask.Location = new System.Drawing.Point(230, 136);
            this.tbSubnetMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSubnetMask.Name = "tbSubnetMask";
            this.tbSubnetMask.Size = new System.Drawing.Size(201, 29);
            this.tbSubnetMask.TabIndex = 3;
            this.tbSubnetMask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSubnetMask_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gateway IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subnet Mask:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbBroadcastKnxTraffic);
            this.groupBox2.Controls.Add(this.cbLocalServerEnabled);
            this.groupBox2.Location = new System.Drawing.Point(13, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 148);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local UDP Server";
            // 
            // cbBroadcastKnxTraffic
            // 
            this.cbBroadcastKnxTraffic.AutoSize = true;
            this.cbBroadcastKnxTraffic.Location = new System.Drawing.Point(29, 89);
            this.cbBroadcastKnxTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBroadcastKnxTraffic.Name = "cbBroadcastKnxTraffic";
            this.cbBroadcastKnxTraffic.Size = new System.Drawing.Size(177, 25);
            this.cbBroadcastKnxTraffic.TabIndex = 6;
            this.cbBroadcastKnxTraffic.Text = "Broadcast KNX Traffic";
            this.cbBroadcastKnxTraffic.UseVisualStyleBackColor = true;
            this.cbBroadcastKnxTraffic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBroadcastKnxTraffic_KeyDown);
            // 
            // cbLocalServerEnabled
            // 
            this.cbLocalServerEnabled.AutoSize = true;
            this.cbLocalServerEnabled.Location = new System.Drawing.Point(29, 47);
            this.cbLocalServerEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLocalServerEnabled.Name = "cbLocalServerEnabled";
            this.cbLocalServerEnabled.Size = new System.Drawing.Size(208, 25);
            this.cbLocalServerEnabled.TabIndex = 5;
            this.cbLocalServerEnabled.Text = "Local UDP Server Enabled";
            this.cbLocalServerEnabled.UseVisualStyleBackColor = true;
            this.cbLocalServerEnabled.CheckedChanged += new System.EventHandler(this.cbLocalServerEnabled_CheckedChanged);
            this.cbLocalServerEnabled.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLocalServerEnabled_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 530);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 55);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbDns2
            // 
            this.tbDns2.Location = new System.Drawing.Point(230, 268);
            this.tbDns2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDns2.Name = "tbDns2";
            this.tbDns2.Size = new System.Drawing.Size(201, 29);
            this.tbDns2.TabIndex = 8;
            // 
            // tbDns1
            // 
            this.tbDns1.Location = new System.Drawing.Point(230, 224);
            this.tbDns1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDns1.Name = "tbDns1";
            this.tbDns1.Size = new System.Drawing.Size(201, 29);
            this.tbDns1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 271);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "DNS Server #2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "DNS Server #1:";
            // 
            // frmDeviceSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(496, 609);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeviceSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Settings";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.CheckBox cbDhcpEnabled;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbGatewayAddress;
        private System.Windows.Forms.TextBox tbSubnetMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbBroadcastKnxTraffic;
        private System.Windows.Forms.CheckBox cbLocalServerEnabled;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbDns2;
        private System.Windows.Forms.TextBox tbDns1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}