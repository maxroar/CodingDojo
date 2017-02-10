using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Player
    {
            public string name;
            public List<Card> hand;

        public Player(string pname)
        {
            name = pname;
            hand = new List<Card>();
        }

        //Pass by reference is not needed in this case because we are changing
        //the data withing the object reference by calling its .deal() method
        //public Card draw(ref Deck deck){
        public Card draw(Deck deck) {
            Card card = deck.deal();
            hand.Add(card);
            return card;
        }

        public bool discard(int idx){
            bool discarded = false;
            if (idx < hand.Count){
                hand.Remove(hand[idx]);
                discarded = true;
            }
            return discarded;
        }
        
    }
}
