using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Gorgon:NPC
    {
        public Gorgon(string _name) : base(_name) {
            this.Name = _name;
            this.Species = "Gorgon";
            this.MessageToPlayer = $"\n\nWelcome to the Forest says {this.Name} the {this.Species}. It's nice to finally have a visitor, take this Telescope with you and turn to the Ruined Town next.";

            this.tradeItem.Name = "pommel";
        }
    }
}
