using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_APP_DEV
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        int count = 0;
        private void Loading_Load(object sender, System.EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Style= ProgressBarStyle.Continuous;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(count<=100)
            {
                progressBar1.Value = count;
                label_progress.Text = count.ToString() + " %";
            }
            else if (count == 150)
            {
                timer1.Stop();
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            count++;
        }
    }
}
