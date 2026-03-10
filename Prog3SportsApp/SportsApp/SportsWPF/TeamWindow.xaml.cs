using SportsApp;
using SportsWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportsWPF
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        private readonly SportsRepo _sportsrepo;
        private readonly TeamRepo _teamrepo;
        private readonly TeamViewModel Tvm;
        public TeamWindow()
        {
            InitializeComponent();
            _sportsrepo = App.SportsRepo;
            _teamrepo = App.TeamRepo;
            Tvm = new TeamViewModel(_sportsrepo,_teamrepo);
            DataContext = Tvm;
        }
    }
}
