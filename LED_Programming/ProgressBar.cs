using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LED_Programming
{
    public partial class ProgressBar : Form
    {
        Form1 Main;
        public ProgressBar(Form1 parent)
        {
            InitializeComponent();

            Main = parent;
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {

                Thread.Sleep(80);
                backgroundWorker1.ReportProgress(i);

                /*if (i == 100)
                {
                    this.Close();
                }*/

            }

            /*if (progressBar1.Value == 100)
            {
            */




        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            label1.Text = e.ProgressPercentage.ToString();

            if (progressBar1.Value == 100)
            {
                this.Close();

            }
        }

       

        }
}
