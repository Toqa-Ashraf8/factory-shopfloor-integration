using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EasyModbus;

namespace Modbus.PlcSimulator
{
    public partial class FormEasyModbus : Form
    {
        private ModbusClient modbusClient;
        public FormEasyModbus()
        {
            InitializeComponent();
        }

        private void FormEasyModbus_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIpAddress.Text.ToString();
                int port = Convert.ToInt32(txtPort.Text);
                modbusClient = new ModbusClient(ip, port);
                modbusClient.Connect();
                if (modbusClient.Connected)
                {
                    timer1.Start();
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    MessageBox.Show("Connected successfully to PLC!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if(modbusClient!=null && modbusClient.Connected)
                {
                    int[] registers = modbusClient.ReadHoldingRegisters(0, 4);
                    lblTemperature.Text = registers[0].ToString() + " °C ";
                    lblConveyorSpeed.Text = registers[1].ToString() + " RPM ";
                    lblAirPressure.Text = registers[2].ToString() + " Bar ";
                    lblLineEfficiency.Text = registers[3].ToString() + " % ";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show($"Lost connection: {ex.Message}", "Network Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (modbusClient != null && modbusClient.Connected)
            {
                modbusClient.Disconnect();
                timer1.Stop();
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }
    }
}
