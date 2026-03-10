using PROJECT2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProgrammingIICraftDemoPages
{
    public class Player : Person, Iaction
    {
       
     
        private bool itemIsInInventory(List<Item> list, string name) 
        {
            foreach (Item i in list)
            {
                if (i.ItemName.ToLower() == name.ToLower())
                {
                    return true;
                }
            }

            return false;
        
        }
        //item.amount -- 
        //public void AddToInventory(List<Recipe> recipes)
        //{
        //    foreach (Recipe recipe in recipes)
        //    { 
        //        foreach(Item item in recipe.RecipeRequirements) 
        //        {
        //            if (!changeItemAmount(item, item.ItemAmount)) 
        //            {
        //                AddItem(item);

        //            }

        //        }

        //    }
        //foreach (Item item in recipes)
        //{
        //    AddItem(item);

        //    //foreach (Item item in recipe.RecipeRequirements)
        //    //{
        //    //    AddItem(item);
        //    //We instantiated the recipe class inside of player and tried this but it didnt work

        //    // foreach (Item item in recipe) {
        //    //  AddItem(item);
        //    //WHY WHY WHY YOU SAY THIS CODE DONT WORK? WHAT? YOU SAY YOU CANT SEE THE ITEMS? WHAT? THEYRE RIGHT THERE! WHAT WHAT WHAT?  
        //    // }
        //}

       

        public void Buy(Item item, Person person) {
            //remove the currency from the players guala bank
            // The item that is being passed in MIGHT work if we pass in something like VendorInventory[index of the item in the inventory], something similar to whats in game class above the makeitem method 
            //BUT I THINK THIS SHOULD WORKKKKK

            PersonCurrency = PersonCurrency - item.ItemValue;
            //when calling pass through item,vendor/instances of vendor 
        }

        public void Sell(Item item, Person person) {
            //This method will only remove item from the inventory for the player
            //this should also be similar, where the item that we pass in will be with the index, which is given by the input the player gives when prompted
            Inventory.Remove(item);
            CraftedItems.Remove(item);

          

        
        }
        

        public Player() 
        {
        
            PersonCurrency = 75;

            PersonName = "Player:\n\n";
            //RecipeList = DataLoader.LoadRecipesFromExternalXMLFile("../../../data/recipes.xml");
            //AddToInventory(RecipeList);

        }
    }
}
        //make a sell method


  
