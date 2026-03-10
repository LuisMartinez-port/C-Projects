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
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly iSportsRepo _sportsRepo;
        private Sport _selectedSport;
        private Player _selectedHomePlayer;
        private Player _selectedVisitorPlayer;
        private string _matchDate;
        private ObservableCollection<Match> _matches;

        public ObservableCollection<Sport> Sports { get; set; }
        public ObservableCollection<Player> PlayersForSelectedSport { get; set; }

        public ScheduleViewModel(iSportsRepo sportsRepo)
        {
            _sportsRepo = sportsRepo;
            Sports = new ObservableCollection<Sport>(_sportsRepo.GetAllSports());
            PlayersForSelectedSport = new ObservableCollection<Player>();
            Matches = new ObservableCollection<Match>();

            AddMatchCommand = new RelayCommand(AddMatch, CanAddMatch);
        }

        public Sport SelectedSport
        {
            get => _selectedSport;
            set
            {
                _selectedSport = value;
                OnPropertyChanged();
                LoadPlayersForSelectedSport();
            }
        }

        public Player SelectedHomePlayer
        {
            get => _selectedHomePlayer;
            set
            {
                _selectedHomePlayer = value;
                OnPropertyChanged();
            }
        }

        public Player SelectedVisitorPlayer
        {
            get => _selectedVisitorPlayer;
            set
            {
                _selectedVisitorPlayer = value;
                OnPropertyChanged();
            }
        }

        public string MatchDate
        {
            get => _matchDate;
            set
            {
                _matchDate = value;
                OnPropertyChanged();
                ((RelayCommand)AddMatchCommand).RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Match> Matches
        {
            get => _matches;
            set
            {
                _matches = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddMatchCommand { get; }

        private void LoadPlayersForSelectedSport()
        {
            PlayersForSelectedSport.Clear();
            if (SelectedSport != null)
            {
                foreach (var player in SelectedSport.Players)
                {
                    PlayersForSelectedSport.Add(player);
                }
            }
        }

        private bool CanAddMatch()
        {
            return SelectedSport != null &&
                   SelectedHomePlayer != null &&
                   SelectedVisitorPlayer != null &&
                   IsValidDate(MatchDate);
        }

        private bool IsValidDate(string dateStr)
        {
            return DateTime.TryParse(dateStr, out _);
        }

        private void AddMatch()
        {
            if (!CanAddMatch())
            {
                return;
            }

            var match = new Match(SelectedHomePlayer, SelectedVisitorPlayer, DateTime.Parse(MatchDate));
            Matches.Add(match);

            // Clear fields after adding the match
            SelectedHomePlayer = null;
            SelectedVisitorPlayer = null;
            MatchDate = string.Empty;
        }
    }

   

}
