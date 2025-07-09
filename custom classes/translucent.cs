using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class BlurredRoundedForm : Form
{
    public int BorderRadius { get; set; } = 30;
    public bool EnableShadow { get; set; } = true;
    public bool EnableBlur { get; set; } = true;
    public Color BorderColor { get; set; } = Color.Blue; // Default border color


    public BlurredRoundedForm()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.DoubleBuffered = true;
        this.BackColor = Color.White;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        if (EnableBlur)
        {
            EnableBlurEffect(); // New method
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

    private void EnableBlurEffect()
    {
        var accent = new AccentPolicy
        {
            AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND,
            GradientColor = 0x990000 // Optional tint
        };

        int size = Marshal.SizeOf(accent);
        IntPtr pAccent = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(accent, pAccent, false);

        var data = new WindowCompositionAttributeData
        {
            Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            SizeOfData = size,
            Data = pAccent
        };

        SetWindowCompositionAttribute(this.Handle, ref data);
        Marshal.FreeHGlobal(pAccent);
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

    // Accent Policy definitions
    private enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
        ACCENT_ENABLE_HOSTBACKDROP = 5,
        ACCENT_INVALID_STATE = 6
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct AccentPolicy
    {
        public AccentState AccentState;
        public int Flags;
        public int GradientColor; // ARGB
        public int AnimationId;
    }

    private enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    [DllImport("user32.dll")]
    private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
}
