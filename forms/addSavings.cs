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
    public partial class addSavings : Form
    {
        public addSavings()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += AddSavings_KeyDown;
        }

        private async void RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }


        private void addSavings_Load(object sender, EventArgs e)
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

        private void AddSavings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\22-65\Desktop\School\SavexTracker\database";
            Directory.CreateDirectory(folder);
            string dbPath = Path.Combine(folder, "CRUD.db");
            string connStr = $"Data Source={dbPath};Version=3;";

            string amountText = txt_SA.Texts.Trim();
            string dateText = lbl_date.Text.Trim();

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

                string createTableQuery = @"
CREATE TABLE IF NOT EXISTS savings (
    sid INTEGER PRIMARY KEY AUTOINCREMENT,
    timestamp TEXT NOT NULL,
    amount REAL NOT NULL
);";
                using (SQLiteCommand createCmd = new SQLiteCommand(createTableQuery, conn))
                {
                    createCmd.ExecuteNonQuery();
                }

                string insertQuery = @"
INSERT INTO savings (timestamp, amount)
VALUES (@timestamp, @amount);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", dateText);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.ExecuteNonQuery();
                }
                
                conn.Close();
            }
            History.LogHistory("Added savings", (double)amount);

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
