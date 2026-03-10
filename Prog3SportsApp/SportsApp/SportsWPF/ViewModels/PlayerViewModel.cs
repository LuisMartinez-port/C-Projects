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
    public class PlayerViewModel : BaseViewModel
    {
        private readonly iSportsRepo _sportsRepo;
        private Sport _selectedSport;


        public ObservableCollection<Sport> Sports { get; set; }
        public ObservableCollection<Player> Players { get; set; }

        public Sport SelectedSport
        {
            get => _selectedSport;
            set
            {
                _selectedSport = value;
                OnPropertyChanged();
                UpdatePlayersList(); // Update the Players list based on the selected sport
            }
        }

        private Player _selectedPlayer;
        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value; OnPropertyChanged();
            
        
        // Notify UI to update the relevant fields OnPropertyChanged(nameof(PlayerName));
        OnPropertyChanged(nameof(PlayerNumber));
        OnPropertyChanged(nameof(PlayerWins));
        OnPropertyChanged(nameof(PlayerLosses));
        OnPropertyChanged(nameof(PlayerMatchesPlayed));
            }
        }

        public string PlayerName => SelectedPlayer?.Name ?? string.Empty;
        public int PlayerNumber => SelectedPlayer?.Number ?? 0;
        public int PlayerWins => SelectedPlayer?.Wins ?? 0;
        public int PlayerLosses => SelectedPlayer?.Losses ?? 0;
        public int PlayerMatchesPlayed => SelectedPlayer?.MatchesPlayed ?? 0;

        
           

            private string _newPlayerName;
            public string NewPlayerName
            {
                get => _newPlayerName;
                set
                {
                    _newPlayerName = value;
                    OnPropertyChanged();
                    ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged(); // Notify command to re-evaluate
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
                    ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged(); // Notify command to re-evaluate
                }
            }

        private int _newPlayerWins;
        public int NewPlayerWins
        {
            get => _newPlayerWins;
            set
            {
                _newPlayerWins = value;
                OnPropertyChanged();
                ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged(); // Notify command to re-evaluate
            }
        }

        private int _newPlayerLosses;
        public int NewPlayerLosses
        {
            get => _newPlayerLosses;
            set
            {
                _newPlayerLosses = value;
                OnPropertyChanged();
                ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged(); // Notify command to re-evaluate
            }
        }
        private int _newPlayerMatches;
        public int NewPlayerMatches
        {
            get => _newPlayerMatches;
            set
            {
                _newPlayerMatches = value;
                OnPropertyChanged();
                ((RelayCommand)AddPlayerCommand).RaiseCanExecuteChanged(); // Notify command to re-evaluate
            }
        }

        public ICommand AddPlayerCommand { get; }

        public PlayerViewModel(iSportsRepo sportsRepo)
        {
            _sportsRepo = sportsRepo;
            Sports = new ObservableCollection<Sport>(_sportsRepo.GetAllSports());
            Players = new ObservableCollection<Player>();

            AddPlayerCommand = new RelayCommand(AddPlayer, CanAddPlayer);
        }





        private void UpdatePlayersList()
        {
            if (SelectedSport != null)
            {
                Players.Clear();
                foreach (var player in SelectedSport.Players) // Assume sport has a Players collection
                {
                    Players.Add(player);
                }
            }
        }

        private void AddPlayer()
        {
            if (SelectedSport == null || string.IsNullOrWhiteSpace(NewPlayerName) || NewPlayerNumber <= 0)
            {
                return;
            }

            var newPlayer = new Player(NewPlayerName, NewPlayerNumber,NewPlayerWins,NewPlayerLosses,NewPlayerMatches);
            SelectedSport.AddPlayer(newPlayer); // Add player to the selected sport
            _sportsRepo.UpdateSport(SelectedSport);
            UpdatePlayersList(); 
            NewPlayerName = string.Empty;
            NewPlayerNumber = 0;
            NewPlayerWins = 0;
            NewPlayerLosses = 0;
            NewPlayerMatches = 0;
        }

        private bool CanAddPlayer()
        {
            return !string.IsNullOrWhiteSpace(NewPlayerName) && NewPlayerNumber > 0 && NewPlayerWins >= 0 && NewPlayerLosses >= 0 && NewPlayerMatches >= 0; 
        }
    }

}
