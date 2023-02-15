using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeSakk
{
    class FunctionsMethods
    {
        public static void gamelogic(PictureBox pbx)
        {
            if (Data.selectedIndex[0] != -1)
            {
                if (GetCoords(pbx.Name)[0] == Data.selectedIndex[0] && GetCoords(pbx.Name)[1] == Data.selectedIndex[1]) ResetSelect();
                else
                    DoMove(pbx.Name);
                Display.updateStatus();
            }
            else
            {
                SelectPiece(pbx.Name);
                Display.updateStatus();
            }
        }
        private static void SelectPiece(string name)
        {
            int x = GetCoords(name)[1], y = GetCoords(name)[0];
            if (Data.isWhite==Data.Field[y,x].isWhite && Data.Field[y, x].Type != 0)
            {
                Data.selectedIndex[0] = y;
                Data.selectedIndex[1] = x;
            }
        }
        private static int[] GetCoords(string name) => new int[2] { Convert.ToInt32(name[1].ToString()), Convert.ToInt32(name[2].ToString()) };
        public static void ResetSelect()
        {
            Data.selectedIndex[0] = -1;
            Data.selectedIndex[1] = -1;
        }
        private static void DoMove(string name)
        {
            int x = GetCoords(name)[1], y = GetCoords(name)[0];
            if (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type != 0)
            {
               if (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].GetValidMoves(Data.selectedIndex[1], Data.selectedIndex[0]).Count>0)
               {
                    if (CheckValidMove(x, y))
                    {
                        Mierda(x, y);
                        SwapPieces(x, y);
                        Display.UpdateDisplay(Data.GameForm.Controls);
                        Swap();
                    }
                    else ResetSelect();
               }                
            }
            else return;
        }
        private static void Mierda(int x, int y)
        {
            if (Data.Field[y, x].Type != 0) Data.Field[y, x].Type = 0;
            else return;
        }
        private static void SwapPieces(int x, int y)
        {
            int type = Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type;
            bool white = Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].isWhite;
            Data.Field[y, x] = new Babu(white, type);
            Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]] = new Babu(false, 0);
            ResetSelect();
        }
        private static bool CheckValidMv(int toX, int toY)
        {
            switch (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type)
            {
                case 4:
                    return Babuk.Futo.CheckValid(toY, toX);
                case 5:
                    return false;
                case 2:
                    return Babuk.Bastya.CheckValid(toY, toX);
                case 6:
                    return Babuk.Karoly.CheckValid(toY, toX);
            }
            return false;
        }
        private static bool CheckValidHorseOrPeasant(int toX, int toY)
        {
            foreach (int[] coordinate in Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].GetValidMoves(Data.selectedIndex[1], Data.selectedIndex[0]))
            {
                if (coordinate[1] == toY && coordinate[0] == toX) return true;
            }
            return false;
        }
        private static bool CheckValidMove(int x, int y)
        {
            switch (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type)
            {
                case 1:
                case 3:
                    return CheckValidHorseOrPeasant(y, x);
                default:
                    return CheckValidMv(x, y);
            }
        }
        private static void Swap()
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
