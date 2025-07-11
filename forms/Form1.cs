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
            EnsureDatabaseAndTable();
            LoadExpensesToPanel();
            LoadSavingsToPanel();                        
        }

        public async Task RefreshDataAsync()
        {
            btnRefresh.Text = "Refreshing";
            btnRefresh.Enabled = false;

            LoadSavingsToPanel();
            LoadExpensesToPanel();

            await Task.Delay(500);
            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
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
    timestamp TEXT NOT NULL,
    amount REAL NOT NULL
);";

                // 2. Clean Archive Table
                string createArchiveTable = @"
CREATE TABLE IF NOT EXISTS archive (
    aid INTEGER PRIMARY KEY AUTOINCREMENT,
    sid INTEGER,
    eid INTEGER,
    name TEXT,
    timestamp1 TEXT,
    amount1 REAL,
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

                using (SQLiteCommand cmd = new SQLiteCommand(createSavingsTable, conn))
                    cmd.ExecuteNonQuery();

                using (SQLiteCommand cmd = new SQLiteCommand(createArchiveTable, conn))
                    cmd.ExecuteNonQuery();

                using (SQLiteCommand cmd = new SQLiteCommand(createExpensesTable, conn))
                    cmd.ExecuteNonQuery();
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
            await RefreshDataAsync();
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
                string query = "SELECT sid, timestamp, amount FROM savings ORDER BY sid DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int row = 0;

                    while (reader.Read())
                    {
                        int sid = Convert.ToInt32(reader["sid"]);
                        string timestamp = reader["timestamp"].ToString();
                        double amount = Convert.ToDouble(reader["amount"]);

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
                            Size = new Size(90, 35),
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
                            Anchor = AnchorStyles.Top | AnchorStyles.Left,
                            Dock = DockStyle.None,
                            Size = new Size(430, 25),
                            Margin = new Padding(0)
                        };

                        btnModify.MouseEnter += (s, e) => btnModify.BackColor = Color.FromArgb(30, 144, 255);
                        btnModify.MouseLeave += (s, e) => btnModify.BackColor = Color.White;

                        btnModify.Click += (s, e) =>
                        {
                            GlobalData.CurrentID = eid;
                            GlobalData.CurrentTimestamp = timestamp;
                            GlobalData.CurrentAmount = amount;
                            GlobalData.CurrentNote = note;


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

        private void rjButton9_Click(object sender, EventArgs e)
        {
            ArchiveForm addForm = new ArchiveForm();
            addForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
