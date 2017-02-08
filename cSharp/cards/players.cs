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

        public Card draw(ref Deck deck){
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
