using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk
{
    class FunctionsMethods
    {
        public static void gamelogic()
        {

        }
        public static void Swap()
        {
            Data.isWhite = !Data.isWhite;
        }
        public static void PesantToQween()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Data.Field[0,i].Type==1)
                {
                    AlterPiece(0,i);
                }
            }
        }
        public static void AlterPiece( int y ,int x )
        {
            new PieceChoser(y,x).Show();
        }
    }
}
