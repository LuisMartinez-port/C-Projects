using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestFirstSprint2_Luis;
using SkateboardWPF.ViewModels;

namespace SkateboardWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelSkateBoard vmS;
        public MainWindow()
        {
            InitializeComponent();

            vmS = new ViewModelSkateBoard(new StreetBoard());
            this.DataContext = vmS;
            this.vSkateboard.DataContext = vmS;
            this.vSkateboard.vms = vmS;
            //Learned these could be in the window Loaded event
            //btnKickFlip.Visibility = Visibility.Collapsed;
            //btnDolphinFlip.Visibility = Visibility.Collapsed;

        }

     
        //StreetBoard sb = new StreetBoard();
        //private void btnSkateRight_Click(object sender, RoutedEventArgs e)
        //{
        //    btnOllie.Visibility = Visibility.Visible;
        //    BitmapImage newImage = new BitmapImage();
        //    newImage.BeginInit();
        //    newImage.UriSource = new Uri("Images/rideboard.png", UriKind.Relative);
        //    newImage.EndInit();
        //    imgBoard.Source = newImage;
        //    Canvas.SetLeft(imgBoard, Canvas.GetLeft(imgBoard) + 15);
        //    sb.PushOff();
        //    sb.PushForward(1);
        //}

        //private void btnSkateLeft_Click(object sender, RoutedEventArgs e)
        //{
        //    btnOllie.Visibility = Visibility.Visible;
        //    BitmapImage newImage = new BitmapImage();
        //    newImage.BeginInit();
        //    newImage.UriSource = new Uri("Images/rideboard.png", UriKind.Relative);
        //    newImage.EndInit();
        //    imgBoard.Source = newImage;
        //    Canvas.SetLeft(imgBoard, Canvas.GetLeft(imgBoard) - 10);
        //    sb.SlowDown(1);
        //}

        //private void btnOllie_Click(object sender, RoutedEventArgs e)
        //{
        //    btnDolphinFlip.Visibility=Visibility.Visible;
        //    btnKickFlip.Visibility=Visibility.Visible;
        //    btnSkateLeft.Visibility = Visibility.Collapsed;
        //    btnSkateRight.Visibility=Visibility.Collapsed;
        //    btnOllie.Visibility=Visibility.Collapsed;
        //    BitmapImage newImage = new BitmapImage();
        //    newImage.BeginInit();
        //    newImage.UriSource = new Uri("Images/ollieboard.jpg", UriKind.Relative);
        //    newImage.EndInit();
        //    imgBoard.Source = newImage;
        //    sb.Ollie();
        //}

        //private void btnDolphinFlip_Click(object sender, RoutedEventArgs e)
        //{
        //    btnDolphinFlip.Visibility = Visibility.Collapsed;
        //    btnKickFlip.Visibility = Visibility.Collapsed;
        //    btnSkateLeft.Visibility = Visibility.Visible;
        //    btnSkateRight.Visibility = Visibility.Visible;
        //    btnOllie.Visibility = Visibility.Collapsed;


        //    BitmapImage newImage = new BitmapImage();
        //    newImage.BeginInit();
        //    newImage.UriSource = new Uri("Images/dolphinflipboard.jpg", UriKind.Relative);
        //    newImage.EndInit();
        //    imgBoard.Source = newImage;
        //    sb.DolphinFlip();
        //}

        //private void btnKickFlip_Click(object sender, RoutedEventArgs e)
        //{
        //    btnDolphinFlip.Visibility = Visibility.Collapsed;
        //    btnKickFlip.Visibility = Visibility.Collapsed;
        //    btnSkateLeft.Visibility = Visibility.Visible;
        //    btnSkateRight.Visibility = Visibility.Visible;
        //    btnOllie.Visibility = Visibility.Collapsed;

        //    BitmapImage newImage = new BitmapImage();
        //    newImage.BeginInit();
        //    newImage.UriSource = new Uri("Images/kickflipboard.jpg", UriKind.Relative);
        //    newImage.EndInit();
        //    imgBoard.Source = newImage;
        //    sb.Kickflip();
        //}
    }
}