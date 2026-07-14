using System;
using System.Windows.Forms;
using Opc.UaFx.Client;
using System.Collections.Generic;
using Opc.UaFx;

namespace OpcUa.PlcSimulator
{
    public partial class OpcUaForm : Form
    {
        private OpcClient opcClient;
        public OpcUaForm()
        {
            InitializeComponent();
            txtOpcUrl.Text = "opc.tcp://DESKTOP-5RMLPFJ:53530/OPCUA/SimulationServer";
            lblStatus.Text = "Status: Disconnected";
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }

        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                opcClient = new OpcClient(txtOpcUrl.Text);
                opcClient.Connect();
                lblStatus.Text = "Status: Connected to OPC UA!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                opcTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void opcTimer_Tick(object sender, EventArgs e)
        {
            if (opcClient != null && opcClient.State == OpcClientState.Connected)
            {
                try
                {
                    string constantNodeId = "ns=3;i=1007"; 
                    string counterNodeId = "ns=3;i=1001";
                    string randomNodeId = "ns=3;i=1002";
                    string sawtoothNodeId = "ns=3;i=1003";
                    string sinusoidNodeId = "ns=3;i=1004";
                    string squareNodeId = "ns=3;i=1005";
                    string triangleNodeId = "ns=3;i=1006";

                    IEnumerable<OpcValue> myNodesCollection = opcClient.ReadNodes(new OpcNodeId[] 
                    { 
                        constantNodeId, 
                        counterNodeId, 
                        randomNodeId, 
                        sawtoothNodeId, 
                        sinusoidNodeId, 
                        squareNodeId, 
                        triangleNodeId 
                    });
                    var valuesList = System.Linq.Enumerable.ToList(myNodesCollection);
                    
                    if (valuesList.Count > 0 && valuesList[1] != null && valuesList[1].Value != null)
                    {
                        lblTemperature.Text = valuesList[1].Value.ToString() + " °C";
                    }
                    
                }
                catch (Exception ex)
                {
                    opcTimer.Stop();
                    MessageBox.Show("Error reading nodes: " + ex.Message, "OPC Read Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblStatus.Text = "Status: Error Reading!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (opcClient != null)
            {
                opcTimer.Stop();
                opcClient.Disconnect();
                lblStatus.Text = "Status: Disconnected";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
