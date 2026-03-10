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
    /// Interaction logic for Trade.xaml
    /// </summary>
    public partial class Trade : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        int ButtonNum = 1;
        double guala = 0;
        int vendorItemsSold = 0;
        public Trade()
        {
            InitializeComponent();
        }

        delegate void Printdelegate(string value);

        public void PrintMessage(string value)
        {
            errorbox.Text = value;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SetButtonVisibility();
            Output.Text = mainWindow.game.OtherVendor.GetInventoryItemList(mainWindow.game.OtherVendor.Inventory);
            ButtonNum = 1;
            mainWindow.Currency.Visibility = Visibility.Visible;

        }

        private void SetButtonVisibility()
        {
            mainWindow.Trade.Visibility = Visibility.Collapsed;
            mainWindow.Inventory.Visibility = Visibility.Visible;
            mainWindow.Craft.Visibility = Visibility.Visible;
        }

        private void SwitchToCrafted_Click(object sender, RoutedEventArgs e)
        {
            {

                if (ButtonNum % 2 == 0)
                {
                    SellButton.Visibility = Visibility.Visible;
                    BuyButton.Visibility = Visibility.Collapsed;
                    Output.Text = mainWindow.game.Other.GetInventoryItemList(mainWindow.game.Other.CraftedItems);

                }
                else
                {
                    SellButton.Visibility = Visibility.Visible;
                    BuyButton.Visibility = Visibility.Visible;
                    Output.Text = mainWindow.game.OtherVendor.GetInventoryItemList(mainWindow.game.OtherVendor.Inventory);
                }
                ButtonNum++;
            }

        }
        private void ChangeItemAmount(int indexNumber)
        {


            if (mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmount < 1)
            {

                //variable/ add item at original itemamount before its set to zero
                Item newItem = new Item();
                newItem.ItemAmount = mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmount;
                newItem.ItemName = mainWindow.game.OtherVendor.Inventory[indexNumber].ItemName;
                newItem.ItemDescription = mainWindow.game.OtherVendor.Inventory[indexNumber].ItemDescription;
                newItem.ItemValue = mainWindow.game.OtherVendor.Inventory[indexNumber].ItemValue;
                newItem.ItemAmountType = mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmountType;
                mainWindow.game.Other.Inventory.Add(newItem);

                mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmount = 0;


            }
            else
            {
                mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmount--;
            }

        }
        private void TradeItem(Item item, int indexNumber)
        {
            ChangeItemAmount(indexNumber);

            int index = mainWindow.game.Other.CheckForItem(item);
            if (index != -1)
            {
                if (mainWindow.game.Other.Inventory[index].ItemAmount < 1)
                {

                }


                else
                {
                    //modify player inventory
                    mainWindow.game.Other.Inventory[index].ItemAmount++;

                }


            }

            else
            {

                Item newItem = new Item();
                newItem.ItemAmount = 1;
                newItem.ItemName = item.ItemName;
                newItem.ItemDescription = item.ItemDescription;
                newItem.ItemValue = item.ItemValue;
                newItem.ItemAmountType = item.ItemAmountType;
                mainWindow.game.Other.Inventory.Add(newItem);
                index = mainWindow.game.Other.CheckForItem(newItem);

            }

            Output.Text = mainWindow.game.OtherVendor.GetInventoryItemList(mainWindow.game.OtherVendor.Inventory);
        }
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            string input = ConfirmItemTextBox.Text;

            try
            {
                int number = Convert.ToInt32(input);
                int indexNumber = number - 1;
                Item item = mainWindow.game.OtherVendor.Inventory[indexNumber];

                if (indexNumber >= 0)
                {
                    if (mainWindow.game.OtherVendor.Inventory[indexNumber].ItemAmount == 0)
                    {

                        errorbox.Text = "OUT OF STOCK";
                        ConfirmItemTextBox.Clear();
                    }

                    else if (indexNumber <= mainWindow.game.OtherVendor.Inventory.Count)
                    {
                        if (mainWindow.game.Player.PersonCurrency < item.ItemValue)
                        {
                            errorbox.Text = "You don't have enough money ";
                        }
                        else
                        {
                            errorbox.Text = "";
                            TradeItem(item, indexNumber);
                            ConfirmItemTextBox.Clear();
                            errorbox.Text = $"{item.ItemName} Added Succesfully to your inventory!";
                            //guala = guala + item.ItemValue;
                            mainWindow.game.Other.PersonCurrency = mainWindow.game.Other.PersonCurrency - item.ItemValue;
                            mainWindow.Currency.Text = mainWindow.game.Other.PersonCurrency.ToString("C");

                        }

                    }
                    else
                    {
                        //alert
                        errorbox.Text = "Please enter a valid item number";
                        ConfirmItemTextBox.Clear();

                    }


                }
            }

            catch
            {
                errorbox.Text = "Please enter a valid  number";
                ConfirmItemTextBox.Clear();

            }


        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            string input = ConfirmItemTextBox.Text;

            try
            {
                int number = Convert.ToInt32(input);
                int indexNumber = number - 1;
                Item item = mainWindow.game.Other.CraftedItems[indexNumber];

                if (indexNumber >= 0)
                {
                    if (vendorItemsSold == 6)
                    {

                        errorbox.Text = "Vendor Out Of Money\nPlease Try Again Later";
                        ConfirmItemTextBox.Clear();
                    }

                    else if (indexNumber <= mainWindow.game.Other.CraftedItems.Count)
                    {
                       

                       

                        mainWindow.game.Other.Buy(item, mainWindow.game.Other);
                        mainWindow.game.Other.randomProfitMargin(item);
                        vendorItemsSold++;
                        mainWindow.Currency.Text = mainWindow.game.Other.PersonCurrency.ToString("C");
                        errorbox.Text = "SOLD!";
                        Output.Text = mainWindow.game.Other.GetInventoryItemList(mainWindow.game.Other.CraftedItems);
                        ConfirmItemTextBox.Clear() ;

                    }

                    else
                    {
                        //alert
                        errorbox.Text = "Please enter a valid item number";
                        ConfirmItemTextBox.Clear();

                    }
                }
            }


            catch
            {
                errorbox.Text = "Please enter a valid  number";
                ConfirmItemTextBox.Clear();
            }

        }
    }
}


