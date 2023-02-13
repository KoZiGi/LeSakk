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
                    if (Data.Field[i, x].isWhite && Data.isWhite)
                    {
                        moves.Add(new int[] { up ? i - 1 : i + 1, x });
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
                    if (Data.Field[y, i].isWhite && Data.isWhite)
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
                if (Data.Field[y, i].Type == 0 && i == (left ? 0 : 8))
                {
                    moose.Add(new int[] { y, i });
                    break;
                }
            }
            return moose;
        }
        public static bool CheckValid(int toY, int toX, List<int[]> coordinates)
        {
            if (toY == Data.selectedIndex[0])
            {
                List<int> Xs = coordinates.Where(e => e[0] == toY).Select(g=>g[1]).ToList();
                if (toX <= Xs.Max() && toX >= Xs.Min()) return true;
            }
            if (toX == Data.selectedIndex[1])
            {
                List<int> Ys = coordinates.Where(e => e[1] == toX).Select(g => g[0]).ToList();
                if (toY <= Ys.Max() && toY >= Ys.Min()) return true;
            }
            return false;
        }
    }
}
