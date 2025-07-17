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
using SavexTracker.CustomClasses;


namespace SavexTracker
{
    public partial class Form1 : SolidRoundedForm
    {
        private bool isPnl1Dirty = true;
        private bool isPnl3Dirty = true;
        private SavingsOwnerDrawPanel savingsPanel;
        // private ExpensesOwnerDrawPanel expensesPanel; // Remove this duplicate declaration

        public Form1()
        {
            InitializeComponent();
            // Replace tblSave with SavingsOwnerDrawPanel
            savingsPanel = new SavingsOwnerDrawPanel();
            savingsPanel.Location = new Point(15, 39); // Match previous tblSave location
            savingsPanel.Size = new Size(254, 484);    // Match previous tblSave size
            savingsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            savingsPanel.SelectedRowChanged += SavingsPanel_SelectedRowChanged;
            savingsPanel.RowModifyRequested += SavingsPanel_RowModifyRequested;
            pnlSave.Controls.Add(savingsPanel);
            // Expenses panel
            expensesPanel = new ExpensesOwnerDrawPanel();
            expensesPanel.Location = new Point(14, 39); // Match old tbl_Spend
            expensesPanel.Size = new Size(437, 484);
            expensesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            expensesPanel.SelectedRowChanged += ExpensesPanel_SelectedRowChanged;
            expensesPanel.RowModifyRequested += ExpensesPanel_RowModifyRequested;
            roundedPanel4.Controls.Add(expensesPanel);            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pnl_1.VisibleChanged += pnl_1_VisibleChanged;
            pnl_3.VisibleChanged += pnl_3_VisibleChanged;
            _ = RefreshDataAsync();
            btnNav_1_Click_1(btnNav_1, EventArgs.Empty);
        }

        public async Task RefreshDataAsync()
        {           

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

        private void SavingsPanel_SelectedRowChanged(object sender, EventArgs e)
        {
            
        }

        private void SavingsPanel_RowModifyRequested(object sender, int rowIndex)
        {
            var row = ((SavingsOwnerDrawPanel)sender).SelectedRow;
            if (row == null)
                row = ((SavingsOwnerDrawPanel)sender).GetRow(rowIndex);
            if (row != null)
            {
                GlobalData.CurrentID = row.Sid;
                GlobalData.CurrentTimestamp = row.Timestamp;
                GlobalData.CurrentAmount = row.Amount;
                GlobalData.CurrentType = "Savings";
                var updateForm = new UpdateDeleteForm(this);
                updateForm.Show();
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        private void LoadSavingsToPanel()
        {
            // Remove dynamic controls logic, just set rows for owner-draw panel
            var savingsList = GlobalData.AllSavings ?? new List<Saving>();
            var rows = savingsList.Select(s => new SavingsOwnerDrawPanel.SavingsRow
            {
                Sid = s.Sid,
                Timestamp = s.Timestamp,
                Amount = s.Amount
            });
            savingsPanel.SetRows(rows);
        }


        private void LoadExpensesToPanel()
        {
            var expensesList = GlobalData.AllExpenses ?? new List<Expense>();
            var rows = expensesList.Select(e => new ExpensesOwnerDrawPanel.ExpensesRow
            {
                Eid = e.Eid,
                Timestamp = e.Timestamp,
                Amount = e.Amount,
                Note = e.Note ?? ""
            });
            expensesPanel.SetRows(rows);
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

        private void PerformSearch()
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
            pnl_2.Visible = false;
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
            pnl_3.Visible = false;
        }

        private void btnNav_1_Click_1(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_1);
            pnl_1.Visible = true;
            pnl_1.BringToFront();

            pnl_2.Visible = false;
            pnl_3.Visible = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            // Remove currency symbol and parse value
            string input = txtGoal.Text.Replace("₱", "").Replace(",", "").Trim();
            if (double.TryParse(input, out double newGoal))
            {
                CRUD.UpdateGoalAmount(newGoal);
                MarkPanelsDirty();
                _ = RefreshDataAsync();
            }
            else
            {
                MessageBox.Show("Please enter a valid goal amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void MarkPanelsDirty()
        {
            isPnl1Dirty = true;
            isPnl3Dirty = true;
        }

        private void RefreshPnl1()
        {
            UpdateGoalLabel();
            UpdateTotalLabels();
            LoadGoal();
            LoadHistory();
            ChartBuilder.BuildLineGraph(pnlLine);
            DonutChartBuilder.Build(pnlPie2);
            DonutChartGoalVsTotalBuilder.Build(pnlPie3);
        }

        private void RefreshPnl3()
        {
            LoadExpensesToPanel();
            LoadSavingsToPanel();
            LoadHistory();
            UpdateTotalLabels();
        }

        private void pnl_1_VisibleChanged(object sender, EventArgs e)
        {
            if (pnl_1.Visible && isPnl1Dirty)
            {
                RefreshPnl1();
                isPnl1Dirty = false;
            }
        }

        private void pnl_3_VisibleChanged(object sender, EventArgs e)
        {
            if (pnl_3.Visible && isPnl3Dirty)
            {
                RefreshPnl3();
                isPnl3Dirty = false;
            }
        }

        private void ExpensesPanel_SelectedRowChanged(object sender, EventArgs e)
        {
            // You can enable/disable a Modify button for expenses if needed
        }

        private void ExpensesPanel_RowModifyRequested(object sender, int rowIndex)
        {
            var row = ((ExpensesOwnerDrawPanel)sender).SelectedRow;
            if (row == null)
                row = ((ExpensesOwnerDrawPanel)sender).GetRow(rowIndex);
            if (row != null)
            {
                GlobalData.CurrentID = row.Eid;
                GlobalData.CurrentTimestamp = row.Timestamp;
                GlobalData.CurrentAmount = row.Amount;
                GlobalData.CurrentNote = row.Note;
                GlobalData.CurrentType = "Expenses";
                var updateForm = new UpdateDeleteForm(this);
                updateForm.Show();
                updateForm.ShowExpensePanel();
            }
        }

        private void tbl_Spend_Paint(object sender, PaintEventArgs e)
        {

        }

        public async void TriggerRefreshPnl3()
        {
            await RefreshDataAsync();
        }

        public async void TriggerBtnRefreshClick()
        {
            await RefreshDataAsync();
        }
    }
}
