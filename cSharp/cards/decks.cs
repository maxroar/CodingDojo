using System;
using System.Collections.Generic;



namespace ConsoleApplication
{
    public class Deck
    {
            public List<Card> cards;
        
        public void buildDeck()
        {
            cards = new List<Card>();
            for (int i = 0; i < 4; i++){
                string suit;
                switch(i){
                    case 0:
                        suit = "Clubs";
                        break;
                    case 1:
                        suit = "Spades";
                        break;
                    case 2:
                        suit = "Hearts";
                        break;
                    case 3:
                        suit = "Diamonds";
                        break;
                    default:
                        suit = "";
                        break;
                }
                for (int j = 1; j < 14; j++){
                    if (j == 1){
                        Card card = new Card("A", suit, j);
                        cards.Add(card);
                    }else if (j == 11){
                        Card card = new Card("Jack", suit, j);
                        cards.Add(card);
                    }else if (j == 12){
                        Card card = new Card("Queen", suit, j);
                        cards.Add(card);
                    }else if (j == 13){
                        Card card = new Card("King", suit, j);
                        cards.Add(card);
                    }else{
                        Card card = new Card(j.ToString(), suit, j);
                        cards.Add(card);
                    }
                }
            }
        }
        public Deck()
        {
            buildDeck();
        }
        public Card deal(){
            Card lastCard = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return lastCard;
        }

        public void reset(){
            cards.Clear();
            buildDeck();
        }

        public void shuffle(){
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++){
                Card temp = cards[i];
                int randIdx = rand.Next(0,cards.Count);
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            }
        }

        
    }
}
