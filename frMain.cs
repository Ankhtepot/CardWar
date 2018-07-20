using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardWar {

    public partial class frMain : Form {
        private static int Ticks { set; get; }
        private CardDeck MainDeck;
        private CardDeck DeckPOne;
        private CardDeck DeckPTwo;
        private CardDeckWar WarPOne;
        private CardDeckWar WarPTwo;
        private Boolean gameInProgress;
        public static List<Item> movList = new List<Item>();
        public static List<Item> animateList = new List<Item>();
        StringBuilder sb = new StringBuilder();

        //mniclass for game options
        public static class Settings {
            public static string P1Name = "Player 1";
            public static string P2Name = "Player 2";
            public static int rounds = -1;
            public static int waitTime;
            public static int MaxRounds { set; get; }
        }

        public frMain() {

            MainDeck = new CardDeck("Main Deck", new Point(200, 300));
            DeckPOne = new CardDeck("PlayerOne Deck", new Point(50, 250));
            DeckPTwo = new CardDeck("PlayerTwo Deck", new Point(400, 250));
            WarPOne = new CardDeckWar("WarP1", new Point(200, 200));
            WarPTwo = new CardDeckWar("WarP2", new Point(300, 200));

            InitializeComponent();

            FeedCardDeck();
            //brings cards onto form
            foreach (Card x in MainDeck.Deck) {
                //Console.WriteLine(x.ToString()); 
                this.Controls.Add(x.PB);
                x.PB.BringToFront();
                //Console.WriteLine("Position of card: {0}.",x.GetLocation(Item.enLocationType.topLeft).ToString());
            }
        }

        private void frMain_Load(object sender, EventArgs e) {
            Ticks = 0;
            Settings.MaxRounds = 3;
            Settings.waitTime = 1500;
            gameInProgress = false;
            CardDeck.Settings.Speed = 20;
            CardDeck.Settings.MovingType = Item.enMoveOn.PointToPoint;
            rbWOAnimation.Checked = true;
        }

        //creates cards and add them into MainDeck
        public bool FeedCardDeck() {
            bool result = true;
            try {
                Image backSideRed; Image backSideBlue; Image Backside; Image frontSide;
                CardDeck.enDeckPos topPos = CardDeck.enDeckPos.top;
                backSideRed = new Bitmap(Properties.Resources.redBack3);
                backSideBlue = new Bitmap(Properties.Resources.blueBack3);
                Backside = new Bitmap(Properties.Resources.backSide);
                //Console.WriteLine("Backside pixelformat: "+ backSide.PixelFormat.ToString());
                Rectangle srcRect = new Rectangle(8, 8, 74, 98);
                //backSideBlue = backSideRed = Backside; //comment out to use different backsides
                //Spades
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 0)));
                MainDeck.AddCard(new Card("ASpades", 14, frontSide, backSideRed, 0), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 6)));
                MainDeck.AddCard(new Card("7Spades", 7, frontSide, backSideBlue, 1), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 7)));
                MainDeck.AddCard(new Card("8Spades", 8, frontSide, backSideRed, 2), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 8)));
                MainDeck.AddCard(new Card("9Spades", 9, frontSide, backSideBlue, 3), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 9)));
                MainDeck.AddCard(new Card("10Spades", 10, frontSide, backSideRed, 4), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 10)));
                MainDeck.AddCard(new Card("JSpades", 11, frontSide, backSideBlue, 5), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 11)));
                MainDeck.AddCard(new Card("QSpades", 12, frontSide, backSideRed, 6), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(0, 12)));
                MainDeck.AddCard(new Card("KSpades", 13, frontSide, backSideBlue, 7), topPos);
                //Clubs
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 0)));
                MainDeck.AddCard(new Card("AClubs", 14, frontSide, backSideRed, 8), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 6)));
                MainDeck.AddCard(new Card("7Clubs", 7, frontSide, backSideBlue, 9), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 7)));
                MainDeck.AddCard(new Card("8Clubs", 8, frontSide, backSideRed, 10), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 8)));
                MainDeck.AddCard(new Card("9Clubs", 9, frontSide, backSideBlue, 11), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 9)));
                MainDeck.AddCard(new Card("10Clubs", 10, frontSide, backSideRed, 12), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 10)));
                MainDeck.AddCard(new Card("JClubs", 11, frontSide, backSideBlue, 13), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 11)));
                MainDeck.AddCard(new Card("QClubs", 12, frontSide, backSideRed, 14), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(1, 12)));
                MainDeck.AddCard(new Card("KClubs", 13, frontSide, backSideBlue, 15), topPos);
                //Hearts
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 0)));
                MainDeck.AddCard(new Card("AHearts", 14, frontSide, backSideRed, 16), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 6)));
                MainDeck.AddCard(new Card("7Hearts", 7, frontSide, backSideBlue, 17), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 7)));
                MainDeck.AddCard(new Card("8Hearts", 8, frontSide, backSideRed, 18), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 8)));
                MainDeck.AddCard(new Card("9Hearts", 9, frontSide, backSideBlue, 19), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 9)));
                MainDeck.AddCard(new Card("10Hearts", 10, frontSide, backSideRed, 20), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 10)));
                MainDeck.AddCard(new Card("JHearts", 11, frontSide, backSideBlue, 21), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 11)));
                MainDeck.AddCard(new Card("QHearts", 12, frontSide, backSideRed, 22), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(2, 12)));
                MainDeck.AddCard(new Card("KHearts", 13, frontSide, backSideBlue, 23), topPos);
                //Diamonds
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 0)));
                MainDeck.AddCard(new Card("ADiamonds", 14, frontSide, backSideRed, 24), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 6)));
                MainDeck.AddCard(new Card("7Diamonds", 7, frontSide, backSideBlue, 25), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 7)));
                MainDeck.AddCard(new Card("8Diamonds", 8, frontSide, backSideRed, 26), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 8)));
                MainDeck.AddCard(new Card("9Diamonds", 9, frontSide, backSideBlue, 27), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 9)));
                MainDeck.AddCard(new Card("10Diamonds", 10, frontSide, backSideRed, 28), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 10)));
                MainDeck.AddCard(new Card("JDiamonds", 11, frontSide, backSideBlue, 29), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 11)));
                MainDeck.AddCard(new Card("QDiamonds", 12, frontSide, backSideRed, 30), topPos);
                frontSide = new Bitmap(clipFrontSide(CardWar.Properties.Resources.cards, getRect(3, 12)));
                MainDeck.AddCard(new Card("KDiamonds", 13, frontSide, backSideBlue, 31), topPos);
            } catch (Exception e) {
                result = false; Console.WriteLine("FeedDeck ERR: " + e.Message);
            }
            return result;
        }

        //clips image for card from resource file
        private static Image clipFrontSide(Image srcBitmap, Rectangle srcRegion) {
            Image rImg;
            rImg = new Bitmap(74, 99);
            Graphics gr = default(Graphics);
            gr = Graphics.FromImage(rImg);
            gr.DrawImage(srcBitmap, new Rectangle(0, 0, 74, 99), srcRegion, GraphicsUnit.Pixel);
            return rImg;
        }

        //gets region from where to clip card image
        private static Rectangle getRect(int line, int column) {
            Rectangle resultRect;
            const int offset = 8;
            const int width = 73;
            const int height = 98;
            int rectX = offset + column * width;
            int rectY = offset + line * height;
            resultRect = new Rectangle(rectX, rectY, width, height);
            return resultRect;
        }

        private void tiMain_Tick(object sender, EventArgs e) {
            //Ticks++;
            if (movList.Count > 0) {
                try {
                    foreach (Item oxxo in movList) {
                        oxxo.Move();
                        if (movList.Count() > 0) foreach (Item oxxo2 in movList) oxxo2.ToString();
                    }
                } catch (Exception) {
                    //Console.WriteLine( "tiMain_Tick ERR: " + ex.Message );
                }
            }
        }

        private void GameRound() {
            if (gameInProgress) {
                Settings.rounds++; SetTBTotals();
                AddText(String.Format("New round: nr.{0}.", Settings.rounds.ToString()));
                DeckPOne.MoveCardFromTopToTop(WarPOne); SetTBTotals();
                DeckPTwo.MoveCardFromTopToTop(WarPTwo); SetTBTotals();
                //wait till move is done
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (true) {
                    if (WarPOne.AwaitingRecieving == 0 && WarPTwo.AwaitingRecieving == 0 && stopwatch.ElapsedMilliseconds >= 1500)
                        break;
                    Application.DoEvents();
                }
                switch (CompareCards(WarPOne.TopCard, WarPTwo.TopCard)) {
                    case -1: AddLine("error comparing"); break;
                    case 1: {
                            WarPOne.MoveAllToBottomOfOtherDeck(DeckPOne); SetTBTotals();
                            Stopwatch stopwatchGR = Stopwatch.StartNew();
                            while (true) {
                                if (DeckPOne.AwaitingRecieving == 0 /*&& stopwatchGR.ElapsedMilliseconds >= 1500*/)
                                    break;
                                Application.DoEvents();
                            }
                            WarPTwo.MoveAllToBottomOfOtherDeck(DeckPOne); 
                            AddLine(String.Format("> {0} won.", Settings.P1Name));
                        }
                        break;
                    case 2: {
                            AddLine(String.Format("> {0} won.", Settings.P2Name));
                            WarPTwo.MoveAllToBottomOfOtherDeck(DeckPTwo);
                            Stopwatch stopwatchGR = Stopwatch.StartNew();
                            while (true) {
                                if (DeckPTwo.AwaitingRecieving == 0 /*&& stopwatchGR.ElapsedMilliseconds >= 1500*/)
                                    break;
                                Application.DoEvents();
                            }
                            WarPOne.MoveAllToBottomOfOtherDeck(DeckPTwo);
                        }
                        break;
                    case 0: {
                            AddLine("> WAR!!!");
                            int warCount = 2;
                            if (DeckPOne.Count < 2 || DeckPTwo.Count < 2) {
                                warCount = Math.Min(DeckPOne.Count, DeckPTwo.Count);
                            }
                            for (int i = 0; i < warCount; i++) {
                                DeckPOne.MoveCardFromTopToTop(WarPOne); SetTBTotals();
                                DeckPTwo.MoveCardFromTopToTop(WarPTwo); SetTBTotals();
                                Stopwatch stopwatchGR = Stopwatch.StartNew();
                                while (true) {
                                    if (WarPOne.AwaitingRecieving == 0 && WarPTwo.AwaitingRecieving == 0 && stopwatchGR.ElapsedMilliseconds >= Settings.waitTime)
                                        break;
                                    Application.DoEvents();
                                }
                            }
                            GameRound();
                        }; break;
                }
                stopwatch = Stopwatch.StartNew();
                while (true) {
                    if (DeckPOne.AwaitingRecieving == 0 && DeckPTwo.AwaitingRecieving == 0 &&
                        stopwatch.ElapsedMilliseconds >= Settings.waitTime - 500)
                        break;
                    //if (stopwatch.ElapsedMilliseconds >= 1000) break;
                    Application.DoEvents();
                }
                SetTBTotals();
            } else return;
        }

        private int CompareCards(Card C1, Card C2) {
            int result = -1;
            if (C1 != null && C2 != null) {
                if (C1.value > C2.value) result = 1;
                if (C1.value < C2.value) result = 2;
                if (C1.value == C2.value) result = 0;
            }
            return result;
        }

        private void SetTBTotals() {
            tbP1Total.Text = DeckPOne.Deck.Count().ToString();
            tbP2Total.Text = DeckPTwo.Deck.Count().ToString();
            tbRound.Text = Settings.rounds.ToString();
        }

        //methods for stringbuilder
        private void AddLine(string text) {
            sb.AppendLine(text);
            tbRecord.Text = sb.ToString();
        }
        private void AddText(string text) {
            sb.Append(text);
            tbRecord.Text = sb.ToString();
        }

        private void StartGame() {
            gameInProgress = true;
            AddLine("Shuffing cards.");
            MainDeck.ShuffleDeck();
            AddLine("Sharing cards.");
            SetTBTotals();
            MainDeck.ShareDeckTo2(DeckPOne, DeckPTwo, CardDeck.enDeckPos.top, MainDeck.Deck.Count());
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true) {
                if (DeckPOne.AwaitingRecieving == 0 && DeckPTwo.AwaitingRecieving == 0 && stopwatch.ElapsedMilliseconds >= Settings.waitTime + 500)
                    break;
                Application.DoEvents();
            }
            while (DeckPOne.Deck.Count() != 0 && DeckPTwo.Deck.Count() != 0) 
            {
                if (Settings.rounds >= Settings.MaxRounds) break;
                //stopwatch = Stopwatch.StartNew();
                //while (true) {
                //    if (DeckPOne.AwaitingRecieving == 0 && DeckPTwo.AwaitingRecieving == 0 && stopwatch.ElapsedMilliseconds >= 2000)
                //        break;

                //    Application.DoEvents();
                //}
                if (!gameInProgress) break;
                GameRound();
            } 
            if(gameInProgress) EndOfGame();
        }

        private void EndOfGame() {
            string winString = "";
            if (DeckPOne.Count > DeckPTwo.Count)
                winString = string.Format("{0} won! Congratulations!", Settings.P1Name);
            if (DeckPOne.Count < DeckPTwo.Count)
                winString = string.Format("{0} won! Congratulations!", Settings.P2Name);
            if (DeckPOne.Count == DeckPTwo.Count) {
                AddLine("Both players has same number of cards, one more round is up!");
                GameRound();
                EndOfGame();
            }
            MessageBox.Show("Game ended.\n" + winString);
            Settings.rounds = -1;
            ResetTBs();
            buStartGame.Image = Properties.Resources.startGameSmall;
            gameInProgress = false;
            ResetDecks();
            lbP1Name.Visible = true; lbP2Name.Visible = true;
            tbP1Name.Visible = true; tbP2Name.Visible = true;
        }

        private void ResetTBs() {
            tbRecord.Clear(); sb.Clear();
            tbP1Total.Text = "0"; tbP2Total.Text = "0"; tbRound.Text = "0";
        }

        private void ResetDecks() {
            if (DeckPOne.Count > 0) DeckPOne.MoveAlltoTopOfOtherDeck(MainDeck);
            if (DeckPTwo.Count > 0) DeckPTwo.MoveAlltoTopOfOtherDeck(MainDeck);
            if (WarPOne.Count > 0) WarPOne.MoveAlltoTopOfOtherDeck(MainDeck);
            if (WarPTwo.Count > 0) WarPTwo.MoveAlltoTopOfOtherDeck(MainDeck);
        }

        private void buStartGame_Click(object sender, EventArgs e) {
            if (gameInProgress) {                
                Pause pfr = new Pause();
                var dialogResult = pfr.ShowDialog();
                buStartGame.Location = new Point(144, 119);
                if (dialogResult == DialogResult.Abort) { Console.WriteLine("Exiting"); ExitCardWar(); }
            } else {
                buStartGame.Location = new Point(144, 80);
                buStartGame.Image = Properties.Resources.pauseFinal;
                gameInProgress = true;
                if (Settings.rounds == -1) {
                    lbP1Name.Visible = false; lbP2Name.Visible = false;
                    tbP1Name.Visible = false; tbP2Name.Visible = false;
                    Settings.rounds++;
                    tbRecord.Clear(); sb.Clear();
                    StartGame();
                     }
            }
        }

        private void ExitCardWar() {
            gameInProgress = false;
            Stopwatch stopwatch = new Stopwatch();
            while (true) {
                if (DeckPOne.AwaitingRecieving == 0 && DeckPTwo.AwaitingRecieving == 0 &&
                    WarPOne.AwaitingRecieving == 0 && WarPTwo.AwaitingRecieving == 0)
                    break;
                Application.DoEvents();
            }
            this.Close();
        }

        private void rbWOAnimation_Click(object sender, EventArgs e) {
            CardDeck.Settings.MovingType = Item.enMoveOn.PointToPoint;
            
        }

        private void rbWAnimation_Click(object sender, EventArgs e) {
            
            CardDeck.Settings.MovingType = Item.enMoveOn.Line;
        }

        private void buExit_Click(object sender, EventArgs e) {
            ExitCardWar();
        }

        private void tbP1Name_TextChanged(object sender, EventArgs e) {
            Settings.P1Name = tbP1Name.Text;
        }

        private void tbP2Name_TextChanged(object sender, EventArgs e) {
            Settings.P2Name = tbP2Name.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            ShowOptions();
        }

        private void ShowOptions() {
            Options Ofr = new Options();
            var dialogResult = Ofr.ShowDialog();
        }
    }
}
