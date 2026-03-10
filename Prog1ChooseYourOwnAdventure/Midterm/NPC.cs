using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm
{
    public class NPC
    {
        //This whole class is a second "player" , they choose the cave the user didnt and I want a random
        //number generator to decide how many "treasures" they find, it will have to match the users maximum of three
        protected int AmountOfTreasure;
        protected string NPCName;
        protected int LowerLimitAuctionValue;
        protected int UpperLimitAuctionValue;

        public NPC()
        {
        
        
        
        }

        public int GetTreasureAmount
        {
            get { return this.AmountOfTreasure; }
        
        }

        public string GetNPCName {

        get { return this.NPCName; }
        }

        public int GetLowerLimit
        {

            get { return this.LowerLimitAuctionValue; }

        }

        public int GetUpperLimit
        {

            get { return this.UpperLimitAuctionValue; }

        }

        public int AuctionTreasureValue(int min, int max)
        {
            LowerLimitAuctionValue = min;
            UpperLimitAuctionValue = max;
            Random random = new Random();
            return random.Next(min, max);
            

        }

    }
}
