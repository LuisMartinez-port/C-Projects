using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Player : Person, iPlayer, iStats
    {
        public int Number { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int MatchesPlayed { get; set; }

        public Player(string name, int number) : base(name)
        {
            Number = number;
        }
        public Player(string name, int number, int wins, int losses, int matches) : base(name)
        {
            Number = number;
            Wins = wins;
            Losses = losses;
            MatchesPlayed = matches;
        }

        public void UpdateStats(bool isWin)
        {
            MatchesPlayed++;
            if (isWin) Wins++;
            else Losses++;
        }
    }
}
