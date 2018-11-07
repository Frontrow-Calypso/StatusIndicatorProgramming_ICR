using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LED_Programming
{
    public partial class Fail : Form
    {
        Form1 Main;
        public Fail(Form1 parent)
        {
            InitializeComponent();
            Main = parent;
        }
    }
}
