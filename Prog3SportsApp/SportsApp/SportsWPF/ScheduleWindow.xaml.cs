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
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        private readonly SportsRepo _sportsRepo;
        private readonly ScheduleViewModel _viewModel;

        public ScheduleWindow()
        {
            InitializeComponent();
            _sportsRepo = App.SportsRepo;
            _viewModel = new ScheduleViewModel(_sportsRepo);
            DataContext = _viewModel;
        }
    }
}
