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

                string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS savings (
            sid INTEGER PRIMARY KEY AUTOINCREMENT,
            tbxName TEXT NOT NULL,
            timestamp TEXT NOT NULL,
            amount REAL NOT NULL
        );";

                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
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
            addForm.ShowDialog(); // Modal — pauses until form is closed
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

            await Task.Delay(500); // short delay
            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
        }

        private void LoadSavingsToPanel()
        {
            // Ensure table layout is ready
            tblSave.Controls.Clear();
            tblSave.RowStyles.Clear();
            tblSave.RowCount = 0;
            tblSave.AutoScroll = true; // Allow scrolling if rows overflow

            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string query = "SELECT txtNameDate, txtNameAmount, timestamp, amount FROM savings";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int row = 0;

                    while (reader.Read())
                    {
                        var dateBox = new RJCodeAdvance.RJControls.RJTextBox
                        {
                            Name = reader["txtNameDate"].ToString(),
                            Texts = reader["timestamp"].ToString(),                            
                            BackColor = Color.White,
                            BorderColor = Color.FromArgb(224, 224, 224),
                            BorderFocusColor = Color.MediumSlateBlue,
                            BorderRadius = 0,
                            BorderSize = 1,
                            ForeColor = Color.Silver,
                            UnderlinedStyle = true,
                            Size = new Size(90, 35),
                            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                            Margin = new Padding(5)
                        };

                        var amtBox = new RJCodeAdvance.RJControls.RJTextBox
                        {
                            Name = reader["txtNameAmount"].ToString(),
                            Texts = "₱" + reader["amount"].ToString(),                            
                            BackColor = Color.White,
                            BorderColor = Color.FromArgb(224, 224, 224),
                            BorderFocusColor = Color.MediumSlateBlue,
                            BorderRadius = 0,
                            BorderSize = 1,
                            ForeColor = Color.FromArgb(64, 64, 64),
                            UnderlinedStyle = true,
                            Size = new Size(131, 35),
                            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                            Margin = new Padding(5)
                        };

                        // Add a new row style to allow growth
                        tblSave.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        tblSave.Controls.Add(dateBox, 0, row);
                        tblSave.Controls.Add(amtBox, 1, row);

                        row++;
                        tblSave.RowCount = row; // Ensure row count matches
                    }
                }
            }
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
