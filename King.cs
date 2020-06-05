using System;
using System.Drawing;

namespace chess
{
    class King : Figures
    {
        public King(Tuple<int, int, string> position, Image image) : base(position, image){}

        public override bool CanGo(int[,] table, int deltaX, int deltaY, int myX, int myY, int friendly, bool atk, Player enemy, Player Me, bool careful = false)
        {
            if (careful && ((Math.Abs(deltaX) == 1 && Math.Abs(deltaY) == 1) || (Math.Abs(deltaX) == 1 && deltaY == 0) || (deltaX == 0 && Math.Abs(deltaY) == 1)) &&
                table[myY + deltaY, myX + deltaX] != friendly && enemy.MakeTempMap(true, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me))
                return true;
            else
                return false;
        }
    }
}
