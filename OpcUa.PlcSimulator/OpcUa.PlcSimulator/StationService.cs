using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpcUa.PlcSimulator
{
    public class StationService
    {
        private readonly HttpClient _httpClient;
        public StationService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5223/api/")
            };
        }
        public int GetConfiguredStationId()
        {
            string stationIdConfig = ConfigurationManager.AppSettings["WorkCenterId"];
            return int.TryParse(stationIdConfig, out int id) ? id : 1;
        }
        public async Task<JObject> GetStationDetails(int stationId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"OperatorStation/{stationId}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(json);
                }
            }
            catch { }

            return null;
        }
        public async Task<(bool IsSuccess, string OperatorName, string Qualification, string Message)> AuthenticateOperator(string rfidTag)
        {
            try
            {
                var response = await _httpClient.GetAsync($"OperatorStation/VerifyRfid?rfidTag={rfidTag}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    string name = data["Name"]?.ToString() ?? data["name"]?.ToString() ?? "Operator";
                    string qualification = data["qualification"]?.ToString() ?? "";

                    return (true, name, qualification, "Access Granted");
                }

                return (false, null, null, "ACCESS DENIED! Invalid Card or Worker Not Qualified for this Station.");
            }
            catch (Exception ex)
            {
                return (false, null, null, $"API Connection Error: {ex.Message}");
            }
        }
        public async Task<JArray> GetWorkOrdersForStation()
        {
            try
            {
                var response = await _httpClient.GetAsync($"WorkOrders/station");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JArray.Parse(json);
                }
            }
            catch { }

            return new JArray();
        }
        public async Task<bool> StartWorkOrder(int workOrderId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"WorkOrders/{workOrderId}/start", null);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public Panel CreateWorkOrderCard(int woId, string woNumber, string sku, string status, int targetQty)
        {
            Panel card = new Panel
            {
                Width = 260,
                Height = 150,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(235, 238, 242)
            };

            Label lblSku = new Label
            {
                Text = $"SKU: {sku}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            Label lblWoNumber = new Label
            {
                Text = $"Work Order:\n{woNumber}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(43, 137, 160), 
                Top = 40,
                Left = 10,
                AutoSize = true
            };

            Label lblDetails = new Label
            {
                Text = $"Target Qty: {targetQty} pcs\nStatus: {status}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.DarkGray,
                Top = 90,
                Left = 10,
                AutoSize = true
            };

            card.Controls.Add(lblDetails);
            card.Controls.Add(lblWoNumber);
            card.Controls.Add(lblSku);

            return card;
        }
    }
}