
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SavexTracker.CustomClasses
{
    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rect = this.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Y, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
    }
}
