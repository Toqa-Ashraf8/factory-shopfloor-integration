using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpcUa.PlcSimulator
{
    public partial class FrmStationConsole : Form
    {
        private SerialPort _rfidSerialPort;
        private int _currentStationId;
        private string _stationName;
        private readonly StationService _stationService = new StationService();

        // مسارات الفيديو والصور للسيرفر
        private const string BaseImageUrl = "http://localhost:5223/Images/InstructionSteps/";
        private const string BaseVideoUrl = "http://localhost:5223/Videos/InstructionSteps/";

        // متغيرات إدارة الخطوات
        private JArray _segments;
        private int _currentSegmentIndex = 0;

        public FrmStationConsole()
        {
            InitializeComponent();
            InitSerialPort();
        }

        #region Form Events & Setup
        private async void FrmStationConsole_Load(object sender, EventArgs e)
        {
            pnlHeader.Dock = DockStyle.Top;

            // 2. القائمة الجانبية للأوامر على اليمين بعرض ثابت
            pnlWorkOrders.Dock = DockStyle.Right;
            pnlWorkOrders.Width = 380; // عرض مناسب جداً للكروت

            // 3. تأكد إن قائمة الأوامر جواه بتملى المساحة
            flpWorkOrders.Dock = DockStyle.Fill;
            flpWorkOrders.AutoScroll = true; // سكرول تلقائي

            // 4. منطقة العرض الوسطى (الصورة والخطوات) تملى باقي الشاشة
            // (تأكد إن اسم البانل الوسطى عندك صح أو غير اسمها هنا)
            if (pnlContentContainer != null)
            {
                pnlContentContainer.Dock = DockStyle.Fill;
                pnlContentContainer.BringToFront();
            }

            // --- بقية كودك العادي ---
            InitializeSystemDateTime();
            CenterContainer();

            lblSystemStatus.Text = "ONLINE";
            lblSystemStatus.ForeColor = Color.LimeGreen;

            _currentStationId = _stationService.GetConfiguredStationId();
            await LoadStationDetails();
            lblStationTitle.Visible = true;
            await LoadWorkOrdersForStation();

            btnNext.Click += btnNext_Click;
            btnPrevious.Click += btnPrevious_Click;
        }

        private void FrmStationConsole_Resize(object sender, EventArgs e) => CenterContainer();

        private void FrmStationConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_rfidSerialPort != null)
            {
                if (_rfidSerialPort.IsOpen)
                {
                    _rfidSerialPort.DataReceived -= RfidSerialPort_DataReceived;
                    _rfidSerialPort.Close();
                }
                _rfidSerialPort.Dispose();
            }
        }

        private void CenterContainer()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }

        private void InitializeSystemDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            int currentHour = DateTime.Now.Hour;
            lblShift.Text = (currentHour >= 8 && currentHour < 16) ? "Morning" : "Night";
        }
        #endregion

        #region Station & Work Orders Operations
        private async Task LoadStationDetails()
        {
            var data = await _stationService.GetStationDetails(_currentStationId);
            if (data != null)
            {
                _stationName = data["WorkCenterName"]?.ToString() ?? "Station";
                lblStationTitle.Text = $"STATION: {_stationName}";
            }
            else
            {
                lblStationTitle.Text = $"STATION: {_currentStationId} (Offline Mode)";
            }
        }

        private async Task LoadWorkOrdersForStation()
        {
            try
            {
                JArray workOrders = await _stationService.GetWorkOrdersForStation();
                flpWorkOrders.Controls.Clear();

                if (workOrders == null || workOrders.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No Unreleased Work Orders found for this station.",
                        AutoSize = true,
                        ForeColor = Color.Red,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Padding = new Padding(20)
                    };
                    flpWorkOrders.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var wo in workOrders)
                {
                    int woId = wo["id"]?.ToObject<int>() ?? 0;
                    string woNumber = wo["WorkOrderNumber"]?.ToString() ?? "WO-XXXX";
                    string sku = wo["SKU"]?.ToString() ?? "";
                    string status = wo["status"]?.ToString() ?? "Unreleased";
                    int targetQty = wo["targetQuantity"]?.ToObject<int>() ?? 0;

                    Panel card = _stationService.CreateWorkOrderCard(woId, woNumber, sku, status, targetQty,
                        async (selectedId, selectedWoNum, selectedSku, selectedQty) =>
                        {
                            // 1. بدء أمر العمل عبر API
                            await _stationService.StartWorkOrder(selectedId);

                            // 2. تحميل الخطوات والصور مباشرة في نفس الشاشة
                            await LoadExecutionDetailsInline(selectedSku);
                        });

                    flpWorkOrders.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading work orders: {ex.Message}");
            }
        }
        #endregion

        #region Inline Execution Logic
        private async Task LoadExecutionDetailsInline(string sku)
        {
            JObject details = await _stationService.GetWorkOrderExecutionDetails(sku);

            if (details == null)
            {
                MessageBox.Show("Failed to load execution data from the server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _segments = (JArray)(details["processSegments"] ?? details["ProcessSegments"]);

            if (_segments != null && _segments.Count > 0)
            {
                _currentSegmentIndex = 0;
                BuildStepperButtons();
                DisplayCurrentSegment();
            }
            else
            {
                MessageBox.Show("No process steps found for this SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuildStepperButtons()
        {
            pnlStepper.Controls.Clear();

            for (int i = 0; i < _segments.Count; i++)
            {
                var seg = _segments[i];
                string seqNo = (seg["sequenceNo"] ?? seg["SequenceNo"])?.ToString();
                string seqName = (seg["sequenceName"] ?? seg["SequenceName"])?.ToString();

                Button btnStep = new Button
                {
                    Text = $"{seqNo}. {seqName}",
                    Tag = i,
                    Width = 160,
                    Height = 40,
                    Margin = new Padding(5),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Enabled = false
                };

                btnStep.FlatAppearance.BorderSize = 1;
                pnlStepper.Controls.Add(btnStep);
            }
        }

        private void DisplayCurrentSegment()
        {
            if (_segments == null || _segments.Count == 0) return;

            JToken currentSegment = _segments[_currentSegmentIndex];

            // 1. تحديث نص التقدم
            lblStepProgress.Text = $"Step {_currentSegmentIndex + 1} of {_segments.Count}";

            // 2. تحديث تصميم أزرار الـ Stepper
            UpdateStepperUI();

            // 3. عرض معلومات الخطوة
            JArray instructions = (JArray)(currentSegment["workInstructions"] ?? currentSegment["WorkInstructions"]);
            if (instructions != null && instructions.Count > 0)
            {
                var firstStep = instructions[0];
                //lblInstructionDescription.Text = (firstStep["description"] ?? firstStep["Description"])?.ToString();

                // الصورة
                string imageFileName = (firstStep["imageUrl"] ?? firstStep["ImageUrl"])?.ToString();
                if (!string.IsNullOrEmpty(imageFileName))
                {
                    string fullImageUrl = imageFileName.StartsWith("http") ? imageFileName : $"{BaseImageUrl}{imageFileName}";
                    picInstruction.LoadAsync(fullImageUrl);
                }
                else
                {
                    picInstruction.Image = null;
                }

                // الفيديو
                //string videoFileName = (firstStep["videoUrl"] ?? firstStep["VideoUrl"])?.ToString();
                //if (!string.IsNullOrEmpty(videoFileName))
                //{
                //    btnPlayVideo.Visible = true;
                //    string fullVideoUrl = videoFileName.StartsWith("http") ? videoFileName : $"{BaseVideoUrl}{videoFileName}";
                //    btnPlayVideo.Tag = fullVideoUrl;
                //}
                //else
                //{
                //    btnPlayVideo.Visible = false;
                //}
            }
            else
            {
                //lblInstructionDescription.Text = "No instructions available for this step.";
                picInstruction.Image = null;
                //btnPlayVideo.Visible = false;
            }

            // 4. التحكم بزر السابق
            btnPrevious.Enabled = (_currentSegmentIndex > 0);
        }

        private void UpdateStepperUI()
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                if (i < pnlStepper.Controls.Count && pnlStepper.Controls[i] is Button btnStep)
                {
                    if (i == _currentSegmentIndex)
                    {
                        btnStep.BackColor = Color.FromArgb(0, 122, 204);
                        btnStep.ForeColor = Color.White;
                    }
                    else if (i < _currentSegmentIndex)
                    {
                        btnStep.BackColor = Color.FromArgb(46, 139, 87);
                        btnStep.ForeColor = Color.White;
                    }
                    else
                    {
                        btnStep.BackColor = Color.FromArgb(45, 45, 48);
                        btnStep.ForeColor = Color.Gray;
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_segments == null) return;

            if (_currentSegmentIndex < _segments.Count - 1)
            {
                _currentSegmentIndex++;
                DisplayCurrentSegment();
            }
            else
            {
                MessageBox.Show("All process steps completed!", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentSegmentIndex > 0)
            {
                _currentSegmentIndex--;
                DisplayCurrentSegment();
            }
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            //if (btnPlayVideo.Tag is string videoUrl && !string.IsNullOrEmpty(videoUrl))
            //{
            //    Process.Start(new ProcessStartInfo
            //    {
            //        FileName = videoUrl,
            //        UseShellExecute = true
            //    });
            //}
        }
        #endregion

        #region RFID & Serial Port Operations
        private void InitSerialPort()
        {
            try
            {
                _rfidSerialPort = new SerialPort
                {
                    PortName = "COM4",
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };
                _rfidSerialPort.DataReceived += RfidSerialPort_DataReceived;
                _rfidSerialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Serial Port Error (COM4): {ex.Message}", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RfidSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string rawData = _rfidSerialPort.ReadExisting();
                string cleanedTag = System.Text.RegularExpressions.Regex.Replace(rawData, @"[^\w-]", "").Trim();

                if (string.IsNullOrEmpty(cleanedTag)) return;

                this.Invoke(new Action(async () =>
                {
                    txtRfidInput.Text = cleanedTag;
                    await AuthenticateOperator(cleanedTag);
                }));
            }
            catch { }
        }

        private async Task AuthenticateOperator(string rfidTag)
        {
            if (string.IsNullOrWhiteSpace(rfidTag))
            {
                MessageBox.Show("Please enter or scan an RFID Tag!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                lblRfidStatus.Text = "Reading";
                lblRfidStatus.Visible = true;
                lblRfidStatus.ForeColor = Color.Yellow;

                await Task.Delay(300);

                var result = await _stationService.AuthenticateOperator(rfidTag);

                if (result.IsSuccess)
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 100;
                    lblRfidStatus.Text = "Successed";
                    lblRfidStatus.ForeColor = Color.LimeGreen;

                    await Task.Delay(400);

                    MessageBox.Show($"Welcome: {result.OperatorName}\nStation: {_stationName}", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadWorkOrdersForStation();
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                    lblRfidStatus.Text = "Error";
                    lblRfidStatus.ForeColor = Color.Red;
                    MessageBox.Show(result.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                lblRfidStatus.Text = "Error";
                lblRfidStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                txtRfidInput.Clear();
                txtRfidInput.Focus();
                lblRfidStatus.Text = "";
            }
        }

        private async void btnSimulateScan_Click(object sender, EventArgs e) => await AuthenticateOperator(txtRfidInput.Text);

        private async void txtRfidInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await AuthenticateOperator(txtRfidInput.Text.Trim());
            }
        }
        #endregion

        #region Custom UI Painting
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml("#2A3341")))
            {
                e.Graphics.FillEllipse(bgBrush, 0, 0, iconPanel.Width - 1, iconPanel.Height - 1);
            }
            using (Pen borderPen = new Pen(ColorTranslator.FromHtml("#3A4556"), 1))
            {
                e.Graphics.DrawEllipse(borderPen, 0, 0, iconPanel.Width - 1, iconPanel.Height - 1);
            }
        }

        private void iconPanel_Resize(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, iconPanel.Width, iconPanel.Height);
            iconPanel.Region = new Region(path);
        }

        private void pnlWorkerHeaders_Paint(object sender, PaintEventArgs e)
        {
        }
        #endregion
    }
}