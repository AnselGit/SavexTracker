using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration; // For ElementHost
using System.Windows.Media; // For WPF Brushes

public static class BarGraphBuilder
{
    public static void BuildBarGraph(Panel targetPanel)
    {
        var savingsPerMonth = new Dictionary<string, double>();
        var expensesPerMonth = new Dictionary<string, double>();
        var monthLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                  "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        foreach (var label in monthLabels)
        {
            savingsPerMonth[label] = 0;
            expensesPerMonth[label] = 0;
        }

        string format = "MM/dd/yy";
        CultureInfo provider = CultureInfo.InvariantCulture;

        using (var conn = new SQLiteConnection(SavexTracker.AppConfig.ConnectionString))
        {
            conn.Open();

            using (var cmd = new SQLiteCommand("SELECT timestamp, amount FROM savings", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string rawTimestamp = reader["timestamp"].ToString();
                    if (DateTime.TryParseExact(rawTimestamp, format, provider, DateTimeStyles.None, out DateTime date))
                    {
                        string month = date.ToString("MMM", provider);
                        if (savingsPerMonth.ContainsKey(month))
                            savingsPerMonth[month] += Convert.ToDouble(reader["amount"]);
                    }
                }
            }

            using (var cmd = new SQLiteCommand("SELECT timestamp, amount FROM expenses", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string rawTimestamp = reader["timestamp"].ToString();
                    if (DateTime.TryParseExact(rawTimestamp, format, provider, DateTimeStyles.None, out DateTime date))
                    {
                        string month = date.ToString("MMM", provider);
                        if (expensesPerMonth.ContainsKey(month))
                            expensesPerMonth[month] += Convert.ToDouble(reader["amount"]);
                    }
                }
            }
        }

        var savingsValues = new ChartValues<double>();
        var expensesValues = new ChartValues<double>();

        foreach (var label in monthLabels)
        {
            savingsValues.Add(savingsPerMonth[label]);
            expensesValues.Add(expensesPerMonth[label]);
        }

        var savingsSeries = new ColumnSeries
        {
            Title = "Savings",
            Values = savingsValues,
            Fill = Brushes.SkyBlue
        };

        var expensesSeries = new ColumnSeries
        {
            Title = "Expenses",
            Values = expensesValues,
            Fill = Brushes.MediumPurple
        };

        var chart = new LiveCharts.Wpf.CartesianChart
        {
            Series = new SeriesCollection { savingsSeries, expensesSeries },
            AxisX = new AxesCollection
            {
                new Axis
                {
                    Title = "Month",
                    Labels = monthLabels.ToList(),
                    Foreground = Brushes.Gray
                }
            },
            AxisY = new AxesCollection
            {
                new Axis
                {
                    Title = "Amount",
                    Foreground = Brushes.Gray
                }
            },
            LegendLocation = LegendLocation.Top
        };

        var host = new ElementHost
        {
            Dock = DockStyle.Fill,
            Child = chart
        };

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(host);
    }
}
