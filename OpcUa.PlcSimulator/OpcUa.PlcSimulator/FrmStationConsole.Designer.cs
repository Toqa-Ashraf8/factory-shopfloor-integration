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
            this.btnSimulateScan = new System.Windows.Forms.Button();
            this.txtRfidInput = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScanPrompt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblShiltTitle = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblOpcTitle = new System.Windows.Forms.Label();
            this.lblToastMessage = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlLogin.Controls.Add(this.lblToastMessage);
            this.pnlLogin.Controls.Add(this.txtRfidInput);
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.btnSimulateScan);
            this.pnlLogin.Controls.Add(this.lblOpcTitle);
            this.pnlLogin.Controls.Add(this.lblDate);
            this.pnlLogin.Controls.Add(this.lblDateTitle);
            this.pnlLogin.Controls.Add(this.lblSystemStatus);
            this.pnlLogin.Controls.Add(this.lblSystemTitle);
            this.pnlLogin.Controls.Add(this.lblShift);
            this.pnlLogin.Controls.Add(this.lblShiltTitle);
            this.pnlLogin.Controls.Add(this.progressBar1);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.lblScanPrompt);
            this.pnlLogin.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(1051, 727);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogin_Paint);
            // 
            // btnSimulateScan
            // 
            this.btnSimulateScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSimulateScan.FlatAppearance.BorderSize = 0;
            this.btnSimulateScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulateScan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimulateScan.ForeColor = System.Drawing.Color.White;
            this.btnSimulateScan.Location = new System.Drawing.Point(409, 484);
            this.btnSimulateScan.Name = "btnSimulateScan";
            this.btnSimulateScan.Size = new System.Drawing.Size(241, 40);
            this.btnSimulateScan.TabIndex = 16;
            this.btnSimulateScan.Text = "Simulate RFID Scan";
            this.btnSimulateScan.UseVisualStyleBackColor = false;
            this.btnSimulateScan.Click += new System.EventHandler(this.btnSimulateScan_Click);
            // 
            // txtRfidInput
            // 
            this.txtRfidInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRfidInput.Location = new System.Drawing.Point(308, 433);
            this.txtRfidInput.Name = "txtRfidInput";
            this.txtRfidInput.Size = new System.Drawing.Size(421, 34);
            this.txtRfidInput.TabIndex = 15;
            this.txtRfidInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRfidInput_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(165, 551);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(721, 32);
            this.progressBar1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label2.Location = new System.Drawing.Point(313, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please tap your RFID card to continue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(245, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "NEXARA INDUSTRIES | Plant 01 – Cairo Assembly";
            // 
            // lblScanPrompt
            // 
            this.lblScanPrompt.AutoSize = true;
            this.lblScanPrompt.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblScanPrompt.Location = new System.Drawing.Point(294, 341);
            this.lblScanPrompt.Name = "lblScanPrompt";
            this.lblScanPrompt.Size = new System.Drawing.Size(462, 31);
            this.lblScanPrompt.TabIndex = 0;
            this.lblScanPrompt.Text = " AWAITING OPERATOR IDENTIFICATION    ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpcUa.PlcSimulator.Properties.Resources.rfid__3_;
            this.pictureBox1.Location = new System.Drawing.Point(354, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 269);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblShiltTitle
            // 
            this.lblShiltTitle.AutoSize = true;
            this.lblShiltTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiltTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblShiltTitle.Location = new System.Drawing.Point(275, 613);
            this.lblShiltTitle.Name = "lblShiltTitle";
            this.lblShiltTitle.Size = new System.Drawing.Size(52, 25);
            this.lblShiltTitle.TabIndex = 6;
            this.lblShiltTitle.Text = "Shift:";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblShift.Location = new System.Drawing.Point(333, 613);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(0, 25);
            this.lblShift.TabIndex = 7;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblSystemTitle.Location = new System.Drawing.Point(258, 672);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(73, 25);
            this.lblSystemTitle.TabIndex = 8;
            this.lblSystemTitle.Text = "System:";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblSystemStatus.Location = new System.Drawing.Point(347, 672);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(0, 25);
            this.lblSystemStatus.TabIndex = 9;
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblDateTitle.Location = new System.Drawing.Point(648, 614);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(54, 25);
            this.lblDateTitle.TabIndex = 10;
            this.lblDateTitle.Text = "Date:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblDate.Location = new System.Drawing.Point(718, 614);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 25);
            this.lblDate.TabIndex = 11;
            // 
            // lblOpcTitle
            // 
            this.lblOpcTitle.AutoSize = true;
            this.lblOpcTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblOpcTitle.Location = new System.Drawing.Point(648, 672);
            this.lblOpcTitle.Name = "lblOpcTitle";
            this.lblOpcTitle.Size = new System.Drawing.Size(115, 25);
            this.lblOpcTitle.TabIndex = 12;
            this.lblOpcTitle.Text = "RFID Reader:";
            // 
            // lblToastMessage
            // 
            this.lblToastMessage.AutoSize = true;
            this.lblToastMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblToastMessage.Location = new System.Drawing.Point(750, 433);
            this.lblToastMessage.Name = "lblToastMessage";
            this.lblToastMessage.Size = new System.Drawing.Size(61, 38);
            this.lblToastMessage.TabIndex = 19;
            this.lblToastMessage.Text = "تتت";
            // 
            // FrmStationConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1051, 727);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStationConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES Operator Station - Line 01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStationConsole_Load);
            this.Resize += new System.EventHandler(this.FrmStationConsole_Resize);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblScanPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRfidInput;
        private System.Windows.Forms.Button btnSimulateScan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblOpcTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblShiltTitle;
        private System.Windows.Forms.Label lblToastMessage;
    }
}