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
    public partial class addSavings : Form
    {
        public addSavings()
        {
            InitializeComponent();
        }

        private void addSavings_Load(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Now.ToString("MM/dd/yy");
        }        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
