using IndustrialMES.OperatorConsole;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexera.MES.StationConsole
{
    public partial class FrmStationConsole : Form
    {
        private readonly StationConsoleClass _controller = new StationConsoleClass();

        private int _currentStationId;
        private string _stationName;
        private JArray _segments;
        private int _currentSegmentIndex = 0;
        private IndustrialLed _ledSystemStatus;
        private Label _lblPlaceholder;

        public FrmStationConsole()
        {
            InitializeComponent();
        }

        private async void FrmStationConsole_Load(object sender, EventArgs e)
        {
            
            CreateLedControl();
            CreatePlaceholderLabel();
            ApplyIndustrialThemeAndLayout();
            SetupCenterAreaLayout();
            UpdateSystemStatus(true);
            HideExecutionUI();
            InitializeSystemDateTime();

            _currentStationId = _controller.GetConfiguredStationId();
            await LoadStationDetails();
            await LoadWorkOrders();

        }
        private void CreateLedControl()
        {
            _ledSystemStatus = new IndustrialLed
            {
                Size = new Size(22, 22),
                LedColor = Color.Lime,
                IsOn = true,
                Margin = new Padding(0)
            };
            if (lblSystemStatus.Parent != null)
            {
                lblSystemStatus.Parent.Controls.Add(_ledSystemStatus);
                _ledSystemStatus.Location = new Point(lblSystemStatus.Left - 28, lblSystemStatus.Top + 2);
                _ledSystemStatus.BringToFront();
            }
        }
        private void CreatePlaceholderLabel()
        {
            _lblPlaceholder = new Label
            {
                Text = "Please select a Work Order from the left panel to start execution.",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(120, 135, 150),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(240, 243, 246)
            };

            pnlCenterArea.Controls.Add(_lblPlaceholder);
            _lblPlaceholder.BringToFront();
        }
        private void UpdateSystemStatus(bool isOnline)
        {
            if (isOnline)
            {
                lblSystemStatus.Text = "ONLINE";
                lblSystemStatus.ForeColor = Color.ForestGreen;
                if (_ledSystemStatus != null)
                {
                    _ledSystemStatus.LedColor = Color.Lime;
                    _ledSystemStatus.IsOn = true;
                }
            }
            else
            {
                lblSystemStatus.Text = "OFFLINE";
                lblSystemStatus.ForeColor = Color.Red;
                if (_ledSystemStatus != null)
                {
                    _ledSystemStatus.LedColor = Color.Red;
                    _ledSystemStatus.IsOn = true;
                }
            }
        }
        private void HideExecutionUI()
        {
            lblInstructionDescription.Text = "";
            picInstruction.Image = null;

            pnlFooterContainer.Visible = false;
            flwpnlStepper.Visible = false;

            if (_lblPlaceholder != null) _lblPlaceholder.Visible = true;

            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            if (btnTest != null) btnTTest.Enabled = false;
            if (btnStart != null) btnStart.Enabled = false;
        }

        private void ShowExecutionUI()
        {
            if (_lblPlaceholder != null) _lblPlaceholder.Visible = false;

            pnlFooterContainer.Visible = true;
            flwpnlStepper.Visible = true;
            pnlCenterArea.Visible = true;
            if (btnTest != null) btnTest.Visible = true;
        }

        private void InitializeSystemDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            int currentHour = DateTime.Now.Hour;
            lblShift.Text = (currentHour >= 8 && currentHour < 16) ? "Morning" : "Night";
        }

        private async Task LoadStationDetails()
        {
            var data = await _controller.GetStationDetails(_currentStationId);
            if (data != null)
            {
                _stationName = data["WorkCenterName"]?.ToString() ?? "Station";
                lblStationTitle.Text = $"STATION: {_stationName}";
                UpdateSystemStatus(true);
            }
            else
            {
                lblStationTitle.Text = $"STATION: {_currentStationId} (Offline)";
                UpdateSystemStatus(false);
            }
        }

        private async Task LoadWorkOrders()
        {
            JArray workOrders = await _controller.GetWorkOrdersForStation();
            flpWorkOrders.Controls.Clear();

            flpWorkOrders.BackColor = Color.FromArgb(232, 236, 241);

            if (workOrders == null || workOrders.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "No Unreleased Work Orders.",
                    ForeColor = Color.Firebrick,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Padding = new Padding(15),
                    AutoSize = true
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

                Panel card = _controller.CreateWorkOrderCard(woId, woNumber, sku, status, targetQty,
                    async (selectedId, selectedWoNum, selectedSku, selectedQty) =>
                    {
                        txtWorkOrderValue.Text = selectedWoNum;
                        txtSkuValue.Text = selectedSku;

                        ShowExecutionUI();

                        await LoadExecutionDetails(selectedSku);
                    });

                flpWorkOrders.Controls.Add(card);
            }
        }

        private async Task LoadExecutionDetails(string sku)
        {
            JObject details = await _controller.GetWorkOrderExecutionDetails(sku);
            if (details == null)
            {
                MessageBox.Show("Failed to load execution data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _segments = (JArray)(details["processSegments"] ?? details["ProcessSegments"]);

            if (_segments != null && _segments.Count > 0)
            {
                _currentSegmentIndex = 0;
                BuildStepperButtons();
                DisplayCurrentSegment();
            }
        }

        private void SetupCenterAreaLayout()
        {
            flwpnlStepper.Dock = DockStyle.Top;
            flwpnlStepper.Height = 60;
            flwpnlStepper.BackColor = Color.FromArgb(240, 243, 246);

            picInstruction.Dock = DockStyle.Fill;
            picInstruction.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void BuildStepperButtons()
        {
            flwpnlStepper.Controls.Clear();
            flwpnlStepper.WrapContents = false;
            flwpnlStepper.AutoScroll = true;

            for (int i = 0; i < _segments.Count; i++)
            {
                var seg = _segments[i];
                string seqNo = (seg["sequenceNo"] ?? seg["SequenceNo"])?.ToString();
                string seqName = (seg["sequenceName"] ?? seg["SequenceName"])?.ToString();

                Button btnStep = new Button
                {
                    Text = $"{seqNo}. {seqName}",
                    Width = 200,
                    Height = 45,
                    Margin = new Padding(6),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Enabled = true
                };
                btnStep.FlatAppearance.BorderSize = 1;
                flwpnlStepper.Controls.Add(btnStep);
            }
        }

        private void DisplayCurrentSegment()
        {
            if (_segments == null || _segments.Count == 0) return;

            JToken currentSegment = _segments[_currentSegmentIndex];

            UpdateStepperColors();

            JArray instructions = (JArray)(currentSegment["workInstructions"] ?? currentSegment["WorkInstructions"]);
            if (instructions != null && instructions.Count > 0)
            {
                var firstStep = instructions[0];
                lblInstructionDescription.Text = (firstStep["description"] ?? firstStep["Description"])?.ToString();

                string imageFileName = (firstStep["imageUrl"] ?? firstStep["ImageUrl"])?.ToString();
                if (!string.IsNullOrEmpty(imageFileName))
                {
                    string fullImageUrl = imageFileName.StartsWith("http") ? imageFileName : $"{StationConsoleClass.BaseImageUrl}{imageFileName}";
                    picInstruction.LoadAsync(fullImageUrl);
                }
                else
                {
                    picInstruction.Image = null;
                }
            }

            btnPrevious.Enabled = (_currentSegmentIndex > 0);
            btnNext.Enabled = (_currentSegmentIndex < _segments.Count - 1);
        }

        private void UpdateStepperColors()
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                if (i < flwpnlStepper.Controls.Count && flwpnlStepper.Controls[i] is Button btnStep)
                {
                    if (i == _currentSegmentIndex)
                    {
                        btnStep.BackColor = Color.FromArgb(0, 122, 204);
                        btnStep.ForeColor = Color.White;
                        btnStep.FlatAppearance.BorderColor = Color.FromArgb(0, 90, 160);
                        btnStep.FlatAppearance.BorderSize = 2;
                    }
                    else if (i < _currentSegmentIndex)
                    {
                        btnStep.BackColor = Color.FromArgb(46, 139, 87);
                        btnStep.ForeColor = Color.White;
                        btnStep.FlatAppearance.BorderColor = Color.ForestGreen;
                        btnStep.FlatAppearance.BorderSize = 1;
                    }
                    else
                    {
                        btnStep.BackColor = Color.FromArgb(225, 230, 235);
                        btnStep.ForeColor = Color.FromArgb(60, 70, 80);
                        btnStep.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210);
                        btnStep.FlatAppearance.BorderSize = 1;
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_segments != null && _currentSegmentIndex < _segments.Count - 1)
            {
                _currentSegmentIndex++;
                DisplayCurrentSegment();
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

        private void ApplyIndustrialThemeAndLayout()
        {
            this.BackColor = Color.FromArgb(240, 243, 246);

            picInstruction.Dock = DockStyle.Fill;
            picInstruction.SizeMode = PictureBoxSizeMode.Zoom;
            picInstruction.BackColor = Color.FromArgb(240, 243, 246);

            pnlFooterContainer.Dock = DockStyle.Bottom;
            pnlFooterContainer.Height = 65;
            pnlFooterContainer.BackColor = Color.FromArgb(225, 230, 236);
            pnlFooterContainer.Padding = new Padding(15, 5, 15, 5);

            lblInstructionDescription.Dock = DockStyle.Fill;
            lblInstructionDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInstructionDescription.ForeColor = Color.FromArgb(30, 40, 55);
            lblInstructionDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructionDescription.BackColor = Color.Transparent;
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (_segments != null && _currentSegmentIndex < _segments.Count - 1)
            {
                _currentSegmentIndex++;
                DisplayCurrentSegment();
                btnNext.BackColor = Color.LightGreen;
                btnPrevious.BackColor = SystemColors.Control;
                if (ledBackStatus != null) ledBackStatus.LedColor = Color.Gray;
                if (ledNextStatus != null) ledNextStatus.LedColor = Color.Lime;
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (_currentSegmentIndex > 0)
            {
                _currentSegmentIndex--;
                DisplayCurrentSegment();
                btnPrevious.BackColor = Color.LightGreen;
                btnNext.BackColor = SystemColors.Control;
                if (ledBackStatus != null) ledBackStatus.LedColor = Color.Lime;
                if (ledNextStatus != null) ledNextStatus.LedColor = Color.Gray;
            }
        }
    }
}