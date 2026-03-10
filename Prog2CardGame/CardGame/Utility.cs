using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Utility
    {

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        public static string GetPlayerChoice() => Console.ReadLine();

        public static void Pause()
        {
            Print("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
