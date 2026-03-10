using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsApp;
using SportsWPF.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WPFTests2
{
    [TestClass]
    public class AdminViewModelTests
    {
        private Mock<iSportsRepo> _mockSportsRepo;
        private Mock<iTeamRepo> _mockTeamRepo;
        private AdminViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockSportsRepo = new Mock<iSportsRepo>();
            _mockTeamRepo = new Mock<iTeamRepo>();

            _mockSportsRepo.Setup(repo => repo.GetAllSports()).Returns(new List<Sport>());
            _mockTeamRepo.Setup(repo => repo.GetTeamsBySport(It.IsAny<Sport>())).Returns(new List<Team>());

            _viewModel = new AdminViewModel(_mockSportsRepo.Object, _mockTeamRepo.Object);
        }

        [TestMethod]
        public void AddSportCommand_ShouldAddSport()
        {
            // Arrange
            _viewModel.NewSportName = "Soccer";
            _viewModel.NewSportDescription = "A popular sport";

            // Act
            _viewModel.AddSportCommand.Execute(null);

            // Assert
            _mockSportsRepo.Verify(repo => repo.AddSport(It.IsAny<Sport>()), Times.Once);
            Assert.AreEqual(1, _viewModel.Sports.Count);
            Assert.AreEqual(string.Empty, _viewModel.NewSportName);
            Assert.AreEqual(string.Empty, _viewModel.NewSportDescription);
        }

        [TestMethod]
        public void AddTeamCommand_ShouldAddTeam()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            _viewModel.SelectedSport = sport;
            _viewModel.NewTeamName = "Team A";

            // Act
            _viewModel.AddTeamCommand.Execute(null);

            // Assert
            _mockTeamRepo.Verify(repo => repo.AddTeam(It.IsAny<Team>()), Times.Once);
            Assert.AreEqual(1, _viewModel.Teams.Count);
            Assert.AreEqual(string.Empty, _viewModel.NewTeamName);
        }

        [TestMethod]
        public void SelectedSport_ShouldLoadTeams()
        {
            // Arrange
            var sport = Sport.CreateSport("Soccer", "A popular sport", true);
            var teams = new List<Team> { new Team("Team A", sport) };
            _mockTeamRepo.Setup(repo => repo.GetTeamsBySport(sport)).Returns(teams);

            // Act
            _viewModel.SelectedSport = sport;

            // Assert
            Assert.AreEqual(1, _viewModel.Teams.Count);
            Assert.AreEqual("Team A", _viewModel.Teams.First().Name);
        }

        [TestMethod]
        public void NewSportName_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewSportName))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewSportName = "Basketball";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void NewSportDescription_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewSportDescription))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewSportDescription = "A team sport";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void NewTeamName_ShouldRaisePropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.NewTeamName))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            _viewModel.NewTeamName = "Team B";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }
    }
}

