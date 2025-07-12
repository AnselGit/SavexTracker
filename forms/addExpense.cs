using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavexTracker.forms
{
    public partial class addExpense : Form
    {
        public addExpense()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += AddExpense_KeyDown;
        }

        private void addExpense_Load(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Now.ToString("MM/dd/yy");
            txt_SA.KeyDown += txt_SA_KeyDown;
        }

        private void txt_SA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents ding sound
                btn_save.PerformClick();   // Simulate button click
            }
        }

        private void AddExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\22-65\Desktop\School\SavexTracker\database";
            Directory.CreateDirectory(folder);
            string dbPath = Path.Combine(folder, "CRUD.db");
            string connStr = $"Data Source={dbPath};Version=3;";

            string amountText = txt_SA.Texts.Trim();         // Get from txt_SA
            string dateText = lbl_date.Text.Trim();          // Get from lbl_date
            string noteText = txtNote.Texts.Trim();          // Get from txtNote (RJTextBox for note)

            if (string.IsNullOrEmpty(amountText) || string.IsNullOrEmpty(dateText))
            {
                MessageBox.Show("Please fill out both the amount and date.");
                return;
            }

            if (amountText.StartsWith("₱"))
                amountText = amountText.Substring(1);

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a positive number (greater than 0) and contain only valid digits.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                // Create expenses table if not exists
                string createExpensesQuery = @"
        CREATE TABLE IF NOT EXISTS expenses (
            eid INTEGER PRIMARY KEY AUTOINCREMENT,
            timestamp TEXT NOT NULL,
            amount REAL NOT NULL,
            note TEXT
        );";

                using (SQLiteCommand createCmd = new SQLiteCommand(createExpensesQuery, conn))
                {
                    createCmd.ExecuteNonQuery();
                }

                // Insert expense record
                string insertQuery = @"
        INSERT INTO expenses (timestamp, amount, note)
        VALUES (@timestamp, @amount, @note);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", dateText);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    object noteValue = string.IsNullOrWhiteSpace(noteText) ? (object)DBNull.Value : noteText;
                    cmd.Parameters.AddWithValue("@note", noteValue);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            History.LogHistory("Added expense", (double)amount);

            RefreshRecord();
            pnlAdded.Visible = true;
            pnlAdded.BringToFront();

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
    }
}
