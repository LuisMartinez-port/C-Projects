using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //set the title of the console window
            Console.Title = "Golden Grotto";

            //instantiate a new Game object

            Game myGame = new Game();

            //this will start the game
            myGame.Start();

            Console.ReadLine();
        }
    }
}
