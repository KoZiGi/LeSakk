using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk
{
    class Babu
    {
        public bool isWhite;
        public int Type;
        public Babu(bool white, int type)
        {
            isWhite = white;
            Type = type;
        }
        public List<int[]> GetValidMoves(int x, int y)
        {
            switch (Type)
            {
                case 1:
                    return Babuk.Gyalogos.AllowedMoves(y,x,isWhite);
                case 2:
                    return Babuk.Bastya.AllowedMoves(y, x);
                case 3:
                    return Babuk.Huszar.AllowedMoves(y, x);
                case 4:
                    return Babuk.Futo.AllowedMoves(y, x);
                case 5:
                    return Babuk.Kiralyno.AllowedMoves(y, x);
                case 6:
                    return Babuk.Karoly.AllowedMoves(y, x);
                default: return new List<int[]>();
            }
        }
    }
}
