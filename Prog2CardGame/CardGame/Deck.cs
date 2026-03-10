using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CardGame
{
    public class Deck
    {

        // have to figure out how to remove some of these suits in each individual game
        // do not want to hardcode each suit length for each game

        //static string[] Example; Was planning on having the Example be able to change for each game, cant figure it out
        //static string[] Suits =Example;

        //static string[] Suits =   {"Hearts", "Clubs", "Spades", "Diamonds"};

        

        //static string[] FaceCards = { "king", "queen", "jack" };

        //int NumberOfCardsInDeck = 13 * Suits.Length;

        //List of Cards
        public List<Card> Cards = new List<Card>();

        //List<Card> Shuffle(List<Card> unshuffled)
        //{
        //   Random random = new Random();
        //    return unshuffled.OrderBy(a => random.Next()).ToList();
        //}


        

        //public void ShuffleDeck() {
        //    List<Card> shufflecards = Shuffle(Cards);
        //    foreach (Card card in shufflecards) { 
        //    Console.WriteLine(card);
        //    }
        //    Console.ReadKey();
        //}

        public void Shuffle()//Janells example of shuffle
        {
            Random random = new Random();
            List<Card> unshuffled = Cards;
            Cards = unshuffled.ToList().OrderBy(a => random.Next()).ToList();
        }

        public Deck(int size, string[] suits) {



            for (int i = 0; i < size / suits.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    if (i == 0)
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"Ace of {suits[j]}" });
                    else if (i == 12)
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"King of {suits[j]}" });
                    else if (i==11)
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"Queen of {suits[j]}" });
                    else if (i == 10)
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"jack of {suits[j]}" });
                    else
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"{i + 1} of {suits[j]}" });
                }
            }
            Shuffle();
        }

        public string PrintDeck()
        {
            string output = "Cards in deck: \n";
            foreach (Card card in Cards)
            {
                output += card.Name + Environment.NewLine;
            }
            return output;
        }

        //this is the method to draw a random card from the deck of cards
        Random random = new Random();
        public Card DrawCard()
        {
           int randomCardPicked = random.Next(0,Cards.Count-1);
            Card card = Cards[randomCardPicked];
            Cards.Remove(card);
            return card;
        }

        

    }
}
