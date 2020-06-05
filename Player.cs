using System;
using System.Drawing;
using System.Collections.Generic;

namespace chess
{
    class Player
    {
        public string Name { get; set; }
        public int MovesCount { get; set; }
        public int SecondTimer { get; set; }
        public bool IsInDanger { get; private set; }
        public int LostCount { get; set; }
        public Figures[] figures { get; private set; }
        public int figCount { get; private set; }
        public List<Figures> Castle { get; set; }
        //public Figures Castle { get; set; }
        public List<Tuple<int, int, string>> CastlingLoc { get; set; }
        //public Tuple<int, int, string> CastlingLoc { get; set; }

        public Player(string name, string positionData, string imageData)
        {
            Name = name;
            MovesCount = 0;
            SecondTimer = 0;
            IsInDanger = false;
            figCount = 0;
            LostCount = 0;
            figures = new Figures[24];
            SetToStartingPositions(positionData, imageData);
            Castle = new List<Figures>();
            CastlingLoc = new List<Tuple<int, int, string>>();
        }

        private void SetToStartingPositions(string positionData, string imageData)
        {
            string[] Pparts = positionData.Split(',');
            string[] Iparts = imageData.Split(',');
            for (int i = 0; i < Pparts.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        SetFig(new King(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[0])));
                        break;
                    case 1:
                        SetFig(new Queen(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[1])));
                        break;
                    case 2:
                    case 3:
                        SetFig(new Bishop(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[2])));
                        break;
                    case 4:
                    case 5:
                        SetFig(new Knight(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[3])));
                        break;
                    case 6:
                    case 7:
                        SetFig(new Rock(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[4])));
                        break;
                    case int n when (n > 7 && n < 16):
                        SetFig(new Pawn(GetFullLocation(Pparts[i]), Image.FromFile(Iparts[5])));
                        break;
                }
            }
        }

        private Tuple<int, int, string> GetFullLocation(string data)
        {
            foreach (var v in Form1.cordData)
            {
                if (data == v.Item3)
                    return v;
            }
            return null;
        }

        public void SetFig(Figures f)
        {
            figures[figCount] = f;
            figCount++;
        }
        /// <summary>
        /// Padaro masyvo kopija
        /// </summary>
        /// <param name="a">duotas masyvas</param>
        /// <returns></returns>
        private int[,] MakeCopy(int[,] a)
        {
            int[,] arr = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arr[i, j] = a[i, j];
                }
            }
            return arr;
        }
        /// <summary>
        /// metodas grazina ar padarius ejima nebus shako
        /// </summary>
        /// <param name="startingL"></param>
        /// <param name="targetL"></param>
        /// <param name="EnemyL"></param>
        /// <param name="friendly"></param>
        /// <param name="enemyPlayer"></param>
        /// <param name="Me"></param>
        /// <returns></returns>
        public bool MakeTempMap(bool isking, Point startingL, Point targetL, Point EnemyL, int friendly, Player enemyPlayer, Player me)
        {
            int nonFriendly;
            if (friendly == 1)
                nonFriendly = 2;
            else
                nonFriendly = 1;
            string e = enemyPlayer.Name;
            int[,] st = new int[8,8];
            int[,] fm = MakeCopy(Form1.figMap);
            string position;
            fm[startingL.Y, startingL.X] = 0;
            fm[EnemyL.Y, EnemyL.X] = 0;
            fm[targetL.Y, targetL.X] = friendly;
            if (isking)
                position = Form1.cordData[targetL.Y, targetL.X].Item3;
            else
                position = me.figures[0].Position;
            st = CheckMap(position, fm, st, nonFriendly, enemyPlayer);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (st[j, i] == nonFriendly)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// grazina matrica kurioje vaizduojama ar karaliams sachas
        /// </summary>
        /// <param name="table">figuru matrica</param>
        /// <param name="starting"></param>
        /// <param name="friendly"></param>
        /// <param name="enemyPlayer"></param>
        /// <returns></returns>
        public int[,] CheckMap(string Position, int[,] table, int[,] starting, int friendly, Player enemyPlayer)
        {
            string s = enemyPlayer.Name;
            int kingX = 0;
            int kingY = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Form1.cordData[i, j].Item3 == Position)
                    {
                        kingX = j;
                        kingY = i;
                        i = 8;
                        break;
                    }
                }
            }
            for (int k = 0; k < figCount; k++)
            {
                if (figures[k].IsAlive)
                {
                    CountDelta(out int x, out int y, kingX, kingY, figures[k].Position);
                    if (figures[k].CanGo(table, x, y, kingX - x, kingY - y, friendly, true, enemyPlayer, this) == true)
                    {
                        starting[kingY, kingX] = friendly;
                        enemyPlayer.IsInDanger = true;
                        return starting;
                    }
                }
            }
            enemyPlayer.IsInDanger = false;
            return starting;
        }
        /// <summary>
        /// sudaro karaliaus galmu ejimu matrica
        /// </summary>
        /// <param name="f"></param>
        /// <param name="table"></param>
        /// <param name="basicKingMoves"></param>
        /// <param name="friendly"></param>
        /// <param name="enemyPlayer"></param>
        /// <returns></returns>
        public int[,] KingsMoves(King f, int[,] table, int[,] basicKingMoves, int friendly, Player enemyPlayer)
        {
            int kingX = 0;
            int kingY = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Form1.cordData[i, j].Item3 == f.Position)
                    {
                        kingX = j;
                        kingY = i;
                        i = 8;
                        break;
                    }
                }
            }
            int king = table[kingY, kingX];
            table[kingY, kingX] = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (basicKingMoves[i, j] == 1)
                        for (int k = 0; k < figCount; k++)
                        {
                            if (figures[k].IsAlive)
                            {
                                CountDelta(out int x, out int y, j, i, figures[k].Position);
                                if (figures[k].CanGo(table, x, y, j - x, i - y, friendly, true, enemyPlayer, this) == true)
                                {
                                    basicKingMoves[i, j] = 0;
                                    break;
                                }
                                else
                                    basicKingMoves[i, j] = 1;
                            }
                        }
                }
            }
            if(f.MoveCount == 0)
            {
                if (enemyPlayer.figures[6].MoveCount == 0 && enemyPlayer.figures[6].IsAlive)
                {
                    basicKingMoves = Castling(f, enemyPlayer.figures[6] as Rock, table, basicKingMoves, friendly, enemyPlayer);
                }
                if (enemyPlayer.figures[7].MoveCount == 0 && enemyPlayer.figures[7].IsAlive)
                {
                    basicKingMoves = Castling(f, enemyPlayer.figures[7] as Rock, table, basicKingMoves, friendly, enemyPlayer);
                }
            }
            table[kingY, kingX] = king;
            return basicKingMoves;
        }
        /// <summary>
        /// tikrina ar imanomas castling spec ejimas
        /// </summary>
        /// <param name="K">karaliuss skirtas kastlinimui</param>
        /// <param name="R">bokstas skirtas kastlinimui</param>
        /// <param name="table"></param>
        /// <param name="basicKingMoves"></param>
        /// <param name="friendly"></param>
        /// <param name="enemyPlayer"></param>
        /// <returns></returns>
        private int[,] Castling(King K, Rock R, int[,] table, int[,] basicKingMoves, int friendly, Player enemyPlayer)
        {
            int Y = 0;
            int rx = 0;
            int kx = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (K.Position == Form1.cordData[i, j].Item3)
                    {
                        Y = i;
                        kx = j;
                    }
                    if (R.Position == Form1.cordData[i, j].Item3)
                        rx = j;
                }
            }
            bool clear = true;
            bool threat = false;
            if (rx < kx)
            {
                for (int i = kx; i > rx; i--)
                {
                    if (table[Y, i] != 0)
                        clear = false;
                }
                if (clear)
                {
                    for (int i = kx; i >= kx - 2; i--)
                    {
                        for (int k = 0; k < figCount; k++)
                        {
                            if (figures[k].IsAlive)
                            {
                                CountDelta(out int x, out int y, i, Y, figures[k].Position);
                                if (figures[k].CanGo(table, x, y, i - x, Y - y, friendly, true, enemyPlayer, this) == true)
                                {
                                    threat = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (threat == false)
                    {
                        basicKingMoves[Y, kx - 2] = 1;
                        enemyPlayer.Castle.Add(R);
                        enemyPlayer.CastlingLoc.Add(new Tuple<int, int, string>(R.X + 165, R.Y, R.Position.Replace('A', 'D')));
                    }
                    else
                        threat = false;
                }
            }
            else
            {
                for (int i = kx; i < rx; i++)
                {
                    if (table[Y, i] != 0)
                        clear = false;
                }
                if (clear)
                {
                    for (int i = kx; i < rx; i++)
                    {
                        for (int k = 0; k < figCount; k++)
                        {
                            if (figures[k].IsAlive)
                            {
                                CountDelta(out int x, out int y, i, Y, figures[k].Position);
                                if (figures[k].CanGo(table, x, y, i - x, Y - y, friendly, true, enemyPlayer, this) == true)
                                {
                                    threat = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (threat == false)
                    {
                        basicKingMoves[Y, kx + 2] = 1;
                        enemyPlayer.Castle.Add(R);
                        enemyPlayer.CastlingLoc.Add(new Tuple<int, int, string>(R.X - 110, R.Y, R.Position.Replace('H', 'F')));
                    }
                    else
                        threat = false;
                }
            }
            return basicKingMoves;
        }

        /// <summary>
        /// metodas sudaro lentele kur figura gali judeti
        /// </summary>
        /// <param name="f"></param>
        /// <param name="table">figuru lentele : 1; 2; 0</param>
        /// <param name="friendly"></param>
        /// <returns></returns>
        public int[,] GetPossibleMoves(Figures f, int[,] table, int friendly, Player enemyPlayer, out bool possible)
        {
            possible = false;
            int[,] moves = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (table[i, j] != friendly)
                    {
                        CountDelta(out int x, out int y, j, i, f.Position);
                        if(table[i, j] != 0)
                        {
                            if (f.CanGo(table, x, y, j - x, i - y, friendly, true, enemyPlayer, this, true) == true)
                            {
                                moves[i, j] = 1;
                                possible = true;
                            }
                            else
                                moves[i, j] = 0;
                        }
                        else
                        {
                            if (f.CanGo(table, x, y, j - x, i - y, friendly, false, enemyPlayer, this, true) == true)
                            {
                                moves[i, j] = 1;
                                possible = true;
                            }
                            else
                                moves[i, j] = 0;
                        }
                    }
                }
            }
            return moves;
        }

        private void CountDelta(out int x, out int y, int targetX, int targetY, string position)
        {
            int I = 0;
            int J = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Form1.cordData[i, j].Item3 == position)
                    {
                        J = j;
                        I = i;
                        i = 8;
                        break;
                    }
                }
            }
            x = targetX - J;
            y = targetY - I;
        }
    }
}
