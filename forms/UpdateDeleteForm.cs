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

namespace SavexTracker.forms
{
    public partial class UpdateDeleteForm : Form
    {
        public UpdateDeleteForm()
        {
            InitializeComponent();
        }

        private void UpdateDeleteForm_Load(object sender, EventArgs e)
        {
            txtDate.Texts = GlobalData.CurrentTimestamp;
            txtAmt.Texts = GlobalData.CurrentAmount.ToString("0.00");
            btn_Mod.Enabled = false;

            txtDate._TextChanged += ValidateChanges;
            txtAmt._TextChanged += ValidateChanges;
        }

        private void ValidateChanges(object sender, EventArgs e)
        {
            bool dateChanged = txtDate.Texts != GlobalData.CurrentTimestamp;

            bool amountChanged =
                double.TryParse(txtAmt.Texts.Replace("₱", "").Trim(), out double newAmount) &&
                newAmount != GlobalData.CurrentAmount;

            btn_Mod.Enabled = dateChanged || amountChanged;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
        }

        private void btnCon1_Click(object sender, EventArgs e)
        {
            string newDate = txtDate.Texts.Trim();
            string newAmountText = txtAmt.Texts.Trim().Replace("₱", "").Trim();

            if (!double.TryParse(newAmountText, out double newAmount) || newAmount <= 0)
            {
                MessageBox.Show("Invalid amount. Please enter a valid number greater than 0.");
                return;
            }

            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string updateQuery = @"
            UPDATE savings
            SET timestamp = @timestamp,
                amount = @amount
            WHERE sid = @sid";

                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", newDate);
                    cmd.Parameters.AddWithValue("@amount", newAmount);
                    cmd.Parameters.AddWithValue("@sid", GlobalData.CurrentID);

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                    {
                        MessageBox.Show("Record updated successfully!");
                        pnlUpdateCon.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Record not found.");
                    }
                }
                conn.Close();
            }
            pnlUpdated.Visible = true;
            pnlUpdateCon.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500; // 2 seconds (2000 milliseconds)
            hideTimer.Tick += (s, args) =>
            {
                pnlUpdated.Visible = false;
                pnlUpdateCon.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            pnlDeleted.Visible = true;
            pnlDeleteCon.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500; // 2 seconds (2000 milliseconds)
            hideTimer.Tick += (s, args) =>
            {
                pnlDeleted.Visible = false;
                pnlDeleteCon.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = false;
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
