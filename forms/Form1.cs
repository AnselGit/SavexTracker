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
    
    // Main application form for SavexTracker. Handles navigation, data loading, and user interactions for savings, expenses, goals, and history.
    
    public partial class Form1 : SolidRoundedForm
    {
        private bool isPnl1Dirty = true;
        private bool isPnl3Dirty = true;
        private SavingsOwnerDrawPanel savingsPanel;
        // private ExpensesOwnerDrawPanel expensesPanel; // Remove this duplicate declaration

        
        // Initializes the main form, sets up custom panels, and event handlers.
        
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

        
        // Handles the form load event. Sets up panel visibility and triggers initial data refresh.
        
        private void Form1_Load_1(object sender, EventArgs e)
        {
            pnl_1.VisibleChanged += pnl_1_VisibleChanged;
            pnl_3.VisibleChanged += pnl_3_VisibleChanged;
            _ = RefreshDataAsync();
            btnNav_1_Click_1(btnNav_1, EventArgs.Empty);
        }

        
        // Asynchronously refreshes all data and updates UI components.
        
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
            LoadRecordCount();
            await Task.Delay(500);
        }

        
        // Updates the goal label based on current savings, expenses, and goal amount.
        
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

        
        // Loads the latest goal amount into the goal textbox and updates global data.
        
        private void LoadGoal()
        {
            double amount = CRUD.GetLatestGoalAmount();
            txtGoal.Text = $"₱{amount:N2}";
            GlobalData.CurrentGoal = amount;
        }


        // Opens the add savings form.

        private addSavings addForm = null;

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (addForm == null || addForm.IsDisposed)
            {
                addForm = new addSavings();
                addForm.Show();
            }
            else
            {
                addForm.BringToFront();
                addForm.Focus();
            }
        }


        // Exits the application.

        private void rjButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        // Minimizes the application window.
        
        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        // Refreshes all data when the refresh button is clicked.
        
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        
        // Handles row selection change in the savings panel.
        
        private void SavingsPanel_SelectedRowChanged(object sender, EventArgs e)
        {
            
        }


        // Handles request to modify a savings row.

        private UpdateDeleteForm updateForm6 = null;
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

                if (updateForm6 == null || updateForm6.IsDisposed)
                {
                    updateForm6 = new UpdateDeleteForm(this);
                    updateForm6.Show();
                }
                else
                {
                    updateForm6.BringToFront();
                    updateForm6.Focus();
                }
            }
        }


        // Refreshes all data when the refresh button is clicked (duplicate handler).

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        
        // Loads all savings data into the custom savings panel.
        
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


        
        // Loads all expenses data into the custom expenses panel.
        
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

        
        // Updates the total savings, expenses, and grand total labels.
        
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

        
        // Logs a history action with the specified amount.
        
        public static void LogHistory(string action, double amount)
        {
            CRUD.LogHistory(action, amount);
        }

        
        // Loads all history records into the history rich text box.
        
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

        
        // Performs a search for savings and expenses based on the search term.
        
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


        // Opens the add expense form.

        private addExpense addForm2 = null;
        private void rjButton6_Click(object sender, EventArgs e)
        {
            if (addForm2 == null || addForm2.IsDisposed)
            {
                addForm2 = new addExpense();
                addForm2.Show();
            }
            else
            {
                addForm2.BringToFront();
                addForm2.Focus();
            }
        }


        // Opens the archive form.

        private ArchiveForm addForm3 = null;
        private void rjButton9_Click(object sender, EventArgs e)
        {
            if (addForm3 == null || addForm3.IsDisposed)
            {
                addForm3 = new ArchiveForm();
                addForm3.Show();
            }
            else
            {
                addForm3.BringToFront();
                addForm3.Focus();
            }
        }


        // Shows the delete confirmation panel for all records.

        private void rjButton11_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();


        }

        
        // Deletes all history records and refreshes the history panel.
        
        private void rjButton13_Click(object sender, EventArgs e)
        {
            CRUD.DeleteAllHistory();
            pnlHistory.Visible = true;
            pnlHistory.BringToFront();
            rtbHistory.Clear();
            LoadHistory();
        }

        
        // Cancels the delete confirmation panel.
        
        private void rjButton12_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;
        }

        
        // Handles click on the grand total label (currently unused).
        
        private void lblGrand_Click(object sender, EventArgs e)
        {

        }

        
        // Toggles the visibility of the delete all savings button.
        
        private void rjButton14_Click(object sender, EventArgs e)
        {
            btnDelAll_S.Visible = !btnDelAll_S.Visible;
        }

        
        // Toggles the visibility of the delete all expenses button.
        
        private void rjButton15_Click(object sender, EventArgs e)
        {
            btnDelAll_E.Visible = !btnDelAll_E.Visible;
        }

        
        // Checks if a table is empty in the database.
        
        private bool IsTableEmpty(string tableName)
        {
            return CRUD.IsTableEmpty(tableName);
        }


        private DeleteAll deleteAllForm = null;

        // Handles click on the delete all savings button. Opens the delete all form for savings.
        private void btnDelAll_S_Click(object sender, EventArgs e)
        {
            if (IsTableEmpty("savings"))
            {
                btnDelAll_S.Visible = false;
                return;
            }

            GlobalData.CurrentType = "Savings";

            if (deleteAllForm == null || deleteAllForm.IsDisposed)
            {
                deleteAllForm = new DeleteAll();
                deleteAllForm.Show();
            }
            else
            {
                deleteAllForm.BringToFront();
                deleteAllForm.Focus();
            }

            btnDelAll_S.Visible = false;
        }

        // Handles click on the delete all expenses button. Opens the delete all form for expenses.
        private void btnDelAll_E_Click(object sender, EventArgs e)
        {
            if (IsTableEmpty("expenses"))
            {
                btnDelAll_E.Visible = false;
                return;
            }

            GlobalData.CurrentType = "Expenses";

            if (deleteAllForm == null || deleteAllForm.IsDisposed)
            {
                deleteAllForm = new DeleteAll();
                deleteAllForm.Show();
            }
            else
            {
                deleteAllForm.BringToFront();
                deleteAllForm.Focus();
            }

            btnDelAll_E.Visible = false;
        }


        // Handles navigation to the history panel.

        private void btnNav_3_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_3);
            pnl_3.Visible = true;
            pnl_3.BringToFront();

            pnl_1.Visible = false;
            pnl_2.Visible = false;
        }

        
        // Highlights the selected navigation button.
        
        private void HighlightNavButton(Button selectedButton)
        {
            // Reset all nav buttons to white
            btnNav_1.BackColor = Color.White;
            btnNav_2.BackColor = Color.White;
            btnNav_3.BackColor = Color.White;

            // Set the selected one to highlight color
            selectedButton.BackColor = Color.FromArgb(240, 245, 255);
        }

        
        // Handles navigation to the expenses panel.
        
        private void btnNav_2_Click_1(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_2);
            pnl_2.Visible = true;
            pnl_2.BringToFront();

            pnl_1.Visible = false;
            pnl_3.Visible = false;
        }

        
        // Handles navigation to the savings panel.
        
        private void btnNav_1_Click_1(object sender, EventArgs e)
        {
            HighlightNavButton(btnNav_1);
            pnl_1.Visible = true;
            pnl_1.BringToFront();

            pnl_2.Visible = false;
            pnl_3.Visible = false;
        }

        
        // Sets a new goal amount from the textbox input.
        
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

        
        // Handles the search button click event.
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        
        // Handles text changed event for the search textbox.
        
        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        
        // Handles enter event for the search textbox.
        
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            PerformSearch();
        }

        
        // Marks panels as dirty to trigger refresh on next visibility change.
        
        private void MarkPanelsDirty()
        {
            isPnl1Dirty = true;
            isPnl3Dirty = true;
        }

        
        // Refreshes the savings panel and related UI components.
        
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

        
        // Refreshes the expenses panel and related UI components.
        
        private void RefreshPnl3()
        {
            LoadExpensesToPanel();
            LoadSavingsToPanel();
            LoadHistory();
            UpdateTotalLabels();
        }

        
        // Handles visibility change for the savings panel.
        
        private void pnl_1_VisibleChanged(object sender, EventArgs e)
        {
            if (pnl_1.Visible && isPnl1Dirty)
            {
                RefreshPnl1();
                isPnl1Dirty = false;
            }
        }

        
        // Handles visibility change for the expenses panel.
        
        private void pnl_3_VisibleChanged(object sender, EventArgs e)
        {
            if (pnl_3.Visible && isPnl3Dirty)
            {
                RefreshPnl3();
                isPnl3Dirty = false;
            }
        }

        
        // Handles row selection change in the expenses panel.
        
        private void ExpensesPanel_SelectedRowChanged(object sender, EventArgs e)
        {
            // You can enable/disable a Modify button for expenses if needed
        }


        // Handles request to modify an expenses row.

        private UpdateDeleteForm addForm7 = null;
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

                if (addForm7 == null || addForm7.IsDisposed)
                {
                    addForm7 = new UpdateDeleteForm(this);
                    addForm7.Show();
                    addForm7.ShowExpensePanel();
                }
                else
                {
                    addForm7.BringToFront();
                    addForm7.Focus();
                }
            }
        }


        private void tbl_Spend_Paint(object sender, PaintEventArgs e)
        {

        }

        // Triggers a refresh of the expenses panel asynchronously.
        public async void TriggerRefreshPnl3()
        {
            await RefreshDataAsync();
        }

        
        // Triggers a refresh of the main form asynchronously.
        public async void TriggerBtnRefreshClick()
        {
            await RefreshDataAsync();
        }

        // Loads the record count for savings and expenses and updates the UI.
        private void LoadRecordCount()
        {
            int savingsCount = CRUD.GetSavingsCount();
            int expensesCount = CRUD.GetExpensesCount();
            lblSavingsCnt.Text = savingsCount.ToString();
            lblExpensesCnt.Text = expensesCount.ToString();
        }
    }
}
