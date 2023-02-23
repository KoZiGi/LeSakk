using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk.Babuk
{
    class Karoly
    {
        public static List<int[]> AllowedMoves(int y, int x)
        {
            List<int[]> moose = new List<int[]>();
            if (x + 1 != 8 && (Data.Field[y, x + 1].isWhite == Data.isWhite || Data.Field[y, x + 1].Type == 0)) moose.Add(new int[] {y, x + 1});
            if (x - 1 != -1 && (Data.Field[y, x - 1].isWhite == Data.isWhite || Data.Field[y, x - 1].Type == 0)) moose.Add(new int[] { y, x - 1 });
            if (y - 1 != -1 && (Data.Field[y - 1, x].isWhite == Data.isWhite || Data.Field[y - 1, x].Type == 0)) moose.Add(new int[] { y - 1, x });
            if (y + 1 != 8 && (Data.Field[y + 1, x].isWhite == Data.isWhite || Data.Field[y + 1, x].Type == 0)) moose.Add(new int[] { y + 1, x });
            if (x - 1 != -1 && y - 1 != -1 && (Data.Field[y - 1, x - 1].isWhite == Data.isWhite || Data.Field[y - 1, x - 1].Type == 0)) moose.Add(new int[] { y - 1, x - 1 });
            if (x - 1 != -1 && y + 1 != 8 && (Data.Field[y + 1, x - 1].isWhite == Data.isWhite || Data.Field[y + 1, x - 1].Type == 0)) moose.Add(new int[] { y + 1, x - 1 });
            if (x + 1 != 8 && y - 1 != -1 && (Data.Field[y - 1, x + 1].isWhite == Data.isWhite || Data.Field[y - 1, x + 1].Type == 0)) moose.Add(new int[] { y - 1, x + 1 });
            if (x + 1 != 8 && y + 1 != 8 && (Data.Field[y+1, x+1].isWhite==Data.isWhite || Data.Field[y+1,x+1].Type==0)) moose.Add(new int[] { y + 1, x + 1 });
            return moose;
        }

        public static bool CheckValid(int toY, int toX)
        {
            List<int[]> validCoordinates = AllowedMoves(Data.selectedIndex[0], Data.selectedIndex[1]);
            for (int i = 0; i < validCoordinates.Count; i++)
            {
                if (validCoordinates[i][0] == toY && validCoordinates[i][1] == toX)
                {
                    if (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].isWhite != Data.Field[toY, toX].isWhite || Data.Field[toY, toX].Type == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}   
