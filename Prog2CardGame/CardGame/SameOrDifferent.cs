using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace CardGame
{
    public class SameOrDifferent : Game
    {
       
        private bool playeranswer;
        public override void Play()
        {
            base.Play();
            WriteLine("Press enter to continue");
            ReadLine();
            Clear();
            string[] suits = { "Spades", "Hearts" };
            Carddeck = new Deck(26, suits);
            WriteLine($"Welcome to {Name} ");
            while (Carddeck.Cards.Count > 0)
            {
                Round();
            }
            if (Carddeck.Cards.Count == 0)
            {
                Console.WriteLine($"Congrulations the Game is over your score is {player1.score} ");
                Console.ReadLine();
            }
        }
        public SameOrDifferent()
        {
            string[] suits = { "Spades", "Hearts" };
            Carddeck = new Deck(26, suits);
        }
        private void Round()
        {
            WriteLine("type Yes if you think that the card will be the same if not type No");

            Card cardA = Carddeck.DrawCard();
            Card cardB = Carddeck.DrawCard();
            WriteLine($"The first card is {cardA.Name}\n Will the next card be the same suit?");
            PlayerInput();
            

            if (cardA.Suit == cardB.Suit && playeranswer == true)
            {
                Clear();
                player1.score++;
                Console.WriteLine($"This is Correct card A was {cardA.Name} card B was {cardB.Name} \n");
                WriteLine("Press enter to move onto the next set of cards");
                //SHOWCARDS();
                Console.ReadKey();
                Console.Clear();
                //CardDeck.PrintDeck();

            }
            else if (cardA.Suit != cardB.Suit && playeranswer == false)
            {
                Clear();

                player1.score++;
                Console.WriteLine($"This is Correct card A was {cardA.Name} card B was {cardB.Name}  ");
                WriteLine("Press enter to move onto the next set of cards");
                //SHOWCARDS();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Clear();

                Console.WriteLine($"This is Incorrect card A was {cardA.Name} card B was {cardB.Name}");
                WriteLine("Press enter to move onto the next set of cards");
                ReadKey();
                Clear();

            }


        }
        public void PlayerInput()
        {
            string Input = Console.ReadLine().ToLower();
            //int Input = nul;
            //bool playeranswer;
            if (Input == "yes")
            {
                playeranswer = true;
            }
            else if (Input == "no")
            {
                playeranswer = false;
            }
            else
            {
                Console.WriteLine("That is not a option please retry");
                Console.ReadKey();
                Console.Clear();
                PlayerInput();
            }


        }

    }
}
