using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ProgrammingIICraftDemoPages
{
    public class Game
    {

        public Person Player = new Player();

        public Person Vendor = new Vendor();

        public Character Other = new Character();
        public Character OtherVendor = new Character();


        public List<Recipe> Recipes = new List<Recipe>();

        public List<Recipe> RecipeList = new List<Recipe>();

        bool value;

       

        enum portionSize
        {
            tbsp,
            tsp,
            cup,
            whole,
            half,
            Gallon,
            Litre,
            Ounce,
            Gram
        }

        public Game()
        {
            Recipes = DataLoader.LoadRecipesFromExternalXMLFile("../../../data/recipes.xml");
            
            OtherVendor.AddToInventory(Recipes);

            

           RecipeList = DataLoader.LoadRecipesFromExternalXMLFile("../../../data/recipes.xml");

        }

        //make a method that will add every item that is in our recipe xml to the player inventory
     
        public string GetRecipeList(List<Recipe> listname)
        {
            int number = 1;
            string output = "Recipes:\n\n";
            foreach (Recipe recipe in listname)
            {
                output += $"  {number}. {recipe.GetRecipeDescription()}";
                number++;
            }
            return output;
            

        }

       

        public double ReturnAmount(Item item)//Get Item Amount
        {
            for (int i = 0; i < Player.Inventory.Count(); i++)
            {
                if (Player.Inventory[i].ItemName == item.ItemName)
                {
                    return Player.Inventory[i].ItemAmount;
                }
            }

            return -1;
        }

       

        public void RemoveItem(Item item,Character character)// make sure that item amount is 1
        {
            //check if the time is already in the inventory
            int itemindex = character.CheckForItem(item);

            if (itemindex != -1)
            {
                if(character.Inventory[itemindex].ItemAmount == 1)//see if there is only one 
                {
                    character.Inventory.RemoveAt(itemindex);
                }
                else
                {
                    character.Inventory[itemindex].ItemAmount = character.Inventory[itemindex].ItemAmount- item.ItemAmount;
                    if (character.Inventory[itemindex].ItemAmount == 0) 
                    {
                        character.Inventory.RemoveAt(itemindex);
                    }
                }
                
            }
            else
            {
                //No items to remove
            }

        }
        public void RemoveVendorItem(Item item)// make sure that item amount is 1
        {
            //check if the time is already in the inventory
            int itemindex = Vendor.CheckForItem(item);

            if (itemindex != -1)
            {
                if (Vendor.Inventory[itemindex].ItemAmount == 1)//see if there is only one 
                {
                    Vendor.Inventory.RemoveAt(itemindex);
                }
                else
                {
                    Vendor.Inventory[itemindex].ItemAmount--;
                }

            }
            else
            {
                //No items to remove
            }

        }


        // ask janell where to make delegate for print function, and if its possible to be able to select within the print function specifically which textblock the string gets
        //output to, so we only need one print method set up in main window, then in trade for example we do Print(Tradetextblock, "Whatever text we want in there");


        //this is for the recipe that the player selects, this is most likely going to be in the craft.xaml.cs. I THINK this works since there is a text box that I want to read in input from, then that input should theoretically get shoved
        //into the makeItem method, at least I think
        //selected recipe
        //input that player typed =inpuyt that player typed - 1
        //makeItem(recipes[input that player typed])


        public int makeItem(Recipe recipe,Character character)
        {
           
            foreach (Item recipeitem in recipe.RecipeRequirements)
            {
                if (isInInventory(recipeitem.ItemName, character) >= recipeitem.ItemAmount)
                {
                    //have janell verify this just in case i did it wrong and im stupid
                    value = true;
                    //good to go 
                }
                else 
                {
                    //this break should get out of the foreach and then lead to the else below being returned
                    value = false;
                    break;
                }
            }
            //foreach (Item i in  ) 
            //{
            //    itemIsInInventory(PlayerInventory, "");

            //}
            ////if all the required elements for the recipe are in the player's inventory
            //// AND the amounts of those elements are equal to or greater than what is specified in the recipe
            //// then remove the ingredient items from the player's inventory or modify the amounts of the items
            //// and return an instance of the Item class that matches the recipe
            ///


            //use an interface for the trade method, give it to vendor and player,
            //it will take in Item as a parameter and will trade away said item.
            //For the vendor the items traded will be the ingredients,
            //for the player it is crafted items
            if(value == true) 
            {
                character.Inventory.Add(new Item() { ItemName = recipe.RecipeName, ItemValue = recipe.RecipeValue, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType  });
                character.CraftedItems.Add(new Item() { ItemName = recipe.RecipeName, ItemValue = recipe.RecipeValue, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType });
                foreach (Item recipeitem in recipe.RecipeRequirements)
                {
                    RemoveItem(recipeitem, character);
                }
                    return 1;
            }
            else
            {
                return -1;

            }

            
           

        }
        private double isInInventory(string itemName, Character character)
        {   
            foreach(Item item in character.Inventory) 
            {
                if (item.ItemName.ToLower() == itemName.ToLower())
                {
                    return item.ItemAmount;
                
                }
            
            }
            return 0;
        
        }
  }   }
