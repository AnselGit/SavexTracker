using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SavexTracker;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

public static class DonutChartBuilder
{
    public static void Build(Panel targetPanel)
    {
        double savings = 0;
        double expenses = 0;

        using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
        {
            conn.Open();

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM savings", conn))
                savings = Convert.ToDouble(cmd.ExecuteScalar());

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM expenses", conn))
                expenses = Convert.ToDouble(cmd.ExecuteScalar());
        }

        var model = new PlotModel
        {
            Background = OxyColor.FromRgb(240, 227, 255),
            PlotAreaBorderColor = OxyColors.Transparent
        };

        var pieSeries = new PieSeries
        {
            InnerDiameter = 0.6,
            Stroke = OxyColors.White,
            StrokeThickness = 2,
            AngleSpan = 360,
            StartAngle = 0,
            InsideLabelFormat = "{1}\n₱{0:0.##}",
            OutsideLabelFormat = null,
            TextColor = OxyColors.DimGray
        };

        pieSeries.Slices.Add(new PieSlice("Savings", savings)
        {
            Fill = OxyColor.FromRgb(104, 74, 255) // Custom savings color
        });

        pieSeries.Slices.Add(new PieSlice("Expenses", expenses)
        {
            Fill = OxyColor.FromRgb(192, 192, 255) // Custom expenses color
        });

        model.Series.Add(pieSeries);

        var plotView = new PlotView
        {
            Dock = DockStyle.Fill,
            Model = model,
            BackColor = Color.FromArgb(255, 255, 255)
        };

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(plotView);
    }
}
