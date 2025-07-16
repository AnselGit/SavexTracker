using System.Timers;
using SavexTracker.CustomClasses;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_3 = new System.Windows.Forms.Panel();
            this.btnDelAll_S = new RJCodeAdvance.RJControls.RJButton();
            this.btnDelAll_E = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton9 = new RJCodeAdvance.RJControls.RJButton();
            this.btnModify = new RJCodeAdvance.RJControls.RJButton();
            this.gradientPanelRound6 = new GradientPanelRound();
            this.rjButton15 = new RJCodeAdvance.RJControls.RJButton();
            this.roundedPanel4 = new RoundedPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbl_Spend = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gradientPanelRound5 = new GradientPanelRound();
            this.rjButton14 = new RJCodeAdvance.RJControls.RJButton();
            this.pnlSave = new RoundedPanel();
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
            this.rjButton11 = new RJCodeAdvance.RJControls.RJButton();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlHistory = new RoundedPanel();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.pnlEmpty = new RoundedPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlDeleteCon = new RoundedPanel();
            this.rjButton12 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton13 = new RJCodeAdvance.RJControls.RJButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.gradientPanelRound2 = new GradientPanelRound();
            this.gradientPanelRound3 = new GradientPanelRound();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rjButton6 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton5 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton7 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton8 = new RJCodeAdvance.RJControls.RJButton();
            this.gradientPanelRound4 = new GradientPanelRound();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.roundedPanel11 = new RoundedPanel();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.roundedPanel10 = new RoundedPanel();
            this.lblTotalSave = new System.Windows.Forms.Label();
            this.roundedPanel9 = new RoundedPanel();
            this.lblGrand = new System.Windows.Forms.Label();
            this.roundedPanel1 = new RoundedPanel();
            this.roundedPanel8 = new RoundedPanel();
            this.btnNav_1 = new RJCodeAdvance.RJControls.RJButton();
            this.btnNav_2 = new RJCodeAdvance.RJControls.RJButton();
            this.btnNav_3 = new RJCodeAdvance.RJControls.RJButton();
            this.pnl_2 = new System.Windows.Forms.Panel();
            this.roundedPanel13 = new RoundedPanel();
            this.roundedPanel14 = new RoundedPanel();
            this.dgv_Search = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundedPanel12 = new RoundedPanel();
            this.txtSearch = new RJCodeAdvance.RJControls.RJTextBox();
            this.btnSearch = new RJCodeAdvance.RJControls.RJButton();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new RoundedPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblDashSpend = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblGoal = new System.Windows.Forms.Label();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.roundedPanel6 = new RoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlPie2 = new RoundedPanel();
            this.roundedPanel5 = new RoundedPanel();
            this.btnSet = new RJCodeAdvance.RJControls.RJButton();
            this.pnlPie3 = new RoundedPanel();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.roundedPanel3 = new RoundedPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.lblDashSave = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pnlLine = new RoundedPanel();
            this.pnlPie = new RoundedPanel();
            this.pnl_3.SuspendLayout();
            this.gradientPanelRound6.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.gradientPanelRound5.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox1)).BeginInit();
            this.roundedPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gradientPanelRound1.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.pnlEmpty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlDeleteCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gradientPanelRound2.SuspendLayout();
            this.gradientPanelRound3.SuspendLayout();
            this.gradientPanelRound4.SuspendLayout();
            this.roundedPanel11.SuspendLayout();
            this.roundedPanel10.SuspendLayout();
            this.roundedPanel9.SuspendLayout();
            this.pnl_2.SuspendLayout();
            this.roundedPanel13.SuspendLayout();
            this.roundedPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).BeginInit();
            this.roundedPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.pnl_1.SuspendLayout();
            this.roundedPanel6.SuspendLayout();
            this.roundedPanel5.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_3
            // 
            this.pnl_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnl_3.Controls.Add(this.btnDelAll_S);
            this.pnl_3.Controls.Add(this.btnDelAll_E);
            this.pnl_3.Controls.Add(this.rjButton9);
            this.pnl_3.Controls.Add(this.btnModify);
            this.pnl_3.Controls.Add(this.gradientPanelRound6);
            this.pnl_3.Controls.Add(this.gradientPanelRound5);
            this.pnl_3.Controls.Add(this.label15);
            this.pnl_3.Controls.Add(this.pictureBox2);
            this.pnl_3.Location = new System.Drawing.Point(289, 25);
            this.pnl_3.Name = "pnl_3";
            this.pnl_3.Size = new System.Drawing.Size(854, 862);
            this.pnl_3.TabIndex = 0;
            // 
            // btnDelAll_S
            // 
            this.btnDelAll_S.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelAll_S.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelAll_S.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelAll_S.BorderColor = System.Drawing.Color.White;
            this.btnDelAll_S.BorderRadius = 12;
            this.btnDelAll_S.BorderSize = 0;
            this.btnDelAll_S.FlatAppearance.BorderSize = 0;
            this.btnDelAll_S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelAll_S.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAll_S.ForeColor = System.Drawing.Color.White;
            this.btnDelAll_S.Location = new System.Drawing.Point(28, 165);
            this.btnDelAll_S.Name = "btnDelAll_S";
            this.btnDelAll_S.Size = new System.Drawing.Size(159, 25);
            this.btnDelAll_S.TabIndex = 20;
            this.btnDelAll_S.Text = "Delete all";
            this.btnDelAll_S.TextColor = System.Drawing.Color.White;
            this.btnDelAll_S.UseVisualStyleBackColor = false;
            this.btnDelAll_S.Visible = false;
            this.btnDelAll_S.Click += new System.EventHandler(this.btnDelAll_S_Click);
            // 
            // btnDelAll_E
            // 
            this.btnDelAll_E.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelAll_E.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelAll_E.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelAll_E.BorderColor = System.Drawing.Color.White;
            this.btnDelAll_E.BorderRadius = 12;
            this.btnDelAll_E.BorderSize = 0;
            this.btnDelAll_E.FlatAppearance.BorderSize = 0;
            this.btnDelAll_E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelAll_E.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAll_E.ForeColor = System.Drawing.Color.White;
            this.btnDelAll_E.Location = new System.Drawing.Point(349, 165);
            this.btnDelAll_E.Name = "btnDelAll_E";
            this.btnDelAll_E.Size = new System.Drawing.Size(159, 25);
            this.btnDelAll_E.TabIndex = 19;
            this.btnDelAll_E.Text = "Delete all";
            this.btnDelAll_E.TextColor = System.Drawing.Color.White;
            this.btnDelAll_E.UseVisualStyleBackColor = false;
            this.btnDelAll_E.Visible = false;
            this.btnDelAll_E.Click += new System.EventHandler(this.btnDelAll_E_Click);
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
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnModify.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModify.BorderColor = System.Drawing.Color.White;
            this.btnModify.BorderRadius = 33;
            this.btnModify.BorderSize = 0;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(695, 28);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(133, 65);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "Modify";
            this.btnModify.TextColor = System.Drawing.Color.White;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gradientPanelRound6
            // 
            this.gradientPanelRound6.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelRound6.BorderRadius = 40;
            this.gradientPanelRound6.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.gradientPanelRound6.Controls.Add(this.rjButton15);
            this.gradientPanelRound6.Controls.Add(this.roundedPanel4);
            this.gradientPanelRound6.Controls.Add(this.label17);
            this.gradientPanelRound6.GradientAngle = 90F;
            this.gradientPanelRound6.Location = new System.Drawing.Point(349, 196);
            this.gradientPanelRound6.Name = "gradientPanelRound6";
            this.gradientPanelRound6.Size = new System.Drawing.Size(479, 637);
            this.gradientPanelRound6.TabIndex = 15;
            // 
            // rjButton15
            // 
            this.rjButton15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.rjButton15.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.rjButton15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton15.BackgroundImage")));
            this.rjButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton15.BorderColor = System.Drawing.Color.White;
            this.rjButton15.BorderRadius = 0;
            this.rjButton15.BorderSize = 0;
            this.rjButton15.FlatAppearance.BorderSize = 0;
            this.rjButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton15.ForeColor = System.Drawing.Color.White;
            this.rjButton15.Location = new System.Drawing.Point(32, 17);
            this.rjButton15.Name = "rjButton15";
            this.rjButton15.Size = new System.Drawing.Size(30, 30);
            this.rjButton15.TabIndex = 15;
            this.rjButton15.TextColor = System.Drawing.Color.White;
            this.rjButton15.UseVisualStyleBackColor = false;
            this.rjButton15.Click += new System.EventHandler(this.rjButton15_Click);
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
            this.tbl_Spend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
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
            this.label21.Location = new System.Drawing.Point(146, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 24);
            this.label21.TabIndex = 11;
            this.label21.Text = "Amount";
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
            this.gradientPanelRound5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound5.Controls.Add(this.rjButton14);
            this.gradientPanelRound5.Controls.Add(this.pnlSave);
            this.gradientPanelRound5.Controls.Add(this.label16);
            this.gradientPanelRound5.GradientAngle = 90F;
            this.gradientPanelRound5.Location = new System.Drawing.Point(28, 196);
            this.gradientPanelRound5.Name = "gradientPanelRound5";
            this.gradientPanelRound5.Size = new System.Drawing.Size(293, 637);
            this.gradientPanelRound5.TabIndex = 14;
            // 
            // rjButton14
            // 
            this.rjButton14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rjButton14.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rjButton14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton14.BackgroundImage")));
            this.rjButton14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton14.BorderColor = System.Drawing.Color.White;
            this.rjButton14.BorderRadius = 0;
            this.rjButton14.BorderSize = 0;
            this.rjButton14.FlatAppearance.BorderSize = 0;
            this.rjButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton14.ForeColor = System.Drawing.Color.White;
            this.rjButton14.Location = new System.Drawing.Point(29, 17);
            this.rjButton14.Name = "rjButton14";
            this.rjButton14.Size = new System.Drawing.Size(30, 30);
            this.rjButton14.TabIndex = 14;
            this.rjButton14.TextColor = System.Drawing.Color.White;
            this.rjButton14.UseVisualStyleBackColor = false;
            this.rjButton14.Click += new System.EventHandler(this.rjButton14_Click);
            // 
            // pnlSave
            // 
            this.pnlSave.BackColor = System.Drawing.Color.White;
            this.pnlSave.BorderRadius = 60;
            this.pnlSave.Controls.Add(this.label19);
            this.pnlSave.Controls.Add(this.label18);
            this.pnlSave.Location = new System.Drawing.Point(4, 60);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(284, 549);
            this.pnlSave.TabIndex = 10;
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
            this.gradientPanelRound1.Controls.Add(this.rjButton11);
            this.gradientPanelRound1.Controls.Add(this.label11);
            this.gradientPanelRound1.Controls.Add(this.pnlHistory);
            this.gradientPanelRound1.Controls.Add(this.pnlEmpty);
            this.gradientPanelRound1.Controls.Add(this.pnlDeleteCon);
            this.gradientPanelRound1.GradientAngle = 60F;
            this.gradientPanelRound1.Location = new System.Drawing.Point(1169, 459);
            this.gradientPanelRound1.Name = "gradientPanelRound1";
            this.gradientPanelRound1.Size = new System.Drawing.Size(326, 399);
            this.gradientPanelRound1.TabIndex = 6;
            // 
            // rjButton11
            // 
            this.rjButton11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton11.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rjButton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton11.BorderColor = System.Drawing.Color.White;
            this.rjButton11.BorderRadius = 12;
            this.rjButton11.BorderSize = 0;
            this.rjButton11.FlatAppearance.BorderSize = 0;
            this.rjButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton11.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton11.ForeColor = System.Drawing.Color.SlateBlue;
            this.rjButton11.Location = new System.Drawing.Point(141, 364);
            this.rjButton11.Name = "rjButton11";
            this.rjButton11.Size = new System.Drawing.Size(159, 25);
            this.rjButton11.TabIndex = 18;
            this.rjButton11.Text = "Clear History";
            this.rjButton11.TextColor = System.Drawing.Color.SlateBlue;
            this.rjButton11.UseVisualStyleBackColor = false;
            this.rjButton11.Click += new System.EventHandler(this.rjButton11_Click);
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
            // pnlHistory
            // 
            this.pnlHistory.AutoScroll = true;
            this.pnlHistory.BackColor = System.Drawing.Color.White;
            this.pnlHistory.BorderRadius = 30;
            this.pnlHistory.Controls.Add(this.rtbHistory);
            this.pnlHistory.Location = new System.Drawing.Point(26, 74);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(274, 282);
            this.pnlHistory.TabIndex = 6;
            // 
            // rtbHistory
            // 
            this.rtbHistory.BackColor = System.Drawing.Color.White;
            this.rtbHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHistory.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHistory.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.rtbHistory.Location = new System.Drawing.Point(17, 17);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.ReadOnly = true;
            this.rtbHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbHistory.Size = new System.Drawing.Size(255, 248);
            this.rtbHistory.TabIndex = 0;
            this.rtbHistory.Text = "";
            // 
            // pnlEmpty
            // 
            this.pnlEmpty.BackColor = System.Drawing.Color.White;
            this.pnlEmpty.BorderRadius = 30;
            this.pnlEmpty.Controls.Add(this.label13);
            this.pnlEmpty.Controls.Add(this.pictureBox4);
            this.pnlEmpty.Location = new System.Drawing.Point(26, 74);
            this.pnlEmpty.Name = "pnlEmpty";
            this.pnlEmpty.Size = new System.Drawing.Size(274, 282);
            this.pnlEmpty.TabIndex = 19;
            this.pnlEmpty.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label13.Location = new System.Drawing.Point(52, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(172, 24);
            this.label13.TabIndex = 24;
            this.label13.Text = "The history is empty";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(83, 59);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(110, 110);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // pnlDeleteCon
            // 
            this.pnlDeleteCon.AutoScroll = true;
            this.pnlDeleteCon.BackColor = System.Drawing.Color.White;
            this.pnlDeleteCon.BorderRadius = 30;
            this.pnlDeleteCon.Controls.Add(this.rjButton12);
            this.pnlDeleteCon.Controls.Add(this.rjButton13);
            this.pnlDeleteCon.Controls.Add(this.pictureBox3);
            this.pnlDeleteCon.Location = new System.Drawing.Point(26, 74);
            this.pnlDeleteCon.Name = "pnlDeleteCon";
            this.pnlDeleteCon.Size = new System.Drawing.Size(274, 282);
            this.pnlDeleteCon.TabIndex = 7;
            this.pnlDeleteCon.Visible = false;
            // 
            // rjButton12
            // 
            this.rjButton12.BackColor = System.Drawing.Color.OrangeRed;
            this.rjButton12.BackgroundColor = System.Drawing.Color.OrangeRed;
            this.rjButton12.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton12.BorderRadius = 15;
            this.rjButton12.BorderSize = 0;
            this.rjButton12.FlatAppearance.BorderSize = 0;
            this.rjButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton12.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton12.ForeColor = System.Drawing.Color.White;
            this.rjButton12.Location = new System.Drawing.Point(67, 208);
            this.rjButton12.Name = "rjButton12";
            this.rjButton12.Size = new System.Drawing.Size(135, 30);
            this.rjButton12.TabIndex = 27;
            this.rjButton12.Text = "Cancel";
            this.rjButton12.TextColor = System.Drawing.Color.White;
            this.rjButton12.UseVisualStyleBackColor = false;
            this.rjButton12.Click += new System.EventHandler(this.rjButton12_Click);
            // 
            // rjButton13
            // 
            this.rjButton13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rjButton13.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rjButton13.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton13.BorderRadius = 15;
            this.rjButton13.BorderSize = 0;
            this.rjButton13.FlatAppearance.BorderSize = 0;
            this.rjButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton13.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton13.ForeColor = System.Drawing.Color.White;
            this.rjButton13.Location = new System.Drawing.Point(67, 172);
            this.rjButton13.Name = "rjButton13";
            this.rjButton13.Size = new System.Drawing.Size(135, 30);
            this.rjButton13.TabIndex = 26;
            this.rjButton13.Text = "Clear";
            this.rjButton13.TextColor = System.Drawing.Color.White;
            this.rjButton13.UseVisualStyleBackColor = false;
            this.rjButton13.Click += new System.EventHandler(this.rjButton13_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(57, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 155);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
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
            this.rjButton5.Enabled = false;
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
            this.rjButton7.Enabled = false;
            this.rjButton7.FlatAppearance.BorderSize = 0;
            this.rjButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton7.ForeColor = System.Drawing.Color.White;
            this.rjButton7.Location = new System.Drawing.Point(27, 426);
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
            this.rjButton8.Enabled = false;
            this.rjButton8.FlatAppearance.BorderSize = 0;
            this.rjButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton8.ForeColor = System.Drawing.Color.White;
            this.rjButton8.Location = new System.Drawing.Point(27, 485);
            this.rjButton8.Name = "rjButton8";
            this.rjButton8.Size = new System.Drawing.Size(50, 50);
            this.rjButton8.TabIndex = 11;
            this.rjButton8.TextColor = System.Drawing.Color.White;
            this.rjButton8.UseVisualStyleBackColor = false;
            // 
            // gradientPanelRound4
            // 
            this.gradientPanelRound4.BorderRadius = 20;
            this.gradientPanelRound4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gradientPanelRound4.Controls.Add(this.label22);
            this.gradientPanelRound4.Controls.Add(this.label14);
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
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Silver;
            this.label22.Location = new System.Drawing.Point(210, 195);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 24);
            this.label22.TabIndex = 20;
            this.label22.Text = "Expenses";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(210, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 24);
            this.label14.TabIndex = 19;
            this.label14.Text = "Savings";
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
            this.lblTotalSpent.ForeColor = System.Drawing.Color.Gray;
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
            this.lblTotalSave.ForeColor = System.Drawing.Color.Gray;
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
            this.lblGrand.ForeColor = System.Drawing.Color.Gray;
            this.lblGrand.Location = new System.Drawing.Point(0, 0);
            this.lblGrand.Name = "lblGrand";
            this.lblGrand.Size = new System.Drawing.Size(271, 63);
            this.lblGrand.TabIndex = 13;
            this.lblGrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGrand.Click += new System.EventHandler(this.lblGrand_Click);
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
            // btnNav_1
            // 
            this.btnNav_1.BackColor = System.Drawing.Color.White;
            this.btnNav_1.BackgroundColor = System.Drawing.Color.White;
            this.btnNav_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNav_1.BorderColor = System.Drawing.Color.White;
            this.btnNav_1.BorderRadius = 12;
            this.btnNav_1.BorderSize = 0;
            this.btnNav_1.FlatAppearance.BorderSize = 0;
            this.btnNav_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNav_1.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold);
            this.btnNav_1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_1.Location = new System.Drawing.Point(76, 376);
            this.btnNav_1.Name = "btnNav_1";
            this.btnNav_1.Padding = new System.Windows.Forms.Padding(0, 0, 70, 0);
            this.btnNav_1.Size = new System.Drawing.Size(188, 34);
            this.btnNav_1.TabIndex = 19;
            this.btnNav_1.Text = "Dashboard";
            this.btnNav_1.TextColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_1.UseVisualStyleBackColor = false;
            this.btnNav_1.Click += new System.EventHandler(this.btnNav_1_Click_1);
            // 
            // btnNav_2
            // 
            this.btnNav_2.BackColor = System.Drawing.Color.White;
            this.btnNav_2.BackgroundColor = System.Drawing.Color.White;
            this.btnNav_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNav_2.BorderColor = System.Drawing.Color.White;
            this.btnNav_2.BorderRadius = 12;
            this.btnNav_2.BorderSize = 0;
            this.btnNav_2.FlatAppearance.BorderSize = 0;
            this.btnNav_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNav_2.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold);
            this.btnNav_2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_2.Location = new System.Drawing.Point(76, 434);
            this.btnNav_2.Name = "btnNav_2";
            this.btnNav_2.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.btnNav_2.Size = new System.Drawing.Size(188, 34);
            this.btnNav_2.TabIndex = 20;
            this.btnNav_2.Text = "Search";
            this.btnNav_2.TextColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_2.UseVisualStyleBackColor = false;
            this.btnNav_2.Click += new System.EventHandler(this.btnNav_2_Click_1);
            // 
            // btnNav_3
            // 
            this.btnNav_3.BackColor = System.Drawing.Color.White;
            this.btnNav_3.BackgroundColor = System.Drawing.Color.White;
            this.btnNav_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNav_3.BorderColor = System.Drawing.Color.White;
            this.btnNav_3.BorderRadius = 12;
            this.btnNav_3.BorderSize = 0;
            this.btnNav_3.FlatAppearance.BorderSize = 0;
            this.btnNav_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNav_3.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold);
            this.btnNav_3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_3.Location = new System.Drawing.Point(76, 493);
            this.btnNav_3.Name = "btnNav_3";
            this.btnNav_3.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.btnNav_3.Size = new System.Drawing.Size(188, 34);
            this.btnNav_3.TabIndex = 21;
            this.btnNav_3.Text = "Record";
            this.btnNav_3.TextColor = System.Drawing.Color.RoyalBlue;
            this.btnNav_3.UseVisualStyleBackColor = false;
            this.btnNav_3.Click += new System.EventHandler(this.btnNav_3_Click);
            // 
            // pnl_2
            // 
            this.pnl_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnl_2.Controls.Add(this.roundedPanel13);
            this.pnl_2.Controls.Add(this.roundedPanel12);
            this.pnl_2.Controls.Add(this.label25);
            this.pnl_2.Controls.Add(this.pictureBox5);
            this.pnl_2.Location = new System.Drawing.Point(289, 25);
            this.pnl_2.Name = "pnl_2";
            this.pnl_2.Padding = new System.Windows.Forms.Padding(0, 0, 70, 0);
            this.pnl_2.Size = new System.Drawing.Size(854, 862);
            this.pnl_2.TabIndex = 22;
            // 
            // roundedPanel13
            // 
            this.roundedPanel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.roundedPanel13.BorderRadius = 75;
            this.roundedPanel13.Controls.Add(this.roundedPanel14);
            this.roundedPanel13.Location = new System.Drawing.Point(28, 288);
            this.roundedPanel13.Name = "roundedPanel13";
            this.roundedPanel13.Size = new System.Drawing.Size(800, 502);
            this.roundedPanel13.TabIndex = 19;
            // 
            // roundedPanel14
            // 
            this.roundedPanel14.BackColor = System.Drawing.Color.White;
            this.roundedPanel14.BorderRadius = 75;
            this.roundedPanel14.Controls.Add(this.dgv_Search);
            this.roundedPanel14.Location = new System.Drawing.Point(12, 51);
            this.roundedPanel14.Name = "roundedPanel14";
            this.roundedPanel14.Size = new System.Drawing.Size(776, 436);
            this.roundedPanel14.TabIndex = 20;
            // 
            // dgv_Search
            // 
            this.dgv_Search.AllowUserToAddRows = false;
            this.dgv_Search.AllowUserToOrderColumns = true;
            this.dgv_Search.AllowUserToResizeColumns = false;
            this.dgv_Search.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Search.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Search.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Search.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Search.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Search.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Search.ColumnHeadersHeight = 28;
            this.dgv_Search.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colType,
            this.colAmount,
            this.colNote});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Search.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Search.GridColor = System.Drawing.Color.White;
            this.dgv_Search.Location = new System.Drawing.Point(11, 12);
            this.dgv_Search.Name = "dgv_Search";
            this.dgv_Search.ReadOnly = true;
            this.dgv_Search.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Search.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Search.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Search.RowTemplate.Height = 30;
            this.dgv_Search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Search.Size = new System.Drawing.Size(752, 405);
            this.dgv_Search.TabIndex = 18;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAmount
            // 
            this.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colNote
            // 
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.HeaderText = "Note";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            this.colNote.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // roundedPanel12
            // 
            this.roundedPanel12.BackColor = System.Drawing.Color.White;
            this.roundedPanel12.BorderRadius = 75;
            this.roundedPanel12.Controls.Add(this.txtSearch);
            this.roundedPanel12.Controls.Add(this.btnSearch);
            this.roundedPanel12.Location = new System.Drawing.Point(28, 164);
            this.roundedPanel12.Name = "roundedPanel12";
            this.roundedPanel12.Size = new System.Drawing.Size(800, 74);
            this.roundedPanel12.TabIndex = 18;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderFocusColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 2;
            this.txtSearch.Font = new System.Drawing.Font("Noto Sans SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(29, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Date, Amount, Note";
            this.txtSearch.Size = new System.Drawing.Size(631, 44);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.Texts = "";
            this.txtSearch.UnderlinedStyle = false;
            this.txtSearch._TextChanged += new System.EventHandler(this.txtSearch__TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderColor = System.Drawing.Color.White;
            this.btnSearch.BorderRadius = 25;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(667, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 50);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label25.Location = new System.Drawing.Point(113, 51);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(232, 54);
            this.label25.TabIndex = 13;
            this.label25.Text = "Search";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(28, 28);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 100);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(28, 28);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(100, 100);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(113, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 54);
            this.label9.TabIndex = 13;
            this.label9.Text = "Dashboard";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.roundedPanel2.BorderRadius = 30;
            this.roundedPanel2.Controls.Add(this.label24);
            this.roundedPanel2.Controls.Add(this.lblDashSpend);
            this.roundedPanel2.Controls.Add(this.pictureBox7);
            this.roundedPanel2.Location = new System.Drawing.Point(28, 320);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(347, 92);
            this.roundedPanel2.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(91, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 29);
            this.label24.TabIndex = 21;
            this.label24.Text = "Expenses";
            // 
            // lblDashSpend
            // 
            this.lblDashSpend.BackColor = System.Drawing.Color.Transparent;
            this.lblDashSpend.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashSpend.ForeColor = System.Drawing.Color.White;
            this.lblDashSpend.Location = new System.Drawing.Point(85, 27);
            this.lblDashSpend.Name = "lblDashSpend";
            this.lblDashSpend.Size = new System.Drawing.Size(246, 56);
            this.lblDashSpend.TabIndex = 20;
            this.lblDashSpend.Text = "1000000";
            this.lblDashSpend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(11, 11);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(70, 70);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.BackColor = System.Drawing.Color.Transparent;
            this.lblGoal.Font = new System.Drawing.Font("MODERNIZ", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoal.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblGoal.Location = new System.Drawing.Point(31, 35);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(260, 50);
            this.lblGoal.TabIndex = 12;
            this.lblGoal.Text = "GOAL - %";
            // 
            // pnl_1
            // 
            this.pnl_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.pnl_1.Controls.Add(this.roundedPanel6);
            this.pnl_1.Controls.Add(this.roundedPanel5);
            this.pnl_1.Controls.Add(this.roundedPanel3);
            this.pnl_1.Controls.Add(this.pnlLine);
            this.pnl_1.Controls.Add(this.roundedPanel2);
            this.pnl_1.Controls.Add(this.label9);
            this.pnl_1.Controls.Add(this.pictureBox6);
            this.pnl_1.Location = new System.Drawing.Point(289, 25);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Padding = new System.Windows.Forms.Padding(0, 0, 70, 0);
            this.pnl_1.Size = new System.Drawing.Size(854, 862);
            this.pnl_1.TabIndex = 23;
            // 
            // roundedPanel6
            // 
            this.roundedPanel6.BackColor = System.Drawing.Color.White;
            this.roundedPanel6.BorderRadius = 60;
            this.roundedPanel6.Controls.Add(this.label8);
            this.roundedPanel6.Controls.Add(this.pnlPie2);
            this.roundedPanel6.Location = new System.Drawing.Point(28, 490);
            this.roundedPanel6.Name = "roundedPanel6";
            this.roundedPanel6.Size = new System.Drawing.Size(347, 343);
            this.roundedPanel6.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(76, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 29);
            this.label8.TabIndex = 8;
            this.label8.Text = "Savings vs Expenses";
            // 
            // pnlPie2
            // 
            this.pnlPie2.BackColor = System.Drawing.Color.MistyRose;
            this.pnlPie2.BorderRadius = 60;
            this.pnlPie2.Location = new System.Drawing.Point(0, 70);
            this.pnlPie2.Name = "pnlPie2";
            this.pnlPie2.Size = new System.Drawing.Size(347, 245);
            this.pnlPie2.TabIndex = 16;
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.roundedPanel5.BorderRadius = 60;
            this.roundedPanel5.Controls.Add(this.btnSet);
            this.roundedPanel5.Controls.Add(this.pnlPie3);
            this.roundedPanel5.Controls.Add(this.txtGoal);
            this.roundedPanel5.Controls.Add(this.lblGoal);
            this.roundedPanel5.Location = new System.Drawing.Point(392, 490);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.Size = new System.Drawing.Size(436, 343);
            this.roundedPanel5.TabIndex = 18;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSet.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSet.BorderRadius = 18;
            this.btnSet.BorderSize = 0;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(25, 221);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(176, 62);
            this.btnSet.TabIndex = 18;
            this.btnSet.Text = "Set a Goal";
            this.btnSet.TextColor = System.Drawing.Color.White;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // pnlPie3
            // 
            this.pnlPie3.BackColor = System.Drawing.Color.MistyRose;
            this.pnlPie3.BorderRadius = 60;
            this.pnlPie3.Location = new System.Drawing.Point(207, 132);
            this.pnlPie3.Name = "pnlPie3";
            this.pnlPie3.Size = new System.Drawing.Size(220, 168);
            this.pnlPie3.TabIndex = 17;
            // 
            // txtGoal
            // 
            this.txtGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.txtGoal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGoal.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoal.ForeColor = System.Drawing.Color.SlateBlue;
            this.txtGoal.Location = new System.Drawing.Point(40, 77);
            this.txtGoal.Name = "txtGoal";
            this.txtGoal.Size = new System.Drawing.Size(373, 51);
            this.txtGoal.TabIndex = 13;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.roundedPanel3.BorderRadius = 30;
            this.roundedPanel3.Controls.Add(this.label23);
            this.roundedPanel3.Controls.Add(this.lblDashSave);
            this.roundedPanel3.Controls.Add(this.pictureBox8);
            this.roundedPanel3.Location = new System.Drawing.Point(28, 209);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(347, 95);
            this.roundedPanel3.TabIndex = 16;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Noto Sans SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(94, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 29);
            this.label23.TabIndex = 19;
            this.label23.Text = "Savings";
            // 
            // lblDashSave
            // 
            this.lblDashSave.BackColor = System.Drawing.Color.Transparent;
            this.lblDashSave.Font = new System.Drawing.Font("Noto Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashSave.ForeColor = System.Drawing.Color.White;
            this.lblDashSave.Location = new System.Drawing.Point(88, 32);
            this.lblDashSave.Name = "lblDashSave";
            this.lblDashSave.Size = new System.Drawing.Size(246, 51);
            this.lblDashSave.TabIndex = 19;
            this.lblDashSave.Text = "1000000";
            this.lblDashSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(12, 12);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(70, 70);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 20;
            this.pictureBox8.TabStop = false;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.White;
            this.pnlLine.BorderRadius = 60;
            this.pnlLine.Location = new System.Drawing.Point(392, 209);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(436, 265);
            this.pnlLine.TabIndex = 17;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPie.BorderRadius = 60;
            this.pnlPie.Location = new System.Drawing.Point(312, 66);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(429, 340);
            this.pnlPie.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1520, 911);
            this.Controls.Add(this.btnNav_3);
            this.Controls.Add(this.btnNav_2);
            this.Controls.Add(this.btnNav_1);
            this.Controls.Add(this.roundedPanel8);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.gradientPanelRound4);
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
            this.Controls.Add(this.pnl_3);
            this.Controls.Add(this.pnl_1);
            this.Controls.Add(this.pnl_2);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.pnl_3.ResumeLayout(false);
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
            this.pnlHistory.ResumeLayout(false);
            this.pnlEmpty.ResumeLayout(false);
            this.pnlEmpty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlDeleteCon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gradientPanelRound2.ResumeLayout(false);
            this.gradientPanelRound2.PerformLayout();
            this.gradientPanelRound3.ResumeLayout(false);
            this.gradientPanelRound3.PerformLayout();
            this.gradientPanelRound4.ResumeLayout(false);
            this.gradientPanelRound4.PerformLayout();
            this.roundedPanel11.ResumeLayout(false);
            this.roundedPanel10.ResumeLayout(false);
            this.roundedPanel9.ResumeLayout(false);
            this.pnl_2.ResumeLayout(false);
            this.roundedPanel13.ResumeLayout(false);
            this.roundedPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).EndInit();
            this.roundedPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.pnl_1.ResumeLayout(false);
            this.roundedPanel6.ResumeLayout(false);
            this.roundedPanel6.PerformLayout();
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_3;
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
        private GradientPanelRound gradientPanelRound4;
        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel8;
        private RoundedPanel roundedPanel11;
        private RoundedPanel roundedPanel10;
        private RoundedPanel roundedPanel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        private GradientPanelRound gradientPanelRound5;
        private GradientPanelRound gradientPanelRound6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private RoundedPanel pnlHistory;
        private RoundedPanel pnlSave;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private RoundedPanel roundedPanel4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private RJCodeAdvance.RJControls.RJButton btnModify;
        private RJCodeAdvance.RJControls.RJButton rjButton9;
        private System.Windows.Forms.TableLayoutPanel tbl_Spend;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblGrand;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.Label lblTotalSave;
        private System.Windows.Forms.RichTextBox rtbHistory;
        private RJCodeAdvance.RJControls.RJButton rjButton11;
        private RoundedPanel pnlDeleteCon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private RJCodeAdvance.RJControls.RJButton rjButton12;
        private RJCodeAdvance.RJControls.RJButton rjButton13;
        private RoundedPanel pnlEmpty;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label13;
        private RJCodeAdvance.RJControls.RJButton rjButton15;
        private RJCodeAdvance.RJControls.RJButton rjButton14;
        private RJCodeAdvance.RJControls.RJButton btnDelAll_S;
        private RJCodeAdvance.RJControls.RJButton btnDelAll_E;
        private RJCodeAdvance.RJControls.RJButton btnNav_1;
        private RJCodeAdvance.RJControls.RJButton btnNav_2;
        private RJCodeAdvance.RJControls.RJButton btnNav_3;
        private System.Windows.Forms.Panel pnl_2;
        private RJCodeAdvance.RJControls.RJButton btnSearch;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox pictureBox5;
        private RJCodeAdvance.RJControls.RJTextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Panel pnl_1;
        private RoundedPanel pnlLine;
        private RoundedPanel pnlPie;
        private RoundedPanel pnlPie2;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private RoundedPanel roundedPanel5;
        private RoundedPanel roundedPanel6;
        private RoundedPanel pnlPie3;
        private System.Windows.Forms.TextBox txtGoal;
        private RJCodeAdvance.RJControls.RJButton btnSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblDashSpend;
        private System.Windows.Forms.Label lblDashSave;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private RoundedPanel roundedPanel12;
        private RoundedPanel roundedPanel13;
        private RoundedPanel roundedPanel14;
        private System.Windows.Forms.DataGridView dgv_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}

