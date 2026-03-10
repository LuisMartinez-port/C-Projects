using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Inventory
    {
        //This class will contain a list which I add treasure too, at the end print out a list of the treassure
        //the player found, also will be used to run my auction at the end of the game.

        public List<string> TreasureList = new List<string>();

        public List<string> TreasureDescription = new List<string>();

        //create a method to add an item

        public void AddTreasureList(string _item)
        {
            TreasureList.Add(_item);
        
        }

        public void AddTreasureDescription(string _description)
        {

            TreasureDescription.Add(_description);

        }
    }
}
