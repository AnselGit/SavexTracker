using System;
using System.Windows.Forms;

namespace SavexTracker.forms
{
    public partial class Opening : Form
    {
        private Timer loadingTimer;
        private int progressValue = 0;
        private Form1 mainForm;

        public Opening()
        {
            InitializeComponent();
        }

        private void Opening_Load(object sender, EventArgs e)
        {
            // Configure progress bar
            pgb_init.Minimum = 0;
            pgb_init.Maximum = 100;
            pgb_init.Value = 0;
            pgb_init.Style = ProgressBarStyle.Continuous;

            // Setup timer
            loadingTimer = new Timer();
            loadingTimer.Interval = 30; // ~3 seconds total (30ms * 100 = 3000ms)
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            progressValue += 1;

            if (progressValue <= 100)
                pgb_init.Value = progressValue;

            // At 2 seconds (30ms * 66 ≈ 1980ms), preload Form1 but keep hidden
            if (progressValue == 66 && mainForm == null)
            {
                lblStatus.Text = "Loading the application...";
                mainForm = new Form1();
                mainForm.Opacity = 0; // Load it hidden
                mainForm.Show();      // Show (but invisible), so it can initialize
            }

            // At 100%, show main form visibly and close this
            if (progressValue >= 100)
            {
                lblStatus.Text = "Done";
                loadingTimer.Stop();

                if (mainForm != null)
                {
                    mainForm.Opacity = 1; // Make it visible now
                    mainForm.BringToFront();
                }
                else
                {
                    mainForm = new Form1();
                    mainForm.Show();
                }

                this.Hide();
            }
        }
    }
}
