using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Gremlin:NPC
    {
        public Gremlin(string _name):base(_name) {
            this.Name = _name;
            this.Species = "Gremlin";
            this.MessageToPlayer = $"\n\nWelcome to the village Lost one... says {this.Name} the {this.Species} You seem interesting, much more than this dull village\n" +
                "Take this... Free us from the Hydra... Make sure to stop by the Forest next";

            //give the gnome a trade item to give to the player

            this.tradeItem.Name = "Cross Guard";
        }
    }
}
