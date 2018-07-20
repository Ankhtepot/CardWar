using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardWar {
    public class Card : Item {
        //public string name;
        public Image image;
        public Image frontImage;
        public Image backImage;
        public int value;
        public bool side;
        //public PictureBox PB;
        public int PositionInDeck;

        //additional stuff for moving
        public CardDeck ParentDeck;
        public CardDeck destDeck;
        public CardDeck.enDeckPos destDeckPos;
        public int explicitPos;

        /// <summary>
        /// Constructors
        /// </summary>
        public Card() : this("def", -1) { }

        public Card(string name, int value) : this(name, value, null, null, -1) {

        }

        public Card(string name, int value, Image frontImage, Image backImage, int position) : base(name, new Rectangle(0, 0, 10, 10)) {
            this.name = name;
            this.value = value;
            this.frontImage = frontImage;
            this.backImage = backImage;
            this.image = this.backImage;
            this.side = false;
            this.PositionInDeck = position;

            SetVisuals(backImage, 0, 0);
        }

        //Methods

        public override string ToString() {
            return this.name;
        }
        public bool FlipCard() {
            bool worked = true;
            try {
                this.side = this.side ? false : true;
                this.image = this.side ? this.frontImage : this.backImage;
                this.PB.Image = this.image;
                SetBaseImage(this.image);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                worked = false;
            }
            return worked;
        }

        public override void SetVisuals(Image img, int x = 0, int y = 0) {
            PB = new PictureBox();
            PB.Top = 0; PB.Left = 0; PB.Width = 74; PB.Height = 99; PB.Visible = true;
            PB.Image = img; PB.Enabled = true;
            PB.SizeMode = PictureBoxSizeMode.Normal;
            SetBaseImage(img);
            SetSize(new Rectangle(0, 0, 74, 99));
            SetLocations(new Point(x, y));
        }

        public override void Move() {
            if(movData.path.Length == 1) {
                SetLocations(movData.path[0]);
                destDeck.AddCard(this, this.destDeckPos,explicitPos);
                //Console.WriteLine("Last movPoint: movData.path[" + movData.actualPoint + "] = " + movData.path[movData.actualPoint].X + "," + movData.path[movData.actualPoint].Y + ").");
                SetLocations(movData.path[movData.actualPoint]);
                movData.actualPoint = 0;

                /*update me*/
                frMain.movList.Remove(this);
            }
            else if (movData.actualPoint == 0) {
                SetLocations(movData.path[movData.actualPoint]);
                //Console.WriteLine("movData.path[" + movData.actualPoint + "] = " + movData.path[movData.actualPoint].X + "," + movData.path[movData.actualPoint].Y + ").");
                //ParentDeck.Deck.Remove(this);
                destDeck.AddCard(this, this.destDeckPos);
                if (movData.path.Length > 1) movData.actualPoint++;
            } else if (movData.actualPoint < movData.path.GetUpperBound(0) && movData.actualPoint > 0) {
                movData.actualPoint++;
                //Console.WriteLine("movData.path[" + movData.actualPoint + "] = " + movData.path[movData.actualPoint].X + "," + movData.path[movData.actualPoint].Y + ").");
                SetLocations(movData.path[movData.actualPoint]);
            } else {
                //Console.WriteLine("Last movPoint: movData.path[" + movData.actualPoint + "] = " + movData.path[movData.actualPoint].X + "," + movData.path[movData.actualPoint].Y + ").");
                SetLocations(movData.path[movData.actualPoint]);
                movData.actualPoint = 0;
                /*update me*/
                frMain.movList.Remove(this);
                //Console.WriteLine("ParentDeck (should be new one) = " + this.ParentDeck.ToString());
            }
        }

    }
}
