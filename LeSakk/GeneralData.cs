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

        public GeneralData()
        {
                    
        }
    }
}
