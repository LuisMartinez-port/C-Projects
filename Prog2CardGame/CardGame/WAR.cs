using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class War : Game
    {
        private int ValueOfOpponentsCard;
        public War() : base()
        {
            this.Name = "War";
            this.AmountOfCardsInGame = 0;
            this.StartingHandOfCards = 0;
            this.RulesOfGame = "Whatever the rules are";


        }

        private void PlaceCard() { }

        private void WhichCardValueIsHigher() { }

    }
}
