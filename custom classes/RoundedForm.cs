using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class BlurredRoundedForm : Form
{
    public int BorderRadius { get; set; } = 30;
    public bool EnableBlur { get; set; } = true;
    public bool EnableShadow { get; set; } = true;

    // DWM API structs & constants
    [StructLayout(LayoutKind.Sequential)]
    private struct DWM_BLURBEHIND
    {
        public DwmBlurBehindFlags dwFlags;
        public bool fEnable;
        public IntPtr hRgnBlur;
        public bool fTransitionOnMaximized;
    }

    [Flags]
    private enum DwmBlurBehindFlags : uint
    {
        DWM_BB_ENABLE = 0x1,
        DWM_BB_BLURREGION = 0x2,
        DWM_BB_TRANSITIONONMAXIMIZED = 0x4
    }

    [DllImport("dwmapi.dll")]
    private static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND blurBehind);

    public BlurredRoundedForm()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.DoubleBuffered = true;
        this.BackColor = Color.White;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (EnableBlur && Environment.OSVersion.Version.Major >= 6) // Vista+
        {
            DWM_BLURBEHIND bb = new DWM_BLURBEHIND
            {
                dwFlags = DwmBlurBehindFlags.DWM_BB_ENABLE,
                fEnable = true,
                hRgnBlur = IntPtr.Zero
            };
            DwmEnableBlurBehindWindow(this.Handle, ref bb);
        }
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
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        ApplyRoundedRegion();
    }

    private void ApplyRoundedRegion()
    {
        Rectangle rect = this.ClientRectangle;
        using (GraphicsPath path = new GraphicsPath())
        {
            int r = BorderRadius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
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
