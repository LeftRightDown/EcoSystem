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

        private void Counter()
        {
            //DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
            timeSpan = TimeSpan.FromSeconds(5);

            timer = new DispatcherTimer(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    timerTxt.Text = timeSpan.ToString("c");
                    if (timeSpan == TimeSpan.Zero)
                    {
                        timer.Stop();

                        //What do you want to happen when the timer stops?
                        //Add that code here
                        NextDay();

                    }
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                },
                Application.Current.Dispatcher);

            timer.Start();
        }

        private void SystemGrid_Loaded(object sender, RoutedEventArgs e)
        {
            daynumberTxt.Text = $"Day: {DayNumber}";
            Counter();
        }

        private void NextDay()
        {
            //next day code

            DayNumber++;
            daynumberTxt.Text = $"Day: {DayNumber}";

            Counter();
        }
    }
}
