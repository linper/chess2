using System;
using System.Drawing;


namespace chess
{
    abstract class Figures
    {
        public int MoveCount { get; set; }
        public string Position { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
        public Image Image { get; set; }

        public Figures(Tuple<int, int, string> position, Image image)
        {
            Position = position.Item3;
            X = position.Item1;
            Y = position.Item2;
            Image = image;
            IsAlive = true;
            MoveCount = 0;
        }

        /// <summary>
        /// grazina logine reiksme ar figura gali eiti i duopta pozicija
        /// </summary>
        /// <param name="table">zaideju figuru lentele be figuru tipu</param>
        /// <param name="deltaX"> x pokytis</param>
        /// <param name="deltaY"> y pokytis</param>
        /// <param name="myX"> figuros x koordinate</param>
        /// <param name="myY"> figuros y koordinate</param>
        /// <param name="friendly">koks skaicius table vaizduoja sava figura</param>
        /// <param name="atk">ar turi atakuoti (svarbutik pestininkams)</param>
        /// /// <param name="enemy">priesininko objektas</param>
        /// <returns></returns>
        abstract public bool CanGo(int[,] table, int deltaX, int deltaY, int myX, int myY, int friendly, bool atk, Player enemy, Player Me, bool carelul = false);

    }
}
