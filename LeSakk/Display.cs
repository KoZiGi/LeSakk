using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace LeSakk
{
    class Display
    {
        public static void GenDisplay(Form1 form)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int g = 0; g < 8; g++)
                {
                    form.Controls.Add(GenPbx(i,g));
                }
            }
            form.Width = Data.Field.GetLength(0)*50 + 15;
            form.Height = Data.Field.GetLength(0) * 50 + 36;
        }
        private static PictureBox GenPbx(int i, int g)
        {
            PictureBox pbx = new PictureBox();
            pbx.Height = 50;
            pbx.Width = 50;
            pbx.Top = i * 50;
            pbx.Left = g * 50;
            pbx.BackColor = ColorDecider(i, g);
            pbx.Name = $"_{i}{g}"; //x==g y==i, azaz az első az Y koordináta!
            return pbx;
        }
        public static void UpdateDisplay(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pbx = control as PictureBox;
                    pbx.Image = ImageDecider(pbx.Name);
                }
            }
        }
        private static Image ImageDecider(string name)
        {
            //világos: 255 192 130 | sötét: 128 64 0
            int y = Convert.ToInt32(name[1].ToString()), x = Convert.ToInt32(name[2].ToString());
            Babu piece = Data.Field[y, x];
            return piece.Type != 0 ? ImageFromProperties($"{(piece.isWhite ? "T" : "F")}{(CheckParity(y, x) ? "T" : "F")}{piece.Type}") : null;
        }
        private static Image ImageFromProperties(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }
        private static bool CheckParity(int i, int g) => (i % 2 == 0 && g % 2 == 0) || (i % 2 != 0 && g % 2 != 0);
        private static Color ColorDecider(int i, int g) =>
            CheckParity(i,g) ?
                Color.FromArgb(255, 192, 130) : Color.FromArgb(128, 64, 0);
    }
}
