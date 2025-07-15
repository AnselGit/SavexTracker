using SavexTracker.forms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavexTracker.Database;
using SavexTracker.Models;
using System.Collections.Generic;


namespace SavexTracker
{
    public partial class Form1 : SolidRoundedForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            _ = RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            btnRefresh.Text = "Refreshing";
            btnRefresh.Enabled = false;

            CRUD.EnsureDatabaseAndTables();
            CRUD.LoadAllDataToGlobals();
            UpdateGoalLabel();
            UpdateTotalLabels();
            LoadGoal();
            LoadExpensesToPanel();
            LoadSavingsToPanel();
            LoadHistory();
            ChartBuilder.BuildLineGraph(pnlLine);
            DonutChartBuilder.Build(pnlPie2);
            DonutChartGoalVsTotalBuilder.Build(pnlPie3);

            await Task.Delay(500);
            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
        }

        private void UpdateGoalLabel()
        {
            double totalSavings = CRUD.GetTotalSavings();
            double totalExpenses = CRUD.GetTotalExpenses();
            double goalAmount = CRUD.GetLatestGoalAmount();

            double grandTotal = totalSavings - totalExpenses;
            if (grandTotal < 0) grandTotal = 0;

            double percent = 0;
            if (goalAmount > 0)
            {
                percent = (grandTotal / goalAmount) * 100;
                if (percent > 100) percent = 100; // cap at 100%
            }

            lblGoal.Text = $"GOAL - {percent:0}%";
        }


        private void LoadGoal()
        {
            double amount = CRUD.GetLatestGoalAmount();
            txtGoal.Text = $"₱{amount:N2}";
            GlobalData.CurrentGoal = amount;
        }


        private void rjButton1_Click(object sender, EventArgs e)
        {
            addSavings addForm = new addSavings();
            addForm.Show(); 
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        private void LoadSavingsToPanel()
        {
            tblSave.Controls.Clear();
            tblSave.RowStyles.Clear();
            tblSave.RowCount = 0;
            tblSave.AutoScroll = true;

            var savingsList = GlobalData.AllSavings ?? new List<Saving>();
            int row = 0;
            foreach (var saving in savingsList)
            {
                int sid = saving.Sid;
                string timestamp = saving.Timestamp;
                double amount = saving.Amount;

                string txtNameDate = $"n{sid}";
                string txtNameAmount = $"sa{sid}";

                var dateBox = new RJCodeAdvance.RJControls.RJTextBox
                {
                    Name = txtNameDate,
                    Texts = timestamp,
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(224, 224, 224),
                    BorderFocusColor = Color.MediumSlateBlue,
                    BorderRadius = 0,
                    BorderSize = 1,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    UnderlinedStyle = true,
                    Size = new Size(82, 31),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Margin = new Padding(5)
                };

                var amtBox = new RJCodeAdvance.RJControls.RJTextBox
                {
                    Name = txtNameAmount,
                    Texts = "₱" + amount.ToString("0.00"),
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(224, 224, 224),
                    BorderFocusColor = Color.MediumSlateBlue,
                    BorderRadius = 0,
                    BorderSize = 1,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    UnderlinedStyle = true,
                    Size = new Size(120, 35),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Margin = new Padding(5)
                };

                tblSave.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tblSave.Controls.Add(dateBox, 0, tblSave.RowCount);
                tblSave.Controls.Add(amtBox, 1, tblSave.RowCount);
                tblSave.RowCount++;

                Button btnModify = new Button
                {
                    Text = "Modify",
                    Name = "btnModify_" + row,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.White,
                    Font = new Font("Noto Sans", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Dock = DockStyle.None,
                    Size = new Size(230, 25),
                    Margin = new Padding(0)
                };

                btnModify.MouseEnter += (s, e) => btnModify.BackColor = Color.FromArgb(30, 144, 255);
                btnModify.MouseLeave += (s, e) => btnModify.BackColor = Color.White;

                btnModify.Click += (s, e) =>
                {
                    GlobalData.CurrentID = sid;
                    GlobalData.CurrentTimestamp = timestamp;
                    GlobalData.CurrentAmount = amount;
                    GlobalData.CurrentType = "Savings";


                    var updateForm = new UpdateDeleteForm();
                    updateForm.Show();
                };

                tblSave.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                tblSave.Controls.Add(btnModify, 0, tblSave.RowCount);
                tblSave.SetColumnSpan(btnModify, 2);
                tblSave.RowCount++;

                row++;
            }
        }


        private void LoadExpensesToPanel()
        {
            tbl_Spend.Controls.Clear();
            tbl_Spend.RowStyles.Clear();
            tbl_Spend.RowCount = 0;
            tbl_Spend.AutoScroll = true;

            var expensesList = GlobalData.AllExpenses ?? new List<Expense>();
            int row = 0;
            foreach (var expense in expensesList)
            {
                int eid = expense.Eid;
                string timestamp = expense.Timestamp;
                double amount = expense.Amount;
                string note = expense.Note ?? "";

                string txtNameDate = $"edate_{eid}";
                string txtNameAmount = $"eamt_{eid}";
                string txtNameNote = $"enote_{eid}";

                // Create RJTextBoxes
                var dateBox = new RJCodeAdvance.RJControls.RJTextBox
                {
                    Name = txtNameDate,
                    Texts = timestamp,
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(224, 224, 224),
                    BorderFocusColor = Color.MediumSlateBlue,
                    BorderRadius = 0,
                    BorderSize = 1,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    UnderlinedStyle = true,
                    Size = new Size(107, 31),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Margin = new Padding(5)
                };

                var amtBox = new RJCodeAdvance.RJControls.RJTextBox
                {
                    Name = txtNameAmount,
                    Texts = "₱" + amount.ToString("0.00"),
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(224, 224, 224),
                    BorderFocusColor = Color.MediumSlateBlue,
                    BorderRadius = 0,
                    BorderSize = 1,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    UnderlinedStyle = true,
                    Size = new Size(124, 31),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Margin = new Padding(5)
                };

                var noteBox = new RJCodeAdvance.RJControls.RJTextBox
                {
                    Name = txtNameNote,
                    Texts = note,
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(224, 224, 224),
                    BorderFocusColor = Color.MediumSlateBlue,
                    BorderRadius = 0,
                    BorderSize = 1,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    UnderlinedStyle = true,
                    Size = new Size(182, 31),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Margin = new Padding(5)
                };

                // Add to row
                tbl_Spend.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbl_Spend.Controls.Add(dateBox, 0, tbl_Spend.RowCount);
                tbl_Spend.Controls.Add(amtBox, 1, tbl_Spend.RowCount);
                tbl_Spend.Controls.Add(noteBox, 2, tbl_Spend.RowCount);
                tbl_Spend.RowCount++;

                // Modify button
                Button btnModify = new Button
                {
                    Text = "Modify",
                    Name = "btnModify_" + row,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.White,
                    Font = new Font("Noto Sans", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Dock = DockStyle.None,
                    Size = new Size(430, 25),
                    Margin = new Padding(0)
                };

                btnModify.MouseEnter += (s, e) => btnModify.BackColor = Color.FromArgb(106, 90, 205);
                btnModify.MouseLeave += (s, e) => btnModify.BackColor = Color.White;

                btnModify.Click += (s, e) =>
                {
                    GlobalData.CurrentID = eid;
                    GlobalData.CurrentTimestamp = timestamp;
                    GlobalData.CurrentAmount = amount;
                    GlobalData.CurrentNote = note;
                    GlobalData.CurrentType = "Expenses";


                    var updateForm = new UpdateDeleteForm();
                    updateForm.Show();
                    updateForm.ShowExpensePanel();
                };

                tbl_Spend.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                tbl_Spend.Controls.Add(btnModify, 0, tbl_Spend.RowCount);
                tbl_Spend.SetColumnSpan(btnModify, 3);
                tbl_Spend.RowCount++;

                row++;
            }
        }

        private void UpdateTotalLabels()
        {
            double totalSave = CRUD.GetTotalSavings();
            double totalSpend = CRUD.GetTotalExpenses();
            double grandTotal = totalSave - totalSpend;

            lblTotalSave.Text = totalSave.ToString("₱0.00");
            lblTotalSpent.Text = totalSpend.ToString("₱0.00");
            lblDashSave.Text = totalSave.ToString("₱0.00");
            lblDashSpend.Text = totalSpend.ToString("₱0.00");
            lblGrand.Text = grandTotal.ToString("₱0.00");

            lblTotalSave.ForeColor = Color.Gray;
            lblTotalSpent.ForeColor = Color.Gray;

            if (grandTotal >= GlobalData.CurrentGoal && grandTotal > 0)
            {
                lblGrand.ForeColor = Color.Green;
            }
            else if (grandTotal > 0)
            {
                lblGrand.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (grandTotal < 0)
            {
                lblGrand.ForeColor = Color.Red;
            }
            else
            {
                lblGrand.ForeColor = Color.Gray;
            }

        }

        public static void LogHistory(string action, double amount)
        {
            CRUD.LogHistory(action, amount);
        }

        private void LoadHistory()
        {
            rtbHistory.Clear();
            var historyList = CRUD.GetAllHistory();
            if (historyList == null || historyList.Count == 0)
            {
                pnlEmpty.Visible = true;
                pnlEmpty.BringToFront();
                return;
            }

            foreach (var item in historyList)
            {
                string action = item.Action;
                double amount = item.Amount ?? 0;
                string timestamp = DateTime.Parse(item.Timestamp).ToString("MM/dd/yyyy 'at' hh:mm tt");
                string entry = $"{action} - ₱{amount:N2}\n{timestamp}\n\n";
                rtbHistory.AppendText(entry);
            }

            pnlEmpty.Visible = false;
            rtbHistory.SelectionStart = 0;
            rtbHistory.ScrollToCaret();
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            addExpense addForm = new addExpense();
            addForm.Show();
        }

        private void rjButton9_Click(object sender, EventArgs e)
        {
            ArchiveForm addForm = new ArchiveForm();
            addForm.Show();
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();


        }

        private void rjButton13_Click(object sender, EventArgs e)
        {
            CRUD.DeleteAllHistory();
            pnlHistory.Visible = true;
            pnlHistory.BringToFront();
            rtbHistory.Clear();
            LoadHistory();
        }

        private void rjButton12_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;
        }

        private void lblGrand_Click(object sender, EventArgs e)
        {

        }

        private void rjButton14_Click(object sender, EventArgs e)
        {
            btnDelAll_S.Visible = !btnDelAll_S.Visible;
        }

        private void rjButton15_Click(object sender, EventArgs e)
        {
            btnDelAll_E.Visible = !btnDelAll_E.Visible;
        }

        private bool IsTableEmpty(string tableName)
        {
            return CRUD.IsTableEmpty(tableName);
        }

        private void btnDelAll_S_Click(object sender, EventArgs e)
        {
            if (IsTableEmpty("savings"))
            {
                btnDelAll_S.Visible = false;
                return;
            }

            GlobalData.CurrentType = "Savings";
            DeleteAll deleteForm = new DeleteAll();
            deleteForm.Show();
            btnDelAll_S.Visible = false;
        }

        private void btnDelAll_E_Click(object sender, EventArgs e)
        {
            if (IsTableEmpty("expenses"))
            {
                btnDelAll_E.Visible = false;
                return;
            }

            GlobalData.CurrentType = "Expenses";
            DeleteAll deleteForm = new DeleteAll();
            deleteForm.Show();
            btnDelAll_E.Visible = false;
        }

        private void btnNav_3_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_3);
            pnl_3.Visible = true;
            pnl_3.BringToFront();

            pnl_1.Visible = false;
            pnl_2.Visible = true;
        }

        private void HighlightNavButton(Button selectedButton)
        {
            // Reset all nav buttons to white
            btnNav_1.BackColor = Color.White;
            btnNav_2.BackColor = Color.White;
            btnNav_3.BackColor = Color.White;

            // Set the selected one to highlight color
            selectedButton.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void btnNav_2_Click_1(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_2);
            pnl_2.Visible = true;
            pnl_2.BringToFront();

            pnl_1.Visible = false;
            pnl_3.Visible = true;
        }

        private void btnNav_1_Click_1(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_1);
            pnl_1.Visible = true;
            pnl_1.BringToFront();

            pnl_2.Visible = false;
            pnl_3.Visible = true;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            // Remove currency symbol and parse value
            string input = txtGoal.Text.Replace("₱", "").Replace(",", "").Trim();
            if (double.TryParse(input, out double newGoal))
            {
                CRUD.UpdateGoalAmount(newGoal);
                _ = RefreshDataAsync();
            }
            else
            {
                MessageBox.Show("Please enter a valid goal amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Texts; // RJTextBox uses .Texts
            var results = CRUD.SearchSavingsAndExpenses(searchTerm);
            dgv_Search.Rows.Clear();
            // Use only the designer-defined columns for styling
            foreach (var item in results)
            {
                // Add by column order: Date, Type, Amount, Note
                dgv_Search.Rows.Add(item.Date, item.Type, $"₱{item.Amount:N2}", item.Note);
            }
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Texts; // RJTextBox uses .Texts
            var results = CRUD.SearchSavingsAndExpenses(searchTerm);
            dgv_Search.Rows.Clear();
            // Use only the designer-defined columns for styling
            foreach (var item in results)
            {
                // Add by column order: Date, Type, Amount, Note
                dgv_Search.Rows.Add(item.Date, item.Type, $"₱{item.Amount:N2}", item.Note);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Texts; // RJTextBox uses .Texts
            var results = CRUD.SearchSavingsAndExpenses(searchTerm);
            dgv_Search.Rows.Clear();
            // Use only the designer-defined columns for styling
            foreach (var item in results)
            {
                // Add by column order: Date, Type, Amount, Note
                dgv_Search.Rows.Add(item.Date, item.Type, $"₱{item.Amount:N2}", item.Note);
            }
        }
    }
}
