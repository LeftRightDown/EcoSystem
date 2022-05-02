using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EcoSystem
{
    public class Consumer : Entity
    {
        Ratio ratio = new Ratio();
        public void ConsumerRatio()
        {
            // Bat               4         Guano beetle
            //ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[7]);
            //                     // Bat                4         Dermestid beetle
            //ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[6]);
            //                    //Hawk                 0.13        Bat
            //ratio.CheckRatio(MainWindow.game.Organisms[5], MainWindow.game.Organisms[4]);
                                // Cotton Boll worm    0.3         cotton
            ratio.CheckRatio(MainWindow.game.Organisms[3], MainWindow.game.Organisms[1]);
                                // Corn Ear worm        0.3         corn
            ratio.CheckRatio(MainWindow.game.Organisms[2], MainWindow.game.Organisms[0]);

        }
      
        //Method for Pesticides use
        public void SprayPesticides()
        {
            Item Results = Utility.SearchInventory("Pesticide", MainWindow.game.player.Inventory);

            if (Results == null)
            {
                MessageBox.Show("No Item: 'Pesticide' Found");
            }
            else if (Results.Name == "Pesticide")
            {

                MainWindow.game.Organisms[3].Amount -= MainWindow.game.Organisms[3].Amount / 2;
                MainWindow.game.Organisms[2].Amount -= MainWindow.game.Organisms[2].Amount / 2;

                var s = MainWindow.game.player.Inventory.Find(w => w.Name == "Pesticide");
                MainWindow.game.player.Inventory.Remove(s);

                
            }
        }

        public void PlaceHawkDeterrent()
        {
            Item Results = Utility.SearchInventory("Hawk Deterrent", MainWindow.game.player.Inventory);

            if (Results == null)
            {
                MessageBox.Show("No Item: 'Hawk Deterrent' Found");
            }
            else if (Results.Name == "Hawk Deterrent")
            {

                MainWindow.game.Organisms[5].Amount -= MainWindow.game.Organisms[5].Amount / 2;
               

                var k = MainWindow.game.player.Inventory.Find(w => w.Name == "Hawk Deterrent");
                MainWindow.game.player.Inventory.Remove(k);


            }
        }


    }
     
}
