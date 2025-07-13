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
    // Public method to build and insert donut chart into a given Panel
    public static void Build(Panel targetPanel)
    {
        double savings = 0;
        double expenses = 0;

        // Read data from SQLite
        using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
        {
            conn.Open();

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount),0) FROM savings", conn))
            {
                savings = Convert.ToDouble(cmd.ExecuteScalar());
            }

            using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount),0) FROM expenses", conn))
            {
                expenses = Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        // Create PlotModel
        var model = new PlotModel
        {
            Background = OxyColors.White,
            PlotAreaBorderColor = OxyColors.Transparent
        };

        var pieSeries = new PieSeries
        {
            InnerDiameter = 0.6, // Donut hole
            Stroke = OxyColors.White,
            StrokeThickness = 2,
            AngleSpan = 360,
            StartAngle = 0,
            OutsideLabelFormat = "{1}: {0:0.##}"
        };

        pieSeries.Slices.Add(new PieSlice("Savings", savings)
        {
            Fill = OxyColor.FromRgb(104, 74, 255)
        });

        pieSeries.Slices.Add(new PieSlice("Expenses", expenses)
        {
            Fill = OxyColor.FromRgb(192, 192, 255)
        });

        model.Series.Add(pieSeries);

        var plotView = new PlotView
        {
            Dock = DockStyle.Fill,
            Model = model,
            BackColor = Color.White // Don't use Color.Transparent
        };

        // Replace existing chart in the panel
        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(plotView);
    }
}
