using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsApp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SportsTests
{
    [TestClass]
    public class TeamRepoTests
    {
        private TeamRepo _teamRepo;

        [TestInitialize]
        public void Setup()
        {
            _teamRepo = new TeamRepo();
        }

        [TestMethod]
        public void AddTeam_ShouldAddTeamToList()
        {
            // Arrange
            var team = new Team("Team A", new Sport("Soccer", "A popular sport"));

            // Act
            _teamRepo.AddTeam(team);

            // Assert
            Assert.IsTrue(_teamRepo.GetAllTeams().Contains(team));
        }

        [TestMethod]
        public void GetTeamByName_ShouldReturnCorrectTeam()
        {
            // Arrange
            var team = new Team("Team A", new Sport("Soccer", "A popular sport"));
            _teamRepo.AddTeam(team);

            // Act
            var result = _teamRepo.GetTeamByName("Team A");

            // Assert
            Assert.AreEqual(team, result);
        }

        [TestMethod]
        public void GetTeamByName_ShouldReturnNullIfTeamNotFound()
        {
            // Act
            var result = _teamRepo.GetTeamByName("Nonexistent Team");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTeamsBySport_ShouldReturnCorrectTeams()
        {
            // Arrange
            var sport = new Sport("Soccer", "A popular sport");
            var team1 = new Team("Team A", sport);
            var team2 = new Team("Team B", sport);
            var team3 = new Team("Team C", new Sport("Basketball", "A team sport"));
            _teamRepo.AddTeam(team1);
            _teamRepo.AddTeam(team2);
            _teamRepo.AddTeam(team3);

            // Act
            var result = _teamRepo.GetTeamsBySport(sport);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains(team1));
            Assert.IsTrue(result.Contains(team2));
        }

        [TestMethod]
        public void GetAllTeams_ShouldReturnAllTeams()
        {
            // Arrange
            var team1 = new Team("Team A", new Sport("Soccer", "A popular sport"));
            var team2 = new Team("Team B", new Sport("Basketball", "A team sport"));
            _teamRepo.AddTeam(team1);
            _teamRepo.AddTeam(team2);

            // Act
            var result = _teamRepo.GetAllTeams();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(team1));
            Assert.IsTrue(result.Contains(team2));
        }

        [TestMethod]
        public void LoadTeamsFromFile_ShouldLoadTeams()
        {
            // Arrange
            var filePath = "teams.txt";
            var lines = new[] { "Team A,Soccer", "Team B,Basketball" };
            File.WriteAllLines(filePath, lines);

            // Act
            _teamRepo.LoadTeamsFromFile(filePath);

            // Assert
            var result = _teamRepo.GetAllTeams();
            Assert.AreEqual(2, result.Count);
            Assert.IsNotNull(_teamRepo.GetTeamByName("Team A"));
            Assert.IsNotNull(_teamRepo.GetTeamByName("Team B"));

            // Cleanup
            File.Delete(filePath);
        }
    }
}

