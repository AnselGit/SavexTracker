using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using SavexTracker; // for AppConfig and GlobalData

namespace SavexTracker.forms
{
    public partial class ArchiveForm : Form
    {
        public ArchiveForm()
        {
            InitializeComponent();
            SetupArchiveGrid();
            LoadArchiveData();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            SetupArchiveGrid();
            LoadArchiveData();
            dgv_Archive.SelectionChanged += dgv_Archive_SelectionChanged_1;
            btnRestore.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }

        private void LoadArchiveData()
        {
            dgv_Archive.Rows.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT sid, eid, name, 
                           timestamp1, amount1, 
                           timestamp2, amount2, 
                           note 
                    FROM archive 
                    ORDER BY ROWID DESC";

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
                            ? Convert.ToDouble(reader["amount1"]).ToString("\u20B10.00")
                            : Convert.ToDouble(reader["amount2"]).ToString("\u20B10.00");

                        string note = reader["note"] != DBNull.Value ? reader["note"].ToString() : "";

                        object sid = reader["sid"];
                        object eid = reader["eid"];
                        string id = (sid != DBNull.Value) ? sid.ToString() : eid.ToString();

                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgv_Archive);

                        if (dgv_Archive.Columns.Contains("colId")) row.Cells[dgv_Archive.Columns["colId"].Index].Value = id;
                        if (dgv_Archive.Columns.Contains("colType")) row.Cells[dgv_Archive.Columns["colType"].Index].Value = type;
                        if (dgv_Archive.Columns.Contains("colDate")) row.Cells[dgv_Archive.Columns["colDate"].Index].Value = date;
                        if (dgv_Archive.Columns.Contains("colAmount")) row.Cells[dgv_Archive.Columns["colAmount"].Index].Value = amount;
                        if (dgv_Archive.Columns.Contains("colNote")) row.Cells[dgv_Archive.Columns["colNote"].Index].Value = note;

                        dgv_Archive.Rows.Add(row);
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

        private void dgv_Archive_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgv_Archive.CurrentRow == null) return;

            var row = dgv_Archive.CurrentRow;

            GlobalData.Archive_type = row.Cells["colType"].Value?.ToString();
            GlobalData.Archive_note = row.Cells["colNote"].Value?.ToString();
            string idText = row.Cells["colId"].Value?.ToString();

            if (!int.TryParse(idText, out int archiveId)) return;

            using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT sid, eid, timestamp1, amount1, timestamp2, amount2, note 
                    FROM archive 
                    WHERE sid = @id OR eid = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", archiveId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GlobalData.Archive_sid = reader["sid"] != DBNull.Value ? Convert.ToInt32(reader["sid"]) : (int?)null;
                            GlobalData.Archive_eid = reader["eid"] != DBNull.Value ? Convert.ToInt32(reader["eid"]) : (int?)null;

                            GlobalData.Archive_timestamp1 = reader["timestamp1"]?.ToString();
                            GlobalData.Archive_timestamp2 = reader["timestamp2"]?.ToString();

                            GlobalData.Archive_amount1 = reader["amount1"] != DBNull.Value ? Convert.ToDouble(reader["amount1"]) : (double?)null;
                            GlobalData.Archive_amount2 = reader["amount2"] != DBNull.Value ? Convert.ToDouble(reader["amount2"]) : (double?)null;

                            GlobalData.Archive_note = reader["note"]?.ToString();
                        }
                    }
                }
            }

            btnRestore.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            pnlRestored.Visible = true;
            pnlRestored.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();            
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Archive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlDeleteCon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            if (dgv_Archive.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "This will permanently delete the record from archive.\nAre you sure?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string type = dgv_Archive.CurrentRow.Cells["colType"].Value.ToString();
            int id = Convert.ToInt32(dgv_Archive.CurrentRow.Cells["colId"].Value);

            using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                string deleteQuery = "DELETE FROM archive WHERE " + (type == "Savings" ? "sid" : "eid") + " = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }            
            LoadArchiveData();
            RefreshRecord();
            pnlDeleted.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500;
            hideTimer.Tick += (s, args) =>
            {
                pnlDeleteCon.Visible = false;
                pnlDeleted.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            pnlRestoreCon.Visible = false;
            pnlRestored.Visible = false;
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GlobalData.Archive_type))
            {
                MessageBox.Show("No archive item selected.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                if (GlobalData.Archive_type == "Savings")
                {
                    string query = "INSERT INTO savings (timestamp, amount) VALUES (@timestamp, @amount)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@timestamp", GlobalData.Archive_timestamp1);
                        cmd.Parameters.AddWithValue("@amount", GlobalData.Archive_amount1);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (GlobalData.Archive_type == "Expenses")
                {
                    string query = "INSERT INTO expenses (timestamp, amount, note) VALUES (@timestamp, @amount, @note)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@timestamp", GlobalData.Archive_timestamp2);
                        cmd.Parameters.AddWithValue("@amount", GlobalData.Archive_amount2);
                        cmd.Parameters.AddWithValue("@note", GlobalData.Archive_note);
                        cmd.ExecuteNonQuery();
                    }
                }

                string deleteQuery = "DELETE FROM archive WHERE sid = @id OR eid = @id";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    var id = GlobalData.Archive_sid ?? GlobalData.Archive_eid;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                
            }

            LoadArchiveData();
            RefreshRecord();
            pnlRestored.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 1500;
            hideTimer.Tick += (s, args) =>
            {
                pnlRestoreCon.Visible = false;
                pnlRestored.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }
    }
}
