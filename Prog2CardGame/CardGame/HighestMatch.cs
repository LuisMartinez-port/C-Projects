using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CardGame
{
    public class HighestMatch : Game
    {
        Card PlayercardA;
        Card PlayercardB;
        Card PlayercardC;
        Card PlayercardD;
        Card NpcCardA;
        Card NpcCardB;
        Card NpcCardC;
        Card NpcCardD;

        //variable to increment which turn of the game they are in 
        int TurnCounter = 0;
        bool GameOver = false;
        string playeranswer;
        int playerheartvalue;
        int playerspadevalue;
        int playerclubvalue;
        int playerdiamondvalue;
        int npcheartvalue;
        int npcspadevalue;
        int npcsclubvalue;
        int npcsdiamondvalue;
        int playerheartamount = 0;
        int playerspadeamount= 0 ;
        int playerclubamount = 0;
        int playerdiamondamount = 0;
        int npcheartamount = 0;
        int npcsclubamount = 0;
        int npcsdiamondamount = 0;
        int npcspadeamount = 0;
        string highestplayersuit;
        string highestnpcsuit;
        int highestnpcvalue =-1;
        int highestplayervalue = -1;
        int highestplayersuitamount;
        int highestnpcsuitamount;
        public override void Play()
        {
            base.Play();
            WriteLine("Press enter to continue");
            ReadLine();
            Clear();
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            Carddeck = new Deck(52, suits);
            Carddeck.Shuffle();
            WriteLine($"Welcome to {Name} ");
            setbasecardvalues();
            while(TurnCounter < 10)
            {
                Round();
            }
            if (TurnCounter == 10 || GameOver == true)
            {
                Clear();
                //Display value of both hands of cards and then the comparison of highest matches
                WriteLine($"At the end of the game you finished with the {PlayercardA.Name}, {PlayercardB.Name}, {PlayercardC.Name}, and the {PlayercardD.Name} in your deck.");
                WriteLine($"The dealer finished with the {NpcCardA.Name}, {NpcCardB.Name}, {NpcCardC.Name}, and the {NpcCardD.Name} in their hand");
                WriteLine("\n");
                Determinehighestvalues();
                ReadLine();
                valueofhighestsuits();
                if (highestplayervalue > highestnpcvalue) {
                    WriteLine($"You had {highestplayersuitamount} {highestplayersuit} totaling {highestplayervalue} points. ");
                    WriteLine($"\n The Dealer had {highestnpcsuitamount} {highestnpcsuit} totaling {highestnpcvalue} points.");
                    WriteLine("You win!");
                }
                else if (highestplayervalue < highestnpcvalue) {
                    WriteLine($"You had {highestplayersuitamount} {highestplayersuit} totaling {highestplayervalue} points. ");
                    WriteLine($"\n The Dealer had {highestnpcsuitamount} {highestnpcsuit} totaling {highestnpcvalue} points.");
                    WriteLine("Dealer Wins");
                }
                else if (highestplayervalue == highestnpcvalue) {
                    WriteLine($"You had {highestplayersuitamount} {highestplayersuit} totaling {highestplayervalue} points. ");
                    WriteLine($"\n The Dealer had {highestnpcsuitamount} {highestnpcsuit} totaling {highestnpcvalue} points.");
                    WriteLine("Its A Draw!");
                }
                //compare the npc and player values

                WriteLine("\nPress Enter To Go Back To Game Selection Menu");
                Console.ReadLine();
            }

            
        }
        public void setbasecardvalues() {
            PlayercardA = Carddeck.DrawCard();
            PlayercardB = Carddeck.DrawCard();
            PlayercardC = Carddeck.DrawCard();
            PlayercardD = Carddeck.DrawCard();
            NpcCardA = Carddeck.DrawCard();
            NpcCardB = Carddeck.DrawCard();
            NpcCardC = Carddeck.DrawCard();
            NpcCardD = Carddeck.DrawCard();
        }

        public void valueofhighestsuits() { 
            if (playerheartvalue > highestplayervalue && playerheartamount >= 2) {
                highestplayervalue = playerheartvalue;
                highestplayersuit = "Hearts";
                highestplayersuitamount = playerheartamount ;

            }

            if (playerspadevalue > highestplayervalue && playerspadeamount >= 2) {
                highestplayervalue = playerspadevalue;
                highestplayersuit = "Spades";
                highestplayersuitamount = playerspadeamount;
            }

            if (playerclubvalue > highestplayervalue && playerclubamount >= 2) {
                highestplayervalue = playerclubvalue;
                highestplayersuit = "Clubs";
                highestplayersuitamount = playerclubamount;
            }

            if (playerdiamondvalue > highestplayervalue && playerdiamondamount >= 2) {
                highestplayervalue = playerdiamondvalue;
                highestplayersuit = "Diamonds";
                highestplayersuitamount = playerdiamondamount;
            }


            if (npcheartvalue > highestnpcvalue && npcheartamount >= 2) {
            highestnpcvalue = npcheartvalue;
                highestnpcsuit = "Hearts";
                highestnpcsuitamount= npcheartamount;
            }

            if (npcspadevalue > highestnpcvalue && npcspadeamount >= 2) {
            highestnpcvalue= npcspadevalue;
                highestnpcsuit = "Spades";
                highestnpcsuitamount= npcspadeamount;
            }

            if (npcsclubvalue > highestnpcvalue && npcsclubamount >=2) {
            highestnpcvalue = npcsclubvalue;
                highestnpcsuit = "Clubs";
                highestnpcsuitamount = npcsclubamount;
            }

            if (npcsdiamondvalue > highestnpcvalue && npcsdiamondamount >=2) {
                highestnpcvalue = npcsdiamondvalue;
                highestnpcsuit = "Diamonds";
                highestnpcsuitamount = npcsdiamondamount;
            }

        }

        public void Determinehighestvalues() {
            //this is code for finding the highest npc and player, first find out which suit the card belongs too
            if (PlayercardA.Suit == "Spades") {
                playerspadevalue = playerspadevalue + PlayercardA.Value;
                playerspadeamount++;
            }
            else if (PlayercardA.Suit == "Hearts") {
                playerheartvalue = playerheartvalue + PlayercardA.Value;
                playerheartamount++;
            }
            else if (PlayercardA.Suit == "Clubs") {
                playerclubvalue = playerclubvalue + PlayercardA.Value;
                playerclubamount++;
            }
            else if (PlayercardA.Suit == "Diamonds") {
           playerdiamondvalue = playerdiamondvalue + PlayercardA.Value;
                playerdiamondamount++;
            }

            if (PlayercardB.Suit == "Spades")
            {
               playerspadevalue = playerspadevalue + PlayercardB.Value;
                playerspadeamount++;
            }
            else if (PlayercardB.Suit == "Hearts")
            {
                playerheartvalue = playerheartvalue + PlayercardB.Value;
                playerheartamount++;
            }
            else if (PlayercardB.Suit == "Clubs")
            {
                playerclubvalue = playerclubvalue + PlayercardB.Value;
                playerclubamount++;
            }
            else if (PlayercardB.Suit == "Diamonds")
            {
               playerdiamondvalue = playerdiamondvalue + PlayercardB.Value;
                playerdiamondamount++;
            }

            if (PlayercardC.Suit == "Spades")
            {
               playerspadevalue = playerspadevalue + PlayercardC.Value;
                playerspadeamount++;
            }
            else if (PlayercardC.Suit == "Hearts")
            {
                playerheartvalue = playerheartvalue + PlayercardC.Value;
                playerheartamount++;
            }
            else if (PlayercardC.Suit == "Clubs")
            {
                playerclubvalue = playerclubvalue + PlayercardC.Value;
                playerclubamount++;
            }
            else if (PlayercardC.Suit == "Diamonds")
            {
                playerdiamondvalue = playerdiamondvalue + PlayercardC.Value;
                playerdiamondamount++;
            }

            if (PlayercardD.Suit == "Spades")
            {
                playerspadevalue = playerspadevalue + PlayercardD.Value;
                playerspadeamount++;
            }
            else if (PlayercardD.Suit == "Hearts")
            {
                playerheartvalue = playerheartvalue + PlayercardD.Value;
                playerheartamount++;
            }
            else if (PlayercardD.Suit == "Clubs")
            {
                playerclubvalue = playerclubvalue + PlayercardD.Value;
                playerclubamount++; 
            }
            else if (PlayercardD.Suit == "Diamonds")
            {
               playerdiamondvalue = playerdiamondvalue + PlayercardD.Value;
                playerdiamondamount++;
            }

            //this will do the exact same thing but for the Npc cards
            if (NpcCardA.Suit == "Spades") {
               npcspadevalue = npcspadevalue + NpcCardA.Value;
                npcspadeamount++;
            }
            else if (NpcCardA.Suit == "Hearts") {
                npcheartvalue = npcheartvalue + NpcCardA.Value;
                npcheartamount++;
            }
            else if (NpcCardA.Suit == "Clubs") {
            npcsclubvalue = npcsclubvalue + NpcCardA.Value;
                npcsclubamount++;
            }
            else if (NpcCardA.Suit == "Diamonds") {
             npcsdiamondvalue = npcsdiamondvalue + NpcCardA.Value;
                npcsdiamondamount++;
            }

            if (NpcCardB.Suit == "Spades")
            {
                npcspadevalue = npcspadevalue + NpcCardB.Value;
                npcspadeamount++;
            }
            else if (NpcCardB.Suit == "Hearts")
            {
               npcheartvalue = npcheartvalue + NpcCardB.Value;
                npcheartamount++;
            }
            else if (NpcCardB.Suit == "Clubs")
            {
               npcsclubvalue = npcsclubvalue + NpcCardB.Value;
                npcsclubamount++;
            }
            else if (NpcCardB.Suit == "Diamonds")
            {
               npcsdiamondvalue = npcsdiamondvalue + NpcCardB.Value;
                npcsdiamondamount++;
            }

            if (NpcCardC.Suit == "Spades")
            {
               npcspadevalue = npcspadevalue + NpcCardC.Value;
                npcspadeamount++;
            }
            else if (NpcCardC.Suit == "Hearts")
            {
                npcheartvalue = npcheartvalue + NpcCardC.Value;
                npcheartamount++;
            }
            else if (NpcCardC.Suit == "Clubs")
            {
               npcsclubvalue = npcsclubvalue + NpcCardC.Value;
                npcsclubamount++;
            }
            else if (NpcCardC.Suit == "Diamonds")
            {
                npcsdiamondvalue = npcsdiamondvalue + NpcCardC.Value;
                npcsdiamondamount++;
            }

            if (NpcCardD.Suit == "Spades")
            {
                npcspadevalue = npcspadevalue + NpcCardD.Value;
                npcspadeamount++;
            }
            else if (NpcCardD.Suit == "Hearts")
            {
               npcheartvalue = npcheartvalue + NpcCardD.Value;
                npcheartamount++;
            }
            else if (NpcCardD.Suit == "Clubs")
            {
                npcsclubvalue = npcsclubvalue + NpcCardD.Value;
                npcsclubamount++;
            }
            else if (NpcCardD.Suit == "Diamonds")
            {
                npcsdiamondvalue = npcsdiamondvalue + NpcCardD.Value;
                npcsdiamondamount++;
            }


        }


        public void Round()
        {
            //first part of every round is to show the player which cards they have in their hand 
            //and see if they want to continue or stick with the cards they have now
            Clear();
            WriteLine($"Your hand consists of the {PlayercardA.Name}, {PlayercardB.Name}, {PlayercardC.Name}, and the {PlayercardD.Name}");
            WriteLine("\nWould you like to compare this hand of cards with the dealers hand or would you like to swap out a card?");
            WriteLine("\nPlease press 1 to swap one of your cards, Please press 2 to compare your hand with the dealers");
            PlayerInput();
            if (playeranswer == "1") {
            //this code lets player swap one of their cards, need another input to decide which card they will swap
            Clear();
                PlayerCardChoice();
                
                WriteLine($"After drawing another card your hand consists of the {PlayercardA.Name}, {PlayercardB.Name}, {PlayercardC.Name}, and the {PlayercardD.Name}\n Press enter to move onto the next turn");
                ReadKey();
                TurnCounter++;
            }
            else if (playeranswer == "2")
            {
                //set the GameOver to True and also set TurnCounter to anything higher than 10 so it wont run again after the cards are compared
                TurnCounter = 10;
                GameOver = true;
            }
           

          
           


        }

        public void PlayerCardChoice()
        {
            WriteLine($"Which card will you swap? Type 1 for the {PlayercardA.Name}, 2 for the {PlayercardB.Name}, 3 for the {PlayercardC.Name}, or 4 for the {PlayercardD.Name}");
            string Input = Console.ReadLine();
            //int Input = nul;
            //bool playeranswer;
            if (Input == "1")
            {
                PlayercardA = Carddeck.DrawCard();
            }
            else if (Input == "2")
            {
                PlayercardB= Carddeck.DrawCard();
            }
            else if (Input == "3")
            {
               PlayercardC= Carddeck.DrawCard();
            }
            else if (Input == "4")
            {
                PlayercardD= Carddeck.DrawCard();
            }
            else
            {
                Console.WriteLine("That is not a option please retry");
                Console.ReadKey();
                Console.Clear();
                PlayerCardChoice();
            }


        }
        public void PlayerInput()
        {
            string Input = Console.ReadLine();
            //int Input = nul;
            //bool playeranswer;
            if (Input == "1")
            {
                playeranswer = "1";
            }
            else if (Input == "2")
            {
                playeranswer = "2";
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
   



