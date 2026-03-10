using SportsApp;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SportsWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TeamWindow _teamWindow;
        private static AdminWIndow _adminWindow;
        private static ScheduleWindow _scheduleWindow;
        private static PlayerWindow _playerWindow;

        private static SportsRepo _sportsRepo;
        private static TeamRepo _teamRepo;

        public static SportsRepo SportsRepo
        {
            get
            {
                if (_sportsRepo == null)
                {
                    _sportsRepo = new SportsRepo();
                }
                return _sportsRepo;
            }
        }

        public static TeamRepo TeamRepo
        {
            get
            {
                if (_teamRepo == null)
                {
                    _teamRepo = new TeamRepo();
                }
                return _teamRepo;
            }
        }

        public static TeamWindow TeamWindow
        {
            get
            {
                if (_teamWindow == null)
                    _teamWindow = new TeamWindow();
                return _teamWindow;
            }
        }
        public static AdminWIndow AdminWindow
        {
            get
            {
                if (_adminWindow == null)
                    _adminWindow = new AdminWIndow();
                return _adminWindow;
            }
        }
        public static ScheduleWindow ScheduleWindow
        {
            get
            {
                if (_scheduleWindow == null)
                    _scheduleWindow = new ScheduleWindow();
                return _scheduleWindow;
            }
        }

        public static PlayerWindow PlayerWindow
        {
            get
            {
                if (_playerWindow == null)
                    _playerWindow = new PlayerWindow();
                return _playerWindow;
            }
        }


    }

}
