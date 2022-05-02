using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EcoSystem
{
        
    public class Producer: Entity
    {
        Ratio ratio = new Ratio();
        public void ProducerRatio()
        {
                                 // Corn       3             Corn Ear Worm
            ratio.CheckRatio(MainWindow.game.Organisms[0], MainWindow.game.Organisms[2]);
                                //Cotton           3         Cotton Bool Worm
            ratio.CheckRatio(MainWindow.game.Organisms[1], MainWindow.game.Organisms[3]);
        }

        //Method for Harvesting Crops, Foreach from (https://stackoverflow.com/questions/12986776/change-some-value-inside-the-listt)
        public void HarvestCrops()
        {
            foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Corn"))
                item.Quantity += MainWindow.game.Organisms[0].Amount;
            foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Cotton"))
                item.Quantity += MainWindow.game.Organisms[1].Amount;


            MainWindow.game.Organisms[0].Amount -= MainWindow.game.Organisms[0].Amount;
            MainWindow.game.Organisms[1].Amount -= MainWindow.game.Organisms[1].Amount;

        }

        //Method for planting seeds
        public void PlantSeeds(string itemname)
        {  
            Item Results = Utility.SearchInventory( itemname, MainWindow.game.player.Inventory);
            if (Results == null)
            {
                MessageBox.Show("No Item: 'Corn Seed' or 'Cotton Seed' Found");
            }
            else if (Results.Name == "Corn Seeds")
            {
                foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Corn Seeds"))
                    MainWindow.game.Organisms[0].Amount += item.Quantity;

                var s = MainWindow.game.player.Inventory.Find(w => w.Name == "Corn Seeds");
                MainWindow.game.player.Inventory.Remove(s);

            }
            else if (Results.Name == "Cotton Seeds") 
            { 
                foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Cotton Seeds"))
                MainWindow.game.Organisms[1].Amount += item.Quantity;

                var e = MainWindow.game.player.Inventory.Find(w => w.Name == "Corn Seeds");
                MainWindow.game.player.Inventory.Remove(e);
            }
            
        }
    }
}
