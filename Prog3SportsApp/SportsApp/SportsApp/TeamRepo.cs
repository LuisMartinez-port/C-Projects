using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class TeamRepo : iTeamRepo 
    {
        private List<Team> teams = new List<Team>();

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public Team? GetTeamByName(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }
        public IEnumerable<Team> GetTeamsBySport(Sport sport) {

            return teams.Where(t => t.Sport == sport);
        }
        public List<Team> GetAllTeams()
        {
            return teams;
        }

        public void LoadTeamsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        var teamName = parts[0];
                        var sportName = parts[1];
                        var team = new Team(teamName, new StreetBall());
                        AddTeam(team);
                    }
                }
            }
        }
    }
}
