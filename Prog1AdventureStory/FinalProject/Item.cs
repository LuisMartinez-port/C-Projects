using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FinalProject
{
    public class Item
    {

        //this class is meant to give both the player and the NPC's Items
        //first we need a var for the Item name
        public string Name;
        //create a simple constructor
        public Item()
        {
            //we dont need to put anthing in here this is just so when we instantiate a new instance of 
            //an item in a class it knows it exists without requiring a name input 
        }

        //create an overloaded constructor that takes an input for the Item name
        public Item(string _name)
        {
            this.Name = _name;
            //this assigns the input we put in _name to the Name variable
        }
    }
}
