﻿using System;
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



namespace EcoSystem
{
    /// <summary>
    /// Interaction logic for StartInterface.xaml
    /// </summary>
    public partial class StartInterface : Page
    {
        public StartInterface()
        {
            InitializeComponent();
        }

        private void StartInterfaceGrid_Loaded(object sender, RoutedEventArgs e)
        {
            MainTitle.Content = MainWindow.game.GameName;

        }

        private void StartMenu_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonOne":
                    NavigationService.Navigate(new Uri("SystemInterface.xaml", UriKind.Relative));
                    break;

                case "ButtonTwo":
                    MessageBox.Show
                    (@"
                     Designed and Programed By: Zachary Tan
                     Debugging & Structural Assistance from: Mack, Pearson - Muggli && Janell Baxter
                     Additional Code reused from in class group demos.
                    ",
                    "CREDITS"
                    );
                    break;

                case "ButtonThree":
                    //Environment.Exit(0);
                    break;
            }
        }
    }
}
