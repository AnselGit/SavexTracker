using System.Timers;

namespace SavexTracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rjButton9 = new RJCodeAdvance.RJControls.RJButton();
            this.btnRefresh = new RJCodeAdvance.RJControls.RJButton();
            this.gradientPanelRound6 = new GradientPanelRound();
            this.roundedPanel4 = new RoundedPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbl_Spend = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gradientPanelRound5 = new GradientPanelRound();
            this.pnlSave = new RoundedPanel();
            this.tblSave = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rjCircularPictureBox1 = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton3 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton4 = new RJCodeAdvance.RJControls.RJButton();
            this.roundedPanel7 = new RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjButton10 = new RJCodeAdvance.RJControls.RJButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.gradientPanelRound1 = new GradientPanelRound();
            this.roundedPanel2 = new RoundedPanel();
            this.materialListBox1 = new MaterialSkin.Controls.MaterialListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gradientPanelRound2 = new GradientPanelRound();
            this.gradientPanelRound3 = new GradientPanelRound();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rjButton6 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton5 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton7 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton8 = new RJCodeAdvance.RJControls.RJButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gradientPanelRound4 = new GradientPanelRound();
            this.label10 = new System.Windows.Forms.Label();
            this.roundedPanel11 = new RoundedPanel();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.roundedPanel10 = new RoundedPanel();
            this.lblTotalSave = new System.Windows.Forms.Label();
            this.roundedPanel9 = new RoundedPanel();
            this.lblGrand = new System.Windows.Forms.Label();
            this.roundedPanel1 = new RoundedPanel();
            this.roundedPanel8 = new RoundedPanel();
            this.panel1.SuspendLayout();
            this.gradientPanelRound6.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.gradientPanelRound5.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox1)).BeginInit();
            this.roundedPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gradientPanelRound1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            this.gradientPanelRound2.SuspendLayout();
            this.gradientPanelRound3.SuspendLayout();
            this.gradientPanelRound4.SuspendLayout();
            this.roundedPanel11.SuspendLayout();
            this.roundedPanel10.SuspendLayout();
            this.roundedPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.rjButton9);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.gradientPanelRound6);
            this.panel1.Controls.Add(this.gradientPanelRound5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(289, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 862);
            this.panel1.TabIndex = 0;
            // 
            // rjButton9
            // 
            this.rjButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton9.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton9.BorderColor = System.Drawing.Color.White;
            this.rjButton9.BorderRadius = 33;
            this.rjButton9.BorderSize = 0;
            this.rjButton9.FlatAppearance.BorderSize = 0;
            this.rjButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton9.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton9.ForeColor = System.Drawing.Color.White;
            this.rjButton9.Location = new System.Drawing.Point(695, 111);
            this.rjButton9.Name = "rjButton9";
            this.rjButton9.Size = new System.Drawing.Size(133, 65);
            this.rjButton9.TabIndex = 17;
            this.rjButton9.Text = "Archive";
            this.rjButton9.TextColor = System.Drawing.Color.White;
            this.rjButton9.UseVisualStyleBackColor = false;
            this.rjButton9.Click += new System.EventHandler(this.rjButton9_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnRefresh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.BorderRadius = 33;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(695, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 65);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gradientPanelRound6
            // 
            this.gradientPanelRound6.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelRound6.BorderRadius = 40;
            this.gradientPanelRound6.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Color2 = System.Drawing.Color.White;
            this.gradientPanelRound6.Color3 = System.Drawing.Color.White;
            this.gradientPanelRound6.Color4 = System.Drawing.Color.White;
            this.gradientPanelRound6.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Controls.Add(this.roundedPanel4);
            this.gradientPanelRound6.Controls.Add(this.label17);
            this.gradientPanelRound6.GradientAngle = 90F;
            this.gradientPanelRound6.Location = new System.Drawing.Point(349, 196);
            this.gradientPanelRound6.Name = "gradientPanelRound6";
            this.gradientPanelRound6.Size = new System.Drawing.Size(479, 637);
            this.gradientPanelRound6.TabIndex = 15;
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.White;
            this.roundedPanel4.BorderRadius = 60;
            this.roundedPanel4.Controls.Add(this.label12);
            this.roundedPanel4.Controls.Add(this.tbl_Spend);
            this.roundedPanel4.Controls.Add(this.label20);
            this.roundedPanel4.Controls.Add(this.label21);
            this.roundedPanel4.Location = new System.Drawing.Point(5, 60);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Size = new System.Drawing.Size(468, 549);
            this.roundedPanel4.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(41, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = "Date";
            // 
            // tbl_Spend
            // 
            this.tbl_Spend.AutoScroll = true;
            this.tbl_Spend.ColumnCount = 3;
            this.tbl_Spend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.77419F));
            this.tbl_Spend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.22581F));
            this.tbl_Spend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tbl_Spend.Location = new System.Drawing.Point(14, 39);
            this.tbl_Spend.Name = "tbl_Spend";
            this.tbl_Spend.RowCount = 1;
            this.tbl_Spend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.tbl_Spend.Size = new System.Drawing.Size(437, 484);
            this.tbl_Spend.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(304, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 24);
            this.label20.TabIndex = 12;
            this.label20.Text = "Note";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Location = new System.Drawing.Point(123, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 24);
            this.label21.TabIndex = 11;
            this.label21.Text = "Amount";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.SlateBlue;
            this.label17.Location = new System.Drawing.Point(188, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 32);
            this.label17.TabIndex = 10;
            this.label17.Text = "Expense";
            // 
            // gradientPanelRound5
            // 
            this.gradientPanelRound5.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelRound5.BorderRadius = 40;
            this.gradientPanelRound5.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Color2 = System.Drawing.Color.White;
            this.gradientPanelRound5.Color3 = System.Drawing.Color.White;
            this.gradientPanelRound5.Color4 = System.Drawing.Color.White;
            this.gradientPanelRound5.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Controls.Add(this.pnlSave);
            this.gradientPanelRound5.Controls.Add(this.label16);
            this.gradientPanelRound5.GradientAngle = 90F;
            this.gradientPanelRound5.Location = new System.Drawing.Point(28, 196);
            this.gradientPanelRound5.Name = "gradientPanelRound5";
            this.gradientPanelRound5.Size = new System.Drawing.Size(293, 637);
            this.gradientPanelRound5.TabIndex = 14;
            // 
            // pnlSave
            // 
            this.pnlSave.BackColor = System.Drawing.Color.White;
            this.pnlSave.BorderRadius = 60;
            this.pnlSave.Controls.Add(this.tblSave);
            this.pnlSave.Controls.Add(this.label19);
            this.pnlSave.Controls.Add(this.label18);
            this.pnlSave.Location = new System.Drawing.Point(4, 60);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(284, 549);
            this.pnlSave.TabIndex = 10;
            // 
            // tblSave
            // 
            this.tblSave.AutoScroll = true;
            this.tblSave.ColumnCount = 2;
            this.tblSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.73228F));
            this.tblSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.26772F));
            this.tblSave.Location = new System.Drawing.Point(15, 39);
            this.tblSave.Name = "tblSave";
            this.tblSave.RowCount = 1;
            this.tblSave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.tblSave.Size = new System.Drawing.Size(254, 484);
            this.tblSave.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(161, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 24);
            this.label19.TabIndex = 12;
            this.label19.Text = "Amount";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(40, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 24);
            this.label18.TabIndex = 11;
            this.label18.Text = "Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(112, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 32);
            this.label16.TabIndex = 9;
            this.label16.Text = "Save";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(113, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 54);
            this.label15.TabIndex = 13;
            this.label15.Text = "My Record";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // rjCircularPictureBox1
            // 
            this.rjCircularPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjCircularPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjCircularPictureBox1.BackgroundImage")));
            this.rjCircularPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjCircularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox1.BorderColor = System.Drawing.Color.White;
            this.rjCircularPictureBox1.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox1.BorderSize = 0;
            this.rjCircularPictureBox1.GradientAngle = 50F;
            this.rjCircularPictureBox1.Location = new System.Drawing.Point(27, 25);
            this.rjCircularPictureBox1.Name = "rjCircularPictureBox1";
            this.rjCircularPictureBox1.Size = new System.Drawing.Size(45, 45);
            this.rjCircularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox1.TabIndex = 2;
            this.rjCircularPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Smooth Circulars", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(75, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "SAVEX";
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 18;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(1459, 25);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(36, 36);
            this.rjButton2.TabIndex = 1;
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rjButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rjButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 18;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(1407, 25);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(36, 36);
            this.rjButton3.TabIndex = 4;
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.BorderRadius = 18;
            this.rjButton4.BorderSize = 0;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Location = new System.Drawing.Point(1355, 25);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(36, 36);
            this.rjButton4.TabIndex = 5;
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            this.rjButton4.Click += new System.EventHandler(this.rjButton4_Click);
            // 
            // roundedPanel7
            // 
            this.roundedPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.roundedPanel7.BorderRadius = 40;
            this.roundedPanel7.Controls.Add(this.label4);
            this.roundedPanel7.Controls.Add(this.pictureBox1);
            this.roundedPanel7.Controls.Add(this.rjButton10);
            this.roundedPanel7.Location = new System.Drawing.Point(27, 584);
            this.roundedPanel7.Name = "roundedPanel7";
            this.roundedPanel7.Size = new System.Drawing.Size(237, 274);
            this.roundedPanel7.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(34, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 46);
            this.label4.TabIndex = 8;
            this.label4.Text = "Go premium to unlock\r\nspecial features.\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // rjButton10
            // 
            this.rjButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton10.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton10.BorderRadius = 18;
            this.rjButton10.BorderSize = 0;
            this.rjButton10.FlatAppearance.BorderSize = 0;
            this.rjButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton10.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton10.ForeColor = System.Drawing.Color.White;
            this.rjButton10.Location = new System.Drawing.Point(23, 187);
            this.rjButton10.Name = "rjButton10";
            this.rjButton10.Size = new System.Drawing.Size(189, 62);
            this.rjButton10.TabIndex = 12;
            this.rjButton10.Text = "Upgrade";
            this.rjButton10.TextColor = System.Drawing.Color.White;
            this.rjButton10.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "To Savings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(28, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Add";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.rjButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton1.BackgroundImage")));
            this.rjButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton1.BorderColor = System.Drawing.Color.White;
            this.rjButton1.BorderRadius = 33;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(157, 13);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(65, 65);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // gradientPanelRound1
            // 
            this.gradientPanelRound1.BorderRadius = 20;
            this.gradientPanelRound1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.gradientPanelRound1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.gradientPanelRound1.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.gradientPanelRound1.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.gradientPanelRound1.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.gradientPanelRound1.Controls.Add(this.roundedPanel2);
            this.gradientPanelRound1.Controls.Add(this.label11);
            this.gradientPanelRound1.GradientAngle = 60F;
            this.gradientPanelRound1.Location = new System.Drawing.Point(1169, 459);
            this.gradientPanelRound1.Name = "gradientPanelRound1";
            this.gradientPanelRound1.Size = new System.Drawing.Size(326, 399);
            this.gradientPanelRound1.TabIndex = 6;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderRadius = 30;
            this.roundedPanel2.Controls.Add(this.materialListBox1);
            this.roundedPanel2.Location = new System.Drawing.Point(26, 74);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(274, 300);
            this.roundedPanel2.TabIndex = 6;
            // 
            // materialListBox1
            // 
            this.materialListBox1.BackColor = System.Drawing.Color.White;
            this.materialListBox1.BorderColor = System.Drawing.Color.Transparent;
            this.materialListBox1.Depth = 0;
            this.materialListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialListBox1.Location = new System.Drawing.Point(0, 3);
            this.materialListBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBox1.Name = "materialListBox1";
            this.materialListBox1.SelectedIndex = -1;
            this.materialListBox1.SelectedItem = null;
            this.materialListBox1.ShowBorder = false;
            this.materialListBox1.ShowScrollBar = true;
            this.materialListBox1.Size = new System.Drawing.Size(271, 294);
            this.materialListBox1.Style = MaterialSkin.Controls.MaterialListBox.ListBoxStyle.ThreeLine;
            this.materialListBox1.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Noto Sans", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SlateBlue;
            this.label11.Location = new System.Drawing.Point(134, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 41);
            this.label11.TabIndex = 9;
            this.label11.Text = "HISTORY";
            // 
            // gradientPanelRound2
            // 
            this.gradientPanelRound2.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelRound2.BorderRadius = 20;
            this.gradientPanelRound2.Color1 = System.Drawing.Color.AliceBlue;
            this.gradientPanelRound2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gradientPanelRound2.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gradientPanelRound2.Color4 = System.Drawing.Color.AliceBlue;
            this.gradientPanelRound2.Color5 = System.Drawing.Color.AliceBlue;
            this.gradientPanelRound2.Controls.Add(this.label2);
            this.gradientPanelRound2.Controls.Add(this.label3);
            this.gradientPanelRound2.Controls.Add(this.rjButton1);
            this.gradientPanelRound2.GradientAngle = 25F;
            this.gradientPanelRound2.Location = new System.Drawing.Point(27, 126);
            this.gradientPanelRound2.Name = "gradientPanelRound2";
            this.gradientPanelRound2.Size = new System.Drawing.Size(237, 91);
            this.gradientPanelRound2.TabIndex = 7;
            // 
            // gradientPanelRound3
            // 
            this.gradientPanelRound3.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelRound3.BorderRadius = 20;
            this.gradientPanelRound3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound3.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound3.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound3.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound3.Controls.Add(this.label6);
            this.gradientPanelRound3.Controls.Add(this.label7);
            this.gradientPanelRound3.Controls.Add(this.rjButton6);
            this.gradientPanelRound3.GradientAngle = 25F;
            this.gradientPanelRound3.Location = new System.Drawing.Point(27, 238);
            this.gradientPanelRound3.Name = "gradientPanelRound3";
            this.gradientPanelRound3.Size = new System.Drawing.Size(237, 91);
            this.gradientPanelRound3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SlateBlue;
            this.label6.Location = new System.Drawing.Point(28, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "An Expense";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SlateBlue;
            this.label7.Location = new System.Drawing.Point(28, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Add";
            // 
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.rjButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton6.BackgroundImage")));
            this.rjButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton6.BorderColor = System.Drawing.Color.White;
            this.rjButton6.BorderRadius = 33;
            this.rjButton6.BorderSize = 0;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.ForeColor = System.Drawing.Color.White;
            this.rjButton6.Location = new System.Drawing.Point(158, 13);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(65, 65);
            this.rjButton6.TabIndex = 0;
            this.rjButton6.TextColor = System.Drawing.Color.White;
            this.rjButton6.UseVisualStyleBackColor = false;
            this.rjButton6.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.Transparent;
            this.rjButton5.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton5.BackgroundImage")));
            this.rjButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton5.BorderRadius = 25;
            this.rjButton5.BorderSize = 0;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Location = new System.Drawing.Point(27, 367);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(50, 50);
            this.rjButton5.TabIndex = 9;
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            // 
            // rjButton7
            // 
            this.rjButton7.BackColor = System.Drawing.Color.Transparent;
            this.rjButton7.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton7.BackgroundImage")));
            this.rjButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton7.BorderRadius = 25;
            this.rjButton7.BorderSize = 0;
            this.rjButton7.FlatAppearance.BorderSize = 0;
            this.rjButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton7.ForeColor = System.Drawing.Color.White;
            this.rjButton7.Location = new System.Drawing.Point(27, 427);
            this.rjButton7.Name = "rjButton7";
            this.rjButton7.Size = new System.Drawing.Size(50, 50);
            this.rjButton7.TabIndex = 10;
            this.rjButton7.TextColor = System.Drawing.Color.White;
            this.rjButton7.UseVisualStyleBackColor = false;
            // 
            // rjButton8
            // 
            this.rjButton8.BackColor = System.Drawing.Color.Transparent;
            this.rjButton8.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton8.BackgroundImage")));
            this.rjButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton8.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton8.BorderRadius = 25;
            this.rjButton8.BorderSize = 0;
            this.rjButton8.FlatAppearance.BorderSize = 0;
            this.rjButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton8.ForeColor = System.Drawing.Color.White;
            this.rjButton8.Location = new System.Drawing.Point(27, 486);
            this.rjButton8.Name = "rjButton8";
            this.rjButton8.Size = new System.Drawing.Size(50, 50);
            this.rjButton8.TabIndex = 11;
            this.rjButton8.TextColor = System.Drawing.Color.White;
            this.rjButton8.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(79, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dashboard";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(79, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Search";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(79, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 13;
            this.label9.Text = "My Record";
            // 
            // gradientPanelRound4
            // 
            this.gradientPanelRound4.BorderRadius = 20;
            this.gradientPanelRound4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Controls.Add(this.label10);
            this.gradientPanelRound4.Controls.Add(this.roundedPanel11);
            this.gradientPanelRound4.Controls.Add(this.roundedPanel10);
            this.gradientPanelRound4.Controls.Add(this.roundedPanel9);
            this.gradientPanelRound4.GradientAngle = 25F;
            this.gradientPanelRound4.Location = new System.Drawing.Point(1169, 117);
            this.gradientPanelRound4.Name = "gradientPanelRound4";
            this.gradientPanelRound4.Size = new System.Drawing.Size(326, 253);
            this.gradientPanelRound4.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Noto Sans", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(134, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 41);
            this.label10.TabIndex = 8;
            this.label10.Text = "TOTALS";
            // 
            // roundedPanel11
            // 
            this.roundedPanel11.BackColor = System.Drawing.Color.White;
            this.roundedPanel11.BorderRadius = 30;
            this.roundedPanel11.Controls.Add(this.lblTotalSpent);
            this.roundedPanel11.Location = new System.Drawing.Point(26, 190);
            this.roundedPanel11.Name = "roundedPanel11";
            this.roundedPanel11.Size = new System.Drawing.Size(178, 39);
            this.roundedPanel11.TabIndex = 7;
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSpent.Font = new System.Drawing.Font("Noto Sans SemiBold", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalSpent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalSpent.Location = new System.Drawing.Point(3, 1);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(172, 38);
            this.lblTotalSpent.TabIndex = 15;
            this.lblTotalSpent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedPanel10
            // 
            this.roundedPanel10.BackColor = System.Drawing.Color.White;
            this.roundedPanel10.BorderRadius = 30;
            this.roundedPanel10.Controls.Add(this.lblTotalSave);
            this.roundedPanel10.Location = new System.Drawing.Point(26, 144);
            this.roundedPanel10.Name = "roundedPanel10";
            this.roundedPanel10.Size = new System.Drawing.Size(178, 39);
            this.roundedPanel10.TabIndex = 6;
            // 
            // lblTotalSave
            // 
            this.lblTotalSave.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSave.Font = new System.Drawing.Font("Noto Sans SemiBold", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalSave.Location = new System.Drawing.Point(3, 1);
            this.lblTotalSave.Name = "lblTotalSave";
            this.lblTotalSave.Size = new System.Drawing.Size(172, 38);
            this.lblTotalSave.TabIndex = 14;
            this.lblTotalSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedPanel9
            // 
            this.roundedPanel9.BackColor = System.Drawing.Color.White;
            this.roundedPanel9.BorderRadius = 30;
            this.roundedPanel9.Controls.Add(this.lblGrand);
            this.roundedPanel9.Location = new System.Drawing.Point(26, 74);
            this.roundedPanel9.Name = "roundedPanel9";
            this.roundedPanel9.Size = new System.Drawing.Size(274, 63);
            this.roundedPanel9.TabIndex = 5;
            // 
            // lblGrand
            // 
            this.lblGrand.BackColor = System.Drawing.Color.Transparent;
            this.lblGrand.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblGrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGrand.Location = new System.Drawing.Point(0, 0);
            this.lblGrand.Name = "lblGrand";
            this.lblGrand.Size = new System.Drawing.Size(271, 63);
            this.lblGrand.TabIndex = 13;
            this.lblGrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedPanel1.BackgroundImage")));
            this.roundedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel1.BorderRadius = 50;
            this.roundedPanel1.Location = new System.Drawing.Point(1195, 67);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(100, 100);
            this.roundedPanel1.TabIndex = 6;
            // 
            // roundedPanel8
            // 
            this.roundedPanel8.BackColor = System.Drawing.Color.White;
            this.roundedPanel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedPanel8.BackgroundImage")));
            this.roundedPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel8.BorderRadius = 50;
            this.roundedPanel8.Location = new System.Drawing.Point(1195, 409);
            this.roundedPanel8.Name = "roundedPanel8";
            this.roundedPanel8.Size = new System.Drawing.Size(100, 100);
            this.roundedPanel8.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1520, 911);
            this.Controls.Add(this.roundedPanel8);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.gradientPanelRound4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rjButton8);
            this.Controls.Add(this.rjButton7);
            this.Controls.Add(this.rjButton5);
            this.Controls.Add(this.gradientPanelRound3);
            this.Controls.Add(this.gradientPanelRound2);
            this.Controls.Add(this.gradientPanelRound1);
            this.Controls.Add(this.rjButton4);
            this.Controls.Add(this.rjButton3);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjCircularPictureBox1);
            this.Controls.Add(this.roundedPanel7);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.gradientPanelRound6.ResumeLayout(false);
            this.gradientPanelRound6.PerformLayout();
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel4.PerformLayout();
            this.gradientPanelRound5.ResumeLayout(false);
            this.gradientPanelRound5.PerformLayout();
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox1)).EndInit();
            this.roundedPanel7.ResumeLayout(false);
            this.roundedPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gradientPanelRound1.ResumeLayout(false);
            this.gradientPanelRound1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.gradientPanelRound2.ResumeLayout(false);
            this.gradientPanelRound2.PerformLayout();
            this.gradientPanelRound3.ResumeLayout(false);
            this.gradientPanelRound3.PerformLayout();
            this.gradientPanelRound4.ResumeLayout(false);
            this.gradientPanelRound4.PerformLayout();
            this.roundedPanel11.ResumeLayout(false);
            this.roundedPanel10.ResumeLayout(false);
            this.roundedPanel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedPanel roundedPanel7;
        private RJCodeAdvance.RJControls.RJCircularPictureBox rjCircularPictureBox1;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private RJCodeAdvance.RJControls.RJButton rjButton3;
        private RJCodeAdvance.RJControls.RJButton rjButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private GradientPanelRound gradientPanelRound1;
        private GradientPanelRound gradientPanelRound2;
        private GradientPanelRound gradientPanelRound3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private RJCodeAdvance.RJControls.RJButton rjButton6;
        private RJCodeAdvance.RJControls.RJButton rjButton5;
        private RJCodeAdvance.RJControls.RJButton rjButton7;
        private RJCodeAdvance.RJControls.RJButton rjButton8;
        private RJCodeAdvance.RJControls.RJButton rjButton10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private GradientPanelRound gradientPanelRound4;
        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel8;
        private RoundedPanel roundedPanel11;
        private RoundedPanel roundedPanel10;
        private RoundedPanel roundedPanel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialListBox materialListBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        private GradientPanelRound gradientPanelRound5;
        private GradientPanelRound gradientPanelRound6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private RoundedPanel roundedPanel2;
        private RoundedPanel pnlSave;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private RoundedPanel roundedPanel4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel tblSave;
        private RJCodeAdvance.RJControls.RJButton btnRefresh;
        private RJCodeAdvance.RJControls.RJButton rjButton9;
        private System.Windows.Forms.TableLayoutPanel tbl_Spend;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblGrand;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.Label lblTotalSave;
    }
}

