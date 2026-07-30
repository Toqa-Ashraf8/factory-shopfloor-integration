using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexera.MES.StationConsole
{
    public class StationConsoleClass
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public const string BaseImageUrl = "http://localhost:5223/Images/InstructionSteps/";
        public const string BaseVideoUrl = "http://localhost:5223/Videos/InstructionSteps/";
        private const string ApiBaseUrl = "http://localhost:5223/api/";

        public int GetConfiguredStationId()
        {
            return 1;
        }
        public async Task<JObject> GetStationDetails(int stationId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}WorkCenters/{stationId}");
                return JObject.Parse(response);
            }
            catch
            {
                return null;
            }
        }

        public async Task<JArray> GetWorkOrdersForStation()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}WorkOrders/station");
                return JArray.Parse(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<JObject> GetWorkOrderExecutionDetails(string sku)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}WorkOrders/product-details/{sku}");
                return JObject.Parse(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public Panel CreateWorkOrderCard(int id, string woNumber, string sku, string status, int qty, Action<int, string, string, int> onClick)
        {
            Panel pnlCard = new Panel
            {
                Width = 220,
                Height = 100,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.White, 
                Cursor = Cursors.Hand
            };
            Panel pnlAccent = new Panel
            {
                Width = 5,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(0, 122, 204)
            };

            Label lblWo = new Label
            {
                Text = woNumber,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 55),
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblSku = new Label
            {
                Text = $"SKU: {sku}",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 110, 125), 
                Location = new Point(15, 40),
                AutoSize = true
            };

            Label lblQty = new Label
            {
                Text = $"Qty: {qty}",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136), 
                Location = new Point(15, 66),
                AutoSize = true
            };

            pnlCard.Controls.Add(pnlAccent);
            pnlCard.Controls.Add(lblWo);
            pnlCard.Controls.Add(lblSku);
            pnlCard.Controls.Add(lblQty);
            EventHandler clickHandler = (s, e) => onClick(id, woNumber, sku, qty);
            pnlCard.Click += clickHandler;
            lblWo.Click += clickHandler;
            lblSku.Click += clickHandler;
            lblQty.Click += clickHandler;
            pnlAccent.Click += clickHandler;

            return pnlCard;
        }
    }
}