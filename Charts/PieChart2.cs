using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SavexTracker;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using SavexTracker.Database;

public static class DonutChartGoalVsTotalBuilder
{
    public static void Build(Panel targetPanel)
    {
        double totalSavings = CRUD.GetTotalSavings();
        double totalExpenses = CRUD.GetTotalExpenses();
        double goalAmount = CRUD.GetLatestGoalAmount();

        double grandTotal = totalSavings - totalExpenses;
        if (grandTotal < 0) grandTotal = 0;

        var model = new PlotModel
        {
            Background = OxyColor.FromRgb(240, 227, 255),
            PlotAreaBorderColor = OxyColors.Transparent
        };

        var pieSeries = new PieSeries
        {
            InnerDiameter = 0.8,
            Stroke = OxyColor.FromRgb(240, 227, 255),
            StrokeThickness = 6,
            AngleSpan = 360,
            StartAngle = 0,
            InsideLabelFormat = "{1}\n₱{0:0.##}", 
            OutsideLabelFormat = null,           
            TextColor = OxyColors.DimGray        
        };

        pieSeries.Slices.Add(new PieSlice("Grand Total", grandTotal)
        {
            Fill = OxyColors.SlateBlue
        });

        pieSeries.Slices.Add(new PieSlice("Goal", goalAmount)
        {           
            Fill = OxyColor.FromRgb(128, 128, 255)
        });

        model.Series.Add(pieSeries);

        var plotView = new PlotView
        {
            Dock = DockStyle.Fill,
            Model = model,            
            BackColor = Color.FromArgb(192, 192, 255)
        };

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(plotView);
    }
}
