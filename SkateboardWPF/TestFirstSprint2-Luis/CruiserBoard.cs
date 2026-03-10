using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public class CruiserBoard :Skateboards
    {
      public  CruiserBoard() {
            trucks.width = 9;
            trucks.height = 5;
            Deck.Width = 9;
            Deck.Brand = "Powell Peralta";
            wheels.Diameter = 60;
            wheels.Durometer = 78;
            CurrentSpeed = 0;
            TopSpeed = 70;
            defaultPushSpeed = 10;
        
        }

    }
}
