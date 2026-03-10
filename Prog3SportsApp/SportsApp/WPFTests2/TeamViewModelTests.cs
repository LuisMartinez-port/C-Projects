using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsApp;
using SportsWPF.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SportsWPF.Tests.ViewModels
{
    [TestClass]
    public class TeamViewModelTests
    {
        private Mock<iSportsRepo> _mockSportsRepo;
        private Mock<iTeamRepo> _mockTeamRepo;
        private TeamViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockSportsRepo = new Mock<iSportsRepo>();
            _mockTeamRepo = new Mock<iTeamRepo>();

            _mockSportsRepo.Setup(repo => repo.GetAllSports()).Returns(new List<Sport>());
            _mockTeamRepo.Setup(repo => repo.GetTeamByName(It.IsAny<string>())).Returns((Team)null);

            _viewModel = new TeamViewModel(_mockSportsRepo.Object, _mockTeamRepo.Object);
        }

        [TestMethod]
        public void AddPlayerCommand_ShouldAddPlayer()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            _viewModel.SelectedSport = sport;
            _viewModel.NewPlayerName = "John Doe";
            _viewModel.NewPlayerNumber = 10;

            // Act
            _viewModel.AddPlayerCommand.Execute(null);

            // Assert
            _mockTeamRepo.Verify(repo => repo.AddTeam(It.IsAny<Team>()), Times.Once);
            Assert.AreEqual(string.Empty, _viewModel.NewPlayerName);
            Assert.AreEqual(0, _viewModel.NewPlayerNumber);
        }

        [TestMethod]
        public void SelectedSport_ShouldSetPlayers()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport",true);
            var player = new Player("John Doe", 10);
            sport.Players.Add(player);

            // Act
            _viewModel.SelectedSport = sport;

            // Assert
            Assert.AreEqual(1, _viewModel.SportPlayers.Count);
            Assert.AreEqual("John Doe", _viewModel.SportPlayers.First().Name);
        }

        [TestMethod]
        public void SelectedSport_ShouldSetPracticeTeamPlayers()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport",true);
            var team = new Team("Soccer", sport);
            var player = new Player("John Doe", 10);
            team.AddPlayer(player);
            _mockTeamRepo.Setup(repo => repo.GetTeamByName(sport.Name)).Returns(team);

            // Act
            _viewModel.SelectedSport = sport;

            // Assert
            Assert.AreEqual(1, _viewModel.PracticeTeamPlayers.Count);
            Assert.AreEqual("John Doe", _viewModel.PracticeTeamPlayers.First().Name);
        }

        [TestMethod]
        public void NewPlayerName_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewPlayerName))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewPlayerName = "Jane Doe";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void NewPlayerNumber_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewPlayerNumber))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewPlayerNumber = 11;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void CanAddPlayer_ShouldReturnTrue_WhenAllConditionsAreMet()
        {
            // Arrange
            _viewModel.NewPlayerName = "John Doe";
            _viewModel.NewPlayerNumber = 10;

            // Act
            var canAddPlayer = _viewModel.AddPlayerCommand.CanExecute(null);

            // Assert
            Assert.IsTrue(canAddPlayer);
        }

        [TestMethod]
        public void CanAddPlayer_ShouldReturnFalse_WhenConditionsAreNotMet()
        {
            // Arrange
            _viewModel.NewPlayerName = string.Empty;
            _viewModel.NewPlayerNumber = 0;

            // Act
            var canAddPlayer = _viewModel.AddPlayerCommand.CanExecute(null);

            // Assert
            Assert.IsFalse(canAddPlayer);
        }
    }
}


