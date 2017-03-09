using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck();
            foreach (Card card in deck.cards){
                System.Console.WriteLine(card.cardVal);
                System.Console.WriteLine(card.stringVal);
                System.Console.WriteLine(card.suit);
            }
            Player max = new Player("Max");
            System.Console.WriteLine(max.name);
            deck.shuffle();
            foreach (Card card in deck.cards){
                System.Console.WriteLine(card.cardVal);
                System.Console.WriteLine(card.stringVal);
                System.Console.WriteLine(card.suit);
            }
            System.Console.WriteLine(deck.cards);
            Card newCard = max.draw(ref deck);
            deck.reset();
            foreach (Card card in deck.cards){
                System.Console.WriteLine(card.cardVal);
                System.Console.WriteLine(card.stringVal);
                System.Console.WriteLine(card.suit);
            }
            System.Console.WriteLine(newCard.cardVal);
            System.Console.WriteLine(newCard.stringVal);
            System.Console.WriteLine(newCard.suit);
            System.Console.WriteLine(max.hand);
        }   
    }
}
