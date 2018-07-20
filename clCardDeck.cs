using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO
//moving of cards
//deal cards to players
//normal fight
//war
namespace CardWar {
    public class clCardDeck {
        public List<clCard> Deck;        
        public int Top;
        public int Left;
        //public PictureBox PB;

        public clCardDeck() {
            Deck = new List<clCard>();
            Top = 0; Left = 0;
            //PB = new PictureBox();
            //PB.Top = 0; PB.Left = 0;PB.Width = 74; PB.Height = 99; PB.Visible = true; PB.Image = null;
            //PB.SizeMode = PictureBoxSizeMode.Normal;
        }

        public void AddCard(clCard card) {
            this.Deck.Add( card );
        }

        /// <summary>
        /// shuffles input deck
        /// </summary>

        public void ShuffleDeck() {
            int nrOfCards = Deck.Count;
            int cardsAdded = 0;
            clCardDeck tempDeck = new clCardDeck();
            for(int i = 0; i < this.Deck.Count(); i++) {
                tempDeck.AddCard( Deck[i] );
            }
            Deck.Clear();

            Random rnd = new Random();

            do {
                int tempRnd = rnd.Next(0, nrOfCards);
                if(!Deck.Contains( tempDeck.Deck[tempRnd] )) {
                    tempDeck.Deck[tempRnd].PositionInDeck = cardsAdded;
                    //Console.WriteLine(tempDeck.Deck[tempRnd].PositionInDeck.ToString());
                    AddCard( tempDeck.Deck[tempRnd] );
                    cardsAdded++;
                }
            } while(cardsAdded <= nrOfCards - 1);
            ConstructDeck();
        }

        public void ConstructDeck() {
            for(int i = 0; i < Deck.Count; i++) {
                Console.WriteLine( "index: " + i + " positionInDeck (pos): " + Deck.FindIndex( x => x.PositionInDeck == Deck.Count - 1 - i ).ToString() + "\n" );
                int pos = Deck.FindIndex(x => x.PositionInDeck == i);
                Deck[i].PB.Top = this.Top - 99 - i * 2;
                Deck[i].PB.Left = this.Left + i * 2;
                Deck[i].PB.BringToFront();
            }
        }

        public void setPosition(int Top, int Left) {
            this.Top = Top;
            this.Left = Left;
            ConstructDeck();
        }

        private void paintCardOnTop(clCard card) {
            //Rectangle destRect = new Rectangle(card.PositionInDeck * 2,
            //    this.PB.Bottom-2*card.PositionInDeck,74,99);
            //Image rImg;
            //rImg = new Bitmap(74,99);
            //Graphics gr;
            //gr = Graphics.FromImage( card.image );
            //gr.DrawImage( card.image, destRect, new Rectangle( 0, 0, 74, 99 ), GraphicsUnit.Pixel );
            //PB.Image.
        }
    }
}
