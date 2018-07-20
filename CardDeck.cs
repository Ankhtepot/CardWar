using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO -rewrite receive method for using Insert

namespace CardWar {
     public class CardDeck : IEnumerable<Card> {
        private Boolean isWarDeck;
        public bool IsWarDeck { get => isWarDeck; set => isWarDeck = value; }
        public string name;
        public List<Card> Deck;
        protected Point location;
        private int awaitingRecieving;

        public int AwaitingRecieving { get => awaitingRecieving; set => awaitingRecieving = value; }        

        public CardDeck() : this("def") { }

        public CardDeck(string name = "def") : this(name, new Point(0, 0)) {
        }

        public CardDeck(string name, Point startLocation) {
            Deck = new List<Card>();
            Settings.Set(20, Item.enMoveOn.Line);
            location = startLocation;
            this.name = name;
            awaitingRecieving = 0;

            this.SetLocation(startLocation);
        }

        public override string ToString() {
            return this.name;
        }

        public Card this[int index] {
            set { Deck.Insert( index,value);  }
            get { return this.Deck[index]; }
        }

        public static class Settings {
            private static int speed;
            private static Item.enMoveOn movingType;
            
            public static  int Speed { get => speed; set => speed = value; }
            public static Item.enMoveOn MovingType { get => movingType; set => movingType = value; }

            public static void Set(int sp, Item.enMoveOn mt) {
                try {
                    if (sp >= 1 && sp <= 30) Settings.Speed = sp;
                    else throw new IndexOutOfRangeException();
                   Settings.MovingType = mt;
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            public static void Set(int sp) {
                try {
                    if (sp >= 1 && sp <= 30) Settings.Speed = sp;
                    else throw new IndexOutOfRangeException();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            public static void Set(Item.enMoveOn mt) {
                try {
                    Settings.MovingType = mt;
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public Point GetLocation() {
            return this.location;
        }

        public void AddCard(Card card, enDeckPos posInDeck = enDeckPos.top, int explicitPos = 0) {
            card.ParentDeck = this;
            this.Deck.Add(card);
            ReceiveCard(card, posInDeck,explicitPos);
        }

        public virtual void ReceiveCard(Card newCard, enDeckPos destPos, int explicitPos = 0) {
            switch (destPos) {
                case enDeckPos.top: {
                        newCard.PositionInDeck = this.Deck.Count() - 1;
                        if (awaitingRecieving == 0) {
                            newCard.PB.Top = this.location.Y - newCard.PositionInDeck * 2;
                            newCard.PB.Left = this.location.X + newCard.PositionInDeck * 2;
                            newCard.SetLocations(newCard.PB.Location);
                        } else awaitingRecieving--;
                        newCard.PB.BringToFront();
                        //Console.WriteLine("Received card to top: data: LT of ParentDeck({0}): {1} ;" +
                            //" LT newCard location: {2} .", newCard.ParentDeck.name, newCard.ParentDeck.GetLocation().ToString(), newCard.GetLocation(Item.enLocationType.topLeft).ToString());
                    }; break;
                case enDeckPos.bottom: {
                        if (awaitingRecieving > 0) AwaitingRecieving--;
                        //Console.WriteLine("in receiving to bottom (total cards {0})", this.Deck.Count());
                        int dc = this.Count - 1;
                        //newCard.PositionInDeck = dc;
                        if (newCard.side) newCard.FlipCard();
                        for (int i = 0; i <= dc; i++) {
                            this.Deck[i].PositionInDeck++;
                        }
                        newCard.PositionInDeck = 0;
                        ConstructDeck();
                        
                        //Console.WriteLine("Received card to bottom: data: LT of ParentDeck({0}): {1} ;" +
                        //  " LT newCard location: {2} .", newCard.ParentDeck.name, newCard.ParentDeck.GetLocation().ToString(), newCard.GetLocation(Item.enLocationType.topLeft).ToString());
                    }; break;
                    //TODO more positions in deck
            }
        }

        /// <summary>
        /// visualy creates deck on the Form according to order
        /// </summary>
        public virtual void ConstructDeck() {
            for (int i = 0; i < Deck.Count; i++) {
                //Console.WriteLine("i: " + i + "; positionInDeck (pos): " + Deck.FindIndex(x => x.PositionInDeck == i).ToString() + "\n");
                int pos = Deck.FindIndex(x => x.PositionInDeck == i);
                Card tempCard = this.Deck[i];
                this.Deck[i] = this.Deck[pos];
                this.Deck[pos] = tempCard;
                Deck[i].PB.Location = new Point(this.location.X + i * 2, this.location.Y - i * 2);
                Deck[i].SetLocations(Deck[i].PB.Location);
            }
            for (int i = 0; i < this.Deck.Count(); i++) {
                this.Deck[i].PB.BringToFront();
            }
        }

        /// <summary>
        /// shuffles input deck
        /// </summary>
        public void ShuffleDeck() {
            if (this.Deck.Count() > 0) {
                int nrOfCards = Deck.Count();
                int[] tempDeck = new int[nrOfCards];
                Random rnd = new Random();
                for (int i = 0; i < nrOfCards;) {
                    tempDeck[i] = this.Deck[i].PositionInDeck;
                    int tempRnd = rnd.Next(0, nrOfCards);
                    if (!tempDeck.Contains(tempRnd)) {
                        tempDeck[i] = tempRnd;
                        i++;
                    }
                }
                //Console.WriteLine(PM.ListIntArray(tempDeck, "TempDeck"));
                for (int i = 0; i < nrOfCards; i++) {
                    this.Deck[i].PositionInDeck = tempDeck[i];
                    //Console.WriteLine("Before Construck: Deck[{0}]: {1}", i.ToString(), this.Deck[i].PositionInDeck.ToString());

                }
                ConstructDeck();
                //for (int i = 0; i < this.Deck.Count(); i++) {
                //    Console.WriteLine("After construck: Deck[{0}]: {1}", i.ToString(), this.Deck[i].PositionInDeck.ToString());
                //}
            }
        }

        public void ShareDeckTo2(CardDeck deck1, CardDeck deck2, enDeckPos shareFrom, int cardsToShare) {
            //test if there is enough cards in deck
            if (cardsToShare > this.Deck.Count()) cardsToShare = this.Deck.Count();
            if (cardsToShare <= 0) { Console.WriteLine("ERR: No cards to share."); return; }

            do {
                if (cardsToShare % 2 == 0) {
                    this.MoveCardFromTopToTop( deck1);
                    cardsToShare--; //Console.WriteLine("CardsToShare: {0}.", cardsToShare.ToString());
                } else {
                    this.MoveCardFromTopToTop(deck2);
                    cardsToShare--; //Console.WriteLine("CardsToShare: {0}.", cardsToShare.ToString());
                }
                Stopwatch stopwatch = new Stopwatch();
                while (true) {
                    if (deck1.AwaitingRecieving == 0 && deck2.AwaitingRecieving == 0) break;
                    Application.DoEvents();
                }
            } while (cardsToShare > 0);
        }

        public void MoveCardToOtherDeck(enDeckPos originPos, enDeckPos destPos,
            CardDeck destDeck, Item.enMoveOn moveType = Item.enMoveOn.PointToPoint,
            int explicitMovPosOrigin = 0, int explicitMovPosDest = 0, int speed = 20) {
            if (this.Deck.Count() > 0) {
                Random rnd = new Random(); //RNG for random position in dest Deck
                Card originCard = new Card();                
                destDeck.awaitingRecieving++;
                //determinates which card is being sent depending on originPos variable
                switch (originPos) {
                    case enDeckPos.top: {
                            originCard = Deck[Deck.Count() - 1]; originCard.destDeck = destDeck;
                            //Console.WriteLine("Move to Top of other Deck set: check. CardPos={0}", originCard.PositionInDeck.ToString());
                        }; break;
                    case enDeckPos.bottom:/*TODO*/;break;
                    case enDeckPos.random:
                    case enDeckPos.explicitPos: {
                            if(originPos == enDeckPos.random) explicitMovPosOrigin = rnd.Next(0, this.Count);
                            /*TODO*/
                        }; break;                    
                }
                //determinates endPosition depending on what position in destDeck is card being sent
                int destDeckPos = 0;
                switch (destPos) {
                    case enDeckPos.top: {
                            originCard.destDeckPos = enDeckPos.top;
                            destDeckPos = destDeck.Count;
                            //if (destDeck.Deck.Count()  < 0) destDeckPos = 0;
                            //Console.WriteLine("Move to Top of other {1} set:  CardPos={0}", destDeckPos.ToString(), destDeck.ToString());
                        }; break;
                    case enDeckPos.bottom: {
                            originCard.destDeckPos = enDeckPos.bottom;
                            destDeckPos = 0;
                            //Console.WriteLine("Move to Bottom of other {1} set:  CardPos={0}", destDeckPos.ToString(), destDeck.ToString());
                        }; break;
                    case enDeckPos.random:
                    case enDeckPos.explicitPos: {
                            if(destPos == enDeckPos.random) explicitMovPosDest = rnd.Next(0, destDeck.Count);
                            //TODO
                        };break;
                }
                Point destPoint = new Point();
                //determinates endPosition depending on destination Deck
                //different descendats may have other needs
                Console.WriteLine();
                destPoint = destDeck.GetDestPoint(destDeckPos);
                //for explicit placement of card in dest Deck
                originCard.explicitPos = explicitMovPosDest;
                //next: triggers moving
                originCard.SetMove(destPoint, moveType, false, speed, Item.enLocationType.topLeft);
                this.Deck.Remove(originCard);
                originCard.ParentDeck = destDeck;
            }
        }

        //virtual method to determinate where should new card arrive
        public virtual Point GetDestPoint(int destDeckPos) {
            return new Point(
                this.GetLocation().X + ((destDeckPos + this.AwaitingRecieving) * 2),
                this.GetLocation().Y - ((destDeckPos + this.AwaitingRecieving) * 2));
        }

        public void MoveAllToBottomOfOtherDeck(CardDeck destDeck) {
            while(this.Deck.Count() > 0) { 
                this.MoveCardFromTopToBottom(destDeck);
                Stopwatch stopwatch = new Stopwatch();
                while(true) {
                    if (destDeck.AwaitingRecieving == 0) break;
                    Application.DoEvents();
                }
            }
        }

        public void MoveAlltoTopOfOtherDeck(CardDeck destDeck) {
            while (this.Deck.Count() > 0) {
                this.MoveCardFromTopToTop(destDeck);
                Stopwatch stopwatch = new Stopwatch();
                while (true) {
                    if (destDeck.AwaitingRecieving == 0) break;
                    Application.DoEvents();
                }
            }
        }

        public void MoveCardFromTopToTop(CardDeck destDeck) {
            this.MoveCardToOtherDeck(enDeckPos.top, enDeckPos.top, destDeck,
                speed: Settings.Speed, moveType: Settings.MovingType);
        }

        public void MoveCardFromTopToBottom(CardDeck destDeck) {
            this.MoveCardToOtherDeck(enDeckPos.top, enDeckPos.bottom, destDeck,
                speed: Settings.Speed, moveType: Settings.MovingType);
        }

        public enum enDeckPos {
            top = 1, bottom = 2, random = 3, explicitPos = 4
        }

        //sets location of Deck
        public void SetLocation(Point newLocation) {
            this.location = newLocation;
        }

        public IEnumerator<Card> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        //to make Deck.count() faster
        public int Count {
            get { return this.Deck.Count(); }
        }

        //returns reference to top card in the Deck
        public Card TopCard {
            get {
                if (Deck.Count() > 0) return Deck[Deck.Count() - 1];
                else return null;
            }
        }
    }
}
