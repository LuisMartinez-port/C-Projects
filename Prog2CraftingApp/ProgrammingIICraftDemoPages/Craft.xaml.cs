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

namespace ProgrammingIICraftDemoPages
{
    /// <summary>
    /// Interaction logic for Craft.xaml
    /// </summary>
    public partial class Craft : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public Craft()
        {
            InitializeComponent();
        }

        int value;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SetButtonVisibility();
            Output.Text = mainWindow.game.GetRecipeList(mainWindow.game.RecipeList);
            mainWindow.VendorCurrency.Visibility = Visibility.Collapsed;
            mainWindow.Currency.Visibility = Visibility.Visible;
        }

        private void SetButtonVisibility()
        {
            mainWindow.Craft.Visibility = Visibility.Collapsed;
            mainWindow.Trade.Visibility = Visibility.Visible;
            mainWindow.Inventory.Visibility = Visibility.Visible;
        }

        private void CraftButton_Click(object sender, RoutedEventArgs e)
        {
            string input = RecipeSelector.Text;

            try
            {
                int number = Convert.ToInt32(input);
                int indexNumber = number - 1;
                Recipe recipe = mainWindow.game.RecipeList[indexNumber];

                if (indexNumber <= mainWindow.game.Recipes.Count  )
                {
                    int craftresult = mainWindow.game.makeItem(recipe, mainWindow.game.Other);
                    if (craftresult == 1) 
                    errorbox.Text = $"{recipe.RecipeName} has been added to your inventory! Enjoy!!";
                    RecipeSelector.Clear();
                    {
                    
                    
                    }
                    if (craftresult == -1)
                    {
                        errorbox.Text = "You dont have the sufficient ingredients to make this";

                    }
                   

                }
            }

            catch
            {
                errorbox.Text = "Please enter a valid recipe number";
                RecipeSelector.Clear();

            }
        }
    }
}
