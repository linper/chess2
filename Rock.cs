using System;
using System.Drawing;


namespace chess
{
    class Rock : Figures
    {
        public Rock(Tuple<int, int, string> position, Image image) : base(position, image) { }

        public override bool CanGo(int[,] table, int deltaX, int deltaY, int myX, int myY, int friendly, bool atk, Player enemy, Player Me, bool careful = false)
        {
            int eCount = 0;
            if (deltaX == 0 && deltaY == 0)
                return false;
            if (Form1.cordData[myY, myX].Item3 == Position && table[myY, myX] != friendly)
                return false;
            if (deltaX == 0 && deltaY != 0 && table[myY + deltaY, myX] != friendly)     // palei y asi
            {
                if (deltaY < 0)
                {
                    for (int i = myY - 1; i >= myY + deltaY; i--) // ^
                    {
                        if (eCount > 0)
                            return false;
                        if (careful && !enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                            return false;
                        if (table[i, myX] != 0 && table[i, myX] != friendly)
                            eCount++;
                        if (table[i, myX] == friendly)
                            return false;
                    }
                    return true;
                }
                else
                {
                    for (int i = myY + 1; i <= myY + deltaY; i++) // v
                    {
                        if (eCount > 0)
                            return false;
                        if (careful && !enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                            return false;
                        if (table[i, myX] != 0 && table[i, myX] != friendly)
                            eCount++;
                        if (table[i, myX] == friendly)
                            return false;
                    }
                    return true;
                }
            }
            else if (deltaX != 0 && deltaY == 0 && table[myY, myX + deltaX] != friendly) //palei x asi
            {
                if (deltaX < 0)
                {
                    for (int i = myX - 1; i >= myX + deltaX; i--) // <-
                    {
                        if (eCount > 0)
                            return false;
                        if (careful && !enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                            return false;
                        if (table[myY, i] != 0 && table[myY, i] != friendly)
                            eCount++;
                        if (table[myY, i] == friendly)
                            return false;
                    }
                    return true;
                }
                else
                {
                    for (int i = myX + 1; i <= myX + deltaX; i++) // ->
                    {
                        if (eCount > 0)
                            return false;
                        if (careful && !enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                            return false;
                        if (table[myY, i] != 0 && table[myY, i] != friendly)
                            eCount++;
                        if (table[myY, i] == friendly)
                            return false;
                    }
                    return true;
                }
            }
            else
                return false;
        }
    }
}
