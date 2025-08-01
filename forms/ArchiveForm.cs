﻿using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using SavexTracker; // for AppConfig and GlobalData
using SavexTracker.Models;
using System.Collections.Generic;
using SavexTracker.Database;
using System.Threading.Tasks; // Added for Task

namespace SavexTracker.forms
{
    /// <summary>
    /// ArchiveForm provides UI and logic for viewing, restoring, and deleting archived savings and expenses.
    /// </summary>
    public partial class ArchiveForm : Form
    {
        /// <summary>
        /// Initializes the ArchiveForm, sets up the grid, and loads archive data.
        /// </summary>
        public ArchiveForm()
        {
            InitializeComponent();
            SetupArchiveGrid();
            LoadArchiveData();
            dgv_Archive.ClearSelection();
        }

        /// <summary>
        /// Handles the form load event. Sets up the grid, loads data, and attaches selection event.
        /// </summary>
        private void ArchiveForm_Load(object sender, EventArgs e)
        {            
            SetupArchiveGrid();
            LoadArchiveData();
            dgv_Archive.SelectionChanged += dgv_Archive_SelectionChanged_1;
            btnRestore.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// Refreshes the main form's data asynchronously.
        /// </summary>
        private async Task RefreshRecord()
        {
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                await mainForm.RefreshDataAsync();
            }
        }

        /// <summary>
        /// Loads all archive data into the DataGridView for display.
        /// </summary>
        private void LoadArchiveData()
        {
            dgv_Archive.Rows.Clear();

            var archiveList = GlobalData.AllArchive ?? new List<ArchiveItem>();
            foreach (var item in archiveList)
            {
                string type = item.Name;
                string date = type == "Savings"
                    ? item.Timestamp1 ?? ""
                    : item.Timestamp2 ?? "";
                string amount = type == "Savings"
                    ? (item.Amount1 ?? 0).ToString("\u20B10.00")
                    : (item.Amount2 ?? 0).ToString("\u20B10.00");
                string note = item.Note ?? "";
                string id = item.Sid.HasValue ? item.Sid.ToString() : item.Eid.ToString();

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_Archive);

                // Set cell values for each column if present
                if (dgv_Archive.Columns.Contains("colId")) row.Cells[dgv_Archive.Columns["colId"].Index].Value = id;
                if (dgv_Archive.Columns.Contains("colType")) row.Cells[dgv_Archive.Columns["colType"].Index].Value = type;
                if (dgv_Archive.Columns.Contains("colDate")) row.Cells[dgv_Archive.Columns["colDate"].Index].Value = date;
                if (dgv_Archive.Columns.Contains("colAmount")) row.Cells[dgv_Archive.Columns["colAmount"].Index].Value = amount;
                if (dgv_Archive.Columns.Contains("colNote")) row.Cells[dgv_Archive.Columns["colNote"].Index].Value = note;

                dgv_Archive.Rows.Add(row);
            }
        }

        /// <summary>
        /// Configures the DataGridView for archive display.
        /// </summary>
        private void SetupArchiveGrid()
        {
            dgv_Archive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Archive.MultiSelect = true;
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

        /// <summary>
        /// Handles selection change in the archive DataGridView. Updates global state and enables buttons.
        /// </summary>
        private void dgv_Archive_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgv_Archive.CurrentRow == null) return;

            var row = dgv_Archive.CurrentRow;

            GlobalData.Archive_type = row.Cells["colType"].Value?.ToString();
            GlobalData.CurrentType = row.Cells["colType"].Value?.ToString();
            GlobalData.Archive_note = row.Cells["colNote"].Value?.ToString();
            string idText = row.Cells["colId"].Value?.ToString();

            if (!int.TryParse(idText, out int archiveId)) return;

            // No direct DB logic here; if details needed, add CRUD.GetArchiveItemDetails(archiveId)
            // (Assume GlobalData is set from archive list)

            btnRestore.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Flicker effect variables
        private int flickerCount = 0;
        private Timer flickerTimer;
        private Color originalColor;

        /// <summary>
        /// Triggers a flicker effect on the form background for delete confirmation.
        /// </summary>
        private void FlickerDeleteAllBackground()
        {
            originalColor = this.BackColor; // Save original
            flickerCount = 0;

            flickerTimer = new Timer();
            flickerTimer.Interval = 100; // 0.5 seconds
            flickerTimer.Tick += FlickerTimer_Tick;
            flickerTimer.Start();
        }

        /// <summary>
        /// Handles the flicker timer tick event to alternate background color.
        /// </summary>
        private void FlickerTimer_Tick(object sender, EventArgs e)
        {
            if (flickerCount % 2 == 0)
            {
                this.BackColor = Color.FromArgb(255, 128, 128); // flicker color
            }
            else
            {
                this.BackColor = originalColor; // back to normal
            }

            flickerCount++;

            if (flickerCount >= 6) // two full cycles: (on-off) x2
            {
                flickerTimer.Stop();
                flickerTimer.Dispose();
                this.BackColor = originalColor; // ensure it's reset
            }
        }

        /// <summary>
        /// Shows the restore confirmation panel.
        /// </summary>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            pnlRestoreCon.Visible = true;
            pnlRestoreCon.BringToFront();
        }

        /// <summary>
        /// Shows the delete confirmation panel and triggers flicker effect.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
            pnlDeleteCon.BringToFront();            
            FlickerDeleteAllBackground();
        }

        /// <summary>
        /// Closes the ArchiveForm.
        /// </summary>
        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the delete confirmation. Deletes selected archive items and refreshes the view.
        /// </summary>
        private async void rjButton4_Click(object sender, EventArgs e)
        {
            if (dgv_Archive.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in dgv_Archive.SelectedRows)
            {
                string type = row.Cells["colType"].Value?.ToString();
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                CRUD.DeleteArchiveItem(id, type);
            }

            GlobalData.AllArchive = CRUD.GetAllArchive();
            LoadArchiveData();
            await RefreshRecord();
            pnlDeleted.Visible = true;

            // Hide the confirmation panel after a short delay
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

        /// <summary>
        /// Cancels the delete confirmation panel.
        /// </summary>
        private void rjButton3_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;            
        }

        /// <summary>
        /// Cancels the restore confirmation panel.
        /// </summary>
        private void rjButton1_Click(object sender, EventArgs e)
        {
            pnlRestoreCon.Visible = false;            
        }

        /// <summary>
        /// Handles the restore confirmation. Restores selected archive items and refreshes the view.
        /// </summary>
        private async void rjButton5_Click(object sender, EventArgs e)
        {
            if (dgv_Archive.SelectedRows.Count == 0)
            {
                MessageBox.Show("No archive items selected.");
                return;
            }

            var itemsToRestore = new List<(int id, string type)>();
            foreach (DataGridViewRow row in dgv_Archive.SelectedRows)
            {
                string type = row.Cells["colType"].Value?.ToString();
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                itemsToRestore.Add((id, type));
            }
            CRUD.RestoreArchiveItems(itemsToRestore);

            GlobalData.AllArchive = CRUD.GetAllArchive();
            LoadArchiveData();

            // Replace RefreshRecord with async refresh
            Form1 mainForm = null;
            if (Application.OpenForms["Form1"] is Form1 form)
                mainForm = form;
            if (mainForm != null)
            {
                await mainForm.RefreshDataAsync();
            }

            pnlRestored.Visible = true;

            // Hide the confirmation panel after a short delay
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

        /// <summary>
        /// Handles the select/deselect all link for the DataGridView.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //dgv_Archive.ClearSelection();
            if (linkLabel1.Text == "Select All")
            {
                foreach (DataGridViewRow row in dgv_Archive.Rows)
                {
                    row.Selected = true;
                }
                linkLabel1.Text = "Deselect All";
            }
            else
            {
                dgv_Archive.ClearSelection();
                linkLabel1.Text = "Select All";
            }
        }
    }
}
