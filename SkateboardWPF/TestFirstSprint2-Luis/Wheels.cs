using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public class Wheels
    {
        public int Durometer;
        //This is the "hardness" of the wheels, softer is usually better for rougher ground while harder wheels are better for skating in parks
        public int Diameter;

      

        public bool areRolling;

        public string About()
        {

            return $"{Diameter}mm in diameter and have a {Durometer} Durometer";
        }

        public void StartRolling()
        {
            this.areRolling = true;


        }
        public void StopRolling()
        {
           this.areRolling = false;
        }

    }
}
