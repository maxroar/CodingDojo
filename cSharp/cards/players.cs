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

        public Card discard(int idx){
            if (idx < hand.Count){
                Card discarded = hand[idx];
                hand.Remove(hand[idx]);
                return discarded;
            }
            return null;
        }
        
    }
}
