using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class World
    {
        //think of the world class as the overarching class of everything else, it should have access
        //to pretty much everything

        //instantiate a new Player
        public Player player1 = new Player();

        //instantiate a list of locations inside of the world
        public List<Location> LocationsList = new List<Location>();
        
        //instantiate a list of NPC's inside of the world
        public List<NPC> NPCList = new List<NPC>();

        //create a method that will populate our list of Locations 
        public void setUpLocations()
        {
            LocationsList.Add(new Location("Village"));
            LocationsList.Add(new Location("Forest"));
            LocationsList.Add(new Location("Ruined Town"));
            LocationsList.Add(new Location("Cave"));
        }

        //create a method that will populate our list of NPCs

        public void setUpNPC()
        {

            NPCList.Add(new Gremlin("Adrian"));
            NPCList.Add(new Gorgon("Gabi"));
            NPCList.Add(new Goblin("Kaep"));
            NPCList.Add(new Gnome("Brandon"));
        }
    }
}
