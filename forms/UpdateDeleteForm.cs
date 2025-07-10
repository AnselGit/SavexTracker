using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavexTracker.forms
{
    public partial class UpdateDeleteForm : Form
    {
        public UpdateDeleteForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = true;
        }

        private void btnCon1_Click(object sender, EventArgs e)
        {
            pnlUpdated.Visible = true;
            pnlUpdateCon.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 2000; // 2 seconds (2000 milliseconds)
            hideTimer.Tick += (s, args) =>
            {
                pnlUpdated.Visible = false;
                pnlUpdateCon.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = true;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            pnlDeleted.Visible = true;
            pnlDeleteCon.Visible = true;

            Timer hideTimer = new Timer();
            hideTimer.Interval = 2000; // 2 seconds (2000 milliseconds)
            hideTimer.Tick += (s, args) =>
            {
                pnlDeleted.Visible = false;
                pnlDeleteCon.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            pnlDeleteCon.Visible = false;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            pnlUpdateCon.Visible = false;
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
