using System;
using System.Windows.Forms;

namespace SavexTracker.forms
{
    public partial class Opening : Form
    {
        private Timer loadingTimer;
        private int progressValue = 0;

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

            // Set up the timer to make it finish in exactly 3 seconds
            loadingTimer = new Timer();
            loadingTimer.Interval = 30; // 30ms tick
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            // Since 100 steps * 30ms = 3000ms (3 seconds)
            progressValue += 1;

            if (progressValue <= 100)
            {
                pgb_init.Value = progressValue;
            }

            if (progressValue >= 100)
            {
                loadingTimer.Stop();

                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Close(); // Close the opening form after 3 seconds
            }
        }
    }
}
