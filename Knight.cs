using System;
using System.Drawing;


namespace chess
{
    class Knight : Figures
    {
        public Knight(Tuple<int, int, string> position, Image image) : base(position, image) { }

        public override bool CanGo(int[,] table, int deltaX, int deltaY, int myX, int myY, int friendly, bool atk, Player enemy, Player Me, bool careful = false)
        {
            if (Form1.cordData[myY, myX].Item3 == Position && table[myY, myX] != friendly)
                return false;
            if ((!careful && ((Math.Abs(deltaY) == 2 && Math.Abs(deltaX) == 1 && table[myY + deltaY, myX + deltaX] != friendly) ||
                (Math.Abs(deltaY) == 1 && Math.Abs(deltaX) == 2 && table[myY + deltaY, myX + deltaX] != friendly))) ||
                (careful && (Math.Abs(deltaY) == 2 && Math.Abs(deltaX) == 1 && table[myY + deltaY, myX + deltaX] != friendly ||
                Math.Abs(deltaY) == 1 && Math.Abs(deltaX) == 2 && table[myY + deltaY, myX + deltaX] != friendly) && 
                enemy.MakeTempMap(false, new Point(myX, myY), new Point(myX + deltaX, myY + deltaY), new Point(myX + deltaX, myY + deltaY), friendly, enemy, Me)))
            {
                return true;
            }
            else
                return false;
        }
    }
}
