/*
 * EcoSystem: Bracken Cave
 * Zachary Tan, 5/2/2022
 * Credits
 * - Event Handlers From PROG 201 Canvas Demos
 * - Ratio Method from PROG 201 Canvas Page
 * - Certain Methods of Count and CountUI from Canvas Demo
 * - LoadData entities code from PROG 201 Canvas Demo
 * - DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
 * - Foreach loop assistance from (https://stackoverflow.com/questions/12986776/change-some-value-inside-the-listt)
 * Counter code from MSDN:(https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events)
 * 
 * 
 */

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



namespace EcoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Game game = new Game(); 

        public MainWindow()
        {
            InitializeComponent();
            Title = game.GameName;
            
        }
        
        private void MainWindowGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new StartInterface());
            game.SetUpGame();
        }
    }
}
