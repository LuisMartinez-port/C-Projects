using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Wrestling : Sport
    {
        
        public Wrestling() : base("Wrestling", "Fake Fighting") 
        {
            Players.Add(new Player("Nic Nemeth", 21));
            Players.Add(new Player("Will Ospreay", 37));
        }
    }
}
