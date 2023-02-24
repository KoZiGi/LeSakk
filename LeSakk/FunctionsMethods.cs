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
                if (Data.inCheck) { if (CzechMate(GetKing()[1], GetKing()[0], Data.Checker[1], Data.Checker[0])) { MessageBox.Show("bfdo"); } }
                if (GetCoords(pbx.Name)[0] == Data.selectedIndex[0] && GetCoords(pbx.Name)[1] == Data.selectedIndex[1]) ResetSelect();
                else DoMove(pbx.Name);
            }
            else
                SelectPiece(pbx.Name);
            Display.updateStatus();
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
            if (!CheckMateStuff.CheckTempMove(y, x))
            {
                if (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type != 0)
                {
                    if (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].GetValidMoves(Data.selectedIndex[1], Data.selectedIndex[0]).Count > 0)
                    {
                        if (Data.inCheck)
                        {
                            if (!CheckMateStuff.CheckTempMove(y, x))
                            {
                                Data.inCheck = false;
                                Mierda(x, y);
                                SwapPieces(x, y);
                                CheckPesants();
                                Swap();
                                Display.UpdateDisplay(Data.GameForm.Controls);
                            }
                            else ResetSelect();
                        }
                        else
                        {
                            if (CheckValidMove(x, y))
                            {
                                Mierda(x, y);
                                SwapPieces(x, y);
                                CheckPesants();
                                Data.inCheck = CzechCheck(GetKing()[1], GetKing()[0]);
                                if (Data.inCheck) Data.Checker = new int[] { y, x };
                                Swap();
                                Display.UpdateDisplay(Data.GameForm.Controls);
                            }
                            else ResetSelect();
                        }
                    }
                }
            }
            else ResetSelect();
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
                    return Babuk.Futo.CheckValid(toY, toX) || Babuk.Bastya.CheckValid(toY, toX);
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
                if (coordinate[0] == toY && coordinate[1] == toX) return true;
            }
            return false;
        }
        public static bool CheckValidMove(int x, int y)
        {
            switch (Data.Field[Data.selectedIndex[0], Data.selectedIndex[1]].Type)
            {
                case 1:
                case 3:
                    return CheckValidHorseOrPeasant(x, y);
                default:
                    return CheckValidMv(x, y);
            }
        }
        public static void Swap() => Data.isWhite = !Data.isWhite;
        private static void CheckPesants()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Data.Field[0, i].Type == 1 && Data.Field[0, i].isWhite)
                {
                    AlterPiece(0, i);
                }
                if (Data.Field[7, i].Type == 1 && !Data.Field[7, i].isWhite)
                {
                    AlterPiece(7, i);
                }
            }
        }
        public static void AlterPiece( int y ,int x )
        {
            new PieceChoser(y,x).Show();
        }
        public static void SwapPeasantTo(int x, int y, int type) => Data.Field[y, x].Type = type;
        private static int[] GetKing()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int g = 0; g < 8; g++)
                {
                    if (Data.Field[i, g].Type == 6 && Data.Field[i, g].isWhite != Data.isWhite) return new int[] { i, g };
                }
            }
            return new int[] { -1, -1 };
        }
        private static bool CheckHonse(int kingX, int kingY)
        {
            if (kingX + 1 < 8)
            {
                if (kingY + 2 < 8 && Data.Field[kingY+2, kingX+1].Type==3 && Data.Field[kingY+2, kingX+1].isWhite == Data.isWhite) return true;
                if (kingY - 2 > 0 && Data.Field[kingY-2, kingX+1].Type==3 && Data.Field[kingY-2, kingX+1].isWhite == Data.isWhite) return true;
            }
            if (kingX-1 > -1)
            {
                if (kingY + 2 < 8 && Data.Field[kingY+2, kingX-1].Type==3 && Data.Field[kingY+2, kingX-1].isWhite == Data.isWhite) return true;
                if (kingY - 2 > 0 && Data.Field[kingY-2, kingX-1].Type==3 && Data.Field[kingY-2, kingX-1].isWhite == Data.isWhite) return true;
            }
            if (kingX - 2 > -1)
            {
                if (kingY + 1 < 8 && Data.Field[kingY + 1, kingX - 2].Type == 3 && Data.Field[kingY + 1, kingX - 2].isWhite == Data.isWhite) return true;
                if (kingY - 1 > 8 && Data.Field[kingY - 1, kingX - 2].Type == 3 && Data.Field[kingY - 1, kingX - 2].isWhite == Data.isWhite) return true;
            }
            if (kingX + 2 < 8)
            {
                if (kingY + 1 < 8 && Data.Field[kingY + 1, kingX + 2].Type == 3 && Data.Field[kingY + 1, kingX + 2].isWhite == Data.isWhite) return true;
                if (kingY - 1 > 8 && Data.Field[kingY - 1, kingX + 2].Type == 3 && Data.Field[kingY - 1, kingX + 2].isWhite == Data.isWhite) return true;
            }
            return false;
        }
        private static bool CheckRook(int kingX, int kingY)
        {
            for (int i = kingX; i < 8; i++)
            {
                if (Data.Field[kingY, i].Type == 2 || Data.Field[kingY, i].Type == 5 && Data.Field[kingY, i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY, i].Type != 0 && i != kingX) break;
            }
            for (int i = kingX; i > -1; i--)
            {
                if (Data.Field[kingY, i].Type == 2 || Data.Field[kingY, i].Type == 5 && Data.Field[kingY, i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY, i].Type != 0 && i != kingX) break;
            }
            for (int i = kingY; i < 8; i++)
            {
                if ((Data.Field[i, kingX].Type == 2 || Data.Field[i, kingX].Type == 5) && Data.Field[i, kingX].isWhite == Data.isWhite) return true;
                else if (Data.Field[i, kingX].Type != 0 && i != kingY) break;
            }
            for (int i = kingY; i > 8; i--)
            {
                if ((Data.Field[i, kingX].Type == 2  || Data.Field[i,kingX].Type==5) && Data.Field[i, kingX].isWhite == Data.isWhite) return true;
                else if (Data.Field[i, kingX].Type != 0 && i != kingY) break;
            }
            return false;
        }
        private static bool CheckBishop(int kingX, int kingY)
        {
            for (int i = 1; kingX+i < 8 && kingY + i < 8; i++)
            {
                if ((Data.Field[kingY + i, kingX + i].Type == 4 || Data.Field[kingY + i, kingX + i].Type == 5) && Data.Field[kingY + i, kingX + i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY + i, kingX + i].Type != 0) break; 
            }
            for (int i = 1; kingX+i < 8 && kingY - i > -1; i++)
            {
                if ((Data.Field[kingY - i, kingX + i].Type == 4 || Data.Field[kingY - i, kingX + i].Type == 5) && Data.Field[kingY - i, kingX + i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY - i, kingX + i].Type != 0) break; 
            }
            for (int i = 1; kingX-i > -1 && kingY - i > -1; i++)
            {
                if ((Data.Field[kingY - i, kingX - i].Type == 4 || Data.Field[kingY - i, kingX - i].Type == 5) && Data.Field[kingY - i, kingX - i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY - i, kingX - i].Type != 0) break; 
            }
            for (int i = 1; kingX-i > -1 && kingY + i < 8; i++)
            {
                if ((Data.Field[kingY + i, kingX - i].Type == 4 || Data.Field[kingY + i, kingX - i].Type == 5) && Data.Field[kingY + i, kingX - i].isWhite == Data.isWhite) return true;
                else if (Data.Field[kingY + i, kingX - i].Type != 0) break; 
            }
            return false;
        }
        private static bool CheckPesant(int kingX, int kingY)
        {
            if (Data.isWhite)
            {
                if (kingX + 1 < 8 && kingY + 1 < 8 && Data.Field[kingY + 1, kingX + 1].Type == 1 && Data.Field[kingY + 1, kingX + 1].isWhite == Data.isWhite) return true; 
                if (kingX - 1 > -1 && kingY + 1 < 8 && Data.Field[kingY + 1, kingX - 1].Type == 1 && Data.Field[kingY + 1, kingX - 1].isWhite == Data.isWhite) return true; 
            }
            else
            {
                if (kingX + 1 < 8 && kingY - 1 > -1 && Data.Field[kingY - 1, kingX + 1].Type == 1 && Data.Field[kingY - 1, kingX + 1].isWhite == Data.isWhite) return true; 
                if (kingX - 1 > -1 && kingY - 1 > -1 && Data.Field[kingY - 1, kingX - 1].Type == 1 && Data.Field[kingY - 1, kingX - 1].isWhite == Data.isWhite) return true; 
            }
            return false;
        }
        public static bool CzechCheck(int kingX, int kingY) => CheckRook(kingX, kingY) || CheckBishop(kingX, kingY) || CheckHonse(kingX, kingY) || CheckPesant(kingX, kingY);
        public static bool CzechMate(int kingX, int kingY, int CheckerX, int CheckerY)
        {
            List<int[]> moves =  Babuk.Karoly.AllowedMoves(kingY, kingX);
            int[] tempIndex = new int[] { Data.selectedIndex[0], Data.selectedIndex[1] };
            Data.selectedIndex = GetKing();
            foreach (int[] coord in moves)
            {
                if (CheckMateStuff.CheckTempMove(coord[0], coord[1]))
                {
                    return false;
                }
            }
            Swap();
            Data.selectedIndex = tempIndex;
            if (MayBeheaded()) return false;
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int g = 0; g < 8; g++)
                    {
                        if (Data.Field[i, g].isWhite == Data.isWhite)
                        {
                            Data.selectedIndex = new int[] { i, g };
                            List<int[]> valids = Data.Field[i,g].GetValidMoves(g,i);
                            for (int v = 0; v < valids.Count; v++)
                            {
                                if (!CheckMateStuff.CheckTempMove(valids[v][0], valids[v][1])) return false;
                            }
                        }
                    }
                }
                Data.selectedIndex = tempIndex;
                Swap();
                return true;
            }
        }
        public static void Surrender()
        {
            MessageBox.Show(Data.isWhite ? "Fehér feladta!" : "Fekete feladta!");
            Application.Exit();
        }
        public static bool MayBeheaded() => CzechCheck(Data.Checker[1], Data.Checker[0]);
    }
}
