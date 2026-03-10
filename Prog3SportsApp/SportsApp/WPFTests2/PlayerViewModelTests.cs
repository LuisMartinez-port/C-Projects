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
    public class PlayerViewModelTests
    {
        private Mock<iSportsRepo> _mockSportsRepo;
        private PlayerViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockSportsRepo = new Mock<iSportsRepo>();
            _mockSportsRepo.Setup(repo => repo.GetAllSports()).Returns(new List<Sport>());

            _viewModel = new PlayerViewModel(_mockSportsRepo.Object);
        }

        [TestMethod]
        public void AddPlayerCommand_ShouldAddPlayer()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            _viewModel.SelectedSport = sport;
            _viewModel.NewPlayerName = "John Doe";
            _viewModel.NewPlayerNumber = 10;
            _viewModel.NewPlayerWins = 5;
            _viewModel.NewPlayerLosses = 3;
            _viewModel.NewPlayerMatches = 8;

            // Act
            _viewModel.AddPlayerCommand.Execute(null);

            // Assert
            _mockSportsRepo.Verify(repo => repo.UpdateSport(It.IsAny<Sport>()), Times.Once);
            Assert.AreEqual(1, _viewModel.Players.Count);
            Assert.AreEqual(string.Empty, _viewModel.NewPlayerName);
            Assert.AreEqual(0, _viewModel.NewPlayerNumber);
            Assert.AreEqual(0, _viewModel.NewPlayerWins);
            Assert.AreEqual(0, _viewModel.NewPlayerLosses);
            Assert.AreEqual(0, _viewModel.NewPlayerMatches);
        }

        [TestMethod]
        public void SelectedSport_ShouldUpdatePlayersList()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            var player = new Player("John Doe", 10, 5, 3, 8);
            sport.Players.Add(player);

            // Act
            _viewModel.SelectedSport = sport;

            // Assert
            Assert.AreEqual(1, _viewModel.Players.Count);
            Assert.AreEqual("John Doe", _viewModel.Players.First().Name);
        }

        [TestMethod]
        public void SelectedPlayer_ShouldRaisePropertyChanged()
        {
            // Arrange
            var player = new Player("John Doe", 10, 5, 3, 8);
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.SelectedPlayer))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.SelectedPlayer = player;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
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
        public void NewPlayerWins_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewPlayerWins))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewPlayerWins = 6;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void NewPlayerLosses_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewPlayerLosses))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewPlayerLosses = 4;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void NewPlayerMatches_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewPlayerMatches))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewPlayerMatches = 9;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }
    }
}

