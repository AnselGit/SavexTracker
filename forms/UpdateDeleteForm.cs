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

            string newSavingsAmountText = txtAmt.Texts.Trim().Replace("₱", "").Trim();
            if (double.TryParse(newSavingsAmountText, out double newSavingsAmount) && newSavingsAmount > 0)
            {
                CRUD.UpdateSaving(GlobalData.CurrentID, newDate, newSavingsAmount);
                GlobalData.AllSavings = CRUD.GetAllSavings();
                ShowSuccessPanel();
                return;
            }

            string newExpenseAmountText = txtEamt.Texts.Trim().Replace("₱", "").Trim();
            string newNote = txtNote.Texts.Trim();
            if (!double.TryParse(newExpenseAmountText, out double newExpenseAmount) || newExpenseAmount <= 0)
            {
                MessageBox.Show("Invalid amount. Please enter a valid number greater than 0.");
                return;
            }
            CRUD.UpdateExpense(GlobalData.CurrentID, newDate, newExpenseAmount, newNote);
            GlobalData.AllExpenses = CRUD.GetAllExpenses();
            ShowSuccessPanel();
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
            string type = GlobalData.CurrentType;
            int id = GlobalData.CurrentID;
            CRUD.ArchiveItem(id, type);
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
