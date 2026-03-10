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
using static FinalProject.Utility;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        World world = new World();

        int indexForExplorevalue;

        int indexOfVarToRemove;

        int InitialHydraFightAttackCounter;

        int secondHydraFightWinCounter;
        private void UpdatePlayerInfo()
        {

            PlayerInformationBox.Text = world.player1.GetPlayerInfo();

           HydraFightItemCheck();
        }

     

        private void HydraFightItemCheck()
        {
            if (GetAllItemNames(world.player1.InventoryList).Contains("Cross Guard") &&
                GetAllItemNames(world.player1.InventoryList).Contains("Hilt") &&
                GetAllItemNames(world.player1.InventoryList).Contains("pommel") &&
                GetAllItemNames(world.player1.InventoryList).Contains("Blade"))
            {

                hydraFightButton.Visibility= Visibility.Visible;

                ForestButton.Visibility= Visibility.Collapsed;
                CaveButton.Visibility= Visibility.Collapsed;    
                RuinedTownButton.Visibility= Visibility.Collapsed;
                VillageButton.Visibility= Visibility.Collapsed;

                LocationInformationBox.Text = "You have aquired all of the pieces necessary to put together the Magic Sword! The entire Island is supporting you, Fight the Hydra once more and free us all!!!";

            }

        }

        private void PlayerNameSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            world.player1.Name = NameBox.Text;

            UpdatePlayerInfo();

            PlayerNameCanvas.Visibility = Visibility.Collapsed;
            hydraFightButton.Visibility = Visibility.Visible;
            LocationInformationBox.Text = $"{world.player1.Name}, this... This is the Foul beast that has terrorized us for millenia. Fight it at your own risk";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UpdatePlayerInfo();
            world.setUpNPC();

            world.setUpLocations();

            VillageButton.Visibility = Visibility.Collapsed;
            ForestButton.Visibility = Visibility.Collapsed;
            RuinedTownButton.Visibility = Visibility.Collapsed;
            CaveButton.Visibility = Visibility.Collapsed;
            HydraHead1.Visibility = Visibility.Collapsed;
            HydraHead2.Visibility = Visibility.Collapsed;
            HydraHead3.Visibility = Visibility.Collapsed;
            hydraFightButton.Visibility = Visibility.Collapsed;

            LocationInformationBox.Text = "Welcome Brave warrior to our home. We are a small island yet we have been corrupted by this horrendous beast for millenia. Tell me... What is your name?";
        }

        private void VillageButton_Click(object sender, RoutedEventArgs e)
        {
            world.player1.CurrentLocation.name = "Village";

            indexForExplorevalue = world.LocationsList.FindIndex(a => a.name.Contains(world.player1.CurrentLocation.name));

            if (world.LocationsList[indexForExplorevalue].explored == true)
            {

                if (GetAllItemNames(world.player1.InventoryList).Contains("FireProof Helm")) {

                    world.player1.AddItemToInventory(world.NPCList[0].tradeItem.Name);

                    indexOfVarToRemove = world.player1.InventoryList.FindIndex(a => a.Name.Contains("FireProof Helm"));

                    world.player1.InventoryList.RemoveAt(indexOfVarToRemove);

                    LocationInformationBox.Text = $"{world.NPCList[0].Name} is so thrilled to see you! They trade you the {world.NPCList[0].tradeItem.Name} for your FireProof Helm. They encourage you to keep exploring the island, you'll be sure to get more items";
                }

                else
                {

                    LocationInformationBox.Text = $"You have already visited the {world.player1.CurrentLocation.name}. There is so much more out there {world.player1.Name} go explore!";
                }
            }

            else
            {

                LocationInformationBox.Text = $"After exploring you stumbled upon the {world.player1.CurrentLocation.name}, you spot a strange looking creature and approach it.";

                LocationInformationBox.Text += $"{world.NPCList[0].ReturnMessageToPlayer()}";

                world.player1.AddItemToInventory("Wooden Shield");

                world.LocationsList[indexForExplorevalue].explored = true;
            }
            UpdatePlayerInfo();
        }

        private void ForestButton_Click(object sender, RoutedEventArgs e)
        {
            world.player1.CurrentLocation.name = "Forest";

            indexForExplorevalue = world.LocationsList.FindIndex(a => a.name.Contains(world.player1.CurrentLocation.name));

            if (world.LocationsList[indexForExplorevalue].explored == true)
            {

                if (GetAllItemNames(world.player1.InventoryList).Contains("Running Boots"))
                {

                    world.player1.AddItemToInventory(world.NPCList[1].tradeItem.Name);

                    indexOfVarToRemove = world.player1.InventoryList.FindIndex(a => a.Name.Contains("Running Boots"));

                    world.player1.InventoryList.RemoveAt(indexOfVarToRemove);

                    LocationInformationBox.Text = $"{world.NPCList[1].Name} is so thrilled to see you! They trade you the {world.NPCList[1].tradeItem.Name} for your Running Boots.  They encourage you to keep exploring the island, you'll be sure to get more items";
                }

                else
                {

                    LocationInformationBox.Text = $"You have already visited the {world.player1.CurrentLocation.name}. There is so much more out there {world.player1.Name} go explore!";
                }
            }

            else
            {

                LocationInformationBox.Text = $"After exploring you stumbled upon the {world.player1.CurrentLocation.name}, you spot a strange looking creature and approach it.";

                LocationInformationBox.Text += $"{world.NPCList[1].ReturnMessageToPlayer()}";

                world.player1.AddItemToInventory("Telescope");

                world.LocationsList[indexForExplorevalue].explored = true;
            }
            UpdatePlayerInfo();
        }

        private void RuinedTownButton_Click(object sender, RoutedEventArgs e)
        {
            world.player1.CurrentLocation.name = "Ruined Town";

            indexForExplorevalue = world.LocationsList.FindIndex(a => a.name.Contains(world.player1.CurrentLocation.name));

            if (world.LocationsList[indexForExplorevalue].explored == true)
            {

                if (GetAllItemNames(world.player1.InventoryList).Contains("Wooden Shield"))
                {

                    world.player1.AddItemToInventory(world.NPCList[2].tradeItem.Name);

                    indexOfVarToRemove = world.player1.InventoryList.FindIndex(a => a.Name.Contains("Wooden Shield"));

                    world.player1.InventoryList.RemoveAt(indexOfVarToRemove);

                    LocationInformationBox.Text = $"{world.NPCList[2].Name} is so thrilled to see you! They trade you the {world.NPCList[2].tradeItem.Name} for your Wooden Shield.  They encourage you to keep exploring the island, you'll be sure to get more items";
                }

                else
                {

                    LocationInformationBox.Text = $"You have already visited the {world.player1.CurrentLocation.name}. There is so much more out there {world.player1.Name} go explore!";
                }
            }

            else
            {

                LocationInformationBox.Text = $"After exploring you stumbled upon the {world.player1.CurrentLocation.name}, you spot a strange looking creature and approach it.";

                LocationInformationBox.Text += $"{world.NPCList[2].ReturnMessageToPlayer()}";

                world.player1.AddItemToInventory("Running Boots");

                world.LocationsList[indexForExplorevalue].explored = true;
            }
            UpdatePlayerInfo();
        }

        private void CaveButton_Click(object sender, RoutedEventArgs e)
        {
            world.player1.CurrentLocation.name = "Cave";

            indexForExplorevalue = world.LocationsList.FindIndex(a => a.name.Contains(world.player1.CurrentLocation.name));

            if (world.LocationsList[indexForExplorevalue].explored == true)
            {

                if (GetAllItemNames(world.player1.InventoryList).Contains("Telescope"))
                {

                    world.player1.AddItemToInventory(world.NPCList[3].tradeItem.Name);

                    indexOfVarToRemove = world.player1.InventoryList.FindIndex(a => a.Name.Contains("Telescope"));

                    world.player1.InventoryList.RemoveAt(indexOfVarToRemove);

                    LocationInformationBox.Text = $"{world.NPCList[3].Name} is so thrilled to see you! They trade you the {world.NPCList[3].tradeItem.Name} for your Telescope.  They encourage you to keep exploring the island, you'll be sure to get more items";
                }

                else
                {

                    LocationInformationBox.Text = $"You have already visited the {world.player1.CurrentLocation.name}. There is so much more out there {world.player1.Name} go explore!";
                }
            }

            else
            {

                LocationInformationBox.Text = $"After exploring you stumbled upon the {world.player1.CurrentLocation.name}, you spot a strange looking creature and approach it.";

                LocationInformationBox.Text += $"{world.NPCList[3].ReturnMessageToPlayer()}";

                world.player1.AddItemToInventory("FireProof Helm");

                world.LocationsList[indexForExplorevalue].explored = true;
            }
            UpdatePlayerInfo();
        }

        private void HydraHead1_Click(object sender, RoutedEventArgs e)
        {
            if (GetAllItemNames(world.player1.InventoryList).Contains("Cross Guard") &&
               GetAllItemNames(world.player1.InventoryList).Contains("Hilt") &&
               GetAllItemNames(world.player1.InventoryList).Contains("pommel") &&
               GetAllItemNames(world.player1.InventoryList).Contains("Blade"))
            {
                //was hoping to do if (HydraHead1.visibility = visibility.collapsed && HydraHead2.visibility ..., but I think i will just increment a seperate variable for this since this will be the win condition
                HydraHead1.Visibility = Visibility.Collapsed;
                //since the player has the magic sword at this point we wont bring back the other hydra heads
                //increment the second hydra fight counter to be able to tell if all three heads have been "Cut off"
                secondHydraFightWinCounter++;
                 if (secondHydraFightWinCounter == 3)
                {
                    LocationInformationBox.Text = $"I can't believe it {world.player1.Name} YOU DID IT!! That foul hydra has finally been defeated once and for all!\n You have set us free... Truly Thank you. THE END!";
                }

            }

            else
            {
                HydraHead1.Visibility = Visibility.Collapsed;

                //for the initial fight I want the other Hydra heads to come back after each attack on one of the other hydra heads
                HydraHead2.Visibility = Visibility.Visible;
                HydraHead3.Visibility = Visibility.Visible;

                InitialHydraFightAttackCounter++;

                if (InitialHydraFightAttackCounter == 7)
                {
                    LocationInformationBox.Text = "After your hard fought battle you realise that no matter how many times you strike down one of the hydras heads... it will always come back." +
                        "\n\n You flee from the Hydra and begin exploring the Island in hopes of an answer on how to defeat this beast.";
                    //this will "end" the hydra fight, now we bring forward all of the map buttons and hide the Hydra buttons
                    HydraHead1.Visibility = Visibility.Collapsed;
                    HydraHead2.Visibility = Visibility.Collapsed;
                    HydraHead3.Visibility= Visibility.Collapsed;
                    ForestButton.Visibility = Visibility.Visible;
                    CaveButton.Visibility = Visibility.Visible;
                    RuinedTownButton.Visibility = Visibility.Visible;
                    VillageButton.Visibility = Visibility.Visible;
                }

            }
        }

        private void HydraHead2_Click(object sender, RoutedEventArgs e)
        {
            if (GetAllItemNames(world.player1.InventoryList).Contains("Cross Guard") &&
              GetAllItemNames(world.player1.InventoryList).Contains("Hilt") &&
              GetAllItemNames(world.player1.InventoryList).Contains("pommel") &&
              GetAllItemNames(world.player1.InventoryList).Contains("Blade"))
            {
                //was hoping to do if (HydraHead1.visibility = visibility.collapsed && HydraHead2.visibility ..., but I think i will just increment a seperate variable for this since this will be the win condition
                HydraHead2.Visibility = Visibility.Collapsed;
                //since the player has the magic sword at this point we wont bring back the other hydra heads
                //increment the second hydra fight counter to be able to tell if all three heads have been "Cut off"
                secondHydraFightWinCounter++;
                if (secondHydraFightWinCounter == 3)
                {
                    LocationInformationBox.Text = $"I can't believe it {world.player1.Name} YOU DID IT!! That foul hydra has finally been defeated once and for all!\n You have set us free... Truly Thank you. THE END!";
                }

            }

            else
            {
                HydraHead2.Visibility = Visibility.Collapsed;

                //for the initial fight I want the other Hydra heads to come back after each attack on one of the other hydra heads
                HydraHead1.Visibility = Visibility.Visible;
                HydraHead3.Visibility = Visibility.Visible;

                InitialHydraFightAttackCounter++;

                if (InitialHydraFightAttackCounter == 7)
                {
                    LocationInformationBox.Text = "After your hard fought battle you realise that no matter how many times you strike down one of the hydras heads... it will always come back." +
                        "\n\n You flee from the Hydra and begin exploring the Island.";
                    //this will "end" the hydra fight, now we bring forward all of the map buttons and hide the Hydra buttons
                    HydraHead1.Visibility = Visibility.Collapsed;
                    HydraHead2.Visibility = Visibility.Collapsed;
                    HydraHead3.Visibility = Visibility.Collapsed;
                    ForestButton.Visibility = Visibility.Visible;
                    CaveButton.Visibility = Visibility.Visible;
                    RuinedTownButton.Visibility = Visibility.Visible;
                    VillageButton.Visibility = Visibility.Visible;
                }

            }
        }

        private void HydraHead3_Click(object sender, RoutedEventArgs e)
        {
            if (GetAllItemNames(world.player1.InventoryList).Contains("Cross Guard") &&
              GetAllItemNames(world.player1.InventoryList).Contains("Hilt") &&
              GetAllItemNames(world.player1.InventoryList).Contains("pommel") &&
              GetAllItemNames(world.player1.InventoryList).Contains("Blade"))
            {
                //was hoping to do if (HydraHead1.visibility = visibility.collapsed && HydraHead2.visibility ..., but I think i will just increment a seperate variable for this since this will be the win condition
                HydraHead3.Visibility = Visibility.Collapsed;
                //since the player has the magic sword at this point we wont bring back the other hydra heads
                //increment the second hydra fight counter to be able to tell if all three heads have been "Cut off"
                secondHydraFightWinCounter++;
                if (secondHydraFightWinCounter == 3)
                {
                    LocationInformationBox.Text = $"I can't believe it {world.player1.Name} YOU DID IT!! That foul hydra has finally been defeated once and for all!\n You have set us free... Truly Thank you. THE END!";
                }

            }

            else
            {
                HydraHead3.Visibility = Visibility.Collapsed;

                //for the initial fight I want the other Hydra heads to come back after each attack on one of the other hydra heads
                HydraHead2.Visibility = Visibility.Visible;
                HydraHead1.Visibility = Visibility.Visible;

                InitialHydraFightAttackCounter++;

                if (InitialHydraFightAttackCounter == 7)
                {
                    LocationInformationBox.Text = "After your hard fought battle you realise that no matter how many times you strike down one of the hydras heads... it will always come back." +
                        "\n\n You flee from the Hydra and begin exploring the Island.";
                    //this will "end" the hydra fight, now we bring forward all of the map buttons and hide the Hydra buttons
                    HydraHead1.Visibility = Visibility.Collapsed;
                    HydraHead2.Visibility = Visibility.Collapsed;
                    HydraHead3.Visibility = Visibility.Collapsed;
                    ForestButton.Visibility = Visibility.Visible;
                    CaveButton.Visibility = Visibility.Visible;
                    RuinedTownButton.Visibility = Visibility.Visible;
                    VillageButton.Visibility = Visibility.Visible;
                }

            }
        }

        private void hydraFightButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAllItemNames(world.player1.InventoryList).Contains("Cross Guard") &&
               GetAllItemNames(world.player1.InventoryList).Contains("Hilt") &&
               GetAllItemNames(world.player1.InventoryList).Contains("pommel") &&
               GetAllItemNames(world.player1.InventoryList).Contains("Blade"))
            {
                LocationInformationBox.Text = $"{world.player1.Name} please, use the magic sword and destroy this creature of despair once and for all... We're depending on you {world.player1.Name}";
            }
            else
            {
//this is just the button that is going to initiate the fights with the Hydra, making the buttons visible and removing all other buttons
                LocationInformationBox.Text = "I must warn you... this is no regular beast. The odds are nowhere near being in your favor, nevertheless Please try your hardest";
           
            }
                 //hide the fight button
            hydraFightButton.Visibility = Visibility.Collapsed;
            //bring the hydra head buttons forward
            HydraHead1.Visibility = Visibility.Visible;
            HydraHead2.Visibility = Visibility.Visible;
            HydraHead3.Visibility= Visibility.Visible;
        }
    }
}
