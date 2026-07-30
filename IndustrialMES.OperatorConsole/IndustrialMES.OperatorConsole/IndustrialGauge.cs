using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Nexera.MES.StationConsole
{
    public class IndustrialGauge : Control
    {
        public float Minimum { get; set; } = 0;
        public float Maximum { get; set; } = 2000;

        private float _value = 0;
        public float Value
        {
            get => _value;
            set { _value = Math.Max(Minimum, Math.Min(Maximum, value)); Invalidated(); }
        }

        public string Title { get; set; } = "RPM";
        public string Unit { get; set; } = "RPM";

        public IndustrialGauge()
        {
            this.Size = new Size(180, 150);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        private void Invalidated() => this.Invalidate();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int width = this.Width;
            int height = this.Height;
            Rectangle rect = new Rectangle(10, 10, width - 20, width - 20);
            using (Pen bgPen = new Pen(Color.FromArgb(210, 215, 220), 14))
            {
                g.DrawArc(bgPen, rect, 180, 180);
            }

            using (Pen greenPen = new Pen(Color.ForestGreen, 12))
                g.DrawArc(greenPen, rect, 180, 100);

            using (Pen yellowPen = new Pen(Color.Orange, 12))
                g.DrawArc(yellowPen, rect, 280, 45);

            using (Pen redPen = new Pen(Color.Crimson, 12))
                g.DrawArc(redPen, rect, 325, 35);

            float currentNormalized = (_value - Minimum) / (Maximum - Minimum);
            float angle = 180 + (currentNormalized * 180);

            int cx = width / 2;
            int cy = rect.Y + (rect.Height / 2);
            int needleLength = (rect.Width / 2) - 15;

            double rad = angle * Math.PI / 180.0;
            int endX = cx + (int)(needleLength * Math.Cos(rad));
            int endY = cy + (int)(needleLength * Math.Sin(rad));

            using (Pen needlePen = new Pen(Color.Red, 3))
            {
                g.DrawLine(needlePen, cx, cy, endX, endY);
            }

            g.FillEllipse(Brushes.DarkGray, cx - 6, cy - 6, 12, 12);
            using (Font titleFont = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font valFont = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                SizeF titleSize = g.MeasureString(Title, titleFont);
                g.DrawString(Title, titleFont, Brushes.Black, cx - (titleSize.Width / 2), cy + 15);

                string valText = $"{_value:F1} {Unit}";
                SizeF valSize = g.MeasureString(valText, valFont);
                g.DrawString(valText, valFont, Brushes.DarkBlue, cx - (valSize.Width / 2), cy + 32);
            }
        }
    }
}