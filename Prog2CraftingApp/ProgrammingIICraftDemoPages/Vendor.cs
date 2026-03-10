using PROJECT2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemoPages
{
    public class Vendor : Person, Iaction
    {
        public Random random = new Random();
        public int placeholder;
        public Vendor()
        {
            PersonCurrency = 20.00;
            //VendorCurrency = 40.00; 
            PersonName = "Vendor:\n\n";

        }


        //be able to buy and sell with 
        // will probably need it own inventory 

        public void  Buy(Item item,Person person)
        {
            //this has to give currency to the player

            placeholder = random.Next(1, 10);
            //requires too much math, too sleepy to do math correct. do later
            if (placeholder < 8)
            {
                //regular price
                //sell at item.price or whatver its called
                PersonCurrency = PersonCurrency + item.ItemValue;
               person.PersonCurrency = person.PersonCurrency - item.ItemValue;

            }
            else if (placeholder < 10)
            {
                //slightly more profit 10% more, do item.price1.10 then sell

                PersonCurrency = PersonCurrency + (item.ItemValue * 1.10);
                person.PersonCurrency = person.PersonCurrency - (item.ItemValue * 1.10);
            }
            else
            {
                //can be anything higher than 12% imma do 25, should just be item.price 1.25 then sell
                PersonCurrency = PersonCurrency + (item.ItemValue * 1.25);
                person.PersonCurrency = person.PersonCurrency - (item.ItemValue * 1.25);
            }

        }

        public void Sell(Item item,Person person)
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



        //public void AddToInventory(List<Recipe> recipes)
        //{
        //    foreach (Recipe recipe in recipes)
        //    {
        //        foreach (Item item in recipe.RecipeRequirements)
        //        {
        //            if (!changeItemAmount(item, item.ItemAmount))
        //            {
        //                AddItem(item);

        //            }

        //        }

        //    }

        //}
    }
}
