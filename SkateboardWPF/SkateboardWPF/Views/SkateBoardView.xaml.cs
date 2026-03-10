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
using SkateboardWPF.ViewModels;
using TestFirstSprint2_Luis;

namespace SkateboardWPF.Views
{
    /// <summary>
    /// Interaction logic for SkateBoardView.xaml
    /// </summary>
    public partial class SkateBoardView : UserControl
    {
        public ViewModelSkateBoard vms;

        public SkateBoardView(ViewModelSkateBoard vms) : this()
        {

            this.vms = vms;
        }

      //public SkateBoardView(ViewModelSkateBoard sb)
      //  {
      //      vms = new ViewModelSkateBoard(new StreetBoard());
      //      this.DataContext = vms;
      //  }

        public SkateBoardView()
        {
            InitializeComponent();
        }

        private void btnSkateRight_Click(object sender, RoutedEventArgs e)
        {
            btnOllie.Visibility = Visibility.Visible;
            BitmapImage newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri("../Images/rideboard.png", UriKind.Relative);
            newImage.EndInit();
            imgBoard.Source = newImage;
            Canvas.SetLeft(imgBoard, Canvas.GetLeft(imgBoard) + 15);
            vms.Pushoff();
            vms.PushForward(1);
        }

        private void btnSkateLeft_Click(object sender, RoutedEventArgs e)
        {
            btnOllie.Visibility = Visibility.Visible;
            BitmapImage newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri("../Images/rideboard.png", UriKind.Relative);
            newImage.EndInit();
            imgBoard.Source = newImage;
            
            if (vms.Currentspeed - 1 >= 0)
            {
                vms.SlowDown(1);
                Canvas.SetLeft(imgBoard, Canvas.GetLeft(imgBoard) - 10);
            }
        }

        private void btnOllie_Click(object sender, RoutedEventArgs e)
        {
            btnDolphinFlip.Visibility = Visibility.Visible;
            btnKickFlip.Visibility = Visibility.Visible;
            btnSkateLeft.Visibility = Visibility.Collapsed;
            btnSkateRight.Visibility = Visibility.Collapsed;
            btnOllie.Visibility = Visibility.Collapsed;
            BitmapImage newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri("../Images/ollieboard.jpg", UriKind.Relative);
            newImage.EndInit();
            imgBoard.Source = newImage;
            vms.Ollie();
        }

        private void btnDolphinFlip_Click(object sender, RoutedEventArgs e)
        {
            btnDolphinFlip.Visibility = Visibility.Collapsed;
            btnKickFlip.Visibility = Visibility.Collapsed;
            btnSkateLeft.Visibility = Visibility.Visible;
            btnSkateRight.Visibility = Visibility.Visible;
            btnOllie.Visibility = Visibility.Collapsed;


            BitmapImage newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri("../Images/dolphinflipboard.jpg", UriKind.Relative);
            newImage.EndInit();
            imgBoard.Source = newImage;
            vms.DolphinFlip();

        }

        private void btnKickFlip_Click(object sender, RoutedEventArgs e)
        {
            btnDolphinFlip.Visibility = Visibility.Collapsed;
            btnKickFlip.Visibility = Visibility.Collapsed;
            btnSkateLeft.Visibility = Visibility.Visible;
            btnSkateRight.Visibility = Visibility.Visible;
            btnOllie.Visibility = Visibility.Collapsed;

            BitmapImage newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri("../Images/kickflipboard.jpg", UriKind.Relative);
            newImage.EndInit();
            imgBoard.Source = newImage;
            vms.Kickflip();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnKickFlip.Visibility = Visibility.Collapsed;
            btnDolphinFlip.Visibility = Visibility.Collapsed;
        }

      

    }
}
