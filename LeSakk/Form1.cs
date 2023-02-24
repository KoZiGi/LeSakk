using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeSakk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Data.GameForm = this;
            InitializeComponent();
            Display.updateStatus();
            Display.GenDisplay(this);
            Display.UpdateDisplay(this.Controls);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            FunctionsMethods.Surrender();
        }
    }
}
