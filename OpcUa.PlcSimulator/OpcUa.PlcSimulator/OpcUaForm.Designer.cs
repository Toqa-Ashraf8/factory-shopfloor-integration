namespace OpcUa.PlcSimulator
{
    partial class OpcUaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.opcTimer = new System.Windows.Forms.Timer(this.components);
            this.lblWorkOrderID = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblTargetQuantity = new System.Windows.Forms.Label();
            this.grpWorkOrderDetails = new System.Windows.Forms.GroupBox();
            this.btnStartProduction = new System.Windows.Forms.Button();
            this.grpMachineTelemetry = new System.Windows.Forms.GroupBox();
            this.txtNumTargetTemperature = new System.Windows.Forms.TextBox();
            this.btnWriteSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOvenTemperature = new System.Windows.Forms.Label();
            this.lblCurrentCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.grpWorkOrder = new System.Windows.Forms.GroupBox();
            this.txtTargetQty = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtWorkOrderCode = new System.Windows.Forms.TextBox();
            this.lblTargetQtyHeader = new System.Windows.Forms.Label();
            this.lblProductHeader = new System.Windows.Forms.Label();
            this.lblWorkOrderHeader = new System.Windows.Forms.Label();
            this.grpTelemetry = new System.Windows.Forms.GroupBox();
            this.btnWriteSettingss = new System.Windows.Forms.Button();
            this.numTargetTemp = new System.Windows.Forms.NumericUpDown();
            this.lblOvenTempValue = new System.Windows.Forms.Label();
            this.lblCurrentCountHeader = new System.Windows.Forms.Label();
            this.lblSetTempHeader = new System.Windows.Forms.Label();
            this.lblOvenTempHeader = new System.Windows.Forms.Label();
            this.lblCurrentCountValue = new System.Windows.Forms.Label();
            this.grpSystemStatus = new System.Windows.Forms.GroupBox();
            this.lblMachineStatusText = new System.Windows.Forms.Label();
            this.lblOpcStatusText = new System.Windows.Forms.Label();
            this.rtbConsoleLog = new System.Windows.Forms.RichTextBox();
            this.dgvWorkOrders = new System.Windows.Forms.DataGridView();
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.MachineStatusLED = new OpcUa.PlcSimulator.IndustrialLed();
            this.OpcStatusLED = new OpcUa.PlcSimulator.IndustrialLed();
            this.btnStartPro = new System.Windows.Forms.Button();
            this.btnStopProduction = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpWorkOrderDetails.SuspendLayout();
            this.grpMachineTelemetry.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpWorkOrder.SuspendLayout();
            this.grpTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetTemp)).BeginInit();
            this.grpSystemStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opcTimer
            // 
            this.opcTimer.Interval = 1000;
            // 
            // lblWorkOrderID
            // 
            this.lblWorkOrderID.AutoSize = true;
            this.lblWorkOrderID.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkOrderID.Location = new System.Drawing.Point(179, 47);
            this.lblWorkOrderID.Name = "lblWorkOrderID";
            this.lblWorkOrderID.Size = new System.Drawing.Size(136, 25);
            this.lblWorkOrderID.TabIndex = 0;
            this.lblWorkOrderID.Text = "Work Order ID";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(181, 99);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 25);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name";
            // 
            // lblTargetQuantity
            // 
            this.lblTargetQuantity.AutoSize = true;
            this.lblTargetQuantity.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetQuantity.Location = new System.Drawing.Point(179, 154);
            this.lblTargetQuantity.Name = "lblTargetQuantity";
            this.lblTargetQuantity.Size = new System.Drawing.Size(146, 25);
            this.lblTargetQuantity.TabIndex = 2;
            this.lblTargetQuantity.Text = "Target Quantity";
            // 
            // grpWorkOrderDetails
            // 
            this.grpWorkOrderDetails.Controls.Add(this.btnStartProduction);
            this.grpWorkOrderDetails.Controls.Add(this.lblTargetQuantity);
            this.grpWorkOrderDetails.Controls.Add(this.lblProductName);
            this.grpWorkOrderDetails.Controls.Add(this.lblWorkOrderID);
            this.grpWorkOrderDetails.Location = new System.Drawing.Point(95, 47);
            this.grpWorkOrderDetails.Name = "grpWorkOrderDetails";
            this.grpWorkOrderDetails.Size = new System.Drawing.Size(523, 409);
            this.grpWorkOrderDetails.TabIndex = 3;
            this.grpWorkOrderDetails.TabStop = false;
            this.grpWorkOrderDetails.Text = "Work Order Information";
            // 
            // btnStartProduction
            // 
            this.btnStartProduction.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStartProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartProduction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartProduction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartProduction.Location = new System.Drawing.Point(99, 268);
            this.btnStartProduction.Name = "btnStartProduction";
            this.btnStartProduction.Size = new System.Drawing.Size(307, 69);
            this.btnStartProduction.TabIndex = 3;
            this.btnStartProduction.Text = "Start Production";
            this.btnStartProduction.UseVisualStyleBackColor = false;
            // 
            // grpMachineTelemetry
            // 
            this.grpMachineTelemetry.Controls.Add(this.txtNumTargetTemperature);
            this.grpMachineTelemetry.Controls.Add(this.btnWriteSettings);
            this.grpMachineTelemetry.Controls.Add(this.label1);
            this.grpMachineTelemetry.Controls.Add(this.lblOvenTemperature);
            this.grpMachineTelemetry.Controls.Add(this.lblCurrentCount);
            this.grpMachineTelemetry.Location = new System.Drawing.Point(652, 47);
            this.grpMachineTelemetry.Name = "grpMachineTelemetry";
            this.grpMachineTelemetry.Size = new System.Drawing.Size(523, 409);
            this.grpMachineTelemetry.TabIndex = 4;
            this.grpMachineTelemetry.TabStop = false;
            this.grpMachineTelemetry.Text = "Live Machine Telemetry";
            // 
            // txtNumTargetTemperature
            // 
            this.txtNumTargetTemperature.Location = new System.Drawing.Point(218, 189);
            this.txtNumTargetTemperature.Name = "txtNumTargetTemperature";
            this.txtNumTargetTemperature.Size = new System.Drawing.Size(247, 22);
            this.txtNumTargetTemperature.TabIndex = 4;
            // 
            // btnWriteSettings
            // 
            this.btnWriteSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnWriteSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriteSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWriteSettings.Location = new System.Drawing.Point(102, 293);
            this.btnWriteSettings.Name = "btnWriteSettings";
            this.btnWriteSettings.Size = new System.Drawing.Size(307, 69);
            this.btnWriteSettings.TabIndex = 3;
            this.btnWriteSettings.Text = "Update Settings";
            this.btnWriteSettings.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Target Temperature";
            // 
            // lblOvenTemperature
            // 
            this.lblOvenTemperature.AutoSize = true;
            this.lblOvenTemperature.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOvenTemperature.Location = new System.Drawing.Point(152, 99);
            this.lblOvenTemperature.Name = "lblOvenTemperature";
            this.lblOvenTemperature.Size = new System.Drawing.Size(230, 25);
            this.lblOvenTemperature.TabIndex = 1;
            this.lblOvenTemperature.Text = "Actual Oven Temperature";
            // 
            // lblCurrentCount
            // 
            this.lblCurrentCount.AutoSize = true;
            this.lblCurrentCount.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCount.Location = new System.Drawing.Point(150, 47);
            this.lblCurrentCount.Name = "lblCurrentCount";
            this.lblCurrentCount.Size = new System.Drawing.Size(231, 25);
            this.lblCurrentCount.TabIndex = 0;
            this.lblCurrentCount.Text = "Current Production Count";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblConnectionStatus);
            this.panel1.Location = new System.Drawing.Point(295, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 149);
            this.panel1.TabIndex = 5;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(309, 58);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(44, 16);
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Text = "label2";
            // 
            // grpWorkOrder
            // 
            this.grpWorkOrder.Controls.Add(this.txtTargetQty);
            this.grpWorkOrder.Controls.Add(this.txtItemName);
            this.grpWorkOrder.Controls.Add(this.txtWorkOrderCode);
            this.grpWorkOrder.Controls.Add(this.lblTargetQtyHeader);
            this.grpWorkOrder.Controls.Add(this.lblProductHeader);
            this.grpWorkOrder.Controls.Add(this.lblWorkOrderHeader);
            this.grpWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpWorkOrder.Location = new System.Drawing.Point(12, 12);
            this.grpWorkOrder.Name = "grpWorkOrder";
            this.grpWorkOrder.Size = new System.Drawing.Size(576, 177);
            this.grpWorkOrder.TabIndex = 0;
            this.grpWorkOrder.TabStop = false;
            this.grpWorkOrder.Text = "Active Work Order Information";
            // 
            // txtTargetQty
            // 
            this.txtTargetQty.Location = new System.Drawing.Point(212, 123);
            this.txtTargetQty.Name = "txtTargetQty";
            this.txtTargetQty.Size = new System.Drawing.Size(175, 27);
            this.txtTargetQty.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(212, 81);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(244, 27);
            this.txtItemName.TabIndex = 5;
            // 
            // txtWorkOrderCode
            // 
            this.txtWorkOrderCode.Location = new System.Drawing.Point(212, 41);
            this.txtWorkOrderCode.Name = "txtWorkOrderCode";
            this.txtWorkOrderCode.Size = new System.Drawing.Size(244, 27);
            this.txtWorkOrderCode.TabIndex = 4;
            // 
            // lblTargetQtyHeader
            // 
            this.lblTargetQtyHeader.AutoSize = true;
            this.lblTargetQtyHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetQtyHeader.Location = new System.Drawing.Point(44, 121);
            this.lblTargetQtyHeader.Name = "lblTargetQtyHeader";
            this.lblTargetQtyHeader.Size = new System.Drawing.Size(131, 19);
            this.lblTargetQtyHeader.TabIndex = 3;
            this.lblTargetQtyHeader.Text = "Target Quantity:";
            // 
            // lblProductHeader
            // 
            this.lblProductHeader.AutoSize = true;
            this.lblProductHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductHeader.Location = new System.Drawing.Point(47, 81);
            this.lblProductHeader.Name = "lblProductHeader";
            this.lblProductHeader.Size = new System.Drawing.Size(95, 19);
            this.lblProductHeader.TabIndex = 1;
            this.lblProductHeader.Text = "Item Name:";
            // 
            // lblWorkOrderHeader
            // 
            this.lblWorkOrderHeader.AutoSize = true;
            this.lblWorkOrderHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkOrderHeader.Location = new System.Drawing.Point(47, 44);
            this.lblWorkOrderHeader.Name = "lblWorkOrderHeader";
            this.lblWorkOrderHeader.Size = new System.Drawing.Size(148, 19);
            this.lblWorkOrderHeader.TabIndex = 0;
            this.lblWorkOrderHeader.Text = "Work Order Code:";
            // 
            // grpTelemetry
            // 
            this.grpTelemetry.Controls.Add(this.btnWriteSettingss);
            this.grpTelemetry.Controls.Add(this.numTargetTemp);
            this.grpTelemetry.Controls.Add(this.lblOvenTempValue);
            this.grpTelemetry.Controls.Add(this.lblCurrentCountHeader);
            this.grpTelemetry.Controls.Add(this.lblSetTempHeader);
            this.grpTelemetry.Controls.Add(this.lblOvenTempHeader);
            this.grpTelemetry.Controls.Add(this.lblCurrentCountValue);
            this.grpTelemetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTelemetry.Location = new System.Drawing.Point(10, 211);
            this.grpTelemetry.Name = "grpTelemetry";
            this.grpTelemetry.Size = new System.Drawing.Size(576, 241);
            this.grpTelemetry.TabIndex = 3;
            this.grpTelemetry.TabStop = false;
            this.grpTelemetry.Text = "Live Machine Telemetry (OPC UA Node Monitoring)";
            // 
            // btnWriteSettingss
            // 
            this.btnWriteSettingss.BackColor = System.Drawing.Color.SteelBlue;
            this.btnWriteSettingss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriteSettingss.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteSettingss.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWriteSettingss.Location = new System.Drawing.Point(403, 83);
            this.btnWriteSettingss.Name = "btnWriteSettingss";
            this.btnWriteSettingss.Size = new System.Drawing.Size(158, 68);
            this.btnWriteSettingss.TabIndex = 4;
            this.btnWriteSettingss.Text = "WRITE TO OPC NODE";
            this.btnWriteSettingss.UseVisualStyleBackColor = false;
            this.btnWriteSettingss.Click += new System.EventHandler(this.btnWriteSettingss_Click);
            // 
            // numTargetTemp
            // 
            this.numTargetTemp.Location = new System.Drawing.Point(258, 187);
            this.numTargetTemp.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numTargetTemp.Name = "numTargetTemp";
            this.numTargetTemp.Size = new System.Drawing.Size(72, 27);
            this.numTargetTemp.TabIndex = 12;
            // 
            // lblOvenTempValue
            // 
            this.lblOvenTempValue.AutoSize = true;
            this.lblOvenTempValue.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOvenTempValue.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOvenTempValue.Location = new System.Drawing.Point(252, 120);
            this.lblOvenTempValue.Name = "lblOvenTempValue";
            this.lblOvenTempValue.Size = new System.Drawing.Size(91, 35);
            this.lblOvenTempValue.TabIndex = 11;
            this.lblOvenTempValue.Text = "0.0 °C";
            // 
            // lblCurrentCountHeader
            // 
            this.lblCurrentCountHeader.AutoSize = true;
            this.lblCurrentCountHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCountHeader.Location = new System.Drawing.Point(30, 66);
            this.lblCurrentCountHeader.Name = "lblCurrentCountHeader";
            this.lblCurrentCountHeader.Size = new System.Drawing.Size(124, 19);
            this.lblCurrentCountHeader.TabIndex = 6;
            this.lblCurrentCountHeader.Text = "Current Count:";
            // 
            // lblSetTempHeader
            // 
            this.lblSetTempHeader.AutoSize = true;
            this.lblSetTempHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetTempHeader.Location = new System.Drawing.Point(30, 195);
            this.lblSetTempHeader.Name = "lblSetTempHeader";
            this.lblSetTempHeader.Size = new System.Drawing.Size(167, 19);
            this.lblSetTempHeader.TabIndex = 9;
            this.lblSetTempHeader.Text = "Set Target Temp (°C):";
            // 
            // lblOvenTempHeader
            // 
            this.lblOvenTempHeader.AutoSize = true;
            this.lblOvenTempHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOvenTempHeader.Location = new System.Drawing.Point(30, 132);
            this.lblOvenTempHeader.Name = "lblOvenTempHeader";
            this.lblOvenTempHeader.Size = new System.Drawing.Size(148, 19);
            this.lblOvenTempHeader.TabIndex = 7;
            this.lblOvenTempHeader.Text = "Actual Oven Temp:";
            // 
            // lblCurrentCountValue
            // 
            this.lblCurrentCountValue.AutoSize = true;
            this.lblCurrentCountValue.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCountValue.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentCountValue.Location = new System.Drawing.Point(262, 52);
            this.lblCurrentCountValue.Name = "lblCurrentCountValue";
            this.lblCurrentCountValue.Size = new System.Drawing.Size(42, 37);
            this.lblCurrentCountValue.TabIndex = 8;
            this.lblCurrentCountValue.Text = "0 ";
            // 
            // grpSystemStatus
            // 
            this.grpSystemStatus.Controls.Add(this.MachineStatusLED);
            this.grpSystemStatus.Controls.Add(this.OpcStatusLED);
            this.grpSystemStatus.Controls.Add(this.lblMachineStatusText);
            this.grpSystemStatus.Controls.Add(this.lblOpcStatusText);
            this.grpSystemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSystemStatus.Location = new System.Drawing.Point(663, 12);
            this.grpSystemStatus.Name = "grpSystemStatus";
            this.grpSystemStatus.Size = new System.Drawing.Size(371, 177);
            this.grpSystemStatus.TabIndex = 4;
            this.grpSystemStatus.TabStop = false;
            this.grpSystemStatus.Text = "System Status & Diagnostics";
            // 
            // lblMachineStatusText
            // 
            this.lblMachineStatusText.AutoSize = true;
            this.lblMachineStatusText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineStatusText.Location = new System.Drawing.Point(26, 131);
            this.lblMachineStatusText.Name = "lblMachineStatusText";
            this.lblMachineStatusText.Size = new System.Drawing.Size(194, 19);
            this.lblMachineStatusText.TabIndex = 3;
            this.lblMachineStatusText.Text = "Machine Operating State";
            // 
            // lblOpcStatusText
            // 
            this.lblOpcStatusText.AutoSize = true;
            this.lblOpcStatusText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcStatusText.Location = new System.Drawing.Point(26, 49);
            this.lblOpcStatusText.Name = "lblOpcStatusText";
            this.lblOpcStatusText.Size = new System.Drawing.Size(213, 19);
            this.lblOpcStatusText.TabIndex = 1;
            this.lblOpcStatusText.Text = "OPC UA Server Connection";
            // 
            // rtbConsoleLog
            // 
            this.rtbConsoleLog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtbConsoleLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsoleLog.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsoleLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.rtbConsoleLog.Location = new System.Drawing.Point(-3, 632);
            this.rtbConsoleLog.Name = "rtbConsoleLog";
            this.rtbConsoleLog.ReadOnly = true;
            this.rtbConsoleLog.Size = new System.Drawing.Size(1102, 124);
            this.rtbConsoleLog.TabIndex = 6;
            this.rtbConsoleLog.Text = "";
            // 
            // dgvWorkOrders
            // 
            this.dgvWorkOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrders.Location = new System.Drawing.Point(-3, 458);
            this.dgvWorkOrders.Name = "dgvWorkOrders";
            this.dgvWorkOrders.RowHeadersWidth = 51;
            this.dgvWorkOrders.RowTemplate.Height = 24;
            this.dgvWorkOrders.Size = new System.Drawing.Size(1095, 168);
            this.dgvWorkOrders.TabIndex = 7;
            this.dgvWorkOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkOrders_CellClick);
            // 
            // alarmTimer
            // 
            this.alarmTimer.Interval = 1000;
            this.alarmTimer.Tick += new System.EventHandler(this.alarmTimer_Tick);
            // 
            // MachineStatusLED
            // 
            this.MachineStatusLED.IsOn = false;
            this.MachineStatusLED.LedColor = System.Drawing.Color.DarkGray;
            this.MachineStatusLED.Location = new System.Drawing.Point(272, 118);
            this.MachineStatusLED.Name = "MachineStatusLED";
            this.MachineStatusLED.Size = new System.Drawing.Size(51, 46);
            this.MachineStatusLED.TabIndex = 7;
            this.MachineStatusLED.Text = "industrialLed1";
            // 
            // OpcStatusLED
            // 
            this.OpcStatusLED.IsOn = false;
            this.OpcStatusLED.LedColor = System.Drawing.Color.DarkGray;
            this.OpcStatusLED.Location = new System.Drawing.Point(272, 44);
            this.OpcStatusLED.Name = "OpcStatusLED";
            this.OpcStatusLED.Size = new System.Drawing.Size(51, 46);
            this.OpcStatusLED.TabIndex = 7;
            this.OpcStatusLED.Text = "industrialLed1";
            // 
            // btnStartPro
            // 
            this.btnStartPro.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStartPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartPro.Location = new System.Drawing.Point(72, 29);
            this.btnStartPro.Name = "btnStartPro";
            this.btnStartPro.Size = new System.Drawing.Size(215, 36);
            this.btnStartPro.TabIndex = 0;
            this.btnStartPro.Text = "START PRODUCTION";
            this.btnStartPro.UseVisualStyleBackColor = false;
            this.btnStartPro.Click += new System.EventHandler(this.btnStartPro_Click);
            // 
            // btnStopProduction
            // 
            this.btnStopProduction.BackColor = System.Drawing.Color.Crimson;
            this.btnStopProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopProduction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStopProduction.Location = new System.Drawing.Point(72, 86);
            this.btnStopProduction.Name = "btnStopProduction";
            this.btnStopProduction.Size = new System.Drawing.Size(215, 36);
            this.btnStopProduction.TabIndex = 1;
            this.btnStopProduction.Text = "STOP / PAUSE";
            this.btnStopProduction.UseVisualStyleBackColor = false;
            this.btnStopProduction.Click += new System.EventHandler(this.btnStopProduction_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::OpcUa.PlcSimulator.Properties.Resources.icons8_mute_sound_32;
            this.button1.Location = new System.Drawing.Point(72, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 36);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartPro);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnStopProduction);
            this.groupBox1.Location = new System.Drawing.Point(655, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 202);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // OpcUaForm
            // 
            this.ClientSize = new System.Drawing.Size(1111, 768);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvWorkOrders);
            this.Controls.Add(this.rtbConsoleLog);
            this.Controls.Add(this.grpSystemStatus);
            this.Controls.Add(this.grpTelemetry);
            this.Controls.Add(this.grpWorkOrder);
            this.Name = "OpcUaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Order Execution - OPC UA Interface";
            this.Load += new System.EventHandler(this.OpcUaForm_Load);
            this.grpWorkOrderDetails.ResumeLayout(false);
            this.grpWorkOrderDetails.PerformLayout();
            this.grpMachineTelemetry.ResumeLayout(false);
            this.grpMachineTelemetry.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpWorkOrder.ResumeLayout(false);
            this.grpWorkOrder.PerformLayout();
            this.grpTelemetry.ResumeLayout(false);
            this.grpTelemetry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetTemp)).EndInit();
            this.grpSystemStatus.ResumeLayout(false);
            this.grpSystemStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer opcTimer;
        private System.Windows.Forms.Label lblWorkOrderID;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblTargetQuantity;
        private System.Windows.Forms.GroupBox grpWorkOrderDetails;
        private System.Windows.Forms.Button btnStartProduction;
        private System.Windows.Forms.GroupBox grpMachineTelemetry;
        private System.Windows.Forms.Button btnWriteSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOvenTemperature;
        private System.Windows.Forms.Label lblCurrentCount;
        private System.Windows.Forms.TextBox txtNumTargetTemperature;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.GroupBox grpWorkOrder;
        private System.Windows.Forms.Label lblTargetQtyHeader;
        private System.Windows.Forms.Label lblProductHeader;
        private System.Windows.Forms.Label lblWorkOrderHeader;
        private System.Windows.Forms.GroupBox grpTelemetry;
        private System.Windows.Forms.NumericUpDown numTargetTemp;
        private System.Windows.Forms.Label lblCurrentCountHeader;
        private System.Windows.Forms.Label lblSetTempHeader;
        private System.Windows.Forms.Label lblOvenTempHeader;
        private System.Windows.Forms.Button btnWriteSettingss;
        private System.Windows.Forms.GroupBox grpSystemStatus;
        private System.Windows.Forms.Label lblOpcStatusText;
        private System.Windows.Forms.Label lblMachineStatusText;
        private System.Windows.Forms.RichTextBox rtbConsoleLog;
        private IndustrialLed MachineStatusLED;
        private IndustrialLed OpcStatusLED;
        private System.Windows.Forms.DataGridView dgvWorkOrders;
        private System.Windows.Forms.TextBox txtTargetQty;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtWorkOrderCode;
        private System.Windows.Forms.Label lblOvenTempValue;
        private System.Windows.Forms.Label lblCurrentCountValue;
        private System.Windows.Forms.Timer alarmTimer;
        private System.Windows.Forms.Button btnStartPro;
        private System.Windows.Forms.Button btnStopProduction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

