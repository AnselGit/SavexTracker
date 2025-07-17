using SavexTracker.CustomClasses;

namespace SavexTracker.forms
{
    partial class addExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addExpense));
            this.roundedPanel1 = new SavexTracker.CustomClasses.RoundedPanel();
            this.txtNote = new RJCodeAdvance.RJControls.RJTextBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.btn_save = new RJCodeAdvance.RJControls.RJButton();
            this.roundedPanel2 = new SavexTracker.CustomClasses.RoundedPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_SA = new RJCodeAdvance.RJControls.RJTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAdded = new SavexTracker.CustomClasses.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.roundedPanel6 = new SavexTracker.CustomClasses.RoundedPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlAdded.SuspendLayout();
            this.roundedPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderRadius = 30;
            this.roundedPanel1.Controls.Add(this.txtNote);
            this.roundedPanel1.Controls.Add(this.lbl_date);
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.Controls.Add(this.rjButton2);
            this.roundedPanel1.Controls.Add(this.btn_save);
            this.roundedPanel1.Controls.Add(this.roundedPanel2);
            this.roundedPanel1.Controls.Add(this.txt_SA);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Location = new System.Drawing.Point(12, 12);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(792, 334);
            this.roundedPanel1.TabIndex = 2;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.txtNote.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.txtNote.BorderRadius = 0;
            this.txtNote.BorderSize = 3;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNote.Location = new System.Drawing.Point(541, 202);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = false;
            this.txtNote.Name = "txtNote";
            this.txtNote.Padding = new System.Windows.Forms.Padding(30, 7, 10, 7);
            this.txtNote.PasswordChar = false;
            this.txtNote.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.txtNote.PlaceholderText = "Enter a note...";
            this.txtNote.Size = new System.Drawing.Size(214, 46);
            this.txtNote.TabIndex = 2;
            this.txtNote.Texts = "";
            this.txtNote.UnderlinedStyle = true;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_date.Location = new System.Drawing.Point(429, 160);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(104, 32);
            this.lbl_date.TabIndex = 14;
            this.lbl_date.Text = "00/00/00";
            this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(389, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "at -";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Noto Sans ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateBlue;
            this.label1.Location = new System.Drawing.Point(382, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 73);
            this.label1.TabIndex = 12;
            this.label1.Text = "An Expense";
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.OrangeRed;
            this.rjButton2.BackgroundColor = System.Drawing.Color.OrangeRed;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 23;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(618, 255);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(82, 46);
            this.rjButton2.TabIndex = 4;
            this.rjButton2.Text = "Cancel";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.btn_save.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.btn_save.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_save.BorderRadius = 23;
            this.btn_save.BorderSize = 0;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(395, 255);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(217, 46);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Spend now";
            this.btn_save.TextColor = System.Drawing.Color.White;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.roundedPanel2.BorderRadius = 40;
            this.roundedPanel2.Controls.Add(this.pictureBox2);
            this.roundedPanel2.Controls.Add(this.pictureBox1);
            this.roundedPanel2.Location = new System.Drawing.Point(14, 13);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(342, 309);
            this.roundedPanel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(190, 136);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txt_SA
            // 
            this.txt_SA.BackColor = System.Drawing.Color.White;
            this.txt_SA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.txt_SA.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.txt_SA.BorderRadius = 0;
            this.txt_SA.BorderSize = 3;
            this.txt_SA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_SA.Location = new System.Drawing.Point(395, 202);
            this.txt_SA.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SA.Multiline = false;
            this.txt_SA.Name = "txt_SA";
            this.txt_SA.Padding = new System.Windows.Forms.Padding(30, 7, 10, 7);
            this.txt_SA.PasswordChar = false;
            this.txt_SA.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.txt_SA.PlaceholderText = "";
            this.txt_SA.Size = new System.Drawing.Size(138, 46);
            this.txt_SA.TabIndex = 1;
            this.txt_SA.Texts = "";
            this.txt_SA.UnderlinedStyle = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SlateBlue;
            this.label3.Location = new System.Drawing.Point(378, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 97);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add";
            // 
            // pnlAdded
            // 
            this.pnlAdded.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlAdded.BorderRadius = 30;
            this.pnlAdded.Controls.Add(this.label2);
            this.pnlAdded.Controls.Add(this.label10);
            this.pnlAdded.Controls.Add(this.roundedPanel6);
            this.pnlAdded.Location = new System.Drawing.Point(12, 12);
            this.pnlAdded.Name = "pnlAdded";
            this.pnlAdded.Size = new System.Drawing.Size(792, 334);
            this.pnlAdded.TabIndex = 20;
            this.pnlAdded.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateBlue;
            this.label2.Location = new System.Drawing.Point(334, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 73);
            this.label2.TabIndex = 19;
            this.label2.Text = "Successfully";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Noto Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SlateBlue;
            this.label10.Location = new System.Drawing.Point(334, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 73);
            this.label10.TabIndex = 18;
            this.label10.Text = "Added!";
            // 
            // roundedPanel6
            // 
            this.roundedPanel6.BackColor = System.Drawing.Color.SlateBlue;
            this.roundedPanel6.BorderRadius = 40;
            this.roundedPanel6.Controls.Add(this.pictureBox3);
            this.roundedPanel6.Location = new System.Drawing.Point(145, 80);
            this.roundedPanel6.Name = "roundedPanel6";
            this.roundedPanel6.Size = new System.Drawing.Size(172, 172);
            this.roundedPanel6.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(23, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 125);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // addExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(816, 358);
            this.Controls.Add(this.pnlAdded);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addExpense";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addExpense";
            this.Load += new System.EventHandler(this.addExpense_Load);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlAdded.ResumeLayout(false);
            this.pnlAdded.PerformLayout();
            this.roundedPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private RJCodeAdvance.RJControls.RJButton btn_save;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJCodeAdvance.RJControls.RJTextBox txt_SA;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJTextBox txtNote;
        private RoundedPanel pnlAdded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private RoundedPanel roundedPanel6;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}