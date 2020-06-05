using System;
using System.Drawing;

namespace chess
{
    class Pawn : Figures
    {
        public Pawn(Tuple<int, int, string> position, Image image) : base(position, image) { }

        public override bool CanGo(int[,] table, int deltaX, int deltaY, int myX, int myY, int friendly, bool atk, Player enemy, Player Me, bool careful = false)
        {
            int direction = 1;
            if (Form1.cordData[myY, myX].Item3 == Position && table[myY, myX] != friendly)
                return false;
            if (friendly == 2)
                direction = -1;
            if (deltaY * direction > 2 || deltaY * direction < 1 || Math.Abs(deltaX) > 1)
                return false;
            else
            {
                if (MoveCount == 0 && deltaY * direction == 2 && deltaX == 0 && table[myY + deltaY - direction, myX] == 0)
                {
                    if (atk == true || (careful && enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me) == false))
                        return false;
                    else
                        return true;
                }
                else if (deltaY * direction == 1 && Math.Abs(deltaX) == 1 && table[myY + deltaY, myX + deltaX] != friendly)
                {
                    if (table[myY + deltaY, myX + deltaX] == 0)
                    {
                        for (int i = 0; i < enemy.figCount; i++)
                        {
                            if (careful && enemy.figures[i].Position == Form1.cordData[myY, myX + deltaX].Item3 && enemy.figures[i].IsAlive == true && enemy.figures[i].MoveCount == 1 && enemy.figures[i] is Pawn &&
                                enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY), friendly, enemy, Me)) // Vieta svarbi en passant ejimui                      
                                return true;
                        }
                        return false;
                    }
                    else if (table[myY + deltaY, myX + deltaX] != 0 && (!careful || (careful && enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))))
                        return true;
                    else
                        return false;
                }

                else if (careful && deltaY * direction == 1 && deltaX == 0 && table[myY + deltaY, myX + deltaX] == 0 && enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                    if (atk == true)
                        return false;
                    else
                        return true;
                else
                    return false;
            }
        }
    }
}
