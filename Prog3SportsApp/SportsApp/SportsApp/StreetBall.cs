using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class StreetBall : Sport
    {
        public StreetBall() : base("StreetBall", "Basketball but you gamble money on your skil") 
        {
            Players.Add(new Player("John Morrison", 82));
            Players.Add(new Player("Joey Mercury", 75));
        }
    }
}
