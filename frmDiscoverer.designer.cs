namespace uKNX_Configurator
{
    partial class frmDiscoverer
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMACAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFirmware = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDemopadCommands = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWriteRcv = new System.Windows.Forms.Button();
            this.pbValue = new System.Windows.Forms.PictureBox();
            this.pbKknxGroupAddress = new System.Windows.Forms.PictureBox();
            this.tbKnxTraffic = new System.Windows.Forms.TextBox();
            this.btnTry = new System.Windows.Forms.Button();
            this.tbDemopadCommand = new System.Windows.Forms.TextBox();
            this.btnBuildFeedback = new System.Windows.Forms.Button();
            this.btnBuildRead = new System.Windows.Forms.Button();
            this.btnBuildWrite = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.cbValueType = new System.Windows.Forms.ComboBox();
            this.lblValueType = new System.Windows.Forms.Label();
            this.tbKnxGroupAddress = new System.Windows.Forms.TextBox();
            this.lblKnxGroupAddress = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblFoundDevices = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timerCyclic = new System.Windows.Forms.Timer(this.components);
            this.panelDemopadCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKknxGroupAddress)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIPAddress,
            this.columnMACAddress,
            this.columnModel,
            this.columnFirmware});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(792, 281);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnIPAddress
            // 
            this.columnIPAddress.Text = "IP Adres";
            this.columnIPAddress.Width = 198;
            // 
            // columnMACAddress
            // 
            this.columnMACAddress.Text = "MAC Adres";
            this.columnMACAddress.Width = 207;
            // 
            // columnModel
            // 
            this.columnModel.Text = "Model";
            this.columnModel.Width = 233;
            // 
            // columnFirmware
            // 
            this.columnFirmware.Text = "Firmware";
            this.columnFirmware.Width = 137;
            // 
            // panelDemopadCommands
            // 
            this.panelDemopadCommands.Controls.Add(this.button1);
            this.panelDemopadCommands.Controls.Add(this.btnWriteRcv);
            this.panelDemopadCommands.Controls.Add(this.pbValue);
            this.panelDemopadCommands.Controls.Add(this.pbKknxGroupAddress);
            this.panelDemopadCommands.Controls.Add(this.tbKnxTraffic);
            this.panelDemopadCommands.Controls.Add(this.btnTry);
            this.panelDemopadCommands.Controls.Add(this.tbDemopadCommand);
            this.panelDemopadCommands.Controls.Add(this.btnBuildFeedback);
            this.panelDemopadCommands.Controls.Add(this.btnBuildRead);
            this.panelDemopadCommands.Controls.Add(this.btnBuildWrite);
            this.panelDemopadCommands.Controls.Add(this.tbValue);
            this.panelDemopadCommands.Controls.Add(this.lblValue);
            this.panelDemopadCommands.Controls.Add(this.cbValueType);
            this.panelDemopadCommands.Controls.Add(this.lblValueType);
            this.panelDemopadCommands.Controls.Add(this.tbKnxGroupAddress);
            this.panelDemopadCommands.Controls.Add(this.lblKnxGroupAddress);
            this.panelDemopadCommands.Location = new System.Drawing.Point(0, 0);
            this.panelDemopadCommands.Name = "panelDemopadCommands";
            this.panelDemopadCommands.Size = new System.Drawing.Size(792, 402);
            this.panelDemopadCommands.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnCyclicTest_Click);
            // 
            // btnWriteRcv
            // 
            this.btnWriteRcv.Location = new System.Drawing.Point(558, 149);
            this.btnWriteRcv.Name = "btnWriteRcv";
            this.btnWriteRcv.Size = new System.Drawing.Size(201, 53);
            this.btnWriteRcv.TabIndex = 12;
            this.btnWriteRcv.Text = "Build WRITE RCV";
            this.btnWriteRcv.UseVisualStyleBackColor = true;
            this.btnWriteRcv.Click += new System.EventHandler(this.btnWriteRcv_Click);
            // 
            // pbValue
            // 
            this.pbValue.Image = global::uKNX_Configurator.Properties.Resources.blue_help_button_icon_65910;
            this.pbValue.Location = new System.Drawing.Point(416, 102);
            this.pbValue.Name = "pbValue";
            this.pbValue.Size = new System.Drawing.Size(30, 30);
            this.pbValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbValue.TabIndex = 11;
            this.pbValue.TabStop = false;
            this.pbValue.Click += new System.EventHandler(this.pbValue_Click);
            // 
            // pbKknxGroupAddress
            // 
            this.pbKknxGroupAddress.Image = global::uKNX_Configurator.Properties.Resources.blue_help_button_icon_65910;
            this.pbKknxGroupAddress.Location = new System.Drawing.Point(416, 20);
            this.pbKknxGroupAddress.Name = "pbKknxGroupAddress";
            this.pbKknxGroupAddress.Size = new System.Drawing.Size(30, 30);
            this.pbKknxGroupAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbKknxGroupAddress.TabIndex = 10;
            this.pbKknxGroupAddress.TabStop = false;
            this.pbKknxGroupAddress.Click += new System.EventHandler(this.pbKknxGroupAddress_Click);
            // 
            // tbKnxTraffic
            // 
            this.tbKnxTraffic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbKnxTraffic.Location = new System.Drawing.Point(30, 273);
            this.tbKnxTraffic.Multiline = true;
            this.tbKnxTraffic.Name = "tbKnxTraffic";
            this.tbKnxTraffic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKnxTraffic.Size = new System.Drawing.Size(729, 110);
            this.tbKnxTraffic.TabIndex = 9;
            // 
            // btnTry
            // 
            this.btnTry.Location = new System.Drawing.Point(669, 211);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(90, 51);
            this.btnTry.TabIndex = 8;
            this.btnTry.Text = "Try";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // tbDemopadCommand
            // 
            this.tbDemopadCommand.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDemopadCommand.ForeColor = System.Drawing.Color.Red;
            this.tbDemopadCommand.Location = new System.Drawing.Point(30, 219);
            this.tbDemopadCommand.Name = "tbDemopadCommand";
            this.tbDemopadCommand.Size = new System.Drawing.Size(618, 38);
            this.tbDemopadCommand.TabIndex = 7;
            this.tbDemopadCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDemopadCommand_KeyDown);
            // 
            // btnBuildFeedback
            // 
            this.btnBuildFeedback.Location = new System.Drawing.Point(326, 149);
            this.btnBuildFeedback.Name = "btnBuildFeedback";
            this.btnBuildFeedback.Size = new System.Drawing.Size(226, 53);
            this.btnBuildFeedback.TabIndex = 6;
            this.btnBuildFeedback.Text = "Build RESPONSE RCV";
            this.btnBuildFeedback.UseVisualStyleBackColor = true;
            this.btnBuildFeedback.Click += new System.EventHandler(this.btnBuildFeedback_Click);
            // 
            // btnBuildRead
            // 
            this.btnBuildRead.Location = new System.Drawing.Point(179, 149);
            this.btnBuildRead.Name = "btnBuildRead";
            this.btnBuildRead.Size = new System.Drawing.Size(141, 53);
            this.btnBuildRead.TabIndex = 5;
            this.btnBuildRead.Text = "Build READ";
            this.btnBuildRead.UseVisualStyleBackColor = true;
            this.btnBuildRead.Click += new System.EventHandler(this.btnBuildRead_Click);
            // 
            // btnBuildWrite
            // 
            this.btnBuildWrite.Location = new System.Drawing.Point(30, 149);
            this.btnBuildWrite.Name = "btnBuildWrite";
            this.btnBuildWrite.Size = new System.Drawing.Size(143, 53);
            this.btnBuildWrite.TabIndex = 4;
            this.btnBuildWrite.Text = "Build WRITE";
            this.btnBuildWrite.UseVisualStyleBackColor = true;
            this.btnBuildWrite.Click += new System.EventHandler(this.btnBuildWrite_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(247, 102);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(147, 34);
            this.tbValue.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(25, 105);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(63, 28);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value:";
            // 
            // cbValueType
            // 
            this.cbValueType.FormattingEnabled = true;
            this.cbValueType.Items.AddRange(new object[] {
            "1-6 Bit",
            "1 Byte",
            "2 Byte"});
            this.cbValueType.Location = new System.Drawing.Point(247, 60);
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.Size = new System.Drawing.Size(147, 36);
            this.cbValueType.TabIndex = 2;
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Location = new System.Drawing.Point(25, 63);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(109, 28);
            this.lblValueType.TabIndex = 2;
            this.lblValueType.Text = "Value Type:";
            // 
            // tbKnxGroupAddress
            // 
            this.tbKnxGroupAddress.Location = new System.Drawing.Point(247, 20);
            this.tbKnxGroupAddress.Name = "tbKnxGroupAddress";
            this.tbKnxGroupAddress.Size = new System.Drawing.Size(147, 34);
            this.tbKnxGroupAddress.TabIndex = 1;
            this.tbKnxGroupAddress.Validating += new System.ComponentModel.CancelEventHandler(this.tbKnxGroupAddress_Validating);
            // 
            // lblKnxGroupAddress
            // 
            this.lblKnxGroupAddress.AutoSize = true;
            this.lblKnxGroupAddress.Location = new System.Drawing.Point(25, 23);
            this.lblKnxGroupAddress.Name = "lblKnxGroupAddress";
            this.lblKnxGroupAddress.Size = new System.Drawing.Size(191, 28);
            this.lblKnxGroupAddress.TabIndex = 0;
            this.lblKnxGroupAddress.Text = "KNX Group Address:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 443);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.lblFoundDevices);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Device Discoverer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(613, 331);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(157, 57);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Update Selected Device Firmware";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblFoundDevices
            // 
            this.lblFoundDevices.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFoundDevices.Location = new System.Drawing.Point(6, 360);
            this.lblFoundDevices.Name = "lblFoundDevices";
            this.lblFoundDevices.Size = new System.Drawing.Size(780, 28);
            this.lblFoundDevices.TabIndex = 2;
            this.lblFoundDevices.Text = "No device found!";
            this.lblFoundDevices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelDemopadCommands);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Demopad Command Builder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timerCyclic
            // 
            this.timerCyclic.Tick += new System.EventHandler(this.timerCyclic_Tick);
            // 
            // frmDiscoverer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(823, 468);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmDiscoverer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uKNX Configurator";
            this.Load += new System.EventHandler(this.frmDiscoverer_Load);
            this.panelDemopadCommands.ResumeLayout(false);
            this.panelDemopadCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKknxGroupAddress)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnIPAddress;
        private System.Windows.Forms.ColumnHeader columnMACAddress;
        private System.Windows.Forms.ColumnHeader columnModel;
        private System.Windows.Forms.ColumnHeader columnFirmware;
        private System.Windows.Forms.Panel panelDemopadCommands;
        private System.Windows.Forms.Button btnTry;
        private System.Windows.Forms.TextBox tbDemopadCommand;
        private System.Windows.Forms.Button btnBuildFeedback;
        private System.Windows.Forms.Button btnBuildRead;
        private System.Windows.Forms.Button btnBuildWrite;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ComboBox cbValueType;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.TextBox tbKnxGroupAddress;
        private System.Windows.Forms.Label lblKnxGroupAddress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbKnxTraffic;
        private System.Windows.Forms.PictureBox pbKknxGroupAddress;
        private System.Windows.Forms.PictureBox pbValue;
        private System.Windows.Forms.Button btnWriteRcv;
        private System.Windows.Forms.Label lblFoundDevices;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timerCyclic;
        private System.Windows.Forms.Button button1;
    }
}

