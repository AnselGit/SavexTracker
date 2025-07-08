using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GradientPanelRound : Panel
{
    private Color[] gradientColors = new Color[5]
    {
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Blue
    };

    private float gradientAngle = 45f;
    private int borderRadius = 20;

    [Category("Custom")]
    [Description("The 5 gradient colors used in the background.")]
    public Color Color1 { get => gradientColors[0]; set { gradientColors[0] = value; Invalidate(); } }
    public Color Color2 { get => gradientColors[1]; set { gradientColors[1] = value; Invalidate(); } }
    public Color Color3 { get => gradientColors[2]; set { gradientColors[2] = value; Invalidate(); } }
    public Color Color4 { get => gradientColors[3]; set { gradientColors[3] = value; Invalidate(); } }
    public Color Color5 { get => gradientColors[4]; set { gradientColors[4] = value; Invalidate(); } }

    [Category("Custom")]
    public float GradientAngle
    {
        get => gradientAngle;
        set { gradientAngle = value; Invalidate(); }
    }

    [Category("Custom")]
    public int BorderRadius
    {
        get => borderRadius;
        set { borderRadius = value < 0 ? 0 : value; Invalidate(); }
    }

    public GradientPanelRound()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = this.ClientRectangle;
        if (bounds.Width == 0 || bounds.Height == 0) return;

        using (GraphicsPath path = RoundedRect(bounds, borderRadius))
        using (Brush gradientBrush = CreateMultiGradientBrush(bounds, gradientColors, gradientAngle))
        {
            g.FillPath(gradientBrush, path);
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();

        // Top left
        path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
        // Top right
        path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
        // Bottom right
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        // Bottom left
        path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }

    private Brush CreateMultiGradientBrush(Rectangle bounds, Color[] colors, float angle)
    {
        LinearGradientBrush baseBrush = new LinearGradientBrush(bounds, colors[0], colors[colors.Length - 1], angle, true);

        ColorBlend blend = new ColorBlend
        {
            Colors = colors,
            Positions = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1f }
        };

        baseBrush.InterpolationColors = blend;
        return baseBrush;
    }
}
