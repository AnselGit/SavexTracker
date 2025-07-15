using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SavexTracker;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

public static class ChartBuilder
{
    public static void BuildLineGraph(Panel targetPanel)
    {
        var savingsData = new Dictionary<int, double>();
        var expensesData = new Dictionary<int, double>();

        int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        for (int day = 1; day <= daysInMonth; day++)
        {
            savingsData[day] = 0;
            expensesData[day] = 0;
        }

        string format = "MM/dd/yy";
        CultureInfo provider = CultureInfo.InvariantCulture;

        using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
        {
            conn.Open();

            // Read savings
            using (var cmd = new SQLiteCommand("SELECT timestamp, amount FROM savings", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string rawTimestamp = reader["timestamp"].ToString();
                    if (DateTime.TryParseExact(rawTimestamp, format, provider, DateTimeStyles.None, out DateTime date))
                    {
                        if (date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year)
                        {
                            int day = date.Day;
                            double amount = Convert.ToDouble(reader["amount"]);
                            savingsData[day] += amount;
                        }
                    }
                }
            }

            // Read expenses
            using (var cmd = new SQLiteCommand("SELECT timestamp, amount FROM expenses", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string rawTimestamp = reader["timestamp"].ToString();
                    if (DateTime.TryParseExact(rawTimestamp, format, provider, DateTimeStyles.None, out DateTime date))
                    {
                        if (date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year)
                        {
                            int day = date.Day;
                            double amount = Convert.ToDouble(reader["amount"]);
                            expensesData[day] += amount;
                        }
                    }
                }
            }
        }

        var model = new PlotModel
        {
            Title = "Savings vs Expenses (This Month)",
            PlotAreaBorderColor = OxyColors.Transparent,
            Background = OxyColors.White,
            TextColor = OxyColors.DimGray
        };

        // X Axis (Days)
        model.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Bottom,
            Minimum = 1,
            Maximum = daysInMonth,
            Title = "Day",
            MajorStep = Math.Max(1, daysInMonth / 4),
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            MajorTickSize = 0,
            MinorTickSize = 0,
            TextColor = OxyColors.Gray,
            AxislineColor = OxyColors.LightGray,
            AxislineStyle = LineStyle.Solid,
            AxislineThickness = 1
        });

        // Y Axis (Amount)
        model.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Left,
            Title = "Amount",
            MajorStep = CalculateStep(savingsData, expensesData),
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            MajorTickSize = 0,
            MinorTickSize = 0,
            TextColor = OxyColors.Gray,
            AxislineColor = OxyColors.LightGray,
            AxislineStyle = LineStyle.Solid,
            AxislineThickness = 1
        });

        // Area under Savings
        var savingsArea = new AreaSeries
        {
            Color = OxyColor.FromAColor(100, OxyColor.FromRgb(74, 183, 255)),
            StrokeThickness = 0,
            LineStyle = LineStyle.None
        };

        // Area under Expenses
        var expensesArea = new AreaSeries
        {
            Color = OxyColor.FromAColor(80, OxyColor.FromRgb(137, 74, 255)),
            StrokeThickness = 0,
            LineStyle = LineStyle.None
        };

        foreach (var kv in savingsData)
        {
            savingsArea.Points.Add(new DataPoint(kv.Key, kv.Value));
            savingsArea.Points2.Add(new DataPoint(kv.Key, 0));
        }

        foreach (var kv in expensesData)
        {
            expensesArea.Points.Add(new DataPoint(kv.Key, kv.Value));
            expensesArea.Points2.Add(new DataPoint(kv.Key, 0));
        }

        // Savings Line
        var savingsLine = new LineSeries
        {
            Title = "Savings",
            Color = OxyColor.FromRgb(74, 183, 255),
            MarkerType = MarkerType.Circle,
            MarkerSize = 4,
            MarkerStroke = OxyColors.White,
            StrokeThickness = 4,
            //Smooth = true
        };

        foreach (var kv in savingsData)
            savingsLine.Points.Add(new DataPoint(kv.Key, kv.Value));

        // Expenses Line
        var expensesLine = new LineSeries
        {
            Title = "Expenses",
            Color = OxyColor.FromRgb(137, 74, 255),
            MarkerType = MarkerType.Square,
            MarkerSize = 4,
            MarkerStroke = OxyColors.White,
            StrokeThickness = 4,
            //Smooth = true
        };

        foreach (var kv in expensesData)
            expensesLine.Points.Add(new DataPoint(kv.Key, kv.Value));

        // Add all layers
        model.Series.Add(savingsArea);
        model.Series.Add(expensesArea);
        model.Series.Add(savingsLine);
        model.Series.Add(expensesLine);

        // Render chart
        var plotView = new PlotView
        {
            Dock = DockStyle.Fill,
            Model = model,
            BackColor = targetPanel.BackColor
        };

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(plotView);
    }

    private static double CalculateStep(Dictionary<int, double> savings, Dictionary<int, double> expenses)
    {
        double maxVal = Math.Max(
            savings.Values.Count > 0 ? savings.Values.Max() : 1,
            expenses.Values.Count > 0 ? expenses.Values.Max() : 1
        );

        double rawStep = Math.Ceiling(maxVal / 4);
        return rawStep > 0 ? rawStep : 1;
    }

}
