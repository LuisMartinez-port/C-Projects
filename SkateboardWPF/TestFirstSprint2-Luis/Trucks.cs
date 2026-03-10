using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public class Trucks
    {
        public int width;
        public int height;
        public int TruckTightness;

        public string About() 
        {
            return $"have a width of {width} inches and a height of {height} inches";
        }


        public string Grind(string Surface, int Distance) 
        {
            if (TruckTightness > 100)
            {
               return "Your trucks are WAY too tight, Loosen them before you attempt to grind!!";
            }
            else if (TruckTightness < 30)
            {
                return"Your trucks are WAY too loose, tighten them before you attempt to grind!!";
            }
            else
            {
                return $"You grind on the {Surface} for a staggering {Distance} feet!!";
            }
            //make the test check for the surface and the distance, but when I break it in the return do like distance +2 or something to break it
        }

        public string TightenTrucks(int amount) 
        {
            if (TruckTightness + amount > 100)
            {
                TruckTightness += amount;
                return $"A truck tightness of {TruckTightness} is way too tight, it needs to be above 30 and below 100! Loosen them before you try anything else!";
                
            }
            else {
                TruckTightness += amount;
                return $"You tightened your trucks! They now have a tightness of {TruckTightness}";
            }

        }

        public string LoosenTrucks(int amount) 
        {
            if (TruckTightness - amount < 30)
            { 
            TruckTightness -= amount;
                return $"A truck tightness of {TruckTightness} is way too loose, it needs to be above 30 and below 100! You'll fall if you try to turn, make sure to tighten them before you try anything else!";
                //IMPORTANT
                //IMPORTANT
                //IMPORTANT
                //MAKE SURE THEY CANNOT DO ANYTHING ELSE BUT LOOSEN THE TRUCKS IF ITS TOO LOOSE
            }
            else
            {
                TruckTightness -= amount;
                return $"You loosened your trucks! They now have a tightness of {TruckTightness}";

            }
        }

    }
}
