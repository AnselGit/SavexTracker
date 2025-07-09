using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavexTracker
{
    public partial class Form1 : SolidRoundedForm
    {
        public Form1()
        {
            InitializeComponent();            
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rjButton10_Click(object sender, EventArgs e)
        {

        }

        private void rjCircularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sd5__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox74__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox75__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox76__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox77__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox78__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox79__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox49__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox50__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox51__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox52__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox53__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox54__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox55__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox56__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox57__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox58__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox59__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox60__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox21__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox22__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox23__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox24__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox17__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox18__TextChanged(object sender, EventArgs e)
        {

        }

        private void sd6__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox73__TextChanged(object sender, EventArgs e)
        {

        }

        private void sd4__TextChanged(object sender, EventArgs e)
        {

        }

        private void sd3__TextChanged(object sender, EventArgs e)
        {

        }

        private void sd2__TextChanged(object sender, EventArgs e)
        {

        }

        private void sd1__TextChanged(object sender, EventArgs e)
        {

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
