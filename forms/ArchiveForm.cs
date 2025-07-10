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
            LoadArchivedData();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            LoadArchivedData();
        }

        private void LoadArchivedData()
        {
            string dbPath = @"C:\Users\22-65\Desktop\School\SavexTracker\database\CRUD.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                name AS 'Type',
                COALESCE(timestamp1, timestamp2) AS 'Timestamp',
                COALESCE(amount1, amount2) AS 'Amount',
                note AS 'Note'
            FROM archive
            ORDER BY aid DESC;";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Optional: format amount column with ₱
                    foreach (DataRow row in dt.Rows)
                    {
                        if (double.TryParse(row["Amount"].ToString(), out double amount))
                        {
                            row["Amount"] = $"₱{amount:0.00}";
                        }
                    }

                    dgv_Archive.DataSource = dt;
                }
            }
        }



    }
}
