using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Location
    {
        public string name;
        public string description;

        //var to track if the player has visited a location
        public bool explored = false;

        public Location() { }

        public Location(string _name)
        {

            this.name = _name;
        }
    }
}
