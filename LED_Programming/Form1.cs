using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace LED_Programming
{
    public partial class Form1 : Form
    {
        Success form2;

        Fail form3;

        ProgressBar form4;

        public Form1()
        {
            InitializeComponent();
        }

      private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            led1.OffColor = Color.Yellow;
            this.Refresh();

            var processInfo = new ProcessStartInfo(@"C:\\Users\\vaka\\Desktop\\MSPFET Flasher_Lasso.bat");

            processInfo.CreateNoWindow = true;

            processInfo.UseShellExecute = false;

            //processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            form4 = new ProgressBar(this);

            form4.Show();

            while (form4.Visible == true)
            {
                Application.DoEvents();

            }

            string output = process.StandardOutput.ReadToEnd();

            form4.Dispose();

            process.WaitForExit();

            //MessageBox.Show(output);

            if (output.Contains("No error"))
            {
                led1.OffColor = Color.LawnGreen;
            }

            else 
            {
                MessageBox.Show("Please check the board connections" +
                            "\n 请检查连接");
                led1.OffColor = Color.Red;
            }

            if (led1.OffColor == Color.LawnGreen)
            {
                form2 = new Success(this);
                form2.Show();
                button2.Enabled = true;

            }

            else
            {
                form3 = new Fail(this);

                form3.Show();
                button2.Enabled = true;

            }

        }

      private void button2_Click(object sender, EventArgs e)
      {
          button1.Enabled = true;
          led1.OffColor = Color.Black;
          
      }

      private void button3_Click(object sender, EventArgs e)
      {
          this.Close();
      }


    }
}
