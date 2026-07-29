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
        }

        private void FrmStationConsole_Load(object sender, EventArgs e)
        {
            InitializeSystemDateTime();
            CenterContainer();
            lblSystemStatus.Text = "ONLINE";
            lblSystemStatus.ForeColor = Color.DarkGreen;
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
            lblToastMessage.Text = message;
            lblToastMessage.ForeColor = isSuccess ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Red;
            lblToastMessage.Visible = true;
            await Task.Delay(3000);
            lblToastMessage.Visible = false;
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
                var response = await _httpClient.GetAsync($"OperatorStation/VerifyRfid?rfidTag={rfidTag}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    JObject root = JObject.Parse(jsonString);

                    string empName = root["Name"]?.ToString();
                    string qualification = root["qualification"]?.ToString();

                    ShowToast($"Welcome {empName}!", isSuccess: true);
                  
                }
                else
                {
                    ShowToast("ACCESS DENIED! Invalid Card", isSuccess: false);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Connection Error: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txtRfidInput.Clear();
                txtRfidInput.Focus();
            }
        }
    }

}
