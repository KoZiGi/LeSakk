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
        public static int[] selectedIndex = new int[] { -1, -1 };
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
    }
}
