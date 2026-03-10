using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsApp;
using System.Collections.Generic;
using System.Linq;

namespace SportsTests
{
    [TestClass]
    public class SportsRepoTests
    {
        private SportsRepo _sportsRepo;

        [TestInitialize]
        public void Setup()
        {
            _sportsRepo = new SportsRepo();
        }

        [TestMethod]
        public void AddSport_ShouldAddSportToList()
        {
            // Arrange
            var sport = Sport.CreateSport("Basketball", "A team sport",true);

            // Act
            _sportsRepo.AddSport(sport);

            // Assert
            Assert.IsTrue(_sportsRepo.GetAllSports().Contains(sport));
        }

        [TestMethod]
        public void RemoveSport_ShouldRemoveSportFromList()
        {
            // Arrange
            var sport = Sport.CreateSport("Basketball", "A team sport",true);
            _sportsRepo.AddSport(sport);

            // Act
            _sportsRepo.RemoveSport(sport);

            // Assert
            Assert.IsFalse(_sportsRepo.GetAllSports().Contains(sport));
        }

        [TestMethod]
        public void GetAllSports_ShouldReturnAllSports()
        {
            // Act
            var sports = _sportsRepo.GetAllSports();

            // Assert
            Assert.AreEqual(4, sports.Count); // Assuming the constructor adds 4 sports
        }

        [TestMethod]
        public void UpdateSport_ShouldUpdateExistingSport()
        {
            // Arrange
            var sport = Sport.CreateSport("Basketball", "A team sport",true);
            _sportsRepo.AddSport(sport);
            var updatedSport = Sport.CreateSport("Basketball", "An updated team sport",true);
            updatedSport.Players = new List<Player> { new Player("John Doe", 10) };

            // Act
            _sportsRepo.UpdateSport(updatedSport);

            // Assert
            var existingSport = _sportsRepo.GetAllSports().FirstOrDefault(s => s.Name == "Basketball");
            Assert.IsNotNull(existingSport);
            Assert.AreEqual("An updated team sport", existingSport.Description);
            Assert.AreEqual(1, existingSport.Players.Count);
        }

        [TestMethod]
        public void UpdateSport_ShouldAddNewSportIfNotExists()
        {
            // Arrange
            var sport = Sport.CreateSport("Basketball", "A team sport", true);

            // Act
            _sportsRepo.UpdateSport(sport);

            // Assert
            Assert.IsTrue(_sportsRepo.GetAllSports().Contains(sport));
        }
    }
}
