using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Gyalogos
    {
        public static List<int[]> AllowedMoves(int y, int x, bool isWhite)
        {
            List<int[]> moose = new List<int[]>();
            if (isWhite)
            {
                if (Data.Field[y-1,x].Type==0&&y!=7)
                {
                    moose.Add(new int[] { y - 1, x });
                }
                if (Data.Field[y - 1, x-1].Type!=0&& !Data.Field[y - 1, x - 1].isWhite)
                {
                    moose.Add(new int[] { y - 1, x-1 });
                }
                if (Data.Field[y - 1, x + 1].Type != 0 && !Data.Field[y - 1, x + 1].isWhite)
                {
                    moose.Add(new int[] { y - 1, x + 1 });
                }
            }
            else
            {
                if (Data.Field[y + 1, x].Type == 0 && y != 0)
                {
                    moose.Add(new int[] { y + 1, x });
                }
                if (Data.Field[y + 1, x - 1].Type != 0 && Data.Field[y + 1, x - 1].isWhite)
                {
                    moose.Add(new int[] { y + 1, x - 1 });
                }
                if (Data.Field[y +1, x + 1].Type != 0 && Data.Field[y + 1, x + 1].isWhite)
                {
                    moose.Add(new int[] { y + 1, x + 1 });
                }
            }
            return moose;
        }
    }
}
