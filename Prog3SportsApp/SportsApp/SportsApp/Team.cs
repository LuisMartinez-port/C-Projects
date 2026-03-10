using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Team : iTeam, iStats
    {
        public string Name { get; set; }
        public List<Player> Players { get; private set; }
        public Sport Sport { get; private set; }
        public List<Match> Matches { get; private set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int MatchesPlayed { get; set; }

        public Team(string name, Sport sport)
        {
            Name = name;
            Sport = sport;
            Players = new List<Player>();
            Matches = new List<Match>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public void UpdateStats(bool isWin)
        {
            MatchesPlayed++;
            if (isWin) Wins++;
            else Losses++;
        }
    }
}
