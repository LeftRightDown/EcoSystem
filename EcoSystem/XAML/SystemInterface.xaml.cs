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
        int currentSelection = 0;
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
            cornTxt.Text = $@"Name: {MainWindow.game.Organisms[0].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[0].Amount}";
            cottonTxt.Text = $@"Name: {MainWindow.game.Organisms[1].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[1].Amount}";
            beetleTxt1.Text = $@"Name: {MainWindow.game.Organisms[6].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[6].Amount}";
            beetleTxt2.Text = $@"Name: {MainWindow.game.Organisms[7].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[7].Amount}";
            batTxt.Text = $@"Name: {MainWindow.game.Organisms[4].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[4].Amount}";
            hawkTxt.Text = $@"Name: {MainWindow.game.Organisms[5].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[5].Amount}";
            wormTxt1.Text = $@"Name: {MainWindow.game.Organisms[2].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[2].Amount}";
            wormTxt2.Text = $@"Name: {MainWindow.game.Organisms[3].Name} {Environment.NewLine} Amount: {MainWindow.game.Organisms[3].Amount}";

            

        }




        //Change Indicator Color
        private Brush GetStatusColor(int level)
        {

            if (level <= 50)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (level == 100)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
                return new SolidColorBrush(Colors.Gold);
        }
        #endregion


    }
}
