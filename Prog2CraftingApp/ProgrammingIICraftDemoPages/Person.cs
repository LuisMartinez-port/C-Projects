using PROJECT2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemoPages
{
    public class Person: Iaction
    {

        public string PersonName = "Anonymous";
        public double PersonCurrency = 0.00;
        public List<Item> CraftedItems = new List<Item>();
        public List<Item> Inventory = new List<Item>();

     //   public List<Recipe> RecipeList = new List<Recipe>();


        public string GetInventoryItemList()
        {
            string output = PersonName;
            foreach (Item item in Inventory)
            {
                output += $"* {item.GetItemDescription()}";
            }
            return output;
        }


        public void AddToInventory(List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                foreach (Item item in recipe.RecipeRequirements)
                {
                    if (!changeItemAmount(item, item.ItemAmount))
                    {
                        AddItem(item);

                    }

                }

            }

        }
        //public string GetVendorInventoryItemList()
        //{
        //    int recipenum = 1;
        //    string output = PersonName;
        //    foreach (Item item in VendorInventory)
        //    {
        //        output += $"{recipenum}:     {item.GetItemDescription()}";
        //        recipenum++;
        //    }
        //    return output;
        //}

        public int CheckForItem(Item item)
        {
            for (int i = 0; i < Inventory.Count(); i++)
            {
                if (Inventory[i].ItemName == item.ItemName)
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddItem(Item item)// make sure that item amount is 1
        {
            //check if the time is already in the inventory
            int itemindex = CheckForItem(item);

            if (itemindex != -1)
            {
                Inventory[itemindex].ItemAmount++;
            }
            else
            {
                Inventory.Add(item);
            }

        }

        //public void AddVendorItem(Item item)// make sure that item amount is 1
        //{
        //    //check if the time is already in the inventory
        //    int itemindex = CheckForItem(item);

        //    if (itemindex != -1)
        //    {
        //        VendorInventory[itemindex].ItemAmount++;
        //    }
        //    else
        //    {
        //       VendorInventory.Add(item);
        //    }

        //}


        public bool changeItemAmount(Item item, double amount) 
        {
            int itemindex = CheckForItem(item);
            if (itemindex != -1) 
            {
                Inventory[itemindex].ItemAmount += amount;
                return true;
            }

            return  false;
        }

        public void Buy(Item item, Person person)
        {
 

        }

        public void Sell(Item item, Person person)
        {
            //will only add the item that was bought to the players inventory and remove that item from the vendors inventory
            //remove from vender 
            //PInventory.Remove(item);
            int num = CheckForItem(item);
            changeItemAmount(Inventory[num], -1);
            num = person.CheckForItem(item);
            if (num == -1)
            {
                person.Inventory.Add(item);

            }
            else
            {

                person.changeItemAmount(person.Inventory[num], 1);

            }

            //PInventory.Add(item);

        }



        //sell method 
        //item.amount --
        //player currency ++
    }
}
