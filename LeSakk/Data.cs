using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk
{

    class Data
    {
        public static bool isWhite = true;
        public static bool inCheck = false;
        public static bool CheckMate = false;
        private static Random r = new Random();
        public static int[] selectedIndex = new int[] { -1, -1 };
        public static int[] Checker = new int[2];
        public static Form1 GameForm;
        //játék mező 
        public static Babu[,] Field = new Babu[8, 8]
        {
            { new Babu(false, 2), new Babu(false, 3), new Babu(false, 4), new Babu(false, 5), new Babu(false, 6), new Babu(false, 4), new Babu(false, 3), new Babu(false, 2) },
            { new Babu(false, 1), new Babu(false, 1), new Babu(false, 1), new Babu(false, 1), new Babu(false, 1), new Babu(false, 1), new Babu(false, 1), new Babu(false, 1) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(true, 1), new Babu(true, 1), new Babu(true, 1), new Babu(true, 1), new Babu(true, 1), new Babu(true, 1), new Babu(true, 1), new Babu(true, 1) },
            { new Babu(true, 2), new Babu(true, 3), new Babu(true, 4), new Babu(true, 5), new Babu(true, 6), new Babu(true, 4), new Babu(true, 3), new Babu(true, 2) }
        };
        /*public static Babu[,] Field = new Babu[8, 8]
        {
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0), new Babu(false, 0) },
            { new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0) },
            { new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0), new Babu(true, 0) }
        };*/
        public static Babu[,] ReallyBadField()
        {
            Babu[,] field = new Babu[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int g = 0; g < 8; g++)
                {
                    field[i, g] = GenReallyBadPiece(i, g);
                }
            }
            return field;
        }
        private static Babu GenReallyBadPiece(int i, int g) =>
            i < 2 ?
                g == 4 && i == 0 ? new Babu(false, 6) : new Babu(false, r.Next(1, 6)) :
            i > 5 ?
                g == 4 && i == 7 ? new Babu(true, 6) : new Babu(true, r.Next(1, 6)):
            new Babu(false, 0);
    }

}
