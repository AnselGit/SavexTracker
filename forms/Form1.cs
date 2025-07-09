using SavexTracker.forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SavexTracker
{
    public partial class Form1 : SolidRoundedForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            addSavings addForm = new addSavings();
            addForm.ShowDialog(); // Modal — pauses until form is closed
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }

    public class VerticalFlowPanel : FlowLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00100000; // WS_HSCROLL = 0x00100000
                return cp;
            }
        }
    }
}
