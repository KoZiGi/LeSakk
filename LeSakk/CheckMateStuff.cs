using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeSakk
{
    class CheckMateStuff
    {
        private static void TempMierda(int x, int y, Babu[,] babuk)
        {
            if (babuk[y, x].Type != 0) babuk[y, x].Type = 0;
            else return;
        }
        private static void TempSwap(int x, int y, Babu[,] babuk)
        {
            int type = babuk[Data.selectedIndex[0], Data.selectedIndex[1]].Type;
            bool white = babuk[Data.selectedIndex[0], Data.selectedIndex[1]].isWhite;
            babuk[y, x] = new Babu(white, type);
            babuk[Data.selectedIndex[0], Data.selectedIndex[1]] = new Babu(false, 0);
        }
        public static bool CheckTempMove(int toY, int toX)
        {
            Babu[,] tempMove = GetCurrentField();

            if (FunctionsMethods.CheckValidMove(toX, toY))
            {
                TempMierda(toX, toY, tempMove);
                TempSwap(toX, toY, tempMove);
                FunctionsMethods.Swap();
                if (!TempCzechCheck(tempMove, TempGetKing(tempMove)[1], TempGetKing(tempMove)[0]))
                {
                    FunctionsMethods.Swap();
                    return false;
                }
                else
                {
                    FunctionsMethods.Swap();
                    return true;
                }
            }
            return true;
        }
        public static int[] TempGetKing(Babu[,] babuk)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int g = 0; g < 8; g++)
                {
                    if (babuk[i, g].Type == 6 && babuk[i, g].isWhite != Data.isWhite) return new int[] { i, g };
                }
            }
            return new int[] { -1, -1 };
        }
        public static bool TempCzechCheck(Babu[,] babuk, int kingX, int kingY) =>
            CheckRook(kingX, kingY, babuk) || CheckHonse(kingX, kingY, babuk) || 
            CheckBishop(kingX, kingY, babuk) || CheckPesant(kingX, kingY, babuk);
        private static bool CheckHonse(int kingX, int kingY, Babu[,] babuk)
        {
            if (kingX + 1 < 8)
            {
                if (kingY + 2 < 8 && babuk[kingY + 2, kingX + 1].Type == 3 && babuk[kingY + 2, kingX + 1].isWhite == Data.isWhite) return true;
                if (kingY - 2 > 0 && babuk[kingY - 2, kingX + 1].Type == 3 && babuk[kingY - 2, kingX + 1].isWhite == Data.isWhite) return true;
            }
            if (kingX - 1 > -1)
            {
                if (kingY + 2 < 8 && babuk[kingY + 2, kingX - 1].Type == 3 && babuk[kingY + 2, kingX - 1].isWhite == Data.isWhite) return true;
                if (kingY - 2 > 0 && babuk[kingY - 2, kingX - 1].Type == 3 && babuk[kingY - 2, kingX - 1].isWhite == Data.isWhite) return true;
            }
            if (kingX - 2 > -1)
            {
                if (kingY + 1 < 8 && babuk[kingY + 1, kingX - 2].Type == 3 && babuk[kingY + 1, kingX - 2].isWhite == Data.isWhite) return true;
                if (kingY - 1 > 8 && babuk[kingY - 1, kingX - 2].Type == 3 && babuk[kingY - 1, kingX - 2].isWhite == Data.isWhite) return true;
            }
            if (kingX + 2 < 8)
            {
                if (kingY + 1 < 8 && babuk[kingY + 1, kingX + 2].Type == 3 && babuk[kingY + 1, kingX + 2].isWhite == Data.isWhite) return true;
                if (kingY - 1 > 8 && babuk[kingY - 1, kingX + 2].Type == 3 && babuk[kingY - 1, kingX + 2].isWhite == Data.isWhite) return true;
            }
            return false;
        }
        private static bool CheckBishop(int kingX, int kingY, Babu[,] babuk)
        {
            for (int i = 1; kingX + i < 8 && kingY + i < 8; i++)
            {
                if ((babuk[kingY + i, kingX + i].Type == 4 || babuk[kingY + i, kingX + i].Type == 5) && babuk[kingY + i, kingX + i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY + i, kingX + i].Type != 0) break;
            }
            for (int i = 1; kingX + i < 8 && kingY - i > -1; i++)
            {
                if ((babuk[kingY - i, kingX + i].Type == 4 || babuk[kingY - i, kingX + i].Type == 5) && babuk[kingY - i, kingX + i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY - i, kingX + i].Type != 0) break;
            }
            for (int i = 1; kingX - i > -1 && kingY - i > -1; i++)
            {
                if ((babuk[kingY - i, kingX - i].Type == 4 || babuk[kingY - i, kingX - i].Type == 5) && babuk[kingY - i, kingX - i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY - i, kingX - i].Type != 0) break;
            }
            for (int i = 1; kingX - i > -1 && kingY + i < 8; i++)
            {
                if ((babuk[kingY + i, kingX - i].Type == 4 || babuk[kingY + i, kingX - i].Type == 5) && babuk[kingY + i, kingX - i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY + i, kingX - i].Type != 0) break;
            }
            return false;
        }
        private static bool CheckRook(int kingX, int kingY, Babu[,] babuk)
        {
            for (int i = kingX; i < 8; i++)
            {
                if ((babuk[kingY, i].Type == 2 || babuk[kingY,i].Type==5) && babuk[kingY, i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY, i].Type != 0 && i != kingX) break;
            }
            for (int i = kingX; i > -1; i--)
            {
                if ((babuk[kingY, i].Type == 2 || babuk[kingY, i].Type == 5) && babuk[kingY, i].isWhite == Data.isWhite) return true;
                else if (babuk[kingY, i].Type != 0 && i != kingX) break;
            }
            for (int i = kingY; i < 8; i++)
            {
                if ((babuk[i, kingX].Type == 2 || babuk[i, kingX].Type == 5) && babuk[i, kingX].isWhite == Data.isWhite) return true;
                else if (babuk[i, kingX].Type != 0 && i != kingY) break;
            }
            for (int i = kingY; i > 8; i--)
            {
                if ((babuk[i, kingX].Type == 2 || babuk[i, kingX].Type == 5) && babuk[i, kingX].isWhite == Data.isWhite) return true;
                else if (babuk[i, kingX].Type != 0 && i != kingY) break;
            }
            return false;
        }
        private static bool CheckPesant(int kingX, int kingY, Babu[,] babuk)
        {
            if (Data.isWhite)
            {
                if (kingX + 1 < 8 && kingY + 1 < 8 && babuk[kingY + 1, kingX + 1].Type == 1 && babuk[kingY + 1, kingX + 1].isWhite == Data.isWhite) return true;
                if (kingX - 1 > -1 && kingY + 1 < 8 && babuk[kingY + 1, kingX - 1].Type == 1 && babuk[kingY + 1, kingX - 1].isWhite == Data.isWhite) return true;
            }
            else
            {
                if (kingX + 1 < 8 && kingY - 1 > -1 && babuk[kingY - 1, kingX + 1].Type == 1 && babuk[kingY - 1, kingX + 1].isWhite == Data.isWhite) return true;
                if (kingX - 1 > -1 && kingY - 1 > -1 && babuk[kingY - 1, kingX - 1].Type == 1 && babuk[kingY - 1, kingX - 1].isWhite == Data.isWhite) return true;
            }
            return false;
        }
        private static Babu[,] GetCurrentField()
        {
            Babu[,] babuk = new Babu[8, 8];
            for (int i = 0; i < babuk.GetLength(0); i++)
                for (int g = 0; g < babuk.GetLength(0); g++)
                    babuk[i, g] = new Babu(Data.Field[i, g].isWhite, Data.Field[i, g].Type);
            return babuk;
        }
    }
}
