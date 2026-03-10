using SportsApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsWPF.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly iSportsRepo _sportsRepo;
        private readonly iTeamRepo _teamRepo;

        private Sport _selectedSport;

        public ObservableCollection<Sport> Sports { get; set; }
        public Sport SelectedSport
        {
            get => _selectedSport;
            set
            {
                _selectedSport = value;
                OnPropertyChanged();
                LoadTeamsForSelectedSport();
            }
        }
        public ObservableCollection<Team> Teams { get; set; }

        private string _newSportName;
        public string NewSportName
        {
            get => _newSportName;
            set
            {
                _newSportName = value;
                OnPropertyChanged();
            }
        }

        private string _newSportDescription;
        public string NewSportDescription
        {
            get => _newSportDescription;
            set
            {
                _newSportDescription = value;
                OnPropertyChanged();
            }
        }

        private string _newTeamName;
        public string NewTeamName
        {
            get => _newTeamName;
            set
            {
                _newTeamName = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddSportCommand { get; }
        public ICommand AddTeamCommand { get; }

        public AdminViewModel(iSportsRepo sportsRepo, iTeamRepo teamRepo)
        {
            _sportsRepo = sportsRepo;
            _teamRepo = teamRepo;
            Sports = new ObservableCollection<Sport>(_sportsRepo.GetAllSports());
            Teams = new ObservableCollection<Team>();

            AddSportCommand = new RelayCommand(AddSport);
            AddTeamCommand = new RelayCommand(AddTeam);
        }

        private void AddSport()
        {
            var newSport =  Sport.CreateSport(NewSportName, NewSportDescription,true);
            _sportsRepo.AddSport(newSport);
            Sports.Add(newSport);

            // Clear fields
            NewSportName = string.Empty;
            NewSportDescription = string.Empty;
        }

        private void AddTeam()
        {
            if (SelectedSport == null || string.IsNullOrWhiteSpace(NewTeamName))
            {
                return;
            }

            var newTeam = new Team(NewTeamName, SelectedSport);
            _teamRepo.AddTeam(newTeam);
            Teams.Add(newTeam);

            // Clear fields
            NewTeamName = string.Empty;
        }

        private void LoadTeamsForSelectedSport()
        {
            Teams.Clear();
            if (SelectedSport != null)
            {
                var teams = _teamRepo.GetTeamsBySport(SelectedSport);
                foreach (var team in teams)
                {
                    Teams.Add(team);
                }
            }
        }
    }


}
