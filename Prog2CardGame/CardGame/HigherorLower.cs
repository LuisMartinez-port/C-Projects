using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CardGame
{
    public class HigherorLower : Game
    {
        private string playeranswer;
        public override void Play()
        {
            base.Play();
            WriteLine("Press enter to continue");
            ReadLine();
            Clear();
            string[] suits = { "Spades", "Hearts", "Clubs","Diamonds" };
            Carddeck = new Deck(52, suits);
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

        public HigherorLower() {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            Carddeck = new Deck(52, suits);
        }

        private void Round()
        {
            WriteLine("Type higher if you think the next card will have a higher value, type lower if you think it will have a lower value .");

            Card cardA = Carddeck.DrawCard();
            Card cardB = Carddeck.DrawCard();
            WriteLine($"The first card is {cardA.Name}\n Will the next card be higher or lower?");
            PlayerInput();


            if (cardA.Value <= cardB.Value && playeranswer == "higher")
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
            else if (cardA.Value >= cardB.Value && playeranswer == "lower")
            {
                Clear();

                player1.score++;
                Console.WriteLine($"This is Correct card A was {cardA.Name} card B was {cardB.Name}  ");
                WriteLine("Press enter to move onto the next set of cards");
                //SHOWCARDS();
                Console.ReadKey();
                Console.Clear();
            }
            else if (cardA.Value == cardB.Value ) {
                Clear();

                Console.WriteLine($"Card B is the same value!! Unfortunately no points for you.  ");
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
            if (Input == "higher")
            {
                playeranswer = "higher";
            }
            else if (Input == "lower")
            {
                playeranswer = "lower";
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
