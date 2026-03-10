using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm
{
    public class Player
    {
        //Variable to store player name
         string userName;

        int playerHealth;

        public Player(string playername)
        {
            this.userName = playername;
            this.playerHealth = 2;
            
        }
        public string GetName
        {
            get { return this.userName; }

        }
      
        public void LoseHealth()
        {
            playerHealth = playerHealth - 1;
            if (playerHealth == 0) {
                LeaveCave();
            
            }


        }

        public void LeaveCave()
        {
            Clear();
            WriteLine("Your injuries have become far too severe.\nYou're forced to leave the cave, bringing nothing found with you.");
            //WriteLine("Maybe put in another line of code that essentially says, NpcChoice reunites with you, flaunting the NpcChoice.Treasureamount pieces of treasure they found");
            Game game = new Game();
            game.Exit();

        }

      

    }
}
