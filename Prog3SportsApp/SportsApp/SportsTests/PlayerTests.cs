using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsApp;

namespace SportsTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string name = "John Doe";
            int number = 10;

            // Act
            var player = new Player(name, number);

            // Assert
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(number, player.Number);
            Assert.AreEqual(0, player.Wins);
            Assert.AreEqual(0, player.Losses);
            Assert.AreEqual(0, player.MatchesPlayed);
        }

        [TestMethod]
        public void Constructor_WithStats_ShouldInitializeProperties()
        {
            // Arrange
            string name = "John Doe";
            int number = 10;
            int wins = 5;
            int losses = 3;
            int matches = 8;

            // Act
            var player = new Player(name, number, wins, losses, matches);

            // Assert
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(number, player.Number);
            Assert.AreEqual(wins, player.Wins);
            Assert.AreEqual(losses, player.Losses);
            Assert.AreEqual(matches, player.MatchesPlayed);
        }

        [TestMethod]
        public void UpdateStats_ShouldIncrementMatchesPlayed()
        {
            // Arrange
            var player = new Player("John Doe", 10);

            // Act
            player.UpdateStats(true);

            // Assert
            Assert.AreEqual(1, player.MatchesPlayed);
        }

        [TestMethod]
        public void UpdateStats_ShouldIncrementWins_WhenIsWinIsTrue()
        {
            // Arrange
            var player = new Player("John Doe", 10);

            // Act
            player.UpdateStats(true);

            // Assert
            Assert.AreEqual(1, player.Wins);
            Assert.AreEqual(0, player.Losses);
        }

        [TestMethod]
        public void UpdateStats_ShouldIncrementLosses_WhenIsWinIsFalse()
        {
            // Arrange
            var player = new Player("John Doe", 10);

            // Act
            player.UpdateStats(false);

            // Assert
            Assert.AreEqual(0, player.Wins);
            Assert.AreEqual(1, player.Losses);
        }
    }
}

