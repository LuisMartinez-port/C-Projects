using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Sport: iSport, Iaddable
    {
        public string Name { get; protected set; }
        public string Description { get; set; }

        public List<Player> Players { get;  set; }

        public bool IsUserDefined { get; set; }

        public Sport(string name, string description)
        {
            Name = name;
            Description = description;
            Players = new List<Player>();
        }

        public static Sport CreateSport(string name, string description, bool isUserDefined )
        {
            if (isUserDefined)
            {
                return new UserDefinedSport(name, description);
            }
            else
            {
               
                throw new NotImplementedException();
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

    }

}

