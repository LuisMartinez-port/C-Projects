using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CardGame
{
    public class Game
    {

        
        public string Name = "An Incredible Card Game";
        public string RulesOfGame = "Rules of Game";
        public Player player1= new Player();
        public Deck Carddeck;


        public virtual void Play () {
            WriteLine($"Welcome to {Name}");
            WriteLine($"{RulesOfGame}");

        }

        public void SHOWCARDS()
        {
            foreach (Card card in player1.HandofCards)
            {
                Console.WriteLine($"{card.Value} {card.Suit}");

            }
        }
        public void addCardToHand()
        {
            Card card = Carddeck.DrawCard();
            player1.HandofCards.Add(card);
            Console.WriteLine($"{card.Value} {card.Suit}");

        }

        public void addCardToNpcHand()
        {
            Card card = Carddeck.DrawCard();
            player1.NpcHand.Add(card);

        }
       

        public Game() {
            string[] suits = { "Spade", "Heart", "Club", "Diamonds" };
            Carddeck = new Deck(52, suits);
        }

        //methods    

        

        
    }
}
