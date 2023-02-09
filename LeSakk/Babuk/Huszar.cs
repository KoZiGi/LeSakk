using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Huszar
    {
        public static List<int[]> AllowedMoves(int y,int x)
        {
            List<int[]> moose = new List<int[]>();

            if (y+2<8)
            {
                if (x+1<8 && (Data.isWhite ? !Data.Field[y+2,x+1].isWhite: Data.Field[y + 2, x + 1].isWhite || Data.Field[y + 2, x + 1].Type == 0))
                {
                    moose.Add(new int[] {y +2,x+1 });
                }
                if (x - 1 >= 0 && (Data.isWhite ? !Data.Field[y + 2, x-+ 1].isWhite : Data.Field[y + 2, x- 1].isWhite || Data.Field[y+ 2, x- 1].Type == 0))
                {
                    moose.Add(new int[] { y + 2, x-1 });
                }
            }
            if (y - 2 >= 0)
            {
                if (x + 1 < 8 && (Data.isWhite ? !Data.Field[y - 2, x + 1].isWhite : Data.Field[y - 2, x + 1].isWhite || Data.Field[y - 2, x + 1].Type == 0))
                {
                    moose.Add(new int[] { y - 2, x + 1 });
                }
                if (x - 1 >= 0 && (Data.isWhite ? !Data.Field[y - 2, x - 1].isWhite : Data.Field[y - 2, x - 1].isWhite || Data.Field[y - 2, x - 1].Type == 0))
                {
                    moose.Add(new int[] { y - 2, x - 1 });
                }
            }
            if (x + 2 <8 )
            {
                if (y + 1 < 8 && (Data.isWhite ? !Data.Field[y + 1, x + 2].isWhite : Data.Field[y + 1, x + 2].isWhite || Data.Field[y + 1, x + 2].Type == 0))
                {
                    moose.Add(new int[] {  y + 1 , x + 2});
                }
                if (y - 1 >= 0 && (Data.isWhite ? !Data.Field[y - 1, x + 2].isWhite : Data.Field[y - 1, x + 2].isWhite || Data.Field[y - 1, x + 2].Type == 0))
                {
                    moose.Add(new int[] {  y - 1, x+2 });
                }
            }
            if (x - 2>=0)
            {
                if (y + 1 < 8 && (Data.isWhite ? !Data.Field[y + 1, x - 2].isWhite : Data.Field[y + 1, x - 2].isWhite || Data.Field[y + 1, x - 2].Type == 0))
                {
                    moose.Add(new int[] { y + 1, x - 2 });
                }
                if (y - 1 >= 0 && (Data.isWhite ? !Data.Field[y - 1, x - 2].isWhite : Data.Field[y - 1, x - 2].isWhite || Data.Field[y + 1, x - 2].Type == 0))
                {
                    moose.Add(new int[] { y - 1, x - 2 });
                }
            }
            return moose;
        }
    }
}
