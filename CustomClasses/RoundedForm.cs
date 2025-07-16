using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SavexTracker.CustomClasses
{
    public class SolidRoundedForm : Form
    {
        public int BorderRadius { get; set; } = 70;
        public bool EnableShadow { get; set; } = true;
        public Color BorderColor { get; set; } = Color.DodgerBlue; 

        public SolidRoundedForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.BackColor = Color.White; // Or set in Designer
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (EnableShadow)
                {
                    cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
                }
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ApplyRoundedRegion();

            // Optional: draw a 1px border using the BorderColor
            using (Pen borderPen = new Pen(BorderColor, 1))
            {
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedRegion();
            this.Invalidate(); // Repaint on resize
        }

        private void ApplyRoundedRegion()
        {
            this.Region = new Region(GetRoundedPath(this.ClientRectangle, BorderRadius));
        }

        private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = radius;
            path.AddArc(bounds.X, bounds.Y, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Y, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
