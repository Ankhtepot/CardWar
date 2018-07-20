using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardWar
{
    public class clCard : Item
    {
        //public string name;
        public Image image;
        public Image frontImage;
        public Image backImage;
        public int value;
        public bool side;
        //public PictureBox PB;
        public int PositionInDeck;

        /// <summary>
        /// Constructors
        /// </summary>
        public clCard() : this( "def", -1 ) {            
        }
        
        public clCard(string name, int value) : this(name, value,null,null,-1){            
            
        }

        public clCard(string name, int value, Image frontImage, Image backImage, int position) {
            this.name = name;
            this.value = value;
            this.frontImage = frontImage;
            this.backImage = backImage;
            this.image = this.backImage;
            this.side = false;            
            this.PositionInDeck = position;
            //this.size.wi

            PB = new PictureBox();
            PB.Top = 0; PB.Left = 0; PB.Width = 74; PB.Height = 99; PB.Visible = true; PB.Image = backImage;
            PB.SizeMode = PictureBoxSizeMode.Zoom;

        }

        //Methods
        public bool FlipCard() {
            bool worked = true;
            try {
                this.side = this.side ? false : true;
                this.image = this.side ? this.frontImage : this.backImage;
                this.PB.Image = this.image;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                worked = false;
            }
            return worked;
        }

        

    }
}
