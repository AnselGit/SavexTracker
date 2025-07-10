using SavexTracker.forms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavexTracker
{
    public partial class Form1 : SolidRoundedForm
    {
        public Form1()
        {
            InitializeComponent();
            LoadSavingsToPanel();
            LoadExpensesToPanel();
            EnsureDatabaseAndTable();
        }

        private void EnsureDatabaseAndTable()
        {
            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            bool dbExists = File.Exists(dbPath);

            if (!dbExists)
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                // 1. Savings Table
                string createSavingsTable = @"
        CREATE TABLE IF NOT EXISTS savings (
            sid INTEGER PRIMARY KEY AUTOINCREMENT,
            tbxName TEXT NOT NULL,
            timestamp TEXT NOT NULL,
            amount REAL NOT NULL
        );";

                // 2. Archive Table
                string createArchiveTable = @"
        CREATE TABLE IF NOT EXISTS archive (
            aid INTEGER PRIMARY KEY AUTOINCREMENT,
            sid INTEGER,
            name TEXT,
            txtNameDate1 TEXT,
            txtNameAmount1 TEXT,
            timestamp1 TEXT,
            amount1 REAL,
            eid INTEGER,
            txtNameDate2 TEXT,
            txtNameAmount2 TEXT,
            timestamp2 TEXT,
            amount2 REAL,
            note TEXT
        );";

                // 3. Expenses Table
                string createExpensesTable = @"
        CREATE TABLE IF NOT EXISTS expenses (
            eid INTEGER PRIMARY KEY AUTOINCREMENT,
            timestamp TEXT NOT NULL,
            amount REAL NOT NULL,
            note TEXT
        );";

                // Execute all table creations
                using (SQLiteCommand cmd = new SQLiteCommand(createSavingsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createArchiveTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createExpensesTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureDatabaseAndTable();            
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
            btnRefresh.Text = "Refreshing";
            btnRefresh.Enabled = false;

            LoadSavingsToPanel(); 
            LoadExpensesToPanel();

            await Task.Delay(500);
            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
        }

        private void LoadSavingsToPanel()
        {
            tblSave.Controls.Clear();
            tblSave.RowStyles.Clear();
            tblSave.RowCount = 0;
            tblSave.AutoScroll = true;

            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string query = "SELECT txtNameDate, txtNameAmount, timestamp, amount FROM savings ORDER BY sid DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int row = 0;

                    while (reader.Read())
                    {
                        string txtNameDate = reader["txtNameDate"].ToString();
                        string txtNameAmount = reader["txtNameAmount"].ToString();
                        string timestamp = reader["timestamp"].ToString();
                        double amount = Convert.ToDouble(reader["amount"]);

                        // RJTextBoxes (unchanged)
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
                            Size = new Size(90, 35),
                            Font = new Font("Microsoft Sans Serif", 12F),
                            Margin = new Padding(5)
                        };

                        var amtBox = new RJCodeAdvance.RJControls.RJTextBox
                        {
                            Name = txtNameAmount,
                            Texts = "₱" + amount.ToString(),
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

                        // Add RJTextBoxes row
                        tblSave.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        tblSave.Controls.Add(dateBox, 0, tblSave.RowCount);
                        tblSave.Controls.Add(amtBox, 1, tblSave.RowCount);
                        tblSave.RowCount++;

                        // Replace subpanel + label with a single Button
                        Button btnModify = new Button
                        {
                            Text = "Modify",
                            Name = "btnModify_" + row,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.White,
                            ForeColor = Color.White,
                            Font = new Font("Noto Sans", 9, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            Dock = DockStyle.Left,
                            Size = new Size(230, 20),
                            Margin = new Padding(0)
                        };

                        // Optional hover effect
                        btnModify.MouseEnter += (s, e) => btnModify.BackColor = Color.FromArgb(30, 144, 255); // DodgerBlue
                        btnModify.MouseLeave += (s, e) => btnModify.BackColor = Color.White;

                        // Button click event
                        btnModify.Click += (s, e) =>
                        {
                            GlobalData.CurrentTxtNameDate = txtNameDate;
                            GlobalData.CurrentTxtNameAmount = txtNameAmount;
                            GlobalData.CurrentTimestamp = timestamp;
                            GlobalData.CurrentAmount = amount;

                            using (var conn2 = new SQLiteConnection(connStr))
                            {
                                conn2.Open();
                                string idQuery = "SELECT sid FROM savings WHERE txtNameDate = @date AND txtNameAmount = @amount";
                                using (var cmdID = new SQLiteCommand(idQuery, conn2))
                                {
                                    cmdID.Parameters.AddWithValue("@date", txtNameDate);
                                    cmdID.Parameters.AddWithValue("@amount", txtNameAmount);
                                    object result = cmdID.ExecuteScalar();
                                    if (result != null)
                                        GlobalData.CurrentID = Convert.ToInt32(result);
                                }
                            }

                            var updateForm = new UpdateDeleteForm();
                            updateForm.Show();
                        };

                        // Add the button to a new row
                        tblSave.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                        tblSave.Controls.Add(btnModify, 0, tblSave.RowCount);
                        tblSave.SetColumnSpan(btnModify, 2);
                        tblSave.RowCount++;

                        row++;
                    }
                }
            }
        }

        private void LoadExpensesToPanel()
        {
            tbl_Spend.Controls.Clear();
            tbl_Spend.RowStyles.Clear();
            tbl_Spend.RowCount = 0;
            tbl_Spend.AutoScroll = true;

            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string query = "SELECT eid, timestamp, amount, note FROM expenses ORDER BY eid DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int row = 0;

                    while (reader.Read())
                    {
                        int eid = Convert.ToInt32(reader["eid"]);
                        string timestamp = reader["timestamp"].ToString();
                        double amount = Convert.ToDouble(reader["amount"]);
                        string note = reader["note"] != DBNull.Value ? reader["note"].ToString() : "";

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
                            Size = new Size(77, 35),
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
                            Size = new Size(82, 35),
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
                            Size = new Size(252, 35),
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
                            Dock = DockStyle.Left,
                            Size = new Size(230, 20),
                            Margin = new Padding(0)
                        };

                        btnModify.MouseEnter += (s, e) => btnModify.BackColor = Color.FromArgb(30, 144, 255);
                        btnModify.MouseLeave += (s, e) => btnModify.BackColor = Color.White;

                        btnModify.Click += (s, e) =>
                        {
                            GlobalData.CurrentID = eid;
                            GlobalData.CurrentTimestamp = timestamp;
                            GlobalData.CurrentAmount = amount;
                            //GlobalData.CurrentNote = note;

                            var updateForm = new UpdateDeleteForm();
                            updateForm.Show();
                        };

                        tbl_Spend.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                        tbl_Spend.Controls.Add(btnModify, 0, tbl_Spend.RowCount);
                        tbl_Spend.SetColumnSpan(btnModify, 3);
                        tbl_Spend.RowCount++;

                        row++;
                    }
                }
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            addExpense addForm = new addExpense();
            addForm.Show();
        }
    }

    public class VerticalFlowPanel : FlowLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00100000; // WS_HSCROLL = 0x00100000
                return cp;
            }
        }
    }
}
