using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public class StreetBoard : Skateboards
    {
        public StreetBoard() {
            trucks.width = 8;
            trucks.height = 3;
            wheels.Durometer = 101;
            wheels.Diameter = 52;
            Deck.Width = 8;
            Deck.Brand = "APRIL";
            CurrentSpeed = 0;
            TopSpeed = 60;
            defaultPushSpeed = 5;
        }

    }
}
