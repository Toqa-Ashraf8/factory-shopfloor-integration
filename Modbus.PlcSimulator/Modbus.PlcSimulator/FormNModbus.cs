using System;
using System.Net.Sockets;
using System.Windows.Forms;
using NModbus;

namespace Modbus.PlcSimulator
{
    public partial class FormNModbus : Form
    {
        TcpClient tcpClient;
        IModbusMaster modbusMaster;

        public FormNModbus()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //string ip = txtIpAddress.Text;
                //int port = Convert.ToInt32(txtPort.Text);
                string ip = "127.0.0.1";
                int port = 502;

                tcpClient = new TcpClient(ip, port);

                var factory = new ModbusFactory();
                modbusMaster = factory.CreateMaster(tcpClient);

                timer1.Start();

                MessageBox.Show("Connected successfully via NModbus!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (tcpClient != null && tcpClient.Connected && modbusMaster != null)
                {
                    byte slaveId = 1;
                    ushort startAddress = Convert.ToUInt16(txtRegisterAddress.Text); 
                    ushort numberOfPoints = 5; 

                    ushort[] registers = modbusMaster.ReadHoldingRegisters(slaveId, startAddress, numberOfPoints);

                    lblProductionCount.Text = registers[0].ToString();
                    lblTemperature.Text = registers[1].ToString() + " °C ";
                    lblConveyorSpeed.Text = registers[2].ToString() + " RPM ";
                    lblAirPressure.Text = registers[3].ToString() + " Bar ";
                    lblLineEfficiency.Text = registers[4].ToString() + " % ";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show($"Lost connection to PLC: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (tcpClient != null)
            {
                tcpClient.Close();
                MessageBox.Show("Disconnected. Monitoring stopped.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}