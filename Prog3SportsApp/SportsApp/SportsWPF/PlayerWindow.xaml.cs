using SportsApp;
using SportsWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private readonly SportsRepo _sportsrepo;
        private readonly PlayerViewModel pvm;
        public PlayerWindow()
        {
         
            InitializeComponent();
             _sportsrepo = App.SportsRepo;

           pvm = new PlayerViewModel(_sportsrepo);

            DataContext = pvm;
        }

        
    }
}
