using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Tyrone : NPC
    {

        public Tyrone() : base()
        {
            this.AmountOfTreasure = 3;
            this.NPCName = "Tyrone";
            this.UpperLimitAuctionValue = 8500;
            this.LowerLimitAuctionValue = 2500;


        }
        //this is a child class  of the NPC class
        //This class will have a uniwue amount of Treasure they can hold

    }
}
