using Nexera.MES.StationConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialMES.OperatorConsole
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form testForm = new Form
            {
                Text = "PLC Monitor Test",
                Width = 1000,
                Height = 650,
                StartPosition = FormStartPosition.CenterScreen
            };

            UcPlcExecutionMonitor plcMonitor = new UcPlcExecutionMonitor { Dock = DockStyle.Fill };
            testForm.Controls.Add(plcMonitor);

            Application.Run(testForm);
        }
    }
}
