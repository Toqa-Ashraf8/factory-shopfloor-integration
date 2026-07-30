using IndustrialMES.OperatorConsole;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nexera.MES.StationConsole
{
    public partial class UcPlcExecutionMonitor : UserControl
    {
        public UcPlcExecutionMonitor()
        {
            InitializeComponent();

            // أول ما الشاشة تفتح تعرض البيانات الافتراضية للتجربة
            LoadDummyHeaderData();
        }

        /// <summary>
        /// دالة مؤقتة لتوليد بيانات افتراضية للـ Header عشان نشوف التصميم
        /// </summary>
        private void LoadDummyHeaderData()
        {
            // pnlTopHeader هو FlowLayoutPanel محطوط فوق في الشاشة 
            // Dock = Top, AutoScroll = true, FlowDirection = LeftToRight
            pnlTopHeader.Controls.Clear();

            // أسماء افتراضية لت تجربة التصميم
            pnlTopHeader.Controls.Add(CreateTopParameterHeaderItem("Shielding_Gas_Flow", true, true));
            pnlTopHeader.Controls.Add(CreateTopParameterHeaderItem("Bearing_Press_Force", true, false));
            pnlTopHeader.Controls.Add(CreateTopParameterHeaderItem("Motor_Test_RPM", true, true));
            pnlTopHeader.Controls.Add(CreateTopParameterHeaderItem("Cooling_Temp", false, false));
        }

        /// <summary>
        /// دالة بناء الـ Panel المصغر لكل Parameter
        /// </summary>
        private Panel CreateTopParameterHeaderItem(string paramName, bool status1, bool status2)
        {
            Panel pnl = new Panel
            {
                Size = new Size(220, 45),
                Margin = new Padding(5),
                BackColor = Color.FromArgb(225, 230, 235),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblName = new Label
            {
                Text = paramName,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Location = new Point(6, 13),
                AutoSize = true
            };

            // اللمبة الأولى (حالة الجهاز / Online)
            IndustrialLed led1 = new IndustrialLed
            {
                Size = new Size(18, 18),
                Location = new Point(160, 12),
                LedColor = status1 ? Color.Lime : Color.Red,
                IsOn = true
            };

            // اللمبة الثانية (حالة الـ Value / In Range)
            IndustrialLed led2 = new IndustrialLed
            {
                Size = new Size(18, 18),
                Location = new Point(188, 12),
                LedColor = status2 ? Color.Lime : Color.Gray,
                IsOn = true
            };

            pnl.Controls.Add(lblName);
            pnl.Controls.Add(led1);
            pnl.Controls.Add(led2);

            return pnl;
        }
    }
}