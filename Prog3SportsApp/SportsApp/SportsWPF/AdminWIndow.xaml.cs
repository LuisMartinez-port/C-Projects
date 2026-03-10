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
    /// Interaction logic for AdminWIndow.xaml
    /// </summary>
    public partial class AdminWIndow : Window
    {
        private readonly SportsRepo _sportsrepo;
        private readonly AdminViewModel Avm; 
        private readonly TeamRepo _teamrepo;
        
        public AdminWIndow()
        {
            InitializeComponent();
            _sportsrepo = App.SportsRepo;
            _teamrepo = App.TeamRepo;
            Avm = new AdminViewModel(_sportsrepo,_teamrepo);
            DataContext = Avm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
