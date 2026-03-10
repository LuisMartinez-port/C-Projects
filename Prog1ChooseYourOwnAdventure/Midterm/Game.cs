using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm
{

    public class Game
    {
        string InputPlayerName;
        string caveName;
        string NPCcavename;
        int caveSelect;
        string UserInput;
        //this variable counts how many subsections of a cave the player has gone into, 
        int caveIncrement = 0;

        

        //make variable for deciding if they lose a health 
        //or just dont get a treasure when they pick the wrong path
        int WrongPathOutcome;
        int TotalPlayerAuctionAmount;
        int TotalNPCAuctionAmount;
        public void randomAssigner()
        {
            Random myrand1 = new Random();
            WrongPathOutcome=myrand1.Next(10);

        }
        
       
        


        
        //make a method to generate a random number for the players auction amount
        public int PlayerAuctionAmount(int min, int max)
        {
            Random PlayerAuctionRand = new Random();
            return PlayerAuctionRand.Next(min, max);
        }

        //instantiate the necessary classes
        Story storyline = new Story();
        Inventory inventory = new Inventory();


        Player player;
        NPC NPCSelection;
        
        public void Start()
        {
            //This essentially runs my whole game

            bool gameRunning = true;
            Gameart();
            ReadLine();
            Clear();
            while (gameRunning)
            {
                runMenu();
            }
        }

        public void runMenu()
        {
            WriteLine("\nPlease choose an option from the list below");
            WriteLine("Enter a number for your selection\n");
            WriteLine("1) Read through the instructions \n2) Play Game \n3) Read Credits \n4) Exit Game");
            
            int menuChoice = Convert.ToInt16(ReadLine());

            switch (menuChoice)
            {
                case 1:
                   Instructions();
                    
                    break;

                case 2:
                    PlayGame();
                    Exit();
                    break;

                case 3:
                    Credits();
                    break;

                case 4:
                    Exit();
                    break;

                default:
                    WriteLine("You didnt choose one of the provided options\n");
                    WriteLine("Please choose again");
                    runMenu();
                    break;
            }

        }

        public void Gameart()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(@"   ▄████  ▒█████    ██▓   ▓█████▄  ▓█████ ███▄    █        ▄████  ██▀███   ▒█████  ▄▄▄█████▓▄▄▄█████▓ ▒█████  
▒ ██▒ ▀█▒▒██▒  ██▒ ▓██▒   ▒██▀ ██▌ ▓█   ▀ ██ ▀█   █     ▒ ██▒ ▀█▒▓██ ▒ ██▒▒██▒  ██▒▓  ██▒ ▓▒▓  ██▒ ▓▒▒██▒  ██▒
░▒██░▄▄▄░▒██░  ██▒ ▒██░   ░██   █▌ ▒███  ▓██  ▀█ ██▒    ░▒██░▄▄▄░▓██ ░▄█ ▒▒██░  ██▒▒ ▓██░ ▒░▒ ▓██░ ▒░▒██░  ██▒
░░▓█  ██▓▒██   ██░ ▒██░   ░▓█▄   ▌ ▒▓█  ▄▓██▒  ▐▌██▒    ░░▓█  ██▓▒██▀▀█▄  ▒██   ██░░ ▓██▓ ░ ░ ▓██▓ ░ ▒██   ██░
░▒▓███▀▒░░ ████▓▒░▒░██████░▒████▓ ▒░▒████▒██░   ▓██░    ░▒▓███▀▒░░██▓ ▒██▒░ ████▓▒░  ▒██▒ ░   ▒██▒ ░ ░ ████▓▒░
 ░▒   ▒  ░ ▒░▒░▒░ ░░ ▒░▓   ▒▒▓  ▒ ░░░ ▒░ ░ ▒░   ▒ ▒      ░▒   ▒  ░ ▒▓ ░▒▓░░ ▒░▒░▒░   ▒ ░░     ▒ ░░   ░ ▒░▒░▒░ 
  ░   ░    ░ ▒ ▒░ ░░ ░ ▒   ░ ▒  ▒ ░ ░ ░  ░ ░░   ░ ▒░      ░   ░    ░▒ ░ ▒   ░ ▒ ▒░     ░        ░      ░ ▒ ▒░ 
░ ░   ░ ░░ ░ ░ ▒     ░ ░   ░ ░  ░     ░     ░   ░ ░     ░ ░   ░ ░  ░░   ░ ░ ░ ░ ▒    ░        ░      ░ ░ ░ ▒  
      ░      ░ ░  ░    ░     ░    ░   ░           ░           ░     ░         ░ ░                        ░ ░  
");
            WriteLine("\nPress Enter to continue...");
            ResetColor();
        }
         
        public void Credits()
        {
            Clear();
            WriteLine("Credits: \n");
            WriteLine("\nThis game has been programmed and designed by Luis Martinez.\n\nASCII art from texteditor.com");
            ReadLine();
            Clear();

        }

        private void Instructions()
        {
            Clear(); 
            WriteLine("Instructions:\n");
            WriteLine("\n Throughout this game you will be asked to input values that will send you down one of two caves.\n \n Depending on your choices you may receive Treasure, Nothing, or even be put in severe danger.\n \n Your goal is to collect as much treasure as possible and Auction it off to make more than your exploring partner. ");
            ReadLine();
            Clear();

        }

        public void Exit()
        {
            Environment.Exit(0);


        }
        
        public void GetNpcSelection()
        {
            Clear();
            WriteLine("\nPlease choose an option from the list below\n");
            WriteLine("Enter a number for your selection\n");

            WriteLine(storyline.contentArray[3]);

            int npcSelect = Convert.ToInt32(ReadLine());
            Clear();
            if (npcSelect == 1)
            {
                this.NPCSelection = new Tyrone();
            }
            else if (npcSelect == 2) 
            {
                this.NPCSelection = new Kyle();
            }
            else if (npcSelect == 3)
            {
                this.NPCSelection = new Alex();
            }
            else
            {
                Clear();
                WriteLine("You didnt choose one of the provided options");
                 GetNpcSelection();
            }
            
        }

        public void GetCaveSelection()
        {

            WriteLine(this.storyline.contentArray[6]);
             caveSelect = Convert.ToInt32(ReadLine());
            Clear();

            if (caveSelect == 1)
            {
                caveName = "Cave of Lost Souls";
                caveSelect = 1;
                NPCcavename = "Tavern of the Newts Alloy";
            }
            else if (caveSelect == 2)
            {
                caveName = "Tavern of the Newts Alloy";
                caveSelect = 2;
                NPCcavename = "Cave of Lost Souls";

            }
            else
            {
                Clear();
                WriteLine("You didnt choose one of the provided options\n");
                WriteLine("Please choose again\n");
                GetCaveSelection();
            }
           
        }
        private void PlayGame()
        {
            
            //might have to call my switch statement outside of scene 1 so the value for npc user chooses gets saved correctly
           scene1();
            scene2();
            scene3();
            if (caveIncrement == 3)
            {
                Clear();
                scene5();

            }
            else
            {
                scene4();
                scene5();
            }
            //psuedocode if caveincrement==3
            //run scene5 which would be ending
            //else run scene 4 which is last 

        }
        #region
        public void scene1q2recursion()
        {
            WriteLine(storyline.contentArray[10]);
            //Left or right subpath code
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "left")
            {
                Clear();
                //left subpath code
                WriteLine(storyline.contentArray[12]);
                inventory.AddTreasureList("The Spectral Lantern");
                inventory.AddTreasureDescription("A ghostly lantern that emits an ethereal glow, revealing hidden passages within the cave and allowing its bearer to communicate with the spirits dwelling within its depths," +
                    " offering guidance and protection");
                ReadLine();
            }
            else if (UserInput == "right")
            {
                randomAssigner();
                if (WrongPathOutcome >= 4)
                {
                    Clear();
                    WriteLine(storyline.contentArray[13]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    WriteLine(storyline.contentArray[14]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene1q2recursion();
            }
            caveIncrement++;
        }
        #endregion

        #region 
        public void scene1q1recursion()
        {
            WriteLine(storyline.contentArray[9]);
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath code
                WriteLine(storyline.contentArray[10]);
                //Left or right subpath code
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "left")
                {
                    Clear();
                    //left subpath code
                    WriteLine(storyline.contentArray[12]);
                    inventory.AddTreasureList("The Spectral Lantern");
                    inventory.AddTreasureDescription("A ghostly lantern that emits an ethereal glow, revealing hidden passages within the cave and allowing its bearer to communicate with the spirits dwelling within its depths," +
                        " offering guidance and protection");
                    ReadLine();
                }
                else if (UserInput == "right")
                {
                    randomAssigner();
                    if (WrongPathOutcome >= 4)
                    {
                        Clear();
                        WriteLine(storyline.contentArray[13]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        WriteLine(storyline.contentArray[14]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene1q2recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[11]);
                ReadLine();

            }
            else
            {
                Clear();
                scene1q1recursion();
            }
        }



        #endregion

        #region 
        public void scene1q3recursion()
        {
            WriteLine(storyline.contentArray[16]);
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath code
                WriteLine(storyline.contentArray[17]);
                //Left or right subpath code
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "right")
                {
                    Clear();
                    //right subpath code
                    WriteLine(storyline.contentArray[19]);
                    inventory.AddTreasureList("The Alchemist's Elixir Flask");
                    inventory.AddTreasureDescription("A beautifully crafted flask containing a shimmering liquid that bestows" +
                        " temporary alchemical powers upon the drinker, granting them the ability to transmute materials and concoct potent potions for a limited time.");
                    ReadLine();
                }
                else if (UserInput == "left")
                {
                    randomAssigner();
                    if (WrongPathOutcome <= 4)
                    {
                        Clear();
                        WriteLine(storyline.contentArray[20]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        WriteLine(storyline.contentArray[21]);
                        ReadLine();
                        player.LoseHealth();


                    }

                }
                else
                {
                    Clear();
                    scene1q4recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[18]);
                ReadLine();

            }
            else
            {
                Clear();
                scene1q3recursion();
            }
        }
    
        #endregion

        #region
        public void scene1q4recursion() {
            WriteLine(storyline.contentArray[17]);
            //Left or right subpath code
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "right")
            {
                Clear();
                //right subpath code
                WriteLine(storyline.contentArray[19]);
                inventory.AddTreasureList("The Alchemist's Elixir Flask");
                inventory.AddTreasureDescription("A beautifully crafted flask containing a shimmering liquid that bestows" +
                    " temporary alchemical powers upon the drinker, granting them the ability to transmute materials and concoct potent potions for a limited time.");
                ReadLine();
            }
            else if (UserInput == "left")
            {
                randomAssigner();
                if (WrongPathOutcome <= 4)
                {
                    Clear();
                    WriteLine(storyline.contentArray[20]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    WriteLine(storyline.contentArray[21]);
                    ReadLine();
                    player.LoseHealth();


                }

            }
            else
            {
                Clear();
                scene1q4recursion();
            }
            caveIncrement++;



        }
    
        #endregion
        public void scene1()
        {
            //setup code before the cave
            Clear();
            WriteLine(this.storyline.contentArray[0]);
            
            WriteLine(this.storyline.contentArray[1]);
            InputPlayerName = ReadLine();
             player = new Player(InputPlayerName);
           
            WriteLine($"\nYou tell the Groundskeeper your name is {this.player.GetName}");
            WriteLine("Press Enter to Continue...");
            ReadLine();
            Clear();
            WriteLine($" Groundskeeper:\nWell, It's great to meet you {this.player.GetName}, {this.storyline.contentArray[2]}");
            ReadLine();
            Clear();

            GetNpcSelection();
            Clear();
            
            WriteLine($"\n{this.storyline.contentArray[4]}{this.NPCSelection.GetNPCName} a wonderful choice");
            ReadLine();
            Clear();
            WriteLine($"Ahh, before you go {this.player.GetName}, {this.storyline.contentArray[5]}");

            GetCaveSelection();

            WriteLine($"You chose The {caveName}{storyline.contentArray[7]}{caveName}");
            ReadLine();

            //code for the actual cave section
            Clear();
            WriteLine($"You begin walking towards the {caveName} while {this.NPCSelection.GetNPCName} is walking towards {NPCcavename} "); 
            ReadLine();
            if (caveSelect == 1) {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Clear();
                WriteLine(storyline.contentArray[8]);
                Clear();
                WriteLine(storyline.contentArray[9]);
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath code
                    WriteLine(storyline.contentArray[10]);
                    //Left or right subpath code
                    UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower();
                    if (UserInput =="left")
                    {
                        Clear();
                        //left subpath code
                        WriteLine(storyline.contentArray[12]);
                        inventory.AddTreasureList("The Spectral Lantern");
                        inventory.AddTreasureDescription("A ghostly lantern that emits an ethereal glow, revealing hidden passages within the cave and allowing its bearer to communicate with the spirits dwelling within its depths," +
                            " offering guidance and protection");
                        ReadLine();
                    }
                    else if (UserInput == "right")
                    {
                        randomAssigner();
                        if (WrongPathOutcome >=4)
                        {
                            Clear();
                        WriteLine(storyline.contentArray[13]);
                            ReadLine();
                        }
                        else
                             {
                            Clear();
                        WriteLine(storyline.contentArray[14]);
                            ReadLine();
                            player.LoseHealth();
                            }

                    }
                    else
                    {
                        Clear();
                        scene1q2recursion();
                    }
                    caveIncrement++;
                   


                }
                else if (UserInput == "no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[11]);
                    ReadLine();
                   
                }
                else
                {
                    Clear();
                    scene1q1recursion();
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
                WriteLine(storyline.contentArray[15]);
                WriteLine(storyline.contentArray[16]);
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath code
                    WriteLine(storyline.contentArray[17]);
                    //Left or right subpath code
                    UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower();
                    if (UserInput == "right")
                    {
                        Clear();
                        //right subpath code
                        WriteLine(storyline.contentArray[19]);
                        inventory.AddTreasureList("The Alchemist's Elixir Flask");
                        inventory.AddTreasureDescription("A beautifully crafted flask containing a shimmering liquid that bestows" +
                            " temporary alchemical powers upon the drinker, granting them the ability to transmute materials and concoct potent potions for a limited time.");
                        ReadLine();
                    }
                    else if (UserInput == "left")
                    {
                        randomAssigner();
                        if (WrongPathOutcome <= 4)
                        {
                            Clear();
                            WriteLine(storyline.contentArray[20]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            WriteLine(storyline.contentArray[21]);
                            ReadLine();
                            player.LoseHealth();
                            
                            
                        }

                    }
                    else
                    {
                        Clear();
                        scene1q4recursion();
                    }
                    caveIncrement++;



                }
                else if (UserInput == "no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[18]);
                    ReadLine();

                }
                else
                {
                    Clear();
                    scene1q3recursion();
                }
            }

;           
           

            
        }

        #region

        public void scene2q1recursion()
        {
            WriteLine(storyline.contentArray[22]);
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath code
                WriteLine(storyline.contentArray[23]);
                //Left or right subpath code
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "left")
                {
                    Clear();
                    //Subpath find treasure code
                    WriteLine(storyline.contentArray[25]);
                    inventory.AddTreasureList("The Whispering Shard");
                    inventory.AddTreasureDescription("A shimmering crystal that stores the whispered secrets of long-forgotten souls, capable of imparting ancient knowledge and unlocking the mysteries of the cave, but also carrying a haunting resonance of the sorrows that have echoed through its walls.");
                    ReadLine();
                }
                else if (UserInput == "right")
                {
                    randomAssigner();
                    if (WrongPathOutcome >= 4)
                    {
                        Clear();
                        //dont lose health but no treasure
                        WriteLine(storyline.contentArray[26]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health and no treasure
                        WriteLine(storyline.contentArray[27]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene2q2recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[24]);
                ReadLine();
            }
            else
            {

                Clear();
                scene2q1recursion();
            }

        }
        #endregion


        #region

        public void scene2q2recursion()
        {
            WriteLine(storyline.contentArray[23]);
            //Left or right subpath code
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "left")
            {
                Clear();
                //Subpath find treasure code
                WriteLine(storyline.contentArray[25]);
                inventory.AddTreasureList("The Whispering Shard");
                inventory.AddTreasureDescription("A shimmering crystal that stores the whispered secrets of long-forgotten souls, capable of imparting ancient knowledge and unlocking the mysteries of the cave, but also carrying a haunting resonance of the sorrows that have echoed through its walls.");
                ReadLine();
            }
            else if (UserInput == "right")
            {
                randomAssigner();
                if (WrongPathOutcome >= 4)
                {
                    Clear();
                    //dont lose health but no treasure
                    WriteLine(storyline.contentArray[26]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health and no treasure
                    WriteLine(storyline.contentArray[27]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene2q2recursion();
            }
            caveIncrement++;



        }


        #endregion


        #region

        public void scene2q3recursion()
        {
            WriteLine(storyline.contentArray[28]);
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath yes code
                WriteLine(storyline.contentArray[29]);

                //ask to go left or right
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "left")
                {
                    Clear();
                    //Find treasure subpath code
                    WriteLine(storyline.contentArray[31]);
                    ReadLine();
                    inventory.AddTreasureList("The Newt's Satchel of Infinite Provisions:");
                    inventory.AddTreasureDescription("A magical satchel that continuously replenishes itself with " +
                        "delectable delicacies and refreshing beverages, ensuring that its bearer never goes hungry or thirsty while exploring the depths of the cave.");
                }
                else if (UserInput == "right")
                {
                    randomAssigner();
                    if (WrongPathOutcome <= 4)
                    {
                        Clear();
                        //No treasure but dont lose health
                        WriteLine(storyline.contentArray[32]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health
                        WriteLine(storyline.contentArray[33]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene2q4recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[30]);
                ReadLine();

            }
            else
            {

                Clear();
                scene2q3recursion();
            }
        }

    
        #endregion


        #region

        public void scene2q4recursion()
        {
            WriteLine(storyline.contentArray[29]);

            //ask to go left or right
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "left")
            {
                Clear();
                //Find treasure subpath code
                WriteLine(storyline.contentArray[31]);
                ReadLine();
                inventory.AddTreasureList("The Newt's Satchel of Infinite Provisions:");
                inventory.AddTreasureDescription("A magical satchel that continuously replenishes itself with " +
                    "delectable delicacies and refreshing beverages, ensuring that its bearer never goes hungry or thirsty while exploring the depths of the cave.");
            }
            else if (UserInput == "right")
            {
                randomAssigner();
                if (WrongPathOutcome <= 4)
                {
                    Clear();
                    //No treasure but dont lose health
                    WriteLine(storyline.contentArray[32]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health
                    WriteLine(storyline.contentArray[33]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene2q4recursion();
            }
            caveIncrement++;


        }
        #endregion
        public void scene2()
        {
            //same if else statement, different arrays and values

            if (caveSelect == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[22]);
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath code
                    WriteLine(storyline.contentArray[23]);
                    //Left or right subpath code
                    UserInput = Console.ReadLine();
                    UserInput.ToLower();
                    if (UserInput == "left")
                    {
                        Clear();
                        //Subpath find treasure code
                        WriteLine(storyline.contentArray[25]);
                        inventory.AddTreasureList("The Whispering Shard");
                        inventory.AddTreasureDescription("A shimmering crystal that stores the whispered secrets of long-forgotten souls, capable of imparting ancient knowledge and unlocking the mysteries of the cave, but also carrying a haunting resonance of the sorrows that have echoed through its walls.");
                        ReadLine();
                    }
                    else if (UserInput == "right")
                    {
                        randomAssigner();
                        if (WrongPathOutcome >= 4)
                        {
                            Clear();
                            //dont lose health but no treasure
                            WriteLine(storyline.contentArray[26]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health and no treasure
                            WriteLine(storyline.contentArray[27]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene2q2recursion();
                    }
                    caveIncrement++;



                }
                else if(UserInput =="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[24]);
                    ReadLine();
                }
                else
                {

                    Clear();
                    scene2q1recursion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[28]);
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath yes code
                    WriteLine(storyline.contentArray[29]);

                    //ask to go left or right
                    UserInput = Console.ReadLine();
                    UserInput.ToLower();
                    if (UserInput == "left")
                    {
                        Clear();
                        //Find treasure subpath code
                        WriteLine(storyline.contentArray[31]);
                        ReadLine();
                        inventory.AddTreasureList("The Newt's Satchel of Infinite Provisions:");
                        inventory.AddTreasureDescription("A magical satchel that continuously replenishes itself with " +
                            "delectable delicacies and refreshing beverages, ensuring that its bearer never goes hungry or thirsty while exploring the depths of the cave.");
                    }
                    else if (UserInput == "right")
                    {
                        randomAssigner();
                        if (WrongPathOutcome <= 4)
                        {
                            Clear();
                            //No treasure but dont lose health
                            WriteLine(storyline.contentArray[32]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health
                            WriteLine(storyline.contentArray[33]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene2q4recursion();
                    }
                    caveIncrement++;



                }
                else if(UserInput =="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[30]);
                    ReadLine();

                }
                else
                {

                    Clear();
                    scene2q3recursion();
                }
            }

        }
        #region
        public void scene3q1recursion()
        {
            WriteLine(storyline.contentArray[34]);
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath code
                WriteLine(storyline.contentArray[35]);
                //Left or right subpath code
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "right")
                {
                    Clear();
                    //Subpath find treasure code
                    WriteLine(storyline.contentArray[37]);
                    ReadLine();
                    inventory.AddTreasureList("The Veil of Shadows");
                    inventory.AddTreasureDescription("A tattered cloak that grants its wearer the ability to blend seamlessly into the darkness, enabling them to move unnoticed through the cavern's treacherous passages" +
                        " and evade the grasp of the malevolent entities that lurk within its depths.");
                }
                else if (UserInput == "left")
                {
                    randomAssigner();
                    if (WrongPathOutcome >= 4)
                    {
                        Clear();
                        //dont lose health but no treasure
                        WriteLine(storyline.contentArray[38]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health and no treasure
                        WriteLine(storyline.contentArray[39]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene3q2recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[36]);
                ReadLine();

            }
            else
            {
                Clear();
                scene3q1recursion();
            }
        }
        #endregion

        #region 
        public void scene3q2recursion() {
            WriteLine(storyline.contentArray[35]);
            //Left or right subpath code
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "right")
            {
                Clear();
                //Subpath find treasure code
                WriteLine(storyline.contentArray[37]);
                ReadLine();
                inventory.AddTreasureList("The Veil of Shadows");
                inventory.AddTreasureDescription("A tattered cloak that grants its wearer the ability to blend seamlessly into the darkness, enabling them to move unnoticed through the cavern's treacherous passages" +
                    " and evade the grasp of the malevolent entities that lurk within its depths.");
            }
            else if (UserInput == "left")
            {
                randomAssigner();
                if (WrongPathOutcome >= 4)
                {
                    Clear();
                    //dont lose health but no treasure
                    WriteLine(storyline.contentArray[38]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health and no treasure
                    WriteLine(storyline.contentArray[39]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene3q2recursion();
            }
            caveIncrement++;
        }
        #endregion

        #region
        public void scene3q3recursion()
        {
            WriteLine(storyline.contentArray[41]);

            //ask to go left or right
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "right")
            {
                Clear();
                //Find treasure subpath code
                WriteLine(storyline.contentArray[43]);
                ReadLine();
                inventory.AddTreasureList("The Amphibian's Brew Stein");
                inventory.AddTreasureDescription("A weathered stein adorned with intricate engravings depicting ancient rituals of the tavern's past patrons, capable of conjuring a frothy, rejuvenating brew that imbues the drinker with unparalleled agility and heightened senses for a short duration.");
            }
            else if (UserInput == "left")
            {
                randomAssigner();
                if (WrongPathOutcome <= 4)
                {
                    Clear();
                    //No treasure but dont lose health
                    WriteLine(storyline.contentArray[44]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health
                    WriteLine(storyline.contentArray[45]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene3q3recursion();
            }
            caveIncrement++;
        }
        #endregion

        #region
        public void scene3q4recursion()
        {
            WriteLine(storyline.contentArray[40]);
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath yes code
                WriteLine(storyline.contentArray[41]);

                //ask to go left or right
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "right")
                {
                    Clear();
                    //Find treasure subpath code
                    WriteLine(storyline.contentArray[43]);
                    ReadLine();
                    inventory.AddTreasureList("The Amphibian's Brew Stein");
                    inventory.AddTreasureDescription("A weathered stein adorned with intricate engravings depicting ancient rituals of the tavern's past patrons, capable of conjuring a frothy, rejuvenating brew that imbues the drinker with unparalleled agility and heightened senses for a short duration.");
                }
                else if (UserInput == "left")
                {
                    randomAssigner();
                    if (WrongPathOutcome <= 4)
                    {
                        Clear();
                        //No treasure but dont lose health
                        WriteLine(storyline.contentArray[44]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health
                        WriteLine(storyline.contentArray[45]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene3q3recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[42]);
                ReadLine();

            }
            else
            {
                Clear();
                scene3q4recursion();
            }
        }
        #endregion
        public void scene3()
        {
            //same if else, different values
            if (caveSelect == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[34]);
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath code
                    WriteLine(storyline.contentArray[35]);
                    //Left or right subpath code
                    UserInput = Console.ReadLine();
                    UserInput.ToLower();
                    if (UserInput == "right")
                    {
                        Clear();
                        //Subpath find treasure code
                        WriteLine(storyline.contentArray[37]);
                        ReadLine();
                        inventory.AddTreasureList("The Veil of Shadows");
                        inventory.AddTreasureDescription("A tattered cloak that grants its wearer the ability to blend seamlessly into the darkness, enabling them to move unnoticed through the cavern's treacherous passages" +
                            " and evade the grasp of the malevolent entities that lurk within its depths.");
                    }
                    else if (UserInput == "left")
                    {
                        randomAssigner();
                        if (WrongPathOutcome >= 4)
                        {
                            Clear();
                            //dont lose health but no treasure
                            WriteLine(storyline.contentArray[38]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health and no treasure
                            WriteLine(storyline.contentArray[39]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene3q2recursion();
                    }
                    caveIncrement++;



                }
                else if (UserInput =="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[36]);
                    ReadLine();

                }
                else
                {
                    Clear();
                    scene3q1recursion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[40]);
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath yes code
                    WriteLine(storyline.contentArray[41]);

                    //ask to go left or right
                    UserInput = Console.ReadLine();
                    UserInput.ToLower();
                    if (UserInput == "right")
                    {
                        Clear();
                        //Find treasure subpath code
                        WriteLine(storyline.contentArray[43]);
                        ReadLine();
                        inventory.AddTreasureList("The Amphibian's Brew Stein");
                        inventory.AddTreasureDescription("A weathered stein adorned with intricate engravings depicting ancient rituals of the tavern's past patrons, capable of conjuring a frothy, rejuvenating brew that imbues the drinker with unparalleled agility and heightened senses for a short duration.");
                    }
                    else if (UserInput == "left")
                    {
                        randomAssigner();
                        if (WrongPathOutcome <= 4)
                        {
                            Clear();
                            //No treasure but dont lose health
                            WriteLine(storyline.contentArray[44]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health
                            WriteLine(storyline.contentArray[45]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene3q3recursion();
                    }
                    caveIncrement++;



                }
                else if(UserInput =="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[42]);
                    ReadLine();

                }
                else
                {
                    Clear();
                    scene3q4recursion();
                }
            }


        }

        #region
        public void scene4q1recursion() {
            WriteLine(storyline.contentArray[46]);
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath code
                WriteLine(storyline.contentArray[47]);
                //Left or right subpath code
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower(); ;
                if (UserInput == "left")
                {
                    Clear();
                    //Subpath find treasure code
                    WriteLine(storyline.contentArray[49]);
                    ReadLine();
                    inventory.AddTreasureList("The Echoing Chalice");
                    inventory.AddTreasureDescription("An ornate chalice that resonates with the echoes of lost voices, granting the drinker the ability to understand the forgotten languages spoken within the cave and offering" +
                        " fleeting glimpses into the tragic tales of those who met their fate within its labyrinthine corridors.");
                }
                else if (UserInput == "right")
                {
                    randomAssigner();
                    if (WrongPathOutcome >= 4)
                    {
                        Clear();
                        //dont lose health but no treasure
                        WriteLine(storyline.contentArray[50]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health and no treasure
                        WriteLine(storyline.contentArray[51]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene4q2recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[48]);
                ReadLine();
            }
            else
            {
                Clear();
                scene4q1recursion();
            }
        }
        #endregion
        #region
        public void scene4q2recursion() {
            WriteLine(storyline.contentArray[47]);
            //Left or right subpath code
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower(); ;
            if (UserInput == "left")
            {
                Clear();
                //Subpath find treasure code
                WriteLine(storyline.contentArray[49]);
                ReadLine();
                inventory.AddTreasureList("The Echoing Chalice");
                inventory.AddTreasureDescription("An ornate chalice that resonates with the echoes of lost voices, granting the drinker the ability to understand the forgotten languages spoken within the cave and offering" +
                    " fleeting glimpses into the tragic tales of those who met their fate within its labyrinthine corridors.");
            }
            else if (UserInput == "right")
            {
                randomAssigner();
                if (WrongPathOutcome >= 4)
                {
                    Clear();
                    //dont lose health but no treasure
                    WriteLine(storyline.contentArray[50]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health and no treasure
                    WriteLine(storyline.contentArray[51]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene4q2recursion();
            }
            caveIncrement++;
        }
        #endregion
        #region
        public void scene4q3recursion()
        {//find subpath
            WriteLine(storyline.contentArray[52]);
            UserInput = Console.ReadLine();
            UserInput.ToLower();
            if (UserInput == "yes")
            {
                Clear();
                //subpath yes code
                WriteLine(storyline.contentArray[53]);

                //ask to go left or right
                UserInput = Console.ReadLine();
                UserInput = UserInput.ToLower();
                if (UserInput == "left")
                {
                    Clear();
                    //Find treasure subpath code
                    WriteLine(storyline.contentArray[55]);
                    ReadLine();
                    inventory.AddTreasureList("The Gilded Lute of Melodic Enchantment");
                    inventory.AddTreasureDescription("A gilded lute that, when played, fills the cave with enchanting melodies, lulling any creatures within earshot into a peaceful slumber and allowing the musician to move through the tavern undisturbed or to uncover hidden secrets.\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                }
                else if (UserInput == "right")
                {
                    randomAssigner();
                    if (WrongPathOutcome <= 4)
                    {
                        Clear();
                        //No treasure but dont lose health
                        WriteLine(storyline.contentArray[56]);
                        ReadLine();
                    }
                    else
                    {
                        Clear();
                        //lose health
                        WriteLine(storyline.contentArray[57]);
                        ReadLine();
                        player.LoseHealth();
                    }

                }
                else
                {
                    Clear();
                    scene4q4recursion();
                }
                caveIncrement++;



            }
            else if (UserInput == "no")
            {
                Clear();
                //dont want to go in subpath code
                WriteLine(storyline.contentArray[54]);
                ReadLine();
            }
            else
            {

                Clear();
                scene4q3recursion();
            }
        }
        #endregion
        #region
        public void scene4q4recursion()
        {
            WriteLine(storyline.contentArray[53]);

            //ask to go left or right
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();
            if (UserInput == "left")
            {
                Clear();
                //Find treasure subpath code
                WriteLine(storyline.contentArray[55]);
                ReadLine();
                inventory.AddTreasureList("The Gilded Lute of Melodic Enchantment");
                inventory.AddTreasureDescription("A gilded lute that, when played, fills the cave with enchanting melodies, lulling any creatures within earshot into a peaceful slumber and allowing the musician to move through the tavern undisturbed or to uncover hidden secrets.\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            }
            else if (UserInput == "right")
            {
                randomAssigner();
                if (WrongPathOutcome <= 4)
                {
                    Clear();
                    //No treasure but dont lose health
                    WriteLine(storyline.contentArray[56]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    //lose health
                    WriteLine(storyline.contentArray[57]);
                    ReadLine();
                    player.LoseHealth();
                }

            }
            else
            {
                Clear();
                scene4q4recursion();
            }
            caveIncrement++;
        }
        #endregion
        public void scene4()
        {
            //same if statement, different values, only scene that has a chance to not run if they go into three subsections before this
            if (caveSelect == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[46]);
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath code
                    WriteLine(storyline.contentArray[47]);
                    //Left or right subpath code
                    UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower(); ;
                    if (UserInput == "left")
                    {
                        Clear();
                        //Subpath find treasure code
                        WriteLine(storyline.contentArray[49]);
                        ReadLine();
                        inventory.AddTreasureList("The Echoing Chalice");
                        inventory.AddTreasureDescription("An ornate chalice that resonates with the echoes of lost voices, granting the drinker the ability to understand the forgotten languages spoken within the cave and offering" +
                            " fleeting glimpses into the tragic tales of those who met their fate within its labyrinthine corridors.");
                    }
                    else if (UserInput == "right")
                    {
                        randomAssigner();
                        if (WrongPathOutcome >= 4)
                        {
                            Clear();
                            //dont lose health but no treasure
                            WriteLine(storyline.contentArray[50]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health and no treasure
                            WriteLine(storyline.contentArray[51]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene4q2recursion();
                    }
                    caveIncrement++;



                }
                else if (UserInput=="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[48]);
                    ReadLine();
                }
                else
                {
                    Clear();
                    scene4q1recursion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
                //find subpath
                WriteLine(storyline.contentArray[52]);
                UserInput = Console.ReadLine();
                UserInput.ToLower();
                if (UserInput == "yes")
                {
                    Clear();
                    //subpath yes code
                    WriteLine(storyline.contentArray[53]);

                    //ask to go left or right
                    UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower();
                    if (UserInput == "left")
                    {
                        Clear();
                        //Find treasure subpath code
                        WriteLine(storyline.contentArray[55]);
                        ReadLine();
                        inventory.AddTreasureList("The Gilded Lute of Melodic Enchantment");
                        inventory.AddTreasureDescription("A gilded lute that, when played, fills the cave with enchanting melodies, lulling any creatures within earshot into a peaceful slumber and allowing the musician to move through the tavern undisturbed or to uncover hidden secrets.\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                    }
                    else if (UserInput == "right")
                    {
                        randomAssigner();
                        if (WrongPathOutcome <= 4)
                        {
                            Clear();
                            //No treasure but dont lose health
                            WriteLine(storyline.contentArray[56]);
                            ReadLine();
                        }
                        else
                        {
                            Clear();
                            //lose health
                            WriteLine(storyline.contentArray[57]);
                            ReadLine();
                            player.LoseHealth();
                        }

                    }
                    else
                    {
                        Clear();
                        scene4q4recursion();
                    }
                    caveIncrement++;



                }
                else if (UserInput =="no")
                {
                    Clear();
                    //dont want to go in subpath code
                    WriteLine(storyline.contentArray[54]);
                    ReadLine();
                }
                else
                {

                    Clear();
                    scene4q3recursion();
                }
            }


        }
        #region
        public void scene5q1recursion()
        {
            WriteLine($"{this.NPCSelection.GetNPCName}: So {this.player.GetName}, are you willing to auction off your treasure? \n\n I bet you cant make more money than me");
            WriteLine("\nType Yes to auction your treasure\nType No if you want to keep it");
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();

            if (UserInput == "no")
            {
                Clear();
                WriteLine($"{this.NPCSelection.GetNPCName}: {storyline.contentArray[58]}");
                ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Clear();
                WriteLine("YOU LOSE...");
            }
            else if (UserInput == "yes")
            {
                Clear();
                WriteLine(storyline.contentArray[59]);
                WriteLine($"You and {this.NPCSelection.GetNPCName} make your way to the auction hall");
                WriteLine(storyline.contentArray[60]);
                ReadLine();
                Clear();
                TotalNPCAuctionAmount = 0;
                for (int i = 0; i < this.NPCSelection.GetTreasureAmount; i++)
                {
                    TotalNPCAuctionAmount = TotalNPCAuctionAmount + NPCSelection.AuctionTreasureValue(NPCSelection.GetLowerLimit, NPCSelection.GetUpperLimit);
                }
                WriteLine($"{this.NPCSelection.GetNPCName}: After I auctioned off all my treasure I made: {TotalNPCAuctionAmount} from {NPCSelection.GetTreasureAmount} Treasure, How much did you make?");
                ReadLine();
                for (int i = 0; i < inventory.TreasureList.Count; i++)
                {
                    TotalPlayerAuctionAmount = TotalPlayerAuctionAmount + PlayerAuctionAmount(2750, 7500);
                }

                WriteLine($"I made: {this.TotalPlayerAuctionAmount} from {inventory.TreasureList.Count} Treasure");
                ReadLine();

                Clear();
                if (TotalPlayerAuctionAmount > TotalNPCAuctionAmount)
                {
                    WriteLine($"{this.NPCSelection.GetNPCName}: Dang, looks like you won this time. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine("\n YOU WIN...");

                }
                else if (TotalPlayerAuctionAmount == TotalNPCAuctionAmount)
                {
                    WriteLine($"{this.NPCSelection.GetNPCName}: We made the same amount???");

                    WriteLine("You win???");
                }
                else
                {

                    WriteLine($"{this.NPCSelection.GetNPCName}: Haha, I made more than you!\nYou should've known you never stood a chance against me!\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("\n YOU LOSE...");
                }

            }
            else
            {
                Clear();
                scene5q1recursion();
            }
        }
        #endregion
        public void scene5()
        {
            Clear();
            //this method is the final method, runs the random loops, compares the results then gives an official ending
            if (inventory.TreasureList.Count == 0 )
            {

                WriteLine($"\n{this.NPCSelection.GetNPCName}: HAHA, wow {this.player.GetName}, you didnt find any treasure? How can you auction off treasure if you dont have any?");

                ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Clear();
                WriteLine("\nGame Over...\n");
                Environment.Exit(0);
            }
            WriteLine($"{this.NPCSelection.GetNPCName}: Wow {this.player.GetName} you found {this.inventory.TreasureList.Count} Treasure.\n What are they? Do you know what they do?\n\n");
           for (int i = 0; i < inventory.TreasureList.Count; i++)
            {
                WriteLine(this.inventory.TreasureList[i]);
                WriteLine(this.inventory.TreasureDescription[i]);
                WriteLine("");
            }
            ReadLine();
            Clear();
            WriteLine($"{this.NPCSelection.GetNPCName}: So {this.player.GetName}, are you willing to auction off your treasure? \n\n I bet you cant make more money than me");
            WriteLine("\nType Yes to auction your treasure\nType No if you want to keep it");
            UserInput = Console.ReadLine();
            UserInput = UserInput.ToLower();

            if (UserInput == "no") {
                Clear();
                WriteLine($"{this.NPCSelection.GetNPCName}: {storyline.contentArray[58]}");
                ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Clear();
                WriteLine("YOU LOSE...");
            }
            else if (UserInput == "yes") 
            {
                Clear();
                WriteLine(storyline.contentArray[59]);
                WriteLine($"You and {this.NPCSelection.GetNPCName} make your way to the auction hall");
                WriteLine(storyline.contentArray[60]);
                ReadLine();
                Clear();
                TotalNPCAuctionAmount = 0;
                for (int i = 0; i < this.NPCSelection.GetTreasureAmount; i++)
                {
                    TotalNPCAuctionAmount = TotalNPCAuctionAmount + NPCSelection.AuctionTreasureValue(NPCSelection.GetLowerLimit, NPCSelection.GetUpperLimit);
                }
                WriteLine($"{this.NPCSelection.GetNPCName}: After I auctioned off all my treasure I made: {TotalNPCAuctionAmount} from {NPCSelection.GetTreasureAmount} Treasure, How much did you make?");
                ReadLine();
                for (int i = 0; i < inventory.TreasureList.Count; i++)
                {
                    TotalPlayerAuctionAmount = TotalPlayerAuctionAmount + PlayerAuctionAmount(2750,7500);
                }

                WriteLine($"I made: {this.TotalPlayerAuctionAmount} from {inventory.TreasureList.Count} Treasure");
                ReadLine();

                Clear();
                if (TotalPlayerAuctionAmount > TotalNPCAuctionAmount) {
                    WriteLine($"{this.NPCSelection.GetNPCName}: Dang, looks like you won this time. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine("\n YOU WIN...");

                }
                else if (TotalPlayerAuctionAmount == TotalNPCAuctionAmount)
                {
                    WriteLine($"{this.NPCSelection.GetNPCName}: We made the same amount???");

                    WriteLine("You win???");
                }
                else
                {

                    WriteLine($"{this.NPCSelection.GetNPCName}: Haha, I made more than you!\nYou should've known you never stood a chance against me!\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("\n YOU LOSE...");
                }

            }
            else
            {
                Clear();
                scene5q1recursion();
            }
            ReadLine();
            Environment.Exit(0);
        }



    }
}
