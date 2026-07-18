using Opc.Ua;
using Opc.Ua.Client;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OpcUa.PlcSimulator
{
    public partial class OpcUaForm : Form
    {
        HttpClient client = new HttpClient();
        private OpcClient opcClient;
        private OpcSubscription counterSubscription;
        private OpcSubscription tempSubscription;
        private bool isAlarmColorToggle = false;

        public OpcUaForm()
        {
            InitializeComponent();
        }

        private void LogToConsole(string message)
        {
            if (this.IsDisposed || this.Disposing) return;
            this.Invoke((MethodInvoker)delegate {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                rtbConsoleLog.SelectionStart = rtbConsoleLog.TextLength;
                rtbConsoleLog.SelectionLength = 0;

                rtbConsoleLog.SelectionColor = Color.DarkGray;
                rtbConsoleLog.AppendText($"[{timestamp}] ");

                rtbConsoleLog.SelectionColor = rtbConsoleLog.ForeColor;
                rtbConsoleLog.AppendText($"{message}{Environment.NewLine}");

                rtbConsoleLog.ScrollToCaret();
            });
        }

        private void btnWriteSettingss_Click(object sender, EventArgs e)
        {
            if (opcClient == null || opcClient.State != OpcClientState.Connected)
            {
                LogToConsole("Error: OPC UA Server is not connected!");
                return;
            }

            try
            {
                double targetTemp = (double)numTargetTemp.Value;
                var nodeToWrite = new OpcWriteNode("ns=3;i=1008", targetTemp);
                opcClient.WriteNodes(nodeToWrite);
                LogToConsole($"Success: Sent Target Temperature ({targetTemp} °C) to PLC.");
            }
            catch (Exception ex)
            {
                LogToConsole($"Writing Error: {ex.Message}");
            }
        }

        private void ConnectToOPC()
        {
            try
            {
                opcClient = new OpcClient("opc.tcp://DESKTOP-5RMLPFJ:53530/OPCUA/SimulationServer");
                opcClient.Connect();

                OpcStatusLED.LedColor = Color.Lime;
                OpcStatusLED.IsOn = true;

                MachineStatusLED.LedColor = Color.Lime;
                MachineStatusLED.IsOn = true;

                this.BackColor = SystemColors.Control;
                LogToConsole("System: Connected to OPC UA Server successfully.");

                counterSubscription = opcClient.SubscribeDataChange("ns=3;i=1001", HandleCounterChanged);

                tempSubscription = opcClient.SubscribeDataChange("ns=3;i=1008", HandleTemperatureChanged);

                LogToConsole("System: Live monitoring activated for Counter and Temperature.");
            }
            catch (Exception ex)
            {
                OpcStatusLED.LedColor = Color.Red;
                OpcStatusLED.IsOn = true;
                MachineStatusLED.LedColor = Color.Red;
                MachineStatusLED.IsOn = true;
                this.BackColor = Color.MistyRose;

                LogToConsole($"CRITICAL ERROR: PLC Connection Lost! {ex.Message}");
                MessageBox.Show("OPC UA Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCounterChanged(object sender, OpcDataChangeReceivedEventArgs e)
        {
            if (this.IsDisposed || this.Disposing) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (e.Item != null && e.Item.Value != null)
                {
                    int currentCountFromPLC = Convert.ToInt32(e.Item.Value.Value);
                    int targetQty = Convert.ToInt32(txtTargetQty.Text);

                    if (currentCountFromPLC <= targetQty)
                    {
                        lblCurrentCountValue.Text = $"{currentCountFromPLC} / {targetQty}";
                    }

                    if (currentCountFromPLC >= targetQty)
                    {
                        lblCurrentCountValue.Text = $"{targetQty} / {targetQty}";

                        LogToConsole("SUCCESS: Production Target Reached! Stopping the node counter...");

                        try
                        {
                            if (opcClient != null && opcClient.State == OpcClientState.Connected)
                            {
                                var resetCounterNode = new OpcWriteNode("ns=3;i=1001", 0);
                                opcClient.WriteNodes(resetCounterNode);
                                LogToConsole("System: Sent Reset command to Node i=1001 to stop counting.");

                                var stopNode = new OpcWriteNode("ns=3;i=1009", false);
                                opcClient.WriteNodes(stopNode);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogToConsole($"PLC Stop Error: {ex.Message}");
                        }

                        MachineStatusLED.LedColor = Color.Gray;
                        MachineStatusLED.IsOn = false;

                        if (counterSubscription != null)
                        {
                            counterSubscription.Unsubscribe();
                            LogToConsole("System: Counter subscription paused.");
                        }

                        this.BackColor = Color.LightGreen;

                        PlayIndustrialAlarm();

                        MessageBox.Show("Production Target Reached Successfully!\nMachine and Counter Node stopped.",
                                        "Order Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            });
        }

        private void HandleTemperatureChanged(object sender, OpcDataChangeReceivedEventArgs e)
        {
            if (this.IsDisposed || this.Disposing) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (e.Item != null && e.Item.Value != null)
                {
                    double currentTemp = Convert.ToDouble(e.Item.Value.Value);
                    lblOvenTempValue.Text = $"{currentTemp:F1} °C";
                }
            });
        }

        private void btnStartPro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWorkOrderCode.Text))
            {
                MessageBox.Show("Please select a Work Order from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConnectToOPC();
            alarmTimer.Stop();
            this.BackColor = SystemColors.Control;
        }

        private void btnStopProduction_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTargetQty.Text))
            {
                string[] parts = lblCurrentCountValue.Text.Split('/');
                int currentCount = parts.Length > 0 ? Convert.ToInt32(parts[0].Trim()) : 0;
                int targetQty = Convert.ToInt32(txtTargetQty.Text);

                if (currentCount < targetQty)
                {
                    int scrapCount = targetQty - currentCount;
                    LogToConsole($"PRODUCTION STOPPED: Target was {targetQty}, Completed: {currentCount}. Scrap detected: {scrapCount} units.");
                    MessageBox.Show($"Production stopped early! Scrap units detected: {scrapCount}", "Scrap Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async Task LoadActiveWorkOrders()
        {
            try
            {
                string apiURL = "https://localhost:7088/api/WorkOrders/GetReleasedWO";
                var response = await client.GetAsync(apiURL);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var workOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WorkOrderDTO>>(jsonString);
                    dgvWorkOrders.DataSource = workOrders;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not connect to ERP Server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvWorkOrders.Columns["WorkOrderCode"].HeaderText = "Order Code";
            dgvWorkOrders.Columns["ProductName"].HeaderText = "Item Name";
            dgvWorkOrders.Columns["TargetQuantity"].HeaderText = "Target Qty";
            dgvWorkOrders.Columns["TargetTemperature"].HeaderText = "Target Temp (°C)";
            dgvWorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvWorkOrders.Columns[dgvWorkOrders.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void OpcUaForm_Load(object sender, EventArgs e) => await LoadActiveWorkOrders();

        private void dgvWorkOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWorkOrders.Rows[e.RowIndex];
                txtWorkOrderCode.Text = row.Cells["WorkOrderCode"].Value?.ToString() ?? "";
                txtItemName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                txtTargetQty.Text = row.Cells["TargetQuantity"].Value?.ToString() ?? "0";
                numTargetTemp.Value = Convert.ToDecimal(row.Cells["TargetTemperature"].Value ?? 0);
                lblCurrentCountValue.Text = $"0 / {txtTargetQty.Text}";
            }
        }
        private void PlayIndustrialAlarm()
        {
            
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(1500, 150); 
                Console.Beep(1000, 150); 
            }
        }

        private void btnStopProduction_Click_1(object sender, EventArgs e)
        {
           
            if (opcClient == null || opcClient.State != OpcClientState.Connected)
            {
                LogToConsole("Warning: Cannot send STOP command. OPC UA Server is not connected.");
                return;
            }

            try
            {
                LogToConsole("🚨 CRITICAL ACTION: Operator pressed PAUSE/STOP Production!");

                var stopMachineNode = new OpcWriteNode("ns=3;i=1008", false);
                opcClient.WriteNodes(stopMachineNode);
                LogToConsole("System [PLC]: Sent STOP command to Node i=1008");

                if (counterSubscription != null)
                {
                    counterSubscription.Unsubscribe();
                    LogToConsole("System: Counter live subscription paused.");
                }

                MachineStatusLED.LedColor = Color.Red;
                MachineStatusLED.IsOn = true;
                OpcStatusLED.LedColor = Color.Red;
                OpcStatusLED.IsOn = true;

                alarmTimer.Start();

                if (!string.IsNullOrEmpty(txtTargetQty.Text))
                {
                    string[] parts = lblCurrentCountValue.Text.Split('/');
                    int currentCount = parts.Length > 0 ? Convert.ToInt32(parts[0].Trim()) : 0;
                    int targetQty = Convert.ToInt32(txtTargetQty.Text);
                    int scrapCount = targetQty - currentCount;

                    MessageBox.Show($"🚨 EMERGENCY STOP TRIGGERED!\nProduction halted early.\nScrap/Missing: {scrapCount} units.",
                                    "Emergency Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                LogToConsole($"Error during manual stop: {ex.Message}");
            }
        }

        private void alarmTimer_Tick(object sender, EventArgs e)
        {
            isAlarmColorToggle = !isAlarmColorToggle;

            if (isAlarmColorToggle)
            {
                this.BackColor = Color.Red;

                Console.Beep(1200, 200);
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (alarmTimer.Enabled)
            {
                alarmTimer.Stop(); 
                this.BackColor = Color.Khaki; 
                LogToConsole("Operator acknowledged the alarm. Siren muted.");
            }
        }
    }
}