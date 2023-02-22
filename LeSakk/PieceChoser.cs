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
    public partial class PieceChoser : Form
    {
        static int X, Y;
        public PieceChoser(int y, int x)
        {
            InitializeComponent();
            X = x;
            Y = y;
        }
        private void AlterBabu(int type)
        {
            FunctionsMethods.SwapPeasantTo(X, Y, type);
            Display.UpdateDisplay(Data.GameForm.Controls);
            Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e) => AlterBabu(2);
        private void pictureBox3_Click(object sender, EventArgs e) => AlterBabu(3);
        private void pictureBox4_Click(object sender, EventArgs e) => AlterBabu(4);
        private void pictureBox2_Click(object sender, EventArgs e) => AlterBabu(5);
    }
}
