using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsApp;
using System;

namespace SportsTests
{
    [TestClass]
    public class MatchTests
    {
        private Player _team1;
        private Player _team2;
        private DateTime _dateTime;

        [TestInitialize]
        public void Setup()
        {
            _team1 = new Player("Team 1", 1);
            _team2 = new Player("Team 2", 2);
            _dateTime = DateTime.Now;
        }

        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Act
            var match = new Match(_team1, _team2, _dateTime);

            // Assert
            Assert.AreEqual(_team1, match.Team1);
            Assert.AreEqual(_team2, match.Team2);
            Assert.AreEqual(_dateTime, match.DateTime);
            Assert.AreEqual(0, match.Team1Score);
            Assert.AreEqual(0, match.Team2Score);
            Assert.IsNull(match.Winner);
        }

        [TestMethod]
        public void UpdateScore_ShouldUpdateScores()
        {
            // Arrange
            var match = new Match(_team1, _team2, _dateTime);

            // Act
            match.UpdateScore(3, 2);

            // Assert
            Assert.AreEqual(3, match.Team1Score);
            Assert.AreEqual(2, match.Team2Score);
        }

        [TestMethod]
        public void UpdateScore_ShouldSetWinner_WhenTeam1Wins()
        {
            // Arrange
            var match = new Match(_team1, _team2, _dateTime);

            // Act
            match.UpdateScore(3, 2);

            // Assert
            Assert.AreEqual(_team1, match.Winner);
            Assert.AreEqual(1, _team1.Wins);
            Assert.AreEqual(1, _team2.Losses);
        }

        [TestMethod]
        public void UpdateScore_ShouldSetWinner_WhenTeam2Wins()
        {
            // Arrange
            var match = new Match(_team1, _team2, _dateTime);

            // Act
            match.UpdateScore(2, 3);

            // Assert
            Assert.AreEqual(_team2, match.Winner);
            Assert.AreEqual(1, _team2.Wins);
            Assert.AreEqual(1, _team1.Losses);
        }

        [TestMethod]
        public void MatchDescription_ShouldReturnCorrectDescription()
        {
            // Arrange
            var match = new Match(_team1, _team2, _dateTime);

            // Act
            var description = match.MatchDescription;

            // Assert
            Assert.AreEqual($"{_team1.Name} vs {_team2.Name} on {_dateTime:MM-dd-yyyy}", description);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectString()
        {
            // Arrange
            var match = new Match(_team1, _team2, _dateTime);
            match.UpdateScore(3, 2);

            // Act
            var result = match.ToString();

            // Assert
            Assert.AreEqual($"{_dateTime:MM-dd-yyyy}: {_team1.Name} vs {_team2.Name} - Score: 3:2 | Winner: {_team1.Name}", result);
        }
    }
}

