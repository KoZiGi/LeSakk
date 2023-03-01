using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Bastya
    {
        public static List<int[]> AllowedMoves(int y, int x)
        {
            List<int[]> moves = new List<int[]>();
            moves.AddRange(CheckY(y, x, true));
            moves.AddRange(CheckY(y, x, false));
            moves.AddRange(CheckX(y, x, false));
            moves.AddRange(CheckX(y, x, true));
            return moves;
        }
        private static List<int[]> CheckY(int y, int x, bool up)
        {
            List<int[]> moves = new List<int[]>();
            for (int i = y; up ? i > -1 : i < 8; i+= up ? -1 : 1)
            {
                if (Data.Field[i, x].Type == 0)
                {
                    continue;
                }
                if (Data.Field[i, x].Type != 0)
                {
                    if (y == i) continue;
                    if ((Data.Field[i, x].isWhite && Data.isWhite) || (!Data.Field[i,x].isWhite && !Data.isWhite))
                    {
                        moves.Add(new int[] { up ? i + 1 : i - 1, x });
                        break;
                    }
                    else
                    {
                        moves.Add(new int[] { i, x });
                        break;
                    }
                }
                if (Data.Field[i, x].Type == 0 && i == (up ? 0 : 7))
                {
                    moves.Add(new int[] { i, x });
                    break;
                }
            }
            return moves;
        }
        private static List<int[]> CheckX(int y, int x, bool left)
        {
            List<int[]> moose = new List<int[]>();
            for (int i = x; left ? i > -1 : i < 8 ; i+= left ? -1 : 1)
            {
                if (Data.Field[y, i].Type == 0)
                {
                    continue;
                }
                if (Data.Field[y, i].Type != 0)
                {
                    if (x == i) continue;
                    if ((Data.Field[y, i].isWhite && Data.isWhite) || (!Data.Field[y, i].isWhite && !Data.isWhite))
                    {
                        moose.Add(new int[] { y, left ? i+1 : i-1 });
                        break;
                    }
                    else
                    {
                        moose.Add(new int[] { y, i });
                        break;
                    }
                }
                if (Data.Field[y, i].Type == 0 && i == (left ? 0 : 7))
                {
                    moose.Add(new int[] { y, i });
                    break;
                }
            }
            return moose;
        }
        public static bool CheckValid(int toY, int toX)
        {
            if (Data.selectedIndex[1] == toX)
            {
                for (int i = Data.selectedIndex[0]; Data.selectedIndex[0] >= toY ? i >= toY : i <= toY; i += Data.selectedIndex[0] > toY ? -1 : 1)
                {
                    if (i >= 8 || i <= -1) return false;
                    if (i==Data.selectedIndex[0]) continue;
                    if (Data.Field[i, Data.selectedIndex[1]].Type!=0)
                    {
                        if (Data.Field[i, Data.selectedIndex[1]].isWhite != Data.isWhite)
                        {
                            if (i == toY && toX == Data.selectedIndex[1]) return true;
                            else return false;
                        }
                        else return false;
                    }
                    else
                    {
                        if (i == toY && toX == Data.selectedIndex[1]) return true;
                    }
                }
            }
            if (Data.selectedIndex[0] == toY)
            {
                for (int i = Data.selectedIndex[1]; Data.selectedIndex[1]>=toX ? i >= toX : i <= toX; i+= Data.selectedIndex[1]>=toX ? -1 : 1)
                {
                    if (i == Data.selectedIndex[1]) continue;
                    if (Data.Field[Data.selectedIndex[0], i].Type != 0)
                    {
                        if (Data.Field[Data.selectedIndex[0], i].isWhite != Data.isWhite)
                        {
                            if (i == toX && toY == Data.selectedIndex[0]) return true;
                            else return false;
                        }
                        else return false;
                    }
                    else
                    {
                        if (i == toX && toY == Data.selectedIndex[0]) return true;
                    }
                }
            }
            return false;
        }
    }
}
