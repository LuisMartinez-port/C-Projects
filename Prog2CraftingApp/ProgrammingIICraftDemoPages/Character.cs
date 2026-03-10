using ProgrammingIICraftDemoPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemoPages
{
    public class Character
    {
        public string PersonName = "Anonymous";
        public double PersonCurrency;
        public List<Item> Inventory = new List<Item>();
       public List<Item> CraftedItems = new List<Item>();

      public  Random random = new Random();
        public int Randplaceholder;
     

        public void setupCurrency()
        {
        foreach (Item item in Inventory) 
            {
                PersonCurrency = PersonCurrency + (item.ItemValue * item.ItemAmount);
            }
        }

        public string GetInventoryItemList(List<Item> listname)
        {

            string output = $"{PersonName}: \n\n";
            foreach (Item item in listname)
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

      

        public bool changeItemAmount(Item item, double amount)
        {
            int itemindex = CheckForItem(item);
            if (itemindex != -1)
            {
                Inventory[itemindex].ItemAmount += amount;
                return true;
            }

            return false;
        }

        public void Buy(Item item, Character character)
        {

          

        //this has to give currency to the player
            CraftedItems.Remove(item);

            int indextoremove = -1;

            for (int i = 0; i < Inventory.Count();i++)
            {
                if (item.ItemName == Inventory[i].ItemName) 
                {
                indextoremove = i;
                    break;
                }
            }
            Inventory.RemoveAt(indextoremove);
            //foreach (Item ingredient in Inventory)
            //{
            //    if (item.ItemName == ingredient.ItemName) 
            //    {
            //    item =
            //    }

            //}




        }

        public void randomProfitMargin(Item item) 
        {

          



           


            Randplaceholder = random.Next(1, 11);

            //requires too much math, too sleepy to do math correct. do later
            if (Randplaceholder < 4)
            {
                //regular price
                //sell at item.price or whatver its called
                PersonCurrency = PersonCurrency + item.ItemValue;


            }
            else if (Randplaceholder < 8)
            {
                //slightly more profit 10% more, do item.price1.10 then sell

                PersonCurrency = PersonCurrency + (item.ItemValue * 1.10);

            }
            else
            {
                //can be anything higher than 12% imma do 25, should just be item.price 1.25 then sell
                PersonCurrency = PersonCurrency + (item.ItemValue * 1.25);

            }
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

       
    }
}
