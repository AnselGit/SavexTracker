using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SavexTracker;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

public static class DonutChartGoalVsTotalBuilder
{
    public static void Build(Panel targetPanel)
    {
        double totalSavings = 0;
        double totalExpenses = 0;
        double goalAmount = 0;

        using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
        {
            conn.Open();

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM savings", conn))
                totalSavings = Convert.ToDouble(cmd.ExecuteScalar());

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM expenses", conn))
                totalExpenses = Convert.ToDouble(cmd.ExecuteScalar());

            using (var cmd = new SQLiteCommand("SELECT IFNULL(amount, 0) FROM goal ORDER BY gid DESC LIMIT 1", conn))
                goalAmount = Convert.ToDouble(cmd.ExecuteScalar());
        }

        double grandTotal = totalSavings - totalExpenses;
        if (grandTotal < 0) grandTotal = 0;

        // Create PlotModel with custom background
        var model = new PlotModel
        {
            Background = OxyColor.FromRgb(240, 227, 255), // Light purple background
            PlotAreaBorderColor = OxyColors.Transparent
        };

        var pieSeries = new PieSeries
        {
            InnerDiameter = 0.6,
            Stroke = OxyColors.White,
            StrokeThickness = 2,
            AngleSpan = 360,
            StartAngle = 0,
            OutsideLabelFormat = "{1}: ₱{0:0.##}"
        };

        pieSeries.Slices.Add(new PieSlice("Grand Total", grandTotal)
        {
            Fill = OxyColor.FromRgb(207, 179, 255) // Custom purple
        });

        pieSeries.Slices.Add(new PieSlice("Goal", goalAmount)
        {
            Fill = OxyColor.FromRgb(179, 219, 255) // Custom blue
        });

        model.Series.Add(pieSeries);

        var plotView = new PlotView
        {
            Dock = DockStyle.Fill,
            Model = model,
            BackColor = Color.FromArgb(240, 227, 255) // Match panel bg
        };

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(plotView);
    }
}
