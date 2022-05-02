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
using System.Windows.Threading;


namespace EcoSystem
{
    /// <summary>
    /// Interaction logic for SystemInterface.xaml
    /// </summary>
    
    public partial class SystemInterface : Page
    {

        //Declaring Timer Properties
        CountUI count;
        DispatcherTimer timer;
        TimeSpan timeSpan;
         int DayNumber = 1;

        //Declaring List Property
        int index = 0;


        //Declaring Buy and Sell Delegate
        private Item Input;
        private delegate void BuyAndSell(string itemName, Persons Seller, Persons Buyer, List<Item> SellerList, List<Item> BuyerList);
        
        
        public SystemInterface()
        {
            InitializeComponent();
            
        }
        //Loads Timer objects with Grid
        private void SystemGrid_Loaded(object sender, RoutedEventArgs e)
        {
            daynumberTxt.Text = $"Day: {DayNumber}";
            Timer();
            ButtoneNextDay.Content = "Next Day";
            currencyText.Text = $"{MainWindow.game.player.currencyDetail}";
            MessageBox.Show("KEEP THE ECOSYSTEM BALANCED!");

        }
        //Method for end game conditions.
        public void EndGame()
        {
            if (DayNumber == 15)
            {
               
            }
        }
        #region "Timer"
        //Creates Timer
        private void Timer()
        {
            //DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
            timeSpan = TimeSpan.FromSeconds(1);

            timer = new DispatcherTimer(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    timerTxt.Text = timeSpan.ToString("c");
                    if (timeSpan == TimeSpan.Zero)
                    {
                        timer.Stop();

                        
                        ButtoneNextDay.Visibility = Visibility.Visible;

                    }
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                },
                Application.Current.Dispatcher);

            timer.Start();
        }

        //Counts Days
        private void NextDay()
        {
            //next day code
            DayNumber++;
            daynumberTxt.Text = $"Day: {DayNumber}";
            MainWindow.game.producer.ProducerRatio();
            MainWindow.game.consumer.ConsumerRatio();
            MainWindow.game.decomposer.DecomposerRatio();
            Timer();
        }
        //Calls NextDay Method when clicked
        private void ButtoneNextDay_Click(object sender, RoutedEventArgs e)
        {
            NextDay();
            
            ButtoneNextDay.Visibility=Visibility.Hidden;

            //Updates Txt
            UpdateEnvironmentLog();
            UpdateEntityTxt();
            UpdateEntityIndicator();
            
            
        }
        #endregion

        //Environment TAB
        #region "Environment"

        #region "Buttons"
        //Buttons Located inside Environment tab for player actions
        private void EnvironmentTabButtons_Click(object sender, RoutedEventArgs e)
        {
            Entity w = new Entity();
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonHarvest":
                        
                    MainWindow.game.producer.HarvestCrops();

                    UpdateEntityTxt();
                    UpdateEntityIndicator();
                    
                    break;
                case "ButtonPlant":
                    MainWindow.game.producer.PlantSeeds("Corn Seeds");
                    MainWindow.game.producer.PlantSeeds("Cotton Seeds");

                    UpdateEntityTxt();
                    UpdateEntityIndicator();
                    
                    break;
                case "ButtonPesticides":
                    MainWindow.game.consumer.SprayPesticides();

                    UpdateEntityTxt();
                    UpdateEntityIndicator();
                    break;
                case "ButtonHawkDeterrent":
                    MainWindow.game.consumer.PlaceHawkDeterrent();

                    UpdateEntityTxt();
                    UpdateEntityIndicator();
                    break;
            }
        }

        #endregion

        #region "Environment Indicators/Stats"
        private void EnvironmentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Setting Up information being displayed on Environment Tab
            UpdateEntityTxt();
            UpdateEntityIndicator();
            UpdateEnvironmentLog();


        }


        #region "Entity Info"
        public void UpdateEntityTxt()
        {

            //Producers
            cornTxt.Text = $@"Name: {MainWindow.game.Organisms[0].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[0].Amount}";
            cottonTxt.Text = $@"Name: {MainWindow.game.Organisms[1].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[1].Amount}";

            //Decomposers
            beetleTxt1.Text = $@"Name: {MainWindow.game.Organisms[6].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[6].Amount}";
            beetleTxt2.Text = $@"Name: {MainWindow.game.Organisms[7].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[7].Amount}";

            //Consumers
            batTxt.Text = $@"Name: {MainWindow.game.Organisms[4].Name}{Environment.NewLine} Amount: {MainWindow.game.Organisms[4].Amount}";
            hawkTxt.Text = $@"Name: {MainWindow.game.Organisms[5].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[5].Amount}";
            wormTxt1.Text = $@"Name: {MainWindow.game.Organisms[2].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[2].Amount}";
            wormTxt2.Text = $@"Name: {MainWindow.game.Organisms[3].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[3].Amount}";

          
        }
        public void UpdateEntityIndicator()
        {  
            //Producers 
            cornIndicator.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[0]);
            cottonIndicator.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[1]);

            //Decomposers
            beetleIndicator1.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[6]);
            beetleIndicator2.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[7]);

            //Consumers
            batIndicator.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[4]);
            hawkIndicator.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[5]);
            wormIndicator1.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[2]);
            wormIndicator2.Fill = Utility.GetStatusColor(MainWindow.game.Organisms[3]);

           
        }
        private void UpdateEnvironmentLog()
        {
            foreach (Entity e in MainWindow.game.Organisms)
            {
                if (e.Species.ToLower() != "human")
                {
                    UpdateEntityLogInfo(e);
                }
            }
        }
        private void UpdateEntityLogInfo(Entity entity)
        {
            entity.PopulationChange += entity.Entity_PopulationChanged;
            System.Diagnostics.Debug.WriteLine($"System Class STATUS UPDATE {entity.Name} {entity.EntityStatus}");

            if (entity.EntityStatus == Status.Unbalanced)
            {
                LogTxt.Text += $" Day: {DayNumber} ALERT {entity.Name} populuation {entity.EntityStatus} {Environment.NewLine}";
            }
            else if (entity.EntityStatus == Status.Danger  || entity.EntityStatus == Status.Balanced)
            {
                LogTxt.Text += $" Day: {DayNumber} {entity.Name} populuation {entity.EntityStatus} {Environment.NewLine}";
            }
        }
        #endregion

        #endregion

        #endregion

        //Vendor TAB
        #region "Vendor"

        void BuyGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (index >= MainWindow.game.vendor.Inventory.Count)
            {
                index = 0;
            }
            VendorInventoryCanvas.DataContext = MainWindow.game.vendor.Inventory[index];
        }

        private void SellGrid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (index >= MainWindow.game.player.Inventory.Count)
                {
                    index = 0;
                }
                PlayerInventoryCanvas.DataContext = MainWindow.game.player.Inventory[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                PlayerInventoryCanvas.DataContext = string.Empty;
            }
           
        }

        //Buttons Within Vendor Tab
        private void VendorTabButtons_Click(object sender, RoutedEventArgs e)
        {
            //Player Buys Item from Vendor
            BuyAndSell PlayerBuy = MainWindow.game.player.Buy;
            //Vendor Buys Item from Player
            BuyAndSell VendorBuy = MainWindow.game.player.Sell;
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonBuy":
                    //Player Buys Item from Vendor
                    if (index >= MainWindow.game.vendor.Inventory.Count)
                    {
                        index = 0;
                    }
                    System.Diagnostics.Debug.WriteLine($"System Class {MainWindow.game.vendor.Inventory[index].Name} BOUGHT items");
                    PlayerBuy(MainWindow.game.vendor.Inventory[index].Name, MainWindow.game.vendor, MainWindow.game.player, MainWindow.game.vendor.Inventory, MainWindow.game.player.Inventory);
                    MessageBox.Show($"You've Bought {MainWindow.game.vendor.Inventory[index].Name}!");
                    currencyText.Text = $"{MainWindow.game.player.currencyDetail}";
                    

                    break;
                case "ButtonSell":
                    //Vendor Buys Item from Player
                    try
                    {
                        if (index >= MainWindow.game.player.Inventory.Count)
                        {
                            index = 0;
                            
                        }
                        PlayerInventoryCanvas.DataContext = MainWindow.game.player.Inventory[index];
                        System.Diagnostics.Debug.WriteLine($"System Class {MainWindow.game.player.Inventory[index].Name} SOLD items");
                        VendorBuy(MainWindow.game.player.Inventory[index].Name, MainWindow.game.player, MainWindow.game.vendor, MainWindow.game.player.Inventory, MainWindow.game.vendor.Inventory);
                        MessageBox.Show($"You've Sold {MainWindow.game.player.Inventory[index].Name}!");
                        currencyText.Text = $"{MainWindow.game.player.currencyDetail}";
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        PlayerInventoryCanvas.DataContext = string.Empty;
                    }
                   
                    

                    break;
                case "BuyNextButton":
                    //Switches Item on display for Vendor Inventory
                    index++;

                    if (index >= MainWindow.game.vendor.Inventory.Count)
                    {
                        index = 0;
                    }
                    VendorInventoryCanvas.DataContext = MainWindow.game.vendor.Inventory[index];

                    System.Diagnostics.Debug.WriteLine($"System Class {DataContext} THIS IS WHERE VENDOR");
                    break;
                case "SellNextButton":
                    //Switches Item on dispaly for Player Inventory
                    try
                    {
                        index++;

                        if (index >= MainWindow.game.player.Inventory.Count)
                        {
                            index = 0;
                        }
                        PlayerInventoryCanvas.DataContext = MainWindow.game.player.Inventory[index];

                        System.Diagnostics.Debug.WriteLine($"System Class {DataContext} THIS IS WHERE PLAYER");
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                        MessageBox.Show("Inventory is Currently Empty");
                    }
                    

                    

                    break;
            

            }
        }





        #endregion

        //Inventory TAB
        #region "Inventory"
        private void InventoryGrid_Loaded(object sender, RoutedEventArgs e)
        {
            PlayerItemList.Text = ListPlayerInventory();

        }

        private string ListPlayerInventory()
        {
            string output = "";

            foreach (Item x in MainWindow.game.player.Inventory)
            {
                output += $" Item: {x.Name} ({x.Quantity}) {Environment.NewLine} Price: {x.Price.ToString("c")} {Environment.NewLine} {x.Description} {Environment.NewLine} {Environment.NewLine}";
            }
            return output;

        }

        #endregion


    }
}
