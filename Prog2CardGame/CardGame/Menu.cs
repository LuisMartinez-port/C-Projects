using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGame.Utility;

namespace CardGame
{
    public class Menu
    {
        Game game;
        public void ShowMenu()
        {
            ShowGameOptions();
            LoadGame(GetPlayerChoice());
        }
        private void ShowGameOptions()
        {
            Console.WriteLine("Welcome Choose a game to play");
            Console.WriteLine("1:Same Or Different \n2:Higher or Lower\n3:Highest Match \n4: Credits ");

        }
        private void LoadGame(string choice)
        {
            switch (choice)
            {
                case "1":
                    game = new SameOrDifferent();
                    game.Name = "SameOrDifferent";
                    game.RulesOfGame = "A card is drawn from a shuffled deck and shown to the player. The player then guesses what the suit of the next card will be - will it be the same or different? For each correct guess, the player gains a point.\"";
                    game.Play();
                    break;
                case "2":
                    game = new HigherorLower();
                    game.Name = "Higher Or Lower";
                    game.RulesOfGame = "A card is drawn from a shuffled deck and shown to the player. The player then guesses what the value of the next card will be compared to the previous card.For each correct guess the player will gain a point";
                    game.Play();
                    break;
                case "3":
                    game = new HighestMatch();
                    game.Name = "Highest Match";
                    game.RulesOfGame = "Both you and the dealer will be dealt four starting cards, you can choose to swap one card at a time or compare your cards with the dealer. Your goal is to have at least two matching cards of the same suit, the total value will be added as your score.";
                    game.Play();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine( "CREDITS");
                    Console.WriteLine("The building of this game was assisted by Tyrone King with his assistance in solidifying concepts, assisting with the structurre of code, and brainstorming together. \n Also Janell Baxter, much feedback was given and a demo on a deck class was very useful");
                    Console.WriteLine("Press Enter to Continue ->");
                    Console.ReadKey();
                    Console.Clear();
                    ShowMenu();

                    break;





            }
            Console.Clear();
            ShowMenu();

        }
    }
}
