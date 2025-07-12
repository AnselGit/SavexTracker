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

        public void ShowExpensePanel()
        {
            pnlExpenseMod.Visible = true;
        }

        private async void RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }
        private void UpdateDeleteForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = GlobalData.CurrentTimestamp;
            txtAmt.Texts = GlobalData.CurrentAmount.ToString("0.00");
            txtEamt.Texts = GlobalData.CurrentAmount.ToString("0.00");
            txtNote.Texts = GlobalData.CurrentNote ?? "";

            btn_Mod.Enabled = false;
            btn_Mod2.Enabled = false;

            txtEamt._TextChanged += ValidateChanges; 
            txtAmt._TextChanged += ValidateChanges;
            txtNote._TextChanged += ValidateChanges;            
        }

        private void ValidateChanges(object sender, EventArgs e)
        {
            string currentNote = txtNote.Texts?.Trim() ?? "";
            string originalNote = GlobalData.CurrentNote?.Trim() ?? "";

            bool amountChanged =
                double.TryParse(txtAmt.Texts.Replace("₱", "").Trim(), out double newAmount) &&
                newAmount != GlobalData.CurrentAmount;

            bool amountChanged2 =
                double.TryParse(txtEamt.Texts.Replace("₱", "").Trim(), out double newAmount2) &&
                newAmount2 != GlobalData.CurrentAmount;

            bool noteChanged = currentNote != originalNote;

            btn_Mod.Enabled = amountChanged || noteChanged;
            btn_Mod2.Enabled = amountChanged2 || noteChanged;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
            pnlUpdateCon.BringToFront();
        }

        private void ShowSuccessPanel()
        {
            pnlUpdated.BringToFront();
            pnlUpdated.Visible = true;                        

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500;
            hideTimer.Tick += (s, args) =>
            {
                RefreshRecord();
                this.Close();
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }


        private void btnCon1_Click(object sender, EventArgs e)
        {
            string newDate = lblDate.Text.Trim();
            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                // Try to update savings
                string newSavingsAmountText = txtAmt.Texts.Trim().Replace("₱", "").Trim();

                if (double.TryParse(newSavingsAmountText, out double newSavingsAmount) && newSavingsAmount > 0)
                {
                    string updateSavingsQuery = @"
UPDATE savings
SET timestamp = @timestamp,
    amount = @amount
WHERE sid = @sid";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateSavingsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@timestamp", newDate);
                        cmd.Parameters.AddWithValue("@amount", newSavingsAmount);
                        cmd.Parameters.AddWithValue("@sid", GlobalData.CurrentID);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            History.LogHistory("Updated savings", newSavingsAmount); // ✅ log it
                            ShowSuccessPanel();
                            return;
                        }
                    }
                }

                // Try to update expenses
                string newExpenseAmountText = txtEamt.Texts.Trim().Replace("₱", "").Trim();
                string newNote = txtNote.Texts.Trim();

                if (!double.TryParse(newExpenseAmountText, out double newExpenseAmount) || newExpenseAmount <= 0)
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number greater than 0.");
                    return;
                }

                string updateExpensesQuery = @"
UPDATE expenses
SET timestamp = @timestamp,
    amount = @amount,
    note = @note
WHERE eid = @eid";

                using (SQLiteCommand cmd = new SQLiteCommand(updateExpensesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", newDate);
                    cmd.Parameters.AddWithValue("@amount", newExpenseAmount);
                    cmd.Parameters.AddWithValue("@note", newNote);
                    cmd.Parameters.AddWithValue("@eid", GlobalData.CurrentID);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        History.LogHistory("Updated expense", newExpenseAmount); // ✅ log it
                        ShowSuccessPanel();
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
            pnlDeleteCon.BringToFront();
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

                bool isSavings = false;
                bool isExpenses = false;
                string expenseNote = "";

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

                    // If expense, fetch the note
                    if (isExpenses)
                    {
                        using (SQLiteCommand noteCmd = new SQLiteCommand("SELECT note FROM expenses WHERE eid = @id", conn))
                        {
                            noteCmd.Parameters.AddWithValue("@id", GlobalData.CurrentID);
                            var result = noteCmd.ExecuteScalar();
                            expenseNote = result != DBNull.Value ? result.ToString() : "";
                        }
                    }
                }

                if (!isSavings && !isExpenses)
                {
                    MessageBox.Show("Record not found in either table.");
                    return;
                }

                // Step 2: Insert into archive table (with note now)
                string insertQuery = @"
INSERT INTO archive (
    sid, eid, name,
    timestamp1, amount1,
    timestamp2, amount2,
    note
)
VALUES (
    @sid, @eid, @name,
    @timestamp1, @amount1,
    @timestamp2, @amount2,
    @note
);";

                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    if (isSavings)
                    {
                        insertCmd.Parameters.AddWithValue("@sid", GlobalData.CurrentID);
                        insertCmd.Parameters.AddWithValue("@eid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@name", "Savings");
                        insertCmd.Parameters.AddWithValue("@timestamp1", GlobalData.CurrentTimestamp);
                        insertCmd.Parameters.AddWithValue("@amount1", GlobalData.CurrentAmount);
                        insertCmd.Parameters.AddWithValue("@timestamp2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@note", DBNull.Value);
                    }
                    else if (isExpenses)
                    {
                        insertCmd.Parameters.AddWithValue("@sid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@eid", GlobalData.CurrentID);
                        insertCmd.Parameters.AddWithValue("@name", "Expenses");
                        insertCmd.Parameters.AddWithValue("@timestamp1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@timestamp2", GlobalData.CurrentTimestamp);
                        insertCmd.Parameters.AddWithValue("@amount2", GlobalData.CurrentAmount);
                        insertCmd.Parameters.AddWithValue("@note", expenseNote);
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

                // ✅ Step 4: Log to history
                string action = isSavings ? "Removed savings" : "Removed expense";
                History.LogHistory(action, GlobalData.CurrentAmount);
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
                RefreshRecord();
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

        private void rjButton6_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
            pnlUpdateCon.BringToFront();
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();
        }

        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
