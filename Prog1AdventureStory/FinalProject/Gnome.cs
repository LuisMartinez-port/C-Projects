using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Gnome:NPC
    {
        public Gnome(string _name) : base(_name) { 
        
            this.Name = _name;
            this.Species = "Gnome";
            this.MessageToPlayer = $"\n\nAhh Welcome young one... I am {this.Name} the king of all {this.Species}s, I see you require our assistance to defeat that nasty hydra once and for all. Take this Helmet, it should prove quite useful. By now you should have explored everything, return to the village and see what you may get.";

            this.tradeItem.Name = "Hilt";
        
        
        }
    }
}
