using Newtonsoft.Json.Linq;
using System;
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

        public FrmStationConsole()
        {
            InitializeComponent();
            InitSerialPort();
        }

        private void CenterContainer()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;

            //if (pnlWorkOrders.Width > pnlContentContainer.Width)
            //{
            //    pnlContentContainer.Left = (pnlWorkOrders.Width - pnlContentContainer.Width) / 2;
            //}

            //int availableHeight = pnlWorkOrders.Height - pnlHeader.Height;
            //pnlContentContainer.Top = pnlHeader.Height + ((availableHeight - pnlContentContainer.Height) / 2);
        }

        private async void FrmStationConsole_Load(object sender, EventArgs e)
        {
            pnlWorkOrders.Visible = true;
            pnlWorkOrders.BringToFront();
            InitializeSystemDateTime();
            CenterContainer();

            lblSystemStatus.Text = "ONLINE";
            lblSystemStatus.ForeColor = Color.LimeGreen;

            _currentStationId = _stationService.GetConfiguredStationId();
            await LoadStationDetails();
            lblStationTitle.Visible = true;
            await LoadWorkOrdersForStation();
        }

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

                    Panel card = _stationService.CreateWorkOrderCard(woId, woNumber, sku, status, targetQty);
                    flpWorkOrders.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading work orders: {ex.Message}");
            }
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

        private void InitializeSystemDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            int currentHour = DateTime.Now.Hour;
            lblShift.Text = (currentHour >= 8 && currentHour < 16) ? "Morning" : "Night";
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

        private void FrmStationConsole_Resize(object sender, EventArgs e) => CenterContainer();

        private async void btnSimulateScan_Click(object sender, EventArgs e) => await AuthenticateOperator(txtRfidInput.Text);

        private async void txtRfidInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await AuthenticateOperator(txtRfidInput.Text.Trim());
            }
        }

        private void FrmStationConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_rfidSerialPort != null && _rfidSerialPort.IsOpen)
            {
                _rfidSerialPort.Close();
            }
        }

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
    }
}