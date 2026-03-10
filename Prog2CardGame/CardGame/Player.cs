using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public int score = 0;

        public Player() { }

        //this will be a list of cards that the player currently has in their hand

        public List<Card> HandofCards = new List<Card>();
        
        public List<Card> NpcHand = new List<Card>();   
        
    }
}
