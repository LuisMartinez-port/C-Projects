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
    public class TeamViewModel : BaseViewModel
    {
        private readonly iSportsRepo _sportsRepo;
        private readonly iTeamRepo _teamRepo;


        private Sport _selectedSport;

        public ObservableCollection<Sport> Sports { get; set; }
        public ObservableCollection<Player> SportPlayers { get; set; }
        public ObservableCollection<Player> PracticeTeamPlayers { get; set; }

        private string _newPlayerName;
        public string NewPlayerName
        {
            get => _newPlayerName;
            set
            {
                _newPlayerName = value;
                OnPropertyChanged();
                ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged();
            }
        }

        private int _newPlayerNumber;
        public int NewPlayerNumber
        {
            get => _newPlayerNumber;
            set
            {
                _newPlayerNumber = value;
                OnPropertyChanged();
                ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddPlayerCommand { get; }

        public TeamViewModel(iSportsRepo sportsRepo, iTeamRepo teamRepo)
        {
            _sportsRepo = sportsRepo;
            _teamRepo = teamRepo;
            Sports = new ObservableCollection<Sport>(_sportsRepo.GetAllSports());
            SportPlayers = new ObservableCollection<Player>();
            PracticeTeamPlayers = new ObservableCollection<Player>();
            AddPlayerCommand = new RelayCommand(AddPlayer, CanAddPlayer);
        }

        public Sport SelectedSport
        {
            get => _selectedSport;
            set
            {
                _selectedSport = value;
                OnPropertyChanged();
                SetPlayers();
                SetPracticeTeamPlayers();
            }
        }

        private bool CanAddPlayer()
        {
            return !string.IsNullOrWhiteSpace(NewPlayerName) && NewPlayerNumber > 0;
        }

        private void AddPlayer()
        {
            if (SelectedSport == null || string.IsNullOrWhiteSpace(NewPlayerName) || NewPlayerNumber <= 0)
            {
                return;
            }

            var team = _teamRepo.GetTeamByName(SelectedSport.Name);
            if (team == null)
            {
                team = new Team(SelectedSport.Name, SelectedSport); // Pass the Sport object
                _teamRepo.AddTeam(team);
            }

            var newPlayer = new Player(NewPlayerName, NewPlayerNumber);
            team.AddPlayer(newPlayer);
            SetPracticeTeamPlayers();
            NewPlayerName = string.Empty;
            NewPlayerNumber = 0;
        }

        private void SetPlayers()
        {
            SportPlayers.Clear();
            if (SelectedSport != null)
            {
                foreach (var player in SelectedSport.Players)
                {
                    SportPlayers.Add(player);
                }
            }
        }

        private void SetPracticeTeamPlayers()
        {
            PracticeTeamPlayers.Clear();
            if (SelectedSport != null)
            {
                var team = _teamRepo.GetTeamByName(SelectedSport.Name);
                if (team != null)
                {
                    foreach (var player in team.Players)
                    {
                        PracticeTeamPlayers.Add(player);
                    }
                }
            }
        }
    }


}
