using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = new List<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList());
            List<Card> cardsList = new List<Card>();

            foreach (string cardCombination in cards)
            {
                string[] cardInfo = cardCombination.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    if (CreateCard(cardInfo[0], cardInfo[1]) != null)
                    {
                        cardsList.Add(CreateCard(cardInfo[0], cardInfo[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ",cardsList));
        }

        public static Card CreateCard(string face, string suit)
        {
            string[] validFaces = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[4] { "S", "H", "D", "C" };

            if (validFaces.All(f => f != face))
            {
                throw new Exception("Invalid card!");
            }

            if (validSuits.All(s => s != suit))
            {
                throw new Exception("Invalid card!");
            }

            return new Card(face, suit);
        }
    }

    public class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Suit
        {
            get
            {
                return suit;
            }
            set
            {
                suit = value;
            }
        }


        public string Face
        {
            get
            {
                return face;
            }
            set
            {
                face = value;
            }
        }

        public override string ToString()
        {
            if (Suit == "S")
            {
                Suit = "\u2660";
            }
            else if(Suit == "H")
            {
                Suit = "\u2665";
            }
            else if (Suit == "D")
            {
                Suit = "\u2666";
            }
            else if(Suit == "C")
            {
                Suit = "\u2663";
            }

            return $"[{Face}{Suit}]";
        }
    }
}
