using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IndustrialMES.OperatorConsole
{
    public class IndustrialLed : Control
    {
        private bool _isOn = false;
        private Color _ledColor = Color.Lime;

        public bool IsOn
        {
            get => _isOn;
            set { _isOn = value; Invalidate(); }
        }

        public Color LedColor
        {
            get => _ledColor;
            set { _ledColor = value; Invalidate(); }
        }

        public IndustrialLed()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Size = new Size(30, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color baseColor = _isOn ? _ledColor : Color.FromArgb(60, _ledColor);
            Color lightColor = _isOn ? Color.White : Color.FromArgb(150, baseColor);
            Rectangle ledRect = new Rectangle(1, 1, Width - 2, Height - 2);
            using (LinearGradientBrush pathBrush = new LinearGradientBrush(ledRect, lightColor, baseColor, LinearGradientMode.ForwardDiagonal))
            {
                g.FillEllipse(pathBrush, ledRect);
            }
            if (_isOn)
            {
                Rectangle reflectionRect = new Rectangle(Width / 4, Height / 4, Width / 3, Height / 3);
                using (LinearGradientBrush refBrush = new LinearGradientBrush(reflectionRect, Color.FromArgb(230, Color.White), Color.Transparent, LinearGradientMode.Vertical))
                {
                    g.FillEllipse(refBrush, reflectionRect);
                }
            }
        }
    }
}