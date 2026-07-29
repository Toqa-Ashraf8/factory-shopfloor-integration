//using Opc.Ua;
//using Opc.Ua.Client;
//using Opc.UaFx;
//using Opc.UaFx.Client;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Drawing;

//namespace OpcUa.PlcSimulator
//{
//    public partial class OpcUaForm_ : Form
//    {
//        HttpClient client = new HttpClient();
//        private OpcClient opcClient;
//        private OpcSubscription counterSubscription;
//        private OpcSubscription tempSubscription;
//        private bool isAlarmColorToggle = false;

//        public enum LogType
//        {
//            Info,
//            Warning,
//            Error
//        }

//        public OpcUaForm_()
//        {
//            InitializeComponent();
//        }

//        private void LogToConsole(string message, LogType type = LogType.Info)
//        {
//            if (tabPage1.IsDisposed || tabPage1.Disposing) return;

//            tabPage1.Invoke((MethodInvoker)delegate {
//                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

//                if (rtbConsoleLog.Lines.Length > 100)
//                {
//                    string[] currentLines = rtbConsoleLog.Lines;
//                    string[] newLines = new string[80];
//                    Array.Copy(currentLines, 20, newLines, 0, 80);
//                    rtbConsoleLog.Lines = newLines;
//                }

//                rtbConsoleLog.SelectionStart = rtbConsoleLog.TextLength;
//                rtbConsoleLog.SelectionLength = 0;

//                rtbConsoleLog.SelectionColor = Color.DarkGray;
//                rtbConsoleLog.AppendText($"[{timestamp}] ");

//                switch (type)
//                {
//                    case LogType.Info:
//                        rtbConsoleLog.SelectionColor = Color.White;
//                        break;
//                    case LogType.Warning:
//                        rtbConsoleLog.SelectionColor = Color.Orange;
//                        break;
//                    case LogType.Error:
//                        rtbConsoleLog.SelectionColor = Color.Red;
//                        break;
//                }

//                rtbConsoleLog.AppendText($"{message}{Environment.NewLine}");
//                rtbConsoleLog.ScrollToCaret();
//            });
//        }

//        private void ConnectToOPC()
//        {
//            try
//            {
//                opcClient = new OpcClient("opc.tcp://DESKTOP-5RMLPFJ:53530/OPCUA/SimulationServer");
//                opcClient.Connect();

//                OpcStatusLED.LedColor = Color.Lime;
//                OpcStatusLED.IsOn = true;

//                MachineStatusLED.LedColor = Color.Lime;
//                MachineStatusLED.IsOn = true;

//                tabPage1.BackColor = SystemColors.Control;
//                LogToConsole("System: Connected to OPC UA Server successfully.", LogType.Info);

//                counterSubscription = opcClient.SubscribeDataChange("ns=3;i=1001", HandleCounterChanged);
//                tempSubscription = opcClient.SubscribeDataChange("ns=3;i=1008", HandleTemperatureChanged);

//                LogToConsole("System: Live monitoring activated for Counter and Temperature.", LogType.Info);
//            }
//            catch (Exception ex)
//            {
//                OpcStatusLED.LedColor = Color.Red;
//                OpcStatusLED.IsOn = true;
//                MachineStatusLED.LedColor = Color.Red;
//                MachineStatusLED.IsOn = true;
//                tabPage1.BackColor = Color.MistyRose;

//                LogToConsole($"CRITICAL ERROR: PLC Connection Lost! {ex.Message}", LogType.Error);
//                MessageBox.Show("OPC UA Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void HandleCounterChanged(object sender, OpcDataChangeReceivedEventArgs e)
//        {
//            if (tabPage1.IsDisposed || tabPage1.Disposing) return;

//            tabPage1.Invoke((MethodInvoker)delegate
//            {
//                if (e.Item != null && e.Item.Value != null)
//                {
//                    int currentCountFromPLC = Convert.ToInt32(e.Item.Value.Value);
//                    int targetQty = Convert.ToInt32(txtTargetQty.Text);

//                    if (currentCountFromPLC <= targetQty)
//                    {
//                        lblCurrentCountValue.Text = $"{currentCountFromPLC} / {targetQty}";
//                    }

//                    if (currentCountFromPLC >= targetQty)
//                    {
//                        lblCurrentCountValue.Text = $"{targetQty} / {targetQty}";

//                        LogToConsole("SUCCESS: Production Target Reached! Stopping the node counter...", LogType.Warning);

//                        try
//                        {
//                            if (opcClient != null && opcClient.State == OpcClientState.Connected)
//                            {
//                                var resetCounterNode = new OpcWriteNode("ns=3;i=1001", 0);
//                                opcClient.WriteNodes(resetCounterNode);
//                                LogToConsole("System: Sent Reset command to Node i=1001 to stop counting.", LogType.Info);

//                                var stopNode = new OpcWriteNode("ns=3;i=1009", false);
//                                opcClient.WriteNodes(stopNode);
//                            }
//                        }
//                        catch (Exception ex)
//                        {
//                            LogToConsole($"PLC Stop Error: {ex.Message}", LogType.Error);
//                        }

//                        MachineStatusLED.LedColor = Color.Gray;
//                        MachineStatusLED.IsOn = false;

//                        if (counterSubscription != null)
//                        {
//                            counterSubscription.Unsubscribe();
//                            LogToConsole("System: Counter subscription paused.", LogType.Info);
//                        }

//                        tabPage1.BackColor = Color.LightGreen;
//                        PlayIndustrialAlarm();

//                        MessageBox.Show("Production Target Reached Successfully!\nMachine and Counter Node stopped.",
//                                        "Order Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            });
//        }

//        private void HandleTemperatureChanged(object sender, OpcDataChangeReceivedEventArgs e)
//        {
//            if (this.IsDisposed || this.Disposing) return;

//            this.Invoke((MethodInvoker)delegate
//            {
//                if (e.Item != null && e.Item.Value != null)
//                {
//                    double currentTemp = Convert.ToDouble(e.Item.Value.Value);
//                    lblOvenTempValue.Text = $"{currentTemp:F1} °C";
//                }
//            });
//        }

//        private async Task LoadActiveWorkOrders()
//        {
//            try
//            {
//                string apiURL = "https://localhost:7088/api/WorkOrders/GetReleasedWO";
//                var response = await client.GetAsync(apiURL);
//                if (response.IsSuccessStatusCode)
//                {
//                    string jsonString = await response.Content.ReadAsStringAsync();
//                    var workOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WorkOrderDTO>>(jsonString);
//                    dgvWorkOrders.DataSource = workOrders;
//                    FormatDataGridView();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Could not connect to ERP Server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void FormatDataGridView()
//        {
//            dgvWorkOrders.Columns["WorkOrderCode"].HeaderText = "Order Code";
//            dgvWorkOrders.Columns["ProductName"].HeaderText = "Item Name";
//            dgvWorkOrders.Columns["TargetQuantity"].HeaderText = "Target Qty";
//            dgvWorkOrders.Columns["TargetTemperature"].HeaderText = "Target Temp (°C)";
//            dgvWorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
//            dgvWorkOrders.Columns[dgvWorkOrders.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
//        }

//        private async void OpcUaForm_Load(object sender, EventArgs e) => await LoadActiveWorkOrders();

//        private void PlayIndustrialAlarm()
//        {
//            for (int i = 0; i < 3; i++)
//            {
//                Console.Beep(1500, 150);
//                Console.Beep(1000, 150);
//            }
//        }

//        private void alarmTimer_Tick(object sender, EventArgs e)
//        {
//            isAlarmColorToggle = !isAlarmColorToggle;

//            if (isAlarmColorToggle)
//            {
//                tabPage1.BackColor = Color.Red;
//                Console.Beep(1200, 200);
//            }
//            else
//            {
//                tabPage1.BackColor = SystemColors.Control;
//            }
//        }

//        private void recipeManagementToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            tabControl1.SelectedIndex = 1;
//        }

//        private void mainDashboardToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            tabControl1.SelectedIndex = 0;
//        }

//        private void dgvWorkOrders_CellClick_1(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                DataGridViewRow row = dgvWorkOrders.Rows[e.RowIndex];
//                txtWorkOrderCode.Text = row.Cells["WorkOrderCode"].Value?.ToString() ?? "";
//                txtItemName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
//                txtTargetQty.Text = row.Cells["TargetQuantity"].Value?.ToString() ?? "0";
//                numTargetTemp.Value = Convert.ToDecimal(row.Cells["TargetTemperature"].Value ?? 0);
//                lblCurrentCountValue.Text = $"0 / {txtTargetQty.Text}";
//            }
//        }

//        private void btnWriteSettingss_Click_1(object sender, EventArgs e)
//        {
//            if (opcClient == null || opcClient.State != OpcClientState.Connected)
//            {
//                LogToConsole("Error: OPC UA Server is not connected!", LogType.Error);
//                return;
//            }

//            try
//            {
//                double targetTemp = (double)numTargetTemp.Value;
//                var nodeToWrite = new OpcWriteNode("ns=3;i=1008", targetTemp);
//                opcClient.WriteNodes(nodeToWrite);
//                LogToConsole($"Success: Sent Target Temperature ({targetTemp} °C) to PLC.", LogType.Info);
//            }
//            catch (Exception ex)
//            {
//                LogToConsole($"Writing Error: {ex.Message}", LogType.Error);
//            }
//        }

//        private void btnStartPro_Click_1(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtWorkOrderCode.Text))
//            {
//                MessageBox.Show("Please select a Work Order from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }
//            ConnectToOPC();
//            alarmTimer.Stop();
//            tabPage1.BackColor = SystemColors.Control;
//        }

//        private void btnStopProduction_Click_2(object sender, EventArgs e)
//        {
//            if (opcClient == null || opcClient.State != OpcClientState.Connected)
//            {
//                LogToConsole("Warning: Cannot send STOP command. OPC UA Server is not connected.", LogType.Warning);
//                return;
//            }

//            try
//            {
//                LogToConsole("🚨 CRITICAL ACTION: Operator pressed PAUSE/STOP Production!", LogType.Warning);

//                var stopMachineNode = new OpcWriteNode("ns=3;i=1008", false);
//                opcClient.WriteNodes(stopMachineNode);
//                LogToConsole("System [PLC]: Sent STOP command to Node i=1008", LogType.Info);

//                if (counterSubscription != null)
//                {
//                    counterSubscription.Unsubscribe();
//                    LogToConsole("System: Counter live subscription paused.", LogType.Info);
//                }

//                MachineStatusLED.LedColor = Color.Red;
//                MachineStatusLED.IsOn = true;
//                OpcStatusLED.LedColor = Color.Red;
//                OpcStatusLED.IsOn = true;

//                alarmTimer.Start();

//                if (!string.IsNullOrEmpty(txtTargetQty.Text))
//                {
//                    string[] parts = lblCurrentCountValue.Text.Split('/');
//                    int currentCount = parts.Length > 0 ? Convert.ToInt32(parts[0].Trim()) : 0;
//                    int targetQty = Convert.ToInt32(txtTargetQty.Text);
//                    int scrapCount = targetQty - currentCount;

//                    MessageBox.Show($"🚨 EMERGENCY STOP TRIGGERED!\nProduction halted early.\nScrap/Missing: {scrapCount} units.",
//                                    "Emergency Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            catch (Exception ex)
//            {
//                LogToConsole($"Error during manual stop: {ex.Message}", LogType.Error);
//            }
//        }

//        private void btnAlarmStop_Click(object sender, EventArgs e)
//        {
//            if (alarmTimer.Enabled)
//            {
//                alarmTimer.Stop();
//                tabPage1.BackColor = Color.Khaki;
//                LogToConsole("Operator acknowledged the alarm. Siren muted.", LogType.Info);
//            }
//        }

//        private async void btnResetForm_Click(object sender, EventArgs e)
//        {
//            tabPage1.BackColor = SystemColors.Control;

//            txtWorkOrderCode.Clear();
//            txtItemName.Clear();
//            txtTargetQty.Clear();
//            numTargetTemp.Value = 0;

//            lblCurrentCountValue.Text = "0 / 0";
//            lblOvenTempValue.Text = "0.0 °C";

//            await LoadActiveWorkOrders();

//            LogToConsole("System: Dashboard reset successfully. Ready for a new Work Order.", LogType.Info);
//        }

//        private void groupBox4_Enter(object sender, EventArgs e)
//        {

//        }

//        private void tabPage1_Click(object sender, EventArgs e)
//        {

//        }
//    }

 
//}