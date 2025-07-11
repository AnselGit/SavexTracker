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
    public partial class ArchiveForm : Form
    {
        public ArchiveForm()
        {
            InitializeComponent();            
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            SetupArchiveGrid();
            LoadArchiveData();
            btnRestore.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void LoadArchiveData()
        {
            dgv_Archive.Rows.Clear();

            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                string query = "SELECT name, timestamp1, amount1, timestamp2, amount2 FROM archive ORDER BY ROWID DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string type = reader["name"].ToString();

                        string date = type == "Savings"
                            ? reader["timestamp1"]?.ToString() ?? ""
                            : reader["timestamp2"]?.ToString() ?? "";

                        string amount = type == "Savings"
                            ? Convert.ToDouble(reader["amount1"]).ToString("₱0.00")
                            : Convert.ToDouble(reader["amount2"]).ToString("₱0.00");

                        string note = ""; // Add note logic here if needed

                        dgv_Archive.Rows.Add(type, date, amount, note);
                    }
                }
            }
        }

        private void SetupArchiveGrid()
        {
            dgv_Archive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Archive.MultiSelect = false;
            dgv_Archive.ReadOnly = true;
            dgv_Archive.AllowUserToAddRows = false;
            dgv_Archive.AllowUserToDeleteRows = false;
            dgv_Archive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Archive.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv_Archive.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_Archive.EnableHeadersVisualStyles = false;
            dgv_Archive.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            dgv_Archive.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv_Archive.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dgv_Archive_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = dgv_Archive.SelectedRows.Count > 0;
            btnRestore.Enabled = rowSelected;
            btnDelete.Enabled = rowSelected;
        }

        private void dgv_Archive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
