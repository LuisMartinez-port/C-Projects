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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsWPF.UserControls
{
    /// <summary>
    /// Interaction logic for Nav.xaml
    /// </summary>
    public partial class Nav : UserControl
    {
        public ICommand AdminCommand { get; set; }
        public ICommand TeamCommand { get; set; }

        public ICommand ScheduleCommand { get; set; }

        public Nav()
        {
            InitializeComponent();
            AdminCommand = new BasicCommand(OpenAdmin);
        }

        private void OpenAdmin()
        {
            App.AdminWindow.Activate();
        }

        private void btnNavAdmin_Click(object sender, RoutedEventArgs e)
        {
            App.AdminWindow.Show();
            App.AdminWindow.Activate();
        }
          private void btnNavAdmin_Click_1(object sender, RoutedEventArgs e)
                {
            App.AdminWindow.Show();
            App.AdminWindow.Activate();
        }
        private void btnNavTeams_Click(object sender, RoutedEventArgs e)
        {
            App.TeamWindow.Show();
            App.TeamWindow.Activate();
        }

        private void btnNavSched_Click(object sender, RoutedEventArgs e)
        {
            App.ScheduleWindow.Show();
            App.ScheduleWindow.Activate();
        }

        private void btnNavPlayer_Click(object sender, RoutedEventArgs e)
        {
            App.PlayerWindow.Show();
            App.PlayerWindow.Activate();
        }

        


        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void AdminWindowCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

      
    }
}
