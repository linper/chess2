//Linas Perkauskas IFF 8/9 2019/01/10
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace chess
{
    public partial class Form1 : Form
    {
        public int WhichPlayer { get; set; }
        public bool IsStarted { get; set; }
        public bool IsStoped { get; set; }
        public bool Draw { get; set; }

        readonly double TimeLimit;
        Form4 f4;
        Timer t = new Timer();
        Timer moveTimer = new Timer();
        Timer promTimer = new Timer();
        public static Tuple<int, int, string>[,] cordData = new Tuple<int, int, string>[8, 8];
        public static int[,] figMap = new int[8, 8];
        int[,] map = new int[8, 8];
        public static int[,] check = new int[8, 8];
        Bitmap btm;
        Graphics g;
        Figures objFigure;
        Figures targetObj;
        Figures castlingObj;
        int TempSecondCount = 0;
        Tuple<int, int, string> objLocation = null;
        Tuple<int, int, string> targetLocation = null;
        Tuple<int, int, string> castlingtargetLocation = null;
        List<Tuple<int[,], int, int>> TFRL = new List<Tuple<int[,], int, int>>(); //Three-fold repetition list
        int TFRpivot = 0;
        Player player1;
        Player player2;
        int stepX;
        int stepY;
        int cStepX;
        int moveTimerCount;
        int FiftyMoveRuleCount = 0;
        const string whitePositions = "E8,D8,C8,F8,B8,G8,A8,H8,A7,B7,C7,D7,E7,F7,G7,H7";
        const string blackPositions = "E1,D1,C1,F1,B1,G1,A1,H1,A2,B2,C2,D2,E2,F2,G2,H2";
        const string blackImages =
            "..\\..\\Figures\\BKing.png," +
            "..\\..\\Figures\\BQueen.png," +
            "..\\..\\Figures\\bBishop.png," +
            "..\\..\\Figures\\BKnight.png," +
            "..\\..\\Figures\\BRock.png," +
            "..\\..\\Figures\\BPawn.png";
        const string whiteImages =
            "..\\..\\Figures\\WKing.png," +
            "..\\..\\Figures\\WQueen.png," +
            "..\\..\\Figures\\WBishop.png," +
            "..\\..\\Figures\\WKnight.png," +
            "..\\..\\Figures\\WRock.png," +
            "..\\..\\Figures\\WPawn.png";

        public Form1(string p1, string p2, double timeGiven)
        { 
            TimeLimit = timeGiven;
            IsStarted = false;
            IsStoped = false;
            InitializeComponent();
            DrawBoard();
            t.Interval = 1000;
            t.Tick += T_Tick;
            moveTimer.Interval = 100;
            moveTimer.Tick += MoveTimer_Tick;
            promTimer.Interval = 100;
            promTimer.Tick += PromTimer_Tick;
            player1 = new Player(p1, whitePositions, whiteImages);
            player2 = new Player(p2, blackPositions, blackImages);
            WhichPlayer = 1;
            MakeStartingFigMap();
            PlayerW.Text = p1;
            PlayerB.Text = p2;
            Draw = false;
        }
        /// <summary>
        /// Sudaro pradine zaideju figuru buvimo vietu lentoje kv. matrica
        /// </summary>
        private void MakeStartingFigMap()
        {
            for (int i = 0; i < 8; i++)    //eilutes
            {
                for (int j = 0; j < 8; j++)//stulpeliai
                {
                    if (i == 0 || i == 1)
                        figMap[i, j] = 1;
                    else if (i == 6 || i == 7)
                        figMap[i, j] = 2;
                    else
                        figMap[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// grazina 8 x 8 nuline matrica
        /// </summary>
        /// <returns></returns>
        private int[,] MakeZero()
        {
            int[,] multidimArray = new int[8, 8];
            for (int i = 0; i < 8; i++)    //eilutes
            {
                for (int j = 0; j < 8; j++)//stulpeliai
                {
                    multidimArray[i, j] = 0;
                }
            }
            return multidimArray;
        }
        /// <summary>
        /// Tikrina ar matricojeyra tik 0
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private bool IsClear(int[,] array)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (array[j, i] != 0)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Laikinas metodas kuris isveda i konsole zaideju figuru pozicicas per kvadratine matrica
        /// </summary>
        private void ShowMap(int[,] array)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------");
        }
        /// <summary>
        /// pakeicia figMap jai figura pakeicia pozicija
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="target"></param>
        /// <param name="friendlyNum"></param>
        private void ChangeFigMap(string obj, string target, int friendlyNum, string enemy = "")
        {
            int x = 0;
            int y = 0;
            if(castlingObj != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (cordData[i, j].Item3 == castlingObj.Position)
                        {
                            x = j;
                            y = i;
                            i = 8;
                            break;
                        }
                    }
                }
                figMap[y, x] = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (cordData[i, j].Item3 == castlingtargetLocation.Item3)
                        {
                            x = j;
                            y = i;
                            i = 8;
                            break;
                        }
                    }
                }
                figMap[y, x] = friendlyNum;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cordData[i, j].Item3 == obj)
                    {
                        x = j;
                        y = i;
                        i = 8;
                        break;
                    }
                }
            }
            figMap[y, x] = 0;
            if(enemy != "")
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (cordData[i, j].Item3 == enemy)
                        {
                            x = j;
                            y = i;
                            i = 8;
                            break;
                        }
                    }
                }
                figMap[y, x] = 0;
            }           
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cordData[i, j].Item3 == target)
                    {
                        x = j;
                        y = i;
                        i = 8;
                        break;
                    }
                }
            }
            figMap[y, x] = friendlyNum;
        }
        /// <summary>
        /// pradeda vykdyti ejima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoButtton_Click(object sender, EventArgs e)
        {
            if (IsStarted == true && IsStoped == false && objLocation != null && targetLocation != null) // 
            {
                if (targetObj != null)
                    FiftyMoveRuleCount = 0;
                if (WhichPlayer % 2 == 1)
                {
                    t.Stop();                   
                    player1.SecondTimer = TempSecondCount;
                    if (objFigure is Pawn)
                    {
                        FiftyMoveRuleCount = 0;
                        if(TFRL != null)
                            TFRpivot = TFRL.Count;
                    }    
                    if (player1.SecondTimer > TimeLimit * 60)
                        EndGame(player2, false, "Time's up");
                    if (targetObj != null)
                        ChangeFigMap(objLocation.Item3, targetLocation.Item3, 1, targetObj.Position);
                    else
                        ChangeFigMap(objLocation.Item3, targetLocation.Item3, 1);
                    map = MakeZero();                
                    MakeMove(player1, objLocation, targetLocation);
                    player1.Castle.Clear();
                    player1.CastlingLoc.Clear();
                    player1.MovesCount++;
                    TempSecondCount = player2.SecondTimer;
                    MovesText.Clear();
                    MovesText.AppendText(player2.MovesCount.ToString());
                    PlayerW.BackColor = Color.DarkGray;
                    PlayerB.BackColor = Color.Gray;
                    t.Start();
                }
                else
                {
                    t.Stop();
                    player2.SecondTimer = TempSecondCount;
                    if (objFigure is Pawn)
                    {
                        FiftyMoveRuleCount = 0;
                        if (TFRL != null)
                            TFRpivot = TFRL.Count;
                    }
                    if (player2.SecondTimer > TimeLimit * 60)
                        EndGame(player1, false, "Time's up");
                    if (targetObj != null)
                        ChangeFigMap(objLocation.Item3, targetLocation.Item3, 2, targetObj.Position);
                    else
                        ChangeFigMap(objLocation.Item3, targetLocation.Item3, 2);
                    map = MakeZero();
                    MakeMove(player2, objLocation, targetLocation);
                    player2.Castle.Clear();
                    player2.CastlingLoc.Clear();

                    player2.MovesCount++;
                    TempSecondCount = player1.SecondTimer;
                    MovesText.Clear();
                    MovesText.AppendText(player1.MovesCount.ToString());
                    PlayerB.BackColor = Color.DarkGray;
                    PlayerW.BackColor = Color.Gray;
                    t.Start();
                }
                TFR();
                if (FiftyMoveRuleCount >= 50)
                    EndGame(player1, true, "Fifty-move rule");
                if (player1.figCount - player1.LostCount + player2.figCount - player2.LostCount <= 4)
                    InsuffitientMaterial();
                check = MakeZero();
                check = player1.CheckMap(player2.figures[0].Position, figMap, check, 1, player2);
                check = player2.CheckMap(player1.figures[0].Position, figMap, check, 2, player1);
                WhichPlayer++;
                messageBox.Clear();
                targetLocation = null;
                objLocation = null;
                FiftyMoveRuleCount++;
                if (Draw)
                {
                    Form5 f5;
                    this.Enabled = false;
                    f5 = new Form5(this, "aDraw", "Do you agree to draw the game?");
                    f5.Show();
                }
                Draw = false;
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            TempSecondCount++;
            timeText.Clear();
            timeText.AppendText((TempSecondCount / 3600).ToString() + "h " + ((TempSecondCount / 60) % 60).ToString() + "min " + (TempSecondCount % 60).ToString() + "s");
        }

        private void MakeMove(Player p, Tuple<int, int, string> objLoc, Tuple<int, int, string> targetLoc)
        {
            moveTimerCount = 0;
            stepX = (targetLoc.Item1 - objLocation.Item1) / 11;
            stepY = (targetLoc.Item2 - objLocation.Item2) / 11;
            if(castlingObj != null)
                cStepX = (castlingtargetLocation.Item1 - castlingObj.X) / 11;
            moveTimer.Start();
            t.Stop();
            objFigure.Position = targetLoc.Item3;
            objFigure.MoveCount++;
            if (castlingObj != null)
            {
                castlingObj.MoveCount++;
                castlingObj.Position = castlingtargetLocation.Item3;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawFigures(player1, e);
            DrawFigures(player2, e);
            DrawMoves(IsClear(check), e);
            if (moveTimerCount >= 9)
            {


                if (targetObj != null && moveTimerCount == 9)
                {
                    targetObj.IsAlive = false;
                    targetObj = null;
                    TFRpivot = TFRL.Count;
                    if (WhichPlayer % 2 == 1)
                        player1.LostCount++;
                    else
                        player2.LostCount++;
                }
                if (moveTimerCount >= 10)
                {
                    DrawMoves(IsClear(check), e);
                    moveTimerCount = 0;
                    moveTimer.Stop();
                    if (objFigure is Pawn)
                        IsPromotion();
                    if (WhichPlayer % 2 == 1)
                        MateEndGame(player2, player1, 1);
                    else
                        MateEndGame(player1, player2, 2);                
                    t.Start();
                }
            }
        }
        
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            objFigure.X += stepX;
            objFigure.Y += stepY;
            if(castlingObj != null)
            {
                castlingObj.X += cStepX;
            }         
            Refresh();
            moveTimerCount++;
        }

        private void ressetButton_Click(object sender, EventArgs e)
        {
            Form5 f5;
            this.Enabled = false;
            f5 = new Form5(this, "reset", "Do you really want to reset the game?");
            f5.Show();
        }

        private void PCButton_Click(object sender, EventArgs e)
        {
            if (IsStarted == true)
            {
                if (IsStoped == true)
                {
                    IsStoped = false;
                    t.Start();
                }
                else
                {
                    IsStoped = true;
                    t.Stop();
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (IsStarted == false)
            {
                IsStarted = true;
                MovesText.Clear();
                MovesText.AppendText(player1.MovesCount.ToString());
                PlayerW.BackColor = Color.Gray;
                t.Start();
            }
        }
        /// <summary>
        /// Nupiesia lenta
        /// </summary>
        private void DrawBoard()
        {
            int Edge = canvas.Width;
            int squareEdge = (Edge - 40) / 8;
            int letterNum = 65;

            btm = new Bitmap(Edge, Edge);
            g = Graphics.FromImage(btm);

            Brush brB = new SolidBrush(Color.Black);
            Brush brG = new SolidBrush(Color.Gray);
            Brush brW = new SolidBrush(Color.White);
            g.FillRectangle(brG, 0, 0, Edge, Edge);
            g.FillRectangle(brW, 20, 20, Edge - 40, Edge - 40);

            for (int i = 0; i < 8; i++)
            {
                if (i == 7)
                    letterNum = 65;
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 1 && j % 2 == 0)
                        g.FillRectangle(brB, i * squareEdge + 20, j * squareEdge + 20, squareEdge, squareEdge);
                    if (i % 2 == 0 && j % 2 == 1)
                        g.FillRectangle(brB, i * squareEdge + 20, j * squareEdge + 20, squareEdge, squareEdge);

                    if (i == 1)
                        g.DrawString(((char)letterNum++).ToString(), new Font("Arial", 12), brW, new Point(12 + squareEdge / 2 + j * squareEdge, 1));
                    if (i == 7)
                        g.DrawString(((char)letterNum++).ToString(), new Font("Arial", 12), brW, new Point(12 + squareEdge / 2 + j * squareEdge, 461));
                    if (j == 0)
                    {
                        g.DrawString((8 - i).ToString(), new Font("Arial", 12), brW, new Point(2, 39 + i * squareEdge));
                        g.DrawString((8 - i).ToString(), new Font("Arial", 12), brW, new Point(461, 39 + i * squareEdge));
                    }
                }
            }
            GetCordinates(squareEdge, 20);
            canvas.Image = btm;
            g.Dispose();
        }
        /// <summary>
        /// Nupiesia figuras pradindse positcijose
        /// </summary>
        /// <param name="p"></param>
        private void DrawFigures(Player p, PaintEventArgs e)
        {
            int Edge = canvas.Width;
            int halfSquareEdge = (canvas.Width - 40) / 16;
            for (int i = 0; i < p.figCount; i++)
            {
                if (p.figures[i].IsAlive)
                    e.Graphics.DrawImage(p.figures[i].Image, p.figures[i].X - halfSquareEdge, p.figures[i].Y - halfSquareEdge);
            }
        }
        /// <summary>
        /// nupiesia zalius kvadratus su galimais ejimais
        /// </summary>
        /// <param name="e"></param>
        private void DrawMoves(bool ch, PaintEventArgs e)
        {
            Pen p1 = new Pen(Color.GreenYellow, 3);
            Pen p2 = new Pen(Color.Crimson, 3);
            Pen p3 = new Pen(Color.Blue, 3);
            int Edge = (canvas.Width - 40) / 8;         
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i, j] == 1)
                    {
                        e.Graphics.DrawRectangle(p1, cordData[i, j].Item1 - Edge / 2, cordData[i, j].Item2 - Edge / 2, Edge, Edge);
                    }
                    if (check[i, j] != 0 && !ch)
                    {
                        e.Graphics.DrawRectangle(p2, cordData[i, j].Item1 - Edge / 2, cordData[i, j].Item2 - Edge / 2, Edge, Edge);
                    }
                }
            }
            if (objFigure != null && !moveTimer.Enabled)
                e.Graphics.DrawRectangle(p3, objFigure.X - Edge / 2, objFigure.Y - Edge / 2, Edge, Edge);
        }
        /// <summary>
        /// suskirsto koordinates i kvadratus formuoja Tuple
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="border"></param>
        private void GetCordinates(int edge, int border)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tuple<int, int, string> t = new Tuple<int, int, string>(border + edge / 2 + j * edge, border + edge / 2 + i * edge, ((char)(65 + j)).ToString() + (8 - i).ToString());
                    cordData[i, j] = t;
                }
            }
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            if (moveTimer.Enabled == false && !IsStoped)
            {
                Player pl;
                if (WhichPlayer % 2 == 1)
                    pl = player1;
                else
                    pl = player2;
                MouseEventArgs loc = (MouseEventArgs)e;
                Point cord = loc.Location;
                if (cord.X > 20 && cord.Y > 20 && cord.X < 460 && cord.Y < 460 && IsStarted == true)
                {
                    var square = GetSquare(cord.X, cord.Y);
                    if (ISFriendly(WhichPlayer, square.Item3.ToString()) == true)
                    {
                        if (objLocation != null)
                            messageBox.Clear();
                        objLocation = square;
                        objFigure = FindFriendly(WhichPlayer, square.Item3.ToString());
                        messageBox.Text = square.Item3 + " -> ";
                        bool possible;
                        if (WhichPlayer % 2 == 1)
                        {
                            player1.Castle.Clear();
                            player1.CastlingLoc.Clear();
                            map = player1.GetPossibleMoves(objFigure, figMap, 1, player2, out possible);
                            if (objFigure is King)
                                map = player2.KingsMoves(objFigure as King, figMap, map, 2, player1);
                        }
                        else
                        {
                            player2.Castle.Clear();
                            player2.CastlingLoc.Clear();
                            map = player2.GetPossibleMoves(objFigure, figMap, 2, player1, out possible);
                            if (objFigure is King)
                                map = player1.KingsMoves(objFigure as King, figMap, map, 1, player2);
                        }
                        Refresh();
                    }
                    if (ISFriendly(WhichPlayer, square.Item3.ToString()) == false && objLocation != null && CanMove(square.Item3) == true)
                    {
                        targetObj = null;
                        if (targetLocation != null)
                            messageBox.Text = messageBox.Text.Remove(messageBox.Text.LastIndexOf('>') + 1) + " ";
                        targetLocation = square;
                        messageBox.AppendText(square.Item3);
                        if (WhichPlayer % 2 == 1)
                        {
                            if (ISFriendly(2, square.Item3.ToString()))
                                targetObj = FindFriendly(2, targetLocation.Item3);
                            if (targetObj == null && ISFriendly(1, square.Item3.ToString()) == false && objFigure is Pawn)
                            {
                                Figures enemy;
                                var sq = GetSquare(square.Item1, square.Item2 - 55);
                                if (ISFriendly(2, sq.Item3))
                                {
                                    enemy = FindFriendly(2, sq.Item3);
                                    if (enemy is Pawn && enemy.MoveCount == 1)
                                        targetObj = enemy;
                                }
                            }
                        }
                        else
                        {
                            if (ISFriendly(1, square.Item3.ToString()))
                                targetObj = FindFriendly(1, targetLocation.Item3);
                            if (targetObj == null && ISFriendly(2, square.Item3.ToString()) == false && objFigure is Pawn)
                            {
                                Figures enemy;
                                var sq = GetSquare(square.Item1, square.Item2 + 55);
                                if (ISFriendly(1, sq.Item3))
                                {
                                    enemy = FindFriendly(1, sq.Item3);
                                    if (enemy is Pawn && enemy.MoveCount == 1)
                                        targetObj = enemy;
                                }
                            }
                        }
                        if (pl.Castle.Count > 0 && pl.CastlingLoc.Count > 0)
                        {
                            
                            if(targetLocation.Item3.Contains("G") || targetLocation.Item3.Contains("C"))
                            {
                                
                                if (targetLocation.Item3.Contains("G"))
                                {
                                    foreach(var v in pl.CastlingLoc)
                                    {
                                        if (v.Item3.Contains("F"))
                                            castlingtargetLocation = v;
                                    }
                                    foreach(Figures f in pl.Castle)
                                    {
                                        if (f.Position.Contains("H"))
                                            castlingObj = f;
                                    }
                                }
                                else
                                {
                                    foreach (var v in pl.CastlingLoc)
                                    {
                                        if (v.Item3.Contains("D"))
                                            castlingtargetLocation = v;
                                    }
                                    foreach (Figures f in pl.Castle)
                                    {
                                        if (f.Position.Contains("A"))
                                            castlingObj = f;
                                    }
                                }
                            }
                            else
                            {
                                castlingObj = null;
                                castlingtargetLocation = null;
                                player1.Castle.Clear();
                                player1.CastlingLoc.Clear();
                                player2.Castle.Clear();
                                player2.CastlingLoc.Clear();
                            }
                        }
                        else
                        {
                            castlingObj = null;
                            castlingtargetLocation = null;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// ar figura gali eiti i duota kvadrata
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool CanMove(string s)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cordData[i, j].Item3 == s)
                    {
                        if (map[i, j] == 1)
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// surabda sava figura langelyje
        /// </summary>
        /// <param name="playerNum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private Figures FindFriendly(int playerNum, string data)
        {
            Player player;
            if (playerNum % 2 == 1)
                player = player1;
            else
                player = player2;

            for (int i = 0; i < player.figCount; i++)
            {
                if (player.figures[i].Position == data && player.figures[i].IsAlive == true)
                {
                    return player.figures[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Randa ar yra sava figura
        /// </summary>
        /// <param name="playerNum">kuris zaidejas (1 ar 2)</param>
        /// <param name="data">ieskomas kvadratas (A4, D5, C1...)</param>
        /// <returns></returns>
        private bool ISFriendly(int playerNum, string data)
        {
            int found = 0;
            Player player;
            if (playerNum % 2 == 1)
                player = player1;
            else
                player = player2;

            for (int i = 0; i < player.figCount; i++)
            {
                if (player.figures[i].Position == data && player.figures[i].IsAlive == true)
                {
                    found++;
                }
            }
            if (found > 1)
                Console.WriteLine("Two figures in same position");
            return found == 1;
        }
        /// <summary>
        /// Randa kuriame kvadrate yra paspausta
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Tuple<int, int, string> GetSquare(int x, int y)
        {
            int deltaX = 10000;
            int deltaY = 10000;
            int resultX = 0;
            int resultY = 0;
            for (int i = 0; i < 8; i++)
            {
                int n = Math.Abs(x - cordData[0, i].Item1);

                if (n < deltaX)
                {
                    deltaX = n;
                    if (i == 7)
                        resultX = i;
                }
                else
                {
                    resultX = i - 1;
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                int m = Math.Abs(y - cordData[i, 0].Item2);

                if (m < deltaY)
                {
                    deltaY = m;
                    if (i == 7)
                        resultY = i;
                }
                else
                {
                    resultY = i - 1;
                    break;
                }
            }
            return cordData[resultY, resultX];
        }
        /// <summary>
        /// Patikrina ar galimas promotion spec ejimas
        /// </summary>
        private void IsPromotion()
        {
            if(WhichPlayer % 2 == 0)
            {
                if (objFigure.Y == 432)
                {
                    f4 = new Form4();
                    this.Enabled = false;
                    f4.Show();
                    promTimer.Start();
                }
            }
            else
            {
                if (objFigure.Y == 47)
                {
                    f4 = new Form4();
                    this.Enabled = false;
                    f4.Show();
                    promTimer.Start();
                }
            }
        }
        /// <summary>
        /// %vykdo promotion spec ejima
        /// </summary>
        /// <param name="num"></param>
        private void Promotion(int num)
        {
            if (WhichPlayer % 2 == 0)
            {
                switch (num)
                {
                    case 1:
                        player1.SetFig(new Rock(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\WRock.png")));
                        objFigure.IsAlive = false;    
                        break;
                    case 2:
                        player1.SetFig(new Knight(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\WKnight.png")));
                        objFigure.IsAlive = false;
                        break;
                    case 3:
                        player1.SetFig(new Bishop(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\WBishop.png")));
                        objFigure.IsAlive = false;
                        break;
                    case 4:
                        player1.SetFig(new Queen(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\WQueen.png")));
                        objFigure.IsAlive = false;
                        break;
                }
            }
            else
            {
                switch (num)
                {
                    case 1:
                        player2.SetFig(new Rock(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\BRock.png")));
                        objFigure.IsAlive = false;
                        break;
                    case 2:
                        player2.SetFig(new Knight(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\BKnight.png")));
                        objFigure.IsAlive = false;
                        break;
                    case 3:
                        player2.SetFig(new Bishop(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\bBishop.png")));
                        objFigure.IsAlive = false;
                        break;
                    case 4:
                        player2.SetFig(new Queen(new Tuple<int, int, string>(objFigure.X, objFigure.Y, objFigure.Position), Image.FromFile("..\\..\\Figures\\BQueen.png")));
                        objFigure.IsAlive = false;
                        break;
                }
            }
            check = MakeZero();
            check = player1.CheckMap(player2.figures[0].Position, figMap, check, 1, player2);
            check = player2.CheckMap(player1.figures[0].Position, figMap, check, 2, player1);
            Refresh();
        }

        private void PromTimer_Tick(object sender, EventArgs e)
        {
            if(f4.figMum != 0)
            {
                promTimer.Stop();
                f4.Hide();
                Promotion(f4.figMum);
                this.Enabled = true;
            }
        }
        /// <summary>
        /// metodas kuris sukuria rezultatu forma pasibaigus zaidimui
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="draw"></param>
        /// <param name="condition"></param>
        private void EndGame(Player winner, bool draw, string condition)
        {
            Form3 f3;
            if (draw)
            {
                switch (condition)
                {
                    case "Stalemate"://done + tested!
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Insuffitient material"://done + half tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Agreed"://done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Threefold repetition"://done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Fifty-move rule"://done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                }            
            }
            else
            {
                switch (condition)
                {
                    case "Checkmate"://done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Time's up": //done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                    case "Oponent resigned": //done + tested
                        f3 = new Form3(winner.Name, condition, draw, player1.Name, player2.Name, player1.SecondTimer, player2.SecondTimer, player1.LostCount, player2.LostCount, player1.MovesCount, player2.MovesCount);
                        f3.Show();
                        break;
                }
            }
            this.Enabled = false;
        }
        /// <summary>
        /// Tikrina ar galimi chachmate ar stalmate
        /// </summary>
        /// <param name="PL">zaidejas kuris taikosi i kita karaliu</param>
        /// <param name="pl">zaidejas i kurio karaliu taikomasi</param>
        /// <param name="friendly"></param>
        private void MateEndGame(Player PL, Player pl, int friendly)
        {
            bool possible = false;
            int[,] m;
            if (!IsClear(check))
            {
                for (int i = 0; i < pl.figCount; i++)
                {
                    if (pl.figures[i].IsAlive)
                    {
                        m = pl.GetPossibleMoves(pl.figures[i], figMap, friendly, PL, out possible);
                        if (possible)
                            return;
                    }
                }
                if(!possible)
                    EndGame(PL, false, "Checkmate");
            }
            else
            {
                for (int i = 0; i < pl.figCount; i++)
                {
                    if (pl.figures[i].IsAlive)
                    {
                        m = pl.GetPossibleMoves(pl.figures[i], figMap, friendly, PL, out possible);
                        if (possible)
                            return;
                    }
                }
                if (!possible)
                    EndGame(PL, true, "Stalemate");
            }
        }
        /// <summary>
        /// Tikrina ar galima Insuffitient material zaidimo pabaiga
        /// </summary>
        private void InsuffitientMaterial()
        {
            int BK = 0;
            int WK = 0;
            int BB = 0;
            int WB = 0;
            string WBC = null;
            string BBC = null;
            for (int i = 1; i < player1.figCount; i++)
            {
                if (player1.figures[i].IsAlive)
                {
                    if (player1.figures[i] is Knight)
                        WK++;
                    else if(player1.figures[i] is Bishop)
                    {
                        WB++;
                        if (WBC == null)
                            WBC = BishopPositionColor(player1.figures[i].Position);
                        else if (WBC == BishopPositionColor(player1.figures[i].Position))
                            WB++;
                        else
                            return;

                    }
                }
            }
            for (int i = 1; i < player2.figCount; i++)
            {
                if (player2.figures[i].IsAlive)
                {
                    if (player2.figures[i] is Knight)
                        BK++;
                    if (player2.figures[i] is Bishop)
                    {
                        BB++;
                        if (BBC == null)
                            BBC = BishopPositionColor(player2.figures[i].Position);
                        else if (BBC == BishopPositionColor(player2.figures[i].Position))
                            BB++;
                        else
                            return;
                    }
                }
            }
            if ((BB == 0 && BK == 0 && WB == 0 && WK == 1) || (BB == 0 && BK == 1 && WB == 0 && WK == 0) ||
                (BK == 0 && WK == 0 && WB == 1 && BB == 0) || (BK == 0 && WK == 0 && WB == 0 && BB == 1) ||
                (BK == 0 && WK == 0 && WB > 1 && BB == 0 && WBC != null) || (BK == 0 && WK == 0 && WB == 0 && BB > 1 && BBC != null) ||
                (BK == 0 && WK == 0 && WB > 1 && BB > 1 && WBC != null && BBC != null && WBC == BBC))
                EndGame(player1, true, "Insuffitient material");
        }
        /// <summary>
        /// Suranda ant kokios spalvos kvadrato stovi rikis
        /// </summary>
        /// <param name="position">rikio pozicija</param>
        /// <returns></returns>
        private string BishopPositionColor(string position)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(cordData[i,j].Item3 == position)
                    {
                        if (i % 2 == 0)
                            return "White";
                        else
                            return "black";
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Three Fold Repetition
        /// </summary>
        private void TFR()
        {
            int[,] kv = new int[8, 8];
            int b1;
            int b2;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < player1.figCount; k++)
                    {
                        if (player1.figures[k].IsAlive && player1.figures[k].Position == cordData[i, j].Item3)
                            kv[i, j] = FigureType(player1.figures[k], player1);
                    }

                    for (int k = 0; k < player2.figCount; k++)
                    {
                        if (player2.figures[k].IsAlive && player2.figures[k].Position == cordData[i, j].Item3)
                            kv[i, j] = FigureType(player2.figures[k], player2);
                    }
                }
            }        
            if (WhichPlayer % 2 == 1)
            {
                if (TFRL.Count > 1)
                {
                    b2 = TFRL[TFRL.Count - 1].Item2;
                    if (player1.figures[0].MoveCount == 0 && !(player1.figures[6].MoveCount != 0 && player1.figures[7].MoveCount != 0))
                    {
                        if (player1.figures[6].MoveCount == 0 && player1.figures[7].MoveCount == 0)
                            b1 = 2;
                        else if (player1.figures[6].MoveCount == 0)
                            b1 = -1;
                        else
                            b1 = 1;
                    }
                    else
                        b1 = 0;
                }         
                else
                {
                    b1 = 2;
                    b2 = 2;
                }
            }
            else
            {
                if (TFRL.Count > 1)
                {
                    b1 = TFRL[TFRL.Count - 1].Item2;
                    if (player2.figures[0].MoveCount == 0 && !(player2.figures[6].MoveCount != 0 && player2.figures[7].MoveCount != 0))
                    {
                        if (player2.figures[6].MoveCount == 0 && player2.figures[7].MoveCount == 0)
                            b2 = 2;
                        else if (player2.figures[6].MoveCount == 0)
                            b2 = -1;
                        else
                            b2 = 1;
                    }
                    else
                        b2 = 0;
                }            
                else
                {
                    b1 = 2;
                    b2 = 2;
                }
            }   
            Tuple<int[,], int, int> T = new Tuple<int[,], int, int>(kv, b1, b2);
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(kv[i, j]);
            //        if (kv[i, j] >= 10)
            //            Console.Write(" ");
            //        else
            //            Console.Write("  ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(b1);
            //Console.WriteLine(b2);
            //Console.WriteLine("---------------");
            int repetitions = 0;
            for (int i = TFRpivot; i < TFRL.Count; i++)
            {
                if (CompereMultiDim(TFRL[i].Item1, T.Item1) && TFRL[i].Item2 == T.Item2 && TFRL[i].Item3 == T.Item3)
                    repetitions++;
            }
            TFRL.Add(T);
            if (repetitions >= 2)
                EndGame(player1, true, "Threefold repetition");
        }
        /// <summary>
        /// Gauna skaiciu sudieta su zaideju ir figuros tipu
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private int FigureType(Figures f, Player p)
        {
            int t = 0;
            if (p.Name == player1.Name)
                t += 10;
            else if(p.Name == player2.Name)
                t += 20;
            if (f is King)
                t += 0;
            else if (f is Queen)
                t += 1;
            else if (f is Bishop)
                t += 2;
            else if (f is Knight)
                t += 3;
            else if (f is Rock)
                t += 4;
            else if (f is Pawn)
                t += 5;
            else
                t = 0;
            return t;
        }
        /// <summary>
        /// Patikrina ar matricos yra tokios pat
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        private bool CompereMultiDim(int[,] a1, int[,] a2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (a1[i, j] != a2[i, j])
                        return false;
                }
            }
            return true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (IsStarted == true && IsStoped == false)
            {
                Form5 f5;
                this.Enabled = false;
                f5 = new Form5(this, "oDraw", "Do you want to draw the game?");
                f5.Show();
            }
        }

        public void ToEndGame(bool draw, string condition)
        {
            if (WhichPlayer % 2 == 1)
                EndGame(player2, draw, condition);
            else
                EndGame(player1, draw, condition);
        }

        private void resignButton_Click(object sender, EventArgs e)
        {
            if(IsStarted == true && IsStoped == false)
            {
                Form5 f5;
                this.Enabled = false;
                f5 = new Form5(this, "resign", "Are you shure you want to resign?");
                f5.Show();
            }          
        }
    }
}
