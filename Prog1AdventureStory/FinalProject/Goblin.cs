using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Goblin:NPC
    {
        public Goblin(string _name) : base(_name) {
            this.Name = _name;
            this.Species = "Goblin";
            this.MessageToPlayer = $"\n\nWHO GOES THERE?!!\n You dare tresspass into the land of the GREAT {this.Name}. I should warn you, im the fiercest {this.Species} around.\n Since you pose no threat to me take these Running Boots and make your way to the cave next. ";

            this.tradeItem.Name = "Blade";

        }
    }
}
