using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class NPC
    {
        //make my variables to describe the NPC and have another to assign them an Item to trade with the player
        public string Name;
        public string Species;
        public string MessageToPlayer;

        //this will be customizable for each of the NPCS and this is the Item that they will give the player
        public Item tradeItem = new Item();

        //create another basic constructor 
        public NPC()
        {
            //I could set default values here but for my game I dont think I'll require any

        }

        //create an overloaded constructor so we can give each NPC a unique name
        public NPC(string _name) {

            
            this.Name = _name;
        }

        //now we need a method that will actually allow the NPC's message to the player be put into text
        public string ReturnMessageToPlayer()
        {

            return this.MessageToPlayer;
        }
    }
}
