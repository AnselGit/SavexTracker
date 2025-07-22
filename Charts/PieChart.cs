using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SavexTracker;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using SavexTracker.Database;

// Provides methods to build a donut chart comparing total savings and expenses.
public static class DonutChartBuilder
{
    // Builds and displays a donut chart of total savings vs expenses in the specified panel.
    /// <param name="targetPanel">The panel to display the chart in.</param>
    public static void Build(Panel targetPanel)
    {
        double savings = CRUD.GetTotalSavings();
        double expenses = CRUD.GetTotalExpenses();

        var model = new PlotModel
        {
            Background = OxyColor.FromRgb(255, 255, 255),
            PlotAreaBorderColor = OxyColors.Transparent
        };

        var pieSeries = new PieSeries
        {
            InnerDiameter = 0.6,
            Stroke = OxyColors.White,
            StrokeThickness = 4,
            AngleSpan = 360,
            StartAngle = 0,
            InsideLabelFormat = "{1}\n₱{0:0.##}",
            OutsideLabelFormat = null,
            TextColor = OxyColors.Black, 
            Font = "Noto Sans",
            FontSize = 14,
            FontWeight = 500
        };

        pieSeries.Slices.Add(new PieSlice("Savings", savings)
        {            
            Fill = OxyColor.FromRgb(179, 219, 255)
        });

        pieSeries.Slices.Add(new PieSlice("Expenses", expenses)
        {
            Fill = OxyColor.FromRgb(207, 179, 255)
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
