using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; 
namespace OpcUa.PlcSimulator
{
    public partial class FrmStationConsole : Form
    {
        private readonly HttpClient _httpClient;
        public FrmStationConsole()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5223/api/") };
        }
        private void CenterContainer()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
            pnlHeader.Left = (pnlHeader.Width - pnlHeader.Width) / 2;
            pnlHeader.Top = (pnlHeader.Height - pnlHeader.Height) / 2;
        }

        private void FrmStationConsole_Load(object sender, EventArgs e)
        {
            InitializeSystemDateTime();
            CenterContainer();
            lblSystemStatus.Text = "ONLINE";
            lblSystemStatus.ForeColor = Color.LimeGreen;
        }
        private void InitializeSystemDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dd-Jul-2026"); 

         
            int currentHour = DateTime.Now.Hour;
            string shiftName = "Night"; 

            if (currentHour >= 8 && currentHour < 16)
            {
                shiftName = "Morning";
            }
            else if (currentHour >= 16 && currentHour < 24)
            {
                shiftName = "Night";
            }
            lblShift.Text = shiftName;


        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmStationConsole_Resize(object sender, EventArgs e)
        {
            CenterContainer();
        }

        private async void btnSimulateScan_Click(object sender, EventArgs e)
        {
            await AuthenticateOperator(txtRfidInput.Text);
        }

        private async void txtRfidInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                string inputTag = txtRfidInput.Text.Trim();
                await AuthenticateOperator(inputTag);
            }
        }
        private async void ShowToast(string message, bool isSuccess)
        {
            await Task.Delay(3000);
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
                btnSimulateScan.Enabled = false;
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                lblRfidStatus.Text = "Reading";
                lblRfidStatus.Visible = true;
                lblRfidStatus.ForeColor = Color.Yellow;
                await Task.Delay(300);
                var response = await _httpClient.GetAsync($"OperatorStation/VerifyRfid?rfidTag={rfidTag}");
                if (response.IsSuccessStatusCode)
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 100;
                    lblRfidStatus.Text = "Successed";
                    lblRfidStatus.Visible = true;
                    lblRfidStatus.ForeColor = Color.LimeGreen;
                    var jsonString = await response.Content.ReadAsStringAsync();
                    JObject root = JObject.Parse(jsonString);

                    string empName = root["Name"]?.ToString();
                    string qualification = root["qualification"]?.ToString();
                    await Task.Delay(400);
                    ShowToast($"Welcome {empName}!", isSuccess: true);
                  
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                    lblRfidStatus.Text = "Error";
                    lblRfidStatus.Visible = true;
                    lblRfidStatus.ForeColor = Color.Red;
                    ShowToast("ACCESS DENIED! Invalid Card", isSuccess: false);
                   
                }
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                lblRfidStatus.Text = "Error";
                lblRfidStatus.Visible = true;
                lblRfidStatus.ForeColor = Color.Red;
                MessageBox.Show($"API Connection Error: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                btnSimulateScan.Enabled = true;
                txtRfidInput.Clear();
                txtRfidInput.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // خلفية الدايرة
            using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml("#2A3341")))
            {
                e.Graphics.FillEllipse(bgBrush, 0, 0, iconPanel.Width - 1, iconPanel.Height - 1);
            }

            // حدود الدايرة (border خفيف)
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
