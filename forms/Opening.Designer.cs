namespace SavexTracker.forms
{
    partial class Opening
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.pgb_init = new RJCodeAdvance.RJControls.RJProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Smooth Circulars", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.ForeColor = System.Drawing.Color.White;
            this.lbl_Name.Location = new System.Drawing.Point(27, 9);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(361, 124);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "SAVEX";
            // 
            // pgb_init
            // 
            this.pgb_init.BackColor = System.Drawing.Color.White;
            this.pgb_init.ChannelColor = System.Drawing.Color.SlateBlue;
            this.pgb_init.ChannelHeight = 6;
            this.pgb_init.ForeBackColor = System.Drawing.Color.SlateBlue;
            this.pgb_init.ForeColor = System.Drawing.Color.White;
            this.pgb_init.Location = new System.Drawing.Point(12, 364);
            this.pgb_init.Name = "pgb_init";
            this.pgb_init.ShowMaximun = false;
            this.pgb_init.ShowValue = RJCodeAdvance.RJControls.TextPosition.Right;
            this.pgb_init.Size = new System.Drawing.Size(640, 23);
            this.pgb_init.SliderColor = System.Drawing.Color.White;
            this.pgb_init.SliderHeight = 6;
            this.pgb_init.SymbolAfter = "";
            this.pgb_init.SymbolBefore = "";
            this.pgb_init.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initialing...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your Savings and Expenses Tracker\r\n";
            // 
            // Opening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(664, 399);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgb_init);
            this.Controls.Add(this.lbl_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Opening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening";
            this.Load += new System.EventHandler(this.Opening_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private RJCodeAdvance.RJControls.RJProgressBar pgb_init;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}