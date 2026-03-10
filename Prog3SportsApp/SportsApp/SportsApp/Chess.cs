using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Chess : Sport
    {
        public Chess() : base("Chess", "Nerd Brain Game") 
        {
            Players.Add(new Player("Jon Moxley", 1));
            Players.Add(new Player("Nathan Frazier", 45));
        }
    }
}
