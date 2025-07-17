using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavexTracker.Database;
using SavexTracker.Models;

namespace SavexTracker.forms
{
    public partial class DeleteAll : Form
    {
        public DeleteAll()
        {
            InitializeComponent();
            lblType.Text = $"{GlobalData.CurrentType}?";
            FlickerDeleteAllBackground();
        }

        private async Task RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }

        private int flickerCount = 0;
        private Timer flickerTimer;
        private Color originalColor;

        private void FlickerDeleteAllBackground()
        {
            originalColor = this.BackColor; // Save original
            flickerCount = 0;

            flickerTimer = new Timer();
            flickerTimer.Interval = 100; // 0.5 seconds
            flickerTimer.Tick += FlickerTimer_Tick;
            flickerTimer.Start();
        }

        private void FlickerTimer_Tick(object sender, EventArgs e)
        {
            if (flickerCount % 2 == 0)
            {
                this.BackColor = Color.FromArgb(255, 192, 128); // flicker color
            }
            else
            {
                this.BackColor = originalColor; // back to normal
            }

            flickerCount++;

            if (flickerCount >= 6) // two full cycles: (on-off) x2
            {
                flickerTimer.Stop();
                flickerTimer.Dispose();
                this.BackColor = originalColor; // ensure it's reset
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void DeleteAll_Load(object sender, EventArgs e)
        {
            lblType.Text = $"{GlobalData.CurrentType}?";
        }

        private async void btnCon_Click(object sender, EventArgs e)
        {
            string type = GlobalData.CurrentType;

            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("No type selected.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                if (type == "Savings")
                {
                    // Step 1: Move all savings to archive
                    string selectQuery = "SELECT sid, timestamp, amount FROM savings";
                    using (var selectCmd = new SQLiteCommand(selectQuery, conn))
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sid = Convert.ToInt32(reader["sid"]);
                            string timestamp = reader["timestamp"].ToString();
                            double amount = Convert.ToDouble(reader["amount"]);

                            string insertArchive = @"
                        INSERT INTO archive (sid, eid, name, timestamp1, amount1, timestamp2, amount2, note)
                        VALUES (@sid, NULL, 'Savings', @timestamp, @amount, NULL, NULL, NULL)";
                            using (var insertCmd = new SQLiteCommand(insertArchive, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@sid", sid);
                                insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                                insertCmd.Parameters.AddWithValue("@amount", amount);
                                insertCmd.ExecuteNonQuery();
                            }

                            History.LogHistory("Removed savings", amount, conn);
                        }
                    }

                    // Step 2: Delete all from savings
                    using (var deleteCmd = new SQLiteCommand("DELETE FROM savings", conn))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }
                }
                else if (type == "Expenses")
                {
                    // Step 1: Move all expenses to archive
                    string selectQuery = "SELECT eid, timestamp, amount, note FROM expenses";
                    using (var selectCmd = new SQLiteCommand(selectQuery, conn))
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int eid = Convert.ToInt32(reader["eid"]);
                            string timestamp = reader["timestamp"].ToString();
                            double amount = Convert.ToDouble(reader["amount"]);
                            string note = reader["note"]?.ToString() ?? "";

                            string insertArchive = @"
                        INSERT INTO archive (sid, eid, name, timestamp1, amount1, timestamp2, amount2, note)
                        VALUES (NULL, @eid, 'Expenses', NULL, NULL, @timestamp, @amount, @note)";
                            using (var insertCmd = new SQLiteCommand(insertArchive, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@eid", eid);
                                insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                                insertCmd.Parameters.AddWithValue("@amount", amount);
                                insertCmd.Parameters.AddWithValue("@note", note);
                                insertCmd.ExecuteNonQuery();
                            }

                            History.LogHistory("Removed expense", amount, conn);
                        }
                    }

                    // Step 2: Delete all from expenses
                    using (var deleteCmd = new SQLiteCommand("DELETE FROM expenses", conn))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Unknown type.");
                }
            }
            // Update global variables
            GlobalData.AllSavings = CRUD.GetAllSavings();
            GlobalData.AllExpenses = CRUD.GetAllExpenses();
            GlobalData.AllArchive = CRUD.GetAllArchive();

            await RefreshRecord();
            pnlDeleted.Visible = true;
            pnlDeleted.BringToFront();

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500;
            hideTimer.Tick += (s, args) =>
            {
                this.Close();
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
