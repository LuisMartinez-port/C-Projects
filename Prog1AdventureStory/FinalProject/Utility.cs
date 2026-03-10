using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Utility
    {

        //create a method to enumerate each item name in a list

        public static string GetAllItemNames(List<Item> _inputList)
        {
            //create an output var that will be returned by the method

            string output = "";

            //create a for each loop to enumerate the names of items in a list

            foreach (Item i in _inputList)
            {
                output += $"     - {i.Name}{Environment.NewLine}";


            }


            return output;

        }
    }
}
