using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Futo
    {
        public static List<int[]> AllowedMoves(int y, int x)
        {
            List<int[]> moose = new List<int[]>();
            bool diagonaldownright = false, diagonaldownleft = false, diagonalupright = false, diagonalupleft = false;
            for (int i = 1; i < 8; i++)
            {
                if (x+i<8 && y+i <8 && !diagonaldownright)
                {

                    if (Data.Field[y + i, x + i].Type != 0 && Data.isWhite ? !Data.Field[y + i, x + i].isWhite : Data.Field[y + i, x + i].isWhite)
                    {
                        diagonaldownright = true;
                        moose.Add(new int[] {y+i,x+i });
                    }

                }
                if (x - i >= 0 && y + i < 8 && !diagonaldownleft)
                {

                    if (Data.Field[y + i, x - i].Type != 0 && Data.isWhite ? !Data.Field[y + i, x - i].isWhite : Data.Field[y + i, x - i].isWhite)
                    {
                        diagonaldownleft = true;
                        moose.Add(new int[] { y + i, x - i });
                    }

                }
                if (x - i >= 0 && y - i >=0 && !diagonalupleft)
                {

                    if (Data.Field[y - i, x - i].Type != 0 && Data.isWhite ? !Data.Field[y - i, x - i].isWhite : Data.Field[y - i, x - i].isWhite)
                    {
                        diagonalupleft = true;
                        moose.Add(new int[] { y - i, x - i });
                    }

                }
                if (x + i <8 && y - i >= 0 && !diagonalupright)
                {

                    if (Data.Field[y - i, x + i].Type != 0 && Data.isWhite ? !Data.Field[y - i, x + i].isWhite : Data.Field[y - i, x + i].isWhite)
                    {
                        diagonalupright = true;
                        moose.Add(new int[] { y - i, x + i });
                    }

                }
                if (x+i==7)
                {
                    if (!diagonaldownright)
                    {
                        moose.Add(new int[] { y + i, x + i });
                        diagonaldownright = true;
                    }
                    if (!diagonalupright)
                    {
                        moose.Add(new int[] { y - i, x + i });
                        diagonalupright = true;
                    }
                }
                if (x - i == 0)
                {
                    if (!diagonaldownleft)
                    {
                        moose.Add(new int[] { y + i, x - i });
                        diagonaldownleft = true;
                    }
                    if (!diagonalupleft)
                    {
                        moose.Add(new int[] { y - i, x - i });
                        diagonalupleft = true;
                    }
                }
                if (y - i == 0)
                {
                    if (!diagonalupleft)
                    {
                        moose.Add(new int[] { y - i, x - i });
                        diagonalupleft = true;
                    }
                    if (!diagonalupright)
                    {
                        moose.Add(new int[] { y - i, x + i });
                        diagonalupright= true;
                    }
                }
                if (y + i == 7)
                {
                    if (!diagonaldownleft)
                    {
                        moose.Add(new int[] { y + i, x - i });
                        diagonaldownleft = true;
                    }
                    if (!diagonaldownright)
                    {
                        moose.Add(new int[] { y + i, x + i });
                        diagonaldownright = true;
                    }
                }
            }

            return moose;
        }

    }
}
