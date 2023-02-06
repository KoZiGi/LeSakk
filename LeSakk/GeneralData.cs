using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk
{
    class GeneralData
    {
        public static bool isTurn { get; set; } //true fehér, false fekete
        public static bool inCheck { get; set; } //true igen, false nem
        public static bool CheckMate { get; set; } //true igen, false nem
        public static int[] selectedIndex { get; set; } //0=y, 1=x
        //játék mező 
        public static int[,] Field = new int[8, 8]
        {
            { 2, 3, 4, 5, 6, 4, 3, 2 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 3, 4, 5, 6, 4, 3, 2 }
        };
    }
}
