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
        public static Player player = new Player();
        public static Vendor vendor = new Vendor();
        public MainWindow()
        {
            InitializeComponent();
            Title = game.GameName;
            
        }
        
        private void MainWindowGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new StartInterface());
            player.Inventory = LoadData.LoadItems("../../data/PlayerItems.xml");
            vendor.Inventory = LoadData.LoadItems("../../data/VendorItems.xml");
        }
    }
}
