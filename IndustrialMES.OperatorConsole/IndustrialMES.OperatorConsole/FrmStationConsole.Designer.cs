namespace Nexera.MES.StationConsole
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblStationTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCenterArea = new System.Windows.Forms.Panel();
            this.pnlFooterContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tblFooterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblInstructionDescription = new System.Windows.Forms.Label();
            this.pnlWoBottom = new System.Windows.Forms.Panel();
            this.txtSkuValue = new System.Windows.Forms.TextBox();
            this.txtWorkOrderValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flwpnlStepper = new System.Windows.Forms.FlowLayoutPanel();
            this.picInstruction = new System.Windows.Forms.PictureBox();
            this.flpWorkOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTest = new System.Windows.Forms.Panel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTTest = new System.Windows.Forms.Button();
            this.ledNextStatus = new IndustrialMES.OperatorConsole.IndustrialLed();
            this.ledBackStatus = new IndustrialMES.OperatorConsole.IndustrialLed();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tblMainLayout.SuspendLayout();
            this.pnlCenterArea.SuspendLayout();
            this.pnlFooterContainer.SuspendLayout();
            this.tblFooterLayout.SuspendLayout();
            this.pnlWoBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInstruction)).BeginInit();
            this.btnTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlHeader.Controls.Add(this.lblShift);
            this.pnlHeader.Controls.Add(this.lblStationTitle);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.lblSystemTitle);
            this.pnlHeader.Controls.Add(this.lblSystemStatus);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblDateTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1351, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(155)))), ((int)(((byte)(170)))));
            this.lblShift.Location = new System.Drawing.Point(698, 32);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(63, 28);
            this.lblShift.TabIndex = 30;
            this.lblShift.Text = "Night";
            // 
            // lblStationTitle
            // 
            this.lblStationTitle.AutoSize = true;
            this.lblStationTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.lblStationTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.lblStationTitle.Location = new System.Drawing.Point(28, 44);
            this.lblStationTitle.Name = "lblStationTitle";
            this.lblStationTitle.Size = new System.Drawing.Size(135, 28);
            this.lblStationTitle.TabIndex = 29;
            this.lblStationTitle.Text = "Station Name";
            this.lblStationTitle.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(699, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Shift";
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSystemTitle.Location = new System.Drawing.Point(1042, 9);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(69, 23);
            this.lblSystemTitle.TabIndex = 24;
            this.lblSystemTitle.Text = "System:";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.ForeColor = System.Drawing.Color.Lime;
            this.lblSystemStatus.Location = new System.Drawing.Point(1052, 35);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(0, 25);
            this.lblSystemStatus.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nexera Factory";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(155)))), ((int)(((byte)(170)))));
            this.lblDate.Location = new System.Drawing.Point(840, 32);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 28);
            this.lblDate.TabIndex = 27;
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDateTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDateTitle.Location = new System.Drawing.Point(841, 9);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(51, 23);
            this.lblDateTitle.TabIndex = 26;
            this.lblDateTitle.Text = "Date:";
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 3;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tblMainLayout.Controls.Add(this.pnlCenterArea, 1, 0);
            this.tblMainLayout.Controls.Add(this.flpWorkOrders, 0, 0);
            this.tblMainLayout.Controls.Add(this.btnTest, 2, 0);
            this.tblMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainLayout.Location = new System.Drawing.Point(0, 84);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 1;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Size = new System.Drawing.Size(1351, 625);
            this.tblMainLayout.TabIndex = 1;
            // 
            // pnlCenterArea
            // 
            this.pnlCenterArea.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlCenterArea.Controls.Add(this.lblInstructionDescription);
            this.pnlCenterArea.Controls.Add(this.pnlFooterContainer);
            this.pnlCenterArea.Controls.Add(this.flwpnlStepper);
            this.pnlCenterArea.Controls.Add(this.picInstruction);
            this.pnlCenterArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterArea.Location = new System.Drawing.Point(340, 3);
            this.pnlCenterArea.Name = "pnlCenterArea";
            this.pnlCenterArea.Size = new System.Drawing.Size(771, 619);
            this.pnlCenterArea.TabIndex = 2;
            // 
            // pnlFooterContainer
            // 
            this.pnlFooterContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.pnlFooterContainer.Controls.Add(this.tblFooterLayout);
            this.pnlFooterContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterContainer.Location = new System.Drawing.Point(0, 519);
            this.pnlFooterContainer.Name = "pnlFooterContainer";
            this.pnlFooterContainer.Size = new System.Drawing.Size(771, 100);
            this.pnlFooterContainer.TabIndex = 10;
            // 
            // tblFooterLayout
            // 
            this.tblFooterLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tblFooterLayout.ColumnCount = 2;
            this.tblFooterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFooterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFooterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFooterLayout.Controls.Add(this.pnlWoBottom, 0, 0);
            this.tblFooterLayout.Location = new System.Drawing.Point(3, 3);
            this.tblFooterLayout.Name = "tblFooterLayout";
            this.tblFooterLayout.RowCount = 1;
            this.tblFooterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFooterLayout.Size = new System.Drawing.Size(768, 88);
            this.tblFooterLayout.TabIndex = 0;
            // 
            // lblInstructionDescription
            // 
            this.lblInstructionDescription.AutoSize = true;
            this.lblInstructionDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructionDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInstructionDescription.Location = new System.Drawing.Point(1, 72);
            this.lblInstructionDescription.Name = "lblInstructionDescription";
            this.lblInstructionDescription.Size = new System.Drawing.Size(66, 28);
            this.lblInstructionDescription.TabIndex = 8;
            this.lblInstructionDescription.Text = "label2";
            // 
            // pnlWoBottom
            // 
            this.pnlWoBottom.Controls.Add(this.txtSkuValue);
            this.pnlWoBottom.Controls.Add(this.txtWorkOrderValue);
            this.pnlWoBottom.Controls.Add(this.label2);
            this.pnlWoBottom.Controls.Add(this.label3);
            this.pnlWoBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWoBottom.Location = new System.Drawing.Point(3, 3);
            this.pnlWoBottom.Name = "pnlWoBottom";
            this.pnlWoBottom.Size = new System.Drawing.Size(378, 82);
            this.pnlWoBottom.TabIndex = 13;
            // 
            // txtSkuValue
            // 
            this.txtSkuValue.Location = new System.Drawing.Point(70, 37);
            this.txtSkuValue.Name = "txtSkuValue";
            this.txtSkuValue.Size = new System.Drawing.Size(259, 22);
            this.txtSkuValue.TabIndex = 14;
            // 
            // txtWorkOrderValue
            // 
            this.txtWorkOrderValue.Location = new System.Drawing.Point(70, 9);
            this.txtWorkOrderValue.Name = "txtWorkOrderValue";
            this.txtWorkOrderValue.Size = new System.Drawing.Size(259, 22);
            this.txtWorkOrderValue.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "WO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "SKU:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // flwpnlStepper
            // 
            this.flwpnlStepper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flwpnlStepper.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwpnlStepper.Location = new System.Drawing.Point(0, 0);
            this.flwpnlStepper.Name = "flwpnlStepper";
            this.flwpnlStepper.Size = new System.Drawing.Size(771, 69);
            this.flwpnlStepper.TabIndex = 7;
            // 
            // picInstruction
            // 
            this.picInstruction.BackColor = System.Drawing.SystemColors.HighlightText;
            this.picInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picInstruction.Location = new System.Drawing.Point(0, 0);
            this.picInstruction.Name = "picInstruction";
            this.picInstruction.Size = new System.Drawing.Size(771, 619);
            this.picInstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInstruction.TabIndex = 1;
            this.picInstruction.TabStop = false;
            // 
            // flpWorkOrders
            // 
            this.flpWorkOrders.AutoScroll = true;
            this.flpWorkOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpWorkOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWorkOrders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWorkOrders.Location = new System.Drawing.Point(3, 3);
            this.flpWorkOrders.Name = "flpWorkOrders";
            this.flpWorkOrders.Size = new System.Drawing.Size(331, 619);
            this.flpWorkOrders.TabIndex = 3;
            this.flpWorkOrders.WrapContents = false;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTest.Controls.Add(this.label6);
            this.btnTest.Controls.Add(this.label5);
            this.btnTest.Controls.Add(this.ledBackStatus);
            this.btnTest.Controls.Add(this.ledNextStatus);
            this.btnTest.Controls.Add(this.btnTTest);
            this.btnTest.Controls.Add(this.btnLogout);
            this.btnTest.Controls.Add(this.btnStart);
            this.btnTest.Controls.Add(this.btnPrevious);
            this.btnTest.Controls.Add(this.btnNext);
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.ForeColor = System.Drawing.Color.Teal;
            this.btnTest.Location = new System.Drawing.Point(1117, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(231, 619);
            this.btnTest.TabIndex = 4;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPrevious.Location = new System.Drawing.Point(37, 365);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(156, 58);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "Back";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnNext.Location = new System.Drawing.Point(41, 281);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(152, 59);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Teal;
            this.btnStart.Location = new System.Drawing.Point(37, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 58);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Teal;
            this.btnLogout.Location = new System.Drawing.Point(37, 114);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(152, 59);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTTest
            // 
            this.btnTTest.BackColor = System.Drawing.Color.White;
            this.btnTTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTTest.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTTest.ForeColor = System.Drawing.Color.Teal;
            this.btnTTest.Location = new System.Drawing.Point(37, 200);
            this.btnTTest.Name = "btnTTest";
            this.btnTTest.Size = new System.Drawing.Size(152, 59);
            this.btnTTest.TabIndex = 12;
            this.btnTTest.Text = "Test";
            this.btnTTest.UseVisualStyleBackColor = false;
            // 
            // ledNextStatus
            // 
            this.ledNextStatus.IsOn = false;
            this.ledNextStatus.LedColor = System.Drawing.Color.DarkSlateGray;
            this.ledNextStatus.Location = new System.Drawing.Point(17, 466);
            this.ledNextStatus.Name = "ledNextStatus";
            this.ledNextStatus.Size = new System.Drawing.Size(56, 52);
            this.ledNextStatus.TabIndex = 11;
            this.ledNextStatus.Text = "industrialLed1";
            // 
            // ledBackStatus
            // 
            this.ledBackStatus.IsOn = false;
            this.ledBackStatus.LedColor = System.Drawing.Color.DarkSlateGray;
            this.ledBackStatus.Location = new System.Drawing.Point(17, 525);
            this.ledBackStatus.Name = "ledBackStatus";
            this.ledBackStatus.Size = new System.Drawing.Size(56, 52);
            this.ledBackStatus.TabIndex = 13;
            this.ledBackStatus.Text = "industrialLed2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(92, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Next";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(92, 534);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Back";
            // 
            // FrmStationConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 709);
            this.Controls.Add(this.tblMainLayout);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmStationConsole";
            this.Text = "Production Line";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStationConsole_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblMainLayout.ResumeLayout(false);
            this.pnlCenterArea.ResumeLayout(false);
            this.pnlCenterArea.PerformLayout();
            this.pnlFooterContainer.ResumeLayout(false);
            this.tblFooterLayout.ResumeLayout(false);
            this.pnlWoBottom.ResumeLayout(false);
            this.pnlWoBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInstruction)).EndInit();
            this.btnTest.ResumeLayout(false);
            this.btnTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblStationTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Panel pnlCenterArea;
        private System.Windows.Forms.PictureBox picInstruction;
        private System.Windows.Forms.FlowLayoutPanel flpWorkOrders;
        private System.Windows.Forms.Panel btnTest;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel flwpnlStepper;
        private System.Windows.Forms.Label lblInstructionDescription;
        private System.Windows.Forms.FlowLayoutPanel pnlFooterContainer;
        private System.Windows.Forms.TableLayoutPanel tblFooterLayout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlWoBottom;
        private System.Windows.Forms.TextBox txtSkuValue;
        private System.Windows.Forms.TextBox txtWorkOrderValue;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTTest;
        private IndustrialMES.OperatorConsole.IndustrialLed ledBackStatus;
        private IndustrialMES.OperatorConsole.IndustrialLed ledNextStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

