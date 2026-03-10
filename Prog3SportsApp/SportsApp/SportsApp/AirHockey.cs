using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class AirHockey : Sport
    {
        public AirHockey() : base("Air Hockey", "Hockey for your hands") 
        {
            Players.Add(new Player("Kyle O'Reiley", 3));
            Players.Add(new Player("Adam Cole", 17));
        }
    }
}
