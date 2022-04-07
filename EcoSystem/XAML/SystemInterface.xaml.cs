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
        DispatcherTimer timer;
        TimeSpan timeSpan;
        int DayNumber = 1;
        
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
        private void VendorGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void BuyComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> VendorItems = new List<string>();
            foreach (Item x in MainWindow.vendor.Inventory)
            {
                VendorItems.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("VENDOR DROPDOWN " + VendorItems.Count + x.Name);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = VendorItems;
            combo.SelectedIndex = -1;
        }
        private void SellComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> PlayerItems = new List<string>();
            foreach (Item x in MainWindow.vendor.Inventory)
            {
                PlayerItems.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("PLAYER DROPDOWN " + PlayerItems.Count + x.Name);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = PlayerItems;
            combo.SelectedIndex = -1;
        }

        #endregion

        //Inventory TAB
        #region "Inventory"

        #endregion

        
    }
}
