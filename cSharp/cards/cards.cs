using System;


namespace ConsoleApplication
{
    public class Card
    {
            public string stringVal;
            public string suit;
            public int cardVal;
        public Card(string create_stringVal, string create_suit, int create_cardVal)
        {
            System.Console.WriteLine(create_cardVal);
            stringVal = create_stringVal;
            suit = create_suit;
            cardVal = create_cardVal;
        }

        
    }
}
