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
    // Form for updating or deleting a savings or expense record.
    public partial class UpdateDeleteForm : Form
    {
        private Form1 mainForm;
        // Initializes the UpdateDeleteForm with a reference to the main form.
        public UpdateDeleteForm(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }

        // Shows the expense modification panel.
        public void ShowExpensePanel()
        {
            pnlExpenseMod.Visible = true;
        }

        // Refreshes the main form's data asynchronously.
        private async Task RefreshRecord()
        {
            if (mainForm != null)
            {
                await mainForm.RefreshDataAsync();
            }
        }
        // Handles the form load event. Initializes fields and attaches validation events.
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

        // Validates changes to the amount and note fields, enabling or disabling the modify buttons.
        private void ValidateChanges(object sender, EventArgs e)
        {
            string currentNote = txtNote.Texts?.Trim() ?? "";
            string originalNote = GlobalData.CurrentNote?.Trim() ?? "";

            bool amountChanged =
                double.TryParse(txtAmt.Texts.Replace("\u20b1", "").Trim(), out double newAmount) &&
                newAmount != GlobalData.CurrentAmount;

            bool amountChanged2 =
                double.TryParse(txtEamt.Texts.Replace("\u20b1", "").Trim(), out double newAmount2) &&
                newAmount2 != GlobalData.CurrentAmount;

            bool noteChanged = currentNote != originalNote;

            btn_Mod.Enabled = amountChanged || noteChanged;
            btn_Mod2.Enabled = amountChanged2 || noteChanged;
        }

        // Shows the update confirmation panel.
        private void btn_save_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
            pnlUpdateCon.BringToFront();
        }

        // Shows the success panel after an update.
        private void ShowSuccessPanel()
        {
            pnlUpdated.BringToFront();
            pnlUpdated.Visible = true;                        

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500;
            hideTimer.Tick += async (s, args) =>
            {
                await RefreshRecord();
                this.Close();
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        // Handles the update confirmation. Updates the record in the database.
        private async void btnCon1_Click(object sender, EventArgs e)
        {
            string newDate = lblDate.Text.Trim();

            if (GlobalData.CurrentType == "Savings")
            {
                string newSavingsAmountText = txtAmt.Texts.Trim().Replace("\u20b1", "").Trim();
                if (double.TryParse(newSavingsAmountText, out double newSavingsAmount) && newSavingsAmount > 0)
                {
                    CRUD.UpdateSaving(GlobalData.CurrentID, newDate, newSavingsAmount);
                    GlobalData.AllSavings = CRUD.GetAllSavings();
                    if (mainForm != null)
                    {
                        await mainForm.RefreshDataAsync();
                    }
                    ShowSuccessPanel();
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number greater than 0.");
                    return;
                }
            }
            else if (GlobalData.CurrentType == "Expenses")
            {
                string newExpenseAmountText = txtEamt.Texts.Trim().Replace("\u20b1", "").Trim();
                string newNote = txtNote.Texts.Trim();
                if (!double.TryParse(newExpenseAmountText, out double newExpenseAmount) || newExpenseAmount <= 0)
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number greater than 0.");
                    return;
                }
                CRUD.UpdateExpense(GlobalData.CurrentID, newDate, newExpenseAmount, newNote);
                GlobalData.AllExpenses = CRUD.GetAllExpenses();
                if (mainForm != null)
                {
                    await mainForm.RefreshDataAsync();
                }
                ShowSuccessPanel();
                return;
            }
            else
            {
                MessageBox.Show("Unknown record type. Please try again.");
                return;
            }
        }

        // Shows the delete confirmation panel.
        private void rjButton2_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();
        }

        // Closes the form.
        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Moves the current record to the archive.
        private void MoveToArchive()
        {
            string type = GlobalData.CurrentType;
            int id = GlobalData.CurrentID;
            CRUD.ArchiveItem(id, type);
        }

        // Handles the delete confirmation. Moves the record to the archive and closes the form.
        private async void rjButton4_Click(object sender, EventArgs e)
        {
            MoveToArchive();
            if (mainForm != null)
            {
                await mainForm.RefreshDataAsync();
            }
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

        // Cancels the delete confirmation panel.
        private void rjButton3_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;            
        }

        // Cancels the update confirmation panel.
        private void btnCancel1_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = false;            
        }

        // Closes the form (alternate button).
        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handles click on label6 (currently unused).
        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Shows the update confirmation panel (alternate button).
        private void rjButton6_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
            pnlUpdateCon.BringToFront();
        }

        // Shows the delete confirmation panel (alternate button).
        private void rjButton5_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();
        }

        // Closes the form (alternate button).
        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
