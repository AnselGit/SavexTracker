namespace SavexTracker.forms
{
    partial class ArchiveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveForm));
            this.roundedPanel1 = new RoundedPanel();
            this.btnDelete = new RJCodeAdvance.RJControls.RJButton();
            this.btnRestore = new RJCodeAdvance.RJControls.RJButton();
            this.dgv_Archive = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Archive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderRadius = 50;
            this.roundedPanel1.Controls.Add(this.btnDelete);
            this.roundedPanel1.Controls.Add(this.btnRestore);
            this.roundedPanel1.Controls.Add(this.dgv_Archive);
            this.roundedPanel1.Controls.Add(this.label6);
            this.roundedPanel1.Controls.Add(this.label9);
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.Location = new System.Drawing.Point(12, 12);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(776, 553);
            this.roundedPanel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDelete.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(590, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "rjButton2";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRestore.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRestore.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRestore.BorderRadius = 0;
            this.btnRestore.BorderSize = 0;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(434, 483);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(150, 40);
            this.btnRestore.TabIndex = 18;
            this.btnRestore.Text = "rjButton1";
            this.btnRestore.TextColor = System.Drawing.Color.White;
            this.btnRestore.UseVisualStyleBackColor = false;
            // 
            // dgv_Archive
            // 
            this.dgv_Archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Archive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colDate,
            this.colAmount,
            this.colNote});
            this.dgv_Archive.Location = new System.Drawing.Point(46, 202);
            this.dgv_Archive.Name = "dgv_Archive";
            this.dgv_Archive.Size = new System.Drawing.Size(694, 260);
            this.dgv_Archive.TabIndex = 17;
            this.dgv_Archive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Archive_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(191, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(426, 64);
            this.label6.TabIndex = 16;
            this.label6.Text = "You can Restore or Delete (permanent) \r\nyour savings and expenses here.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Noto Sans Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(180, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 97);
            this.label9.TabIndex = 8;
            this.label9.Text = "Archive";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // colType
            // 
            this.colType.Frozen = true;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colNote
            // 
            this.colNote.HeaderText = "Note";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            this.colNote.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNote.Width = 350;
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArchiveForm";
            this.Text = "ArchiveForm";
            this.Load += new System.EventHandler(this.ArchiveForm_Load);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Archive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_Archive;
        private RJCodeAdvance.RJControls.RJButton btnDelete;
        private RJCodeAdvance.RJControls.RJButton btnRestore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}