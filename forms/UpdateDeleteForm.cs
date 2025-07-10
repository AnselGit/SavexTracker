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
            lblDate.Text = GlobalData.CurrentTimestamp;
            txtAmt.Texts = GlobalData.CurrentAmount.ToString("0.00");
            btn_Mod.Enabled = false;

            txtAmt._TextChanged += ValidateChanges;
        }

        private void ValidateChanges(object sender, EventArgs e)
        {
            bool amountChanged =
            double.TryParse(txtAmt.Texts.Replace("₱", "").Trim(), out double newAmount) &&
            newAmount != GlobalData.CurrentAmount;

            btn_Mod.Enabled = amountChanged;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
        }

        private void btnCon1_Click(object sender, EventArgs e)
        {
            string newDate = lblDate.Text.Trim();  // now using lblDate
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
                        pnlUpdated.Visible = true;

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
                    else
                    {
                        MessageBox.Show("Update failed. Record not found.");
                    }
                }
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MoveToArchive()
        {
            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                // Step 1: Check which table the ID belongs to
                bool isSavings = false;
                bool isExpenses = false;

                using (SQLiteCommand checkSavings = new SQLiteCommand("SELECT COUNT(*) FROM savings WHERE sid = @id", conn))
                {
                    checkSavings.Parameters.AddWithValue("@id", GlobalData.CurrentID);
                    isSavings = Convert.ToInt32(checkSavings.ExecuteScalar()) > 0;
                }

                if (!isSavings)
                {
                    using (SQLiteCommand checkExpenses = new SQLiteCommand("SELECT COUNT(*) FROM expenses WHERE eid = @id", conn))
                    {
                        checkExpenses.Parameters.AddWithValue("@id", GlobalData.CurrentID);
                        isExpenses = Convert.ToInt32(checkExpenses.ExecuteScalar()) > 0;
                    }
                }

                if (!isSavings && !isExpenses)
                {
                    MessageBox.Show("Record not found in either table.");
                    return;
                }

                // Step 2: Insert into archive table
                string insertQuery = @"
            INSERT INTO archive (
                sid, eid, name,
                txtNameDate1, txtNameAmount1, timestamp1, amount1,
                txtNameDate2, txtNameAmount2, timestamp2, amount2
            )
            VALUES (
                @sid, @eid, @name,
                @txtNameDate1, @txtNameAmount1, @timestamp1, @amount1,
                @txtNameDate2, @txtNameAmount2, @timestamp2, @amount2
            );";

                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    if (isSavings)
                    {
                        insertCmd.Parameters.AddWithValue("@sid", GlobalData.CurrentID);
                        insertCmd.Parameters.AddWithValue("@eid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@name", "Savings");

                        insertCmd.Parameters.AddWithValue("@txtNameDate1", GlobalData.CurrentTxtNameDate);
                        insertCmd.Parameters.AddWithValue("@txtNameAmount1", GlobalData.CurrentTxtNameAmount);
                        insertCmd.Parameters.AddWithValue("@timestamp1", GlobalData.CurrentTimestamp);
                        insertCmd.Parameters.AddWithValue("@amount1", GlobalData.CurrentAmount);

                        insertCmd.Parameters.AddWithValue("@txtNameDate2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@txtNameAmount2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@timestamp2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount2", DBNull.Value);
                    }
                    else if (isExpenses)
                    {
                        insertCmd.Parameters.AddWithValue("@sid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@eid", GlobalData.CurrentID);
                        insertCmd.Parameters.AddWithValue("@name", "Expenses");

                        insertCmd.Parameters.AddWithValue("@txtNameDate1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@txtNameAmount1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@timestamp1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount1", DBNull.Value);

                        insertCmd.Parameters.AddWithValue("@txtNameDate2", GlobalData.CurrentTxtNameDate);
                        insertCmd.Parameters.AddWithValue("@txtNameAmount2", GlobalData.CurrentTxtNameAmount);
                        insertCmd.Parameters.AddWithValue("@timestamp2", GlobalData.CurrentTimestamp);
                        insertCmd.Parameters.AddWithValue("@amount2", GlobalData.CurrentAmount);
                    }

                    insertCmd.ExecuteNonQuery();
                }

                // Step 3: Delete from original table
                string deleteQuery = isSavings
                    ? "DELETE FROM savings WHERE sid = @id"
                    : "DELETE FROM expenses WHERE eid = @id";

                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@id", GlobalData.CurrentID);
                    deleteCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record moved to archive successfully!");
            }
        }


        private void rjButton4_Click(object sender, EventArgs e)
        {
            MoveToArchive();
            pnlDeleted.Visible = true;            

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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
