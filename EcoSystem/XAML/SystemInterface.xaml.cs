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
        DispatcherTimer timer;
        TimeSpan timeSpan;
        int DayNumber = 1;

        //Declaring List Property
        int index = 0;


        public SystemInterface()
        {
            InitializeComponent();
        }
        //Loads Timer objects with Grid
        private void SystemGrid_Loaded(object sender, RoutedEventArgs e)
        {
            daynumberTxt.Text = $"Day: {DayNumber}";
            Counter();
            ButtoneNextDay.Content = "Next Day";

        }
        #region "Timer"
        //Creates Timer
        private void Counter()
        {
            //DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
            timeSpan = TimeSpan.FromSeconds(10);

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

            Counter();
        }
        //Calls NextDay Method when clicked
        private void ButtoneNextDay_Click(object sender, RoutedEventArgs e)
        {
            NextDay();
            ButtoneNextDay.Visibility=Visibility.Hidden;
        }
        #endregion

        //Environment TAB
        #region "Environment"

        #region "Buttons"
        //Buttons Located inside Environment tab for player actions
        private void EnvironmentTabButtons_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonHarvest":

                    break;
                case "ButtonPlant":

                    break;
                case "ButtonPesticides":

                    break;
                case "ButtonHawkDeterrent":

                    break;

            }
        }


        #endregion

        #region "Environment Indicators/Stats"
        private void EnvironmentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //batImage.Source = new BitmapImage(new Uri(MainWindow.game.Organisms[currentSelection].ImagePath));
            
            //Setting Up information being displayed on Environment Tab

            //Producers
            cornTxt.Text = $@"Name: {MainWindow.game.Organisms[0].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[0].Amount}";
            cottonTxt.Text = $@"Name: {MainWindow.game.Organisms[1].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[1].Amount}";

            cornIndicator.Fill = GetConsumerStatusColor(MainWindow.game.Organisms[0].Amount, MainWindow.game.Organisms[0]);
            cottonIndicator.Fill = GetConsumerStatusColor(MainWindow.game.Organisms[1].Amount, MainWindow.game.Organisms[1]);
           
            //Decomposers
            beetleTxt1.Text = $@"Name: {MainWindow.game.Organisms[6].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[6].Amount}";
            beetleTxt2.Text = $@"Name: {MainWindow.game.Organisms[7].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[7].Amount}";
            
            beetleIndicator1.Fill = GetDecomposerStatusColor(MainWindow.game.Organisms[6].Amount, MainWindow.game.Organisms[6]);
            beetleIndicator2.Fill = GetDecomposerStatusColor(MainWindow.game.Organisms[7].Amount, MainWindow.game.Organisms[7]);
            
            //Producers
            batTxt.Text = $@"Name: {MainWindow.game.Organisms[4].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[4].Amount}";
            hawkTxt.Text = $@"Name: {MainWindow.game.Organisms[5].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[5].Amount}";
            wormTxt1.Text = $@"Name: {MainWindow.game.Organisms[2].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[2].Amount}";
            wormTxt2.Text = $@"Name: {MainWindow.game.Organisms[3].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[3].Amount}";

            batIndicator.Fill = GetProducerStatusColor(MainWindow.game.Organisms[4].Amount, MainWindow.game.Organisms[4]);
            hawkIndicator.Fill = GetProducerStatusColor(MainWindow.game.Organisms[5].Amount, MainWindow.game.Organisms[5]);
            wormIndicator1.Fill = GetProducerStatusColor(MainWindow.game.Organisms[2].Amount, MainWindow.game.Organisms[2]);
            wormIndicator2.Fill = GetProducerStatusColor(MainWindow.game.Organisms[3].Amount, MainWindow.game.Organisms[3]);
            
        }


        //Change Indicator Color for Producers
        private Brush GetProducerStatusColor(int amount, Entity entity)
        {
          ;
            if (entity.Type == "Producer")
            {
                if (amount <= 300)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if (amount <= 500)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else if (amount >= 1000)
                {
                    return new SolidColorBrush(Colors.Green);
                }

            }
             return new SolidColorBrush(Colors.Green);
        }

        //Change Indicator Color for Consumers
        private Brush GetConsumerStatusColor(int amount, Entity entity)
        {
            if (entity.Type == "Consumer")
            {
                if (entity.Name == "Red-tailed hawk")
                {
                    if (amount >= 10)
                    {
                        return new SolidColorBrush(Colors.Red);
                    }
                    else if (amount >= 5)
                    {
                        return new SolidColorBrush(Colors.Yellow);
                    }
                    else if (amount <= 1)
                    {
                        return new SolidColorBrush(Colors.Green);
                    }
                }
                else
                {
                    if (amount <= 50)
                    {
                        return new SolidColorBrush(Colors.Red);
                    }
                    else if (amount <= 90)
                    {
                        return new SolidColorBrush(Colors.Yellow);
                    }
                    else if (amount <= 250)
                    {
                        return new SolidColorBrush(Colors.Green);
                    }
                }
                

            }
            return new SolidColorBrush(Colors.Green);
        }

        //Change Indicator colors for Decomposers.
        private Brush GetDecomposerStatusColor(int amount, Entity entity)
        {
            if (entity.Type == "Decomposer")
            {
                if (amount >= 10)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if (amount >= 6)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else if (amount <= 5)
                {
                    return new SolidColorBrush(Colors.Green);
                }
            }
            return new SolidColorBrush(Colors.Green);

        }

        #endregion

        #endregion

        //Vendor TAB
        #region "Vendor"
       void BuyGrid_Loaded(object sender, RoutedEventArgs e)
       {
         DataContext = MainWindow.vendor.Inventory[index];
         System.Diagnostics.Debug.WriteLine($"LOADING BUYTAB");
       }

        private void SellGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = MainWindow.player.Inventory[index];
            System.Diagnostics.Debug.WriteLine($"LOADING SELLTAB");
        }

        private void VendorTabButtons_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonBuy":

                    break;
                case "ButtonSell":

                    break;
                case "BuyNextButton":
                    index++;

                    if (index >= MainWindow.vendor.Inventory.Count)
                    {
                        index = 0;
                    }
                    DataContext = MainWindow.vendor.Inventory[index];
                    System.Diagnostics.Debug.WriteLine($"{DataContext} THIS IS WHERE VENDOR");
                    break;
                case "SellNextButton":
                    index++;

                    if (index >= MainWindow.player.Inventory.Count)
                    {
                        index = 0;
                    }
                    DataContext = MainWindow.player.Inventory[index];
                    System.Diagnostics.Debug.WriteLine($"{DataContext} THIS IS WHERE PLAYER");

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

            foreach (Item x in MainWindow.player.Inventory)
            {
                output += $" Item: {x.Name} ({x.Quantity}) {Environment.NewLine} Price: {x.Price.ToString("c")} {Environment.NewLine} {x.Description} {Environment.NewLine} {Environment.NewLine}";
            }
            return output;

        }

        #endregion


    }
}
