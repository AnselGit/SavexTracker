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
using SavexTracker.Database;
using SavexTracker.Models;

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
            string amountText = txt_SA.Texts.Trim();
            string dateText = lbl_date.Text.Trim();
            string noteText = txtNote.Texts.Trim();

            if (string.IsNullOrEmpty(amountText) || string.IsNullOrEmpty(dateText))
            {
                MessageBox.Show("Please fill out both the amount and date.");
                return;
            }

            if (amountText.StartsWith("₱"))
                amountText = amountText.Substring(1);

            if (!double.TryParse(amountText, out double amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a positive number (greater than 0) and contain only valid digits.");
                return;
            }

            // Add expense using CRUD
            var expense = new Expense { Timestamp = dateText, Amount = amount, Note = noteText };
            CRUD.AddExpense(expense);

            // Update global variable
            GlobalData.AllExpenses = CRUD.GetAllExpenses();

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
