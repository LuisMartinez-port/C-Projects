using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject.Utility;

namespace FinalProject
{
    public class Player
    {

        //create variables to assign to the player, these will change based off of input and the current location
        public string Name = "Player1";

        //List to represent the players Inventory
        public List<Item> InventoryList = new List<Item>();

        public Location CurrentLocation;

        //make a basic constructor and set some base values
        public Player()
        {

            CurrentLocation = new Location("Start");

            //give the player base items for their inventory
            InventoryList.Add(new Item("Map"));
            InventoryList.Add(new Item("Sword"));
            InventoryList.Add(new Item("Lunch"));
        }

        //as of now we can only add items to this inventory List through the player class
        //lets make a method that lets us do this outside of the class
        
        public void AddItemToInventory(string _Itemname)
        {

            InventoryList.Add(new Item(_Itemname));
        }

        //make another method that will update the information in the playerInformationBox
        public string GetPlayerInfo()
        {

            string output = "";

            //we will append information to "OUTPUT" 
            output += $"{this.Name} {Environment.NewLine}";

            output += $"Location: {this.CurrentLocation.name} {Environment.NewLine} Inventory: {Environment.NewLine}";

            //output of inventory
            //output +=
            output += GetAllItemNames(InventoryList);

            //return the values stored in output var
            return output;
        }

    }
}
