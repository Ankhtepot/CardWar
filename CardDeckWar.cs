using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar {
    public class CardDeckWar : CardDeck {

        public CardDeckWar() : base() { }
        public CardDeckWar(string name, Point location) : base(name, location) {  }

        public override void ReceiveCard(Card newCard, enDeckPos destPos, int explicitPos = 0) {
            switch (destPos) {
                case enDeckPos.top: {
                        newCard.PositionInDeck = this.Deck.Count() - 1;
                        if (AwaitingRecieving != 0) AwaitingRecieving--;
                        if(!newCard.side) newCard.FlipCard();
                        newCard.PB.BringToFront();
                        //Console.WriteLine("Received card data: LT of ParentDeck({0}): {1} ;" +
                        //    " LT of newCard: {2} .", newCard.ParentDeck.name, newCard.ParentDeck.GetLocation().ToString(), newCard.GetLocation(Item.enLocationType.topLeft).ToString());
                    }; break;
                //War card deck can receive only to top
                default:;break;
            }
            //this.ConstructDeck();
        }

        public override void ConstructDeck() {
            
            for (int i = 0; i < Deck.Count; i++) {
                //Console.WriteLine("CardDeckWar: ConstructDeck.");
                Deck[i].PB.Location = new Point(this.location.X , this.location.Y + i*20);
                Deck[i].SetLocations(Deck[i].PB.Location);
            }
        }

        //for War deck is destDeckPos not used
        public override Point GetDestPoint(int destDeckPos) {
           // Console.WriteLine("CardDeck sends to WarDeck.");
            return new Point(this.GetLocation().X,
                this.GetLocation().Y + 20 * (this.Deck.Count() + this.AwaitingRecieving));
            }

    }
}
