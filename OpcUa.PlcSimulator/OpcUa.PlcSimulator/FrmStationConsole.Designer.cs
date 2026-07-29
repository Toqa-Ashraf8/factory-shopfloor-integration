namespace OpcUa.PlcSimulator
{
    partial class FrmStationConsole
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtRfidInput = new System.Windows.Forms.TextBox();
            this.btnSimulateScan = new System.Windows.Forms.Button();
            this.lblScanPrompt = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblShift = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.lblRfidStatus = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.iconPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.pnlLogin.Controls.Add(this.lblRfidStatus);
            this.pnlLogin.Controls.Add(this.iconPanel);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.progressBar1);
            this.pnlLogin.Controls.Add(this.txtRfidInput);
            this.pnlLogin.Controls.Add(this.btnSimulateScan);
            this.pnlLogin.Controls.Add(this.lblScanPrompt);
            this.pnlLogin.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogin.Location = new System.Drawing.Point(5, 100);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(1186, 821);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogin_Paint);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(281, 726);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(634, 22);
            this.progressBar1.TabIndex = 20;
            // 
            // txtRfidInput
            // 
            this.txtRfidInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRfidInput.Location = new System.Drawing.Point(347, 576);
            this.txtRfidInput.Name = "txtRfidInput";
            this.txtRfidInput.Size = new System.Drawing.Size(488, 34);
            this.txtRfidInput.TabIndex = 15;
            this.txtRfidInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRfidInput_KeyDown);
            // 
            // btnSimulateScan
            // 
            this.btnSimulateScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnSimulateScan.FlatAppearance.BorderSize = 0;
            this.btnSimulateScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulateScan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimulateScan.ForeColor = System.Drawing.Color.White;
            this.btnSimulateScan.Location = new System.Drawing.Point(347, 640);
            this.btnSimulateScan.Name = "btnSimulateScan";
            this.btnSimulateScan.Size = new System.Drawing.Size(488, 40);
            this.btnSimulateScan.TabIndex = 16;
            this.btnSimulateScan.Text = "Simulate RFID Scan";
            this.btnSimulateScan.UseVisualStyleBackColor = false;
            this.btnSimulateScan.Click += new System.EventHandler(this.btnSimulateScan_Click);
            // 
            // lblScanPrompt
            // 
            this.lblScanPrompt.AutoSize = true;
            this.lblScanPrompt.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.lblScanPrompt.Location = new System.Drawing.Point(387, 509);
            this.lblScanPrompt.Name = "lblScanPrompt";
            this.lblScanPrompt.Size = new System.Drawing.Size(404, 31);
            this.lblScanPrompt.TabIndex = 0;
            this.lblScanPrompt.Text = "Please tap your RFID card to continue";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.lblShift);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblDateTitle);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblSystemStatus);
            this.pnlHeader.Controls.Add(this.lblSystemTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1194, 106);
            this.pnlHeader.TabIndex = 23;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblShift.Location = new System.Drawing.Point(683, 38);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(63, 28);
            this.lblShift.TabIndex = 23;
            this.lblShift.Text = "Night";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Location = new System.Drawing.Point(684, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Shift";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 28);
            this.label3.TabIndex = 21;
            this.label3.Text = "Line-01 - Main Assembly";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nexera Factory";
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDateTitle.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblDateTitle.Location = new System.Drawing.Point(826, 15);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(51, 23);
            this.lblDateTitle.TabIndex = 10;
            this.lblDateTitle.Text = "Date:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblDate.Location = new System.Drawing.Point(825, 38);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 28);
            this.lblDate.TabIndex = 11;
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.ForeColor = System.Drawing.Color.Lime;
            this.lblSystemStatus.Location = new System.Drawing.Point(1037, 41);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(0, 25);
            this.lblSystemStatus.TabIndex = 9;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTitle.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSystemTitle.Location = new System.Drawing.Point(1037, 15);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(69, 23);
            this.lblSystemTitle.TabIndex = 8;
            this.lblSystemTitle.Text = "System:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(277, 751);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "RFID reader";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpcUa.PlcSimulator.Properties.Resources.signal;
            this.pictureBox1.Location = new System.Drawing.Point(77, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // iconPanel
            // 
            this.iconPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(65)))));
            this.iconPanel.Controls.Add(this.pictureBox1);
            this.iconPanel.Location = new System.Drawing.Point(334, 75);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(486, 370);
            this.iconPanel.TabIndex = 22;
            this.iconPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.iconPanel.Resize += new System.EventHandler(this.iconPanel_Resize);
            // 
            // lblRfidStatus
            // 
            this.lblRfidStatus.AutoSize = true;
            this.lblRfidStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRfidStatus.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblRfidStatus.Location = new System.Drawing.Point(849, 751);
            this.lblRfidStatus.Name = "lblRfidStatus";
            this.lblRfidStatus.Size = new System.Drawing.Size(66, 20);
            this.lblRfidStatus.TabIndex = 23;
            this.lblRfidStatus.Text = "Standby";
            this.lblRfidStatus.Visible = false;
            // 
            // FrmStationConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1194, 933);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStationConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES Operator Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStationConsole_Load);
            this.Resize += new System.EventHandler(this.FrmStationConsole_Resize);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.iconPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblScanPrompt;
        private System.Windows.Forms.TextBox txtRfidInput;
        private System.Windows.Forms.Button btnSimulateScan;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel iconPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRfidStatus;
    }
}