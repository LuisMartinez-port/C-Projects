using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsApp;
using SportsWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SportsWPF.Tests.ViewModels
{
    [TestClass]
    public class ScheduleViewModelTests
    {
        private Mock<iSportsRepo> _mockSportsRepo;
        private ScheduleViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockSportsRepo = new Mock<iSportsRepo>();
            _mockSportsRepo.Setup(repo => repo.GetAllSports()).Returns(new List<Sport>());

            _viewModel = new ScheduleViewModel(_mockSportsRepo.Object);
        }

        [TestMethod]
        public void AddMatchCommand_ShouldAddMatch()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            var homePlayer = new Player("John Doe", 10);
            var visitorPlayer = new Player("Jane Doe", 11);
            sport.Players.Add(homePlayer);
            sport.Players.Add(visitorPlayer);
            _viewModel.SelectedSport = sport;
            _viewModel.SelectedHomePlayer = homePlayer;
            _viewModel.SelectedVisitorPlayer = visitorPlayer;
            _viewModel.MatchDate = DateTime.Now.ToString();

            // Act
            _viewModel.AddMatchCommand.Execute(null);

            // Assert
            Assert.AreEqual(1, _viewModel.Matches.Count);
            Assert.AreEqual(homePlayer, _viewModel.Matches.First().Team1);
            Assert.AreEqual(visitorPlayer, _viewModel.Matches.First().Team2);
            Assert.IsNull(_viewModel.SelectedHomePlayer);
            Assert.IsNull(_viewModel.SelectedVisitorPlayer);
            Assert.AreEqual(string.Empty, _viewModel.MatchDate);
        }

        [TestMethod]
        public void SelectedSport_ShouldLoadPlayersForSelectedSport()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            var player = new Player("John Doe", 10);
            sport.Players.Add(player);

            // Act
            _viewModel.SelectedSport = sport;

            // Assert
            Assert.AreEqual(1, _viewModel.PlayersForSelectedSport.Count);
            Assert.AreEqual("John Doe", _viewModel.PlayersForSelectedSport.First().Name);
        }

        [TestMethod]
        public void MatchDate_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.MatchDate))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.MatchDate = DateTime.Now.ToString();

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void SelectedHomePlayer_ShouldRaisePropertyChanged()
        {
            // Arrange
            var player = new Player("John Doe", 10);
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.SelectedHomePlayer))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.SelectedHomePlayer = player;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void SelectedVisitorPlayer_ShouldRaisePropertyChanged()
        {
            // Arrange
            var player = new Player("Jane Doe", 11);
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.SelectedVisitorPlayer))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.SelectedVisitorPlayer = player;

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void CanAddMatch_ShouldReturnTrue_WhenAllConditionsAreMet()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport",true);
            var homePlayer = new Player("John Doe", 10);
            var visitorPlayer = new Player("Jane Doe", 11);
            sport.Players.Add(homePlayer);
            sport.Players.Add(visitorPlayer);
            _viewModel.SelectedSport = sport;
            _viewModel.SelectedHomePlayer = homePlayer;
            _viewModel.SelectedVisitorPlayer = visitorPlayer;
            _viewModel.MatchDate = DateTime.Now.ToString();

            // Act
            var canAddMatch = _viewModel.AddMatchCommand.CanExecute(null);

            // Assert
            Assert.IsTrue(canAddMatch);
        }

        [TestMethod]
        public void CanAddMatch_ShouldReturnFalse_WhenConditionsAreNotMet()
        {
            // Arrange
            _viewModel.SelectedSport = null;
            _viewModel.SelectedHomePlayer = null;
            _viewModel.SelectedVisitorPlayer = null;
            _viewModel.MatchDate = string.Empty;

            // Act
            var canAddMatch = _viewModel.AddMatchCommand.CanExecute(null);

            // Assert
            Assert.IsFalse(canAddMatch);
        }
    }
}
