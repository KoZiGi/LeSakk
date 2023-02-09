using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Kiralyno
    {
        public static List<int[]> AllowedMoves(int y, int x)
        {
            List<int[]> moose = new List<int[]>();
            moose.AddRange(Babuk.Bastya.AllowedMoves(y,x));
            moose.AddRange(Babuk.Futo.AllowedMoves(y,x));
            return moose;
        }
    }
}
