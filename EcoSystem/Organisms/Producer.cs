using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
       

        public void HarvestCrops()
        {
            foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Corn"))
                item.Quantity += MainWindow.game.Organisms[0].Amount;
            foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Cotton"))
                item.Quantity += MainWindow.game.Organisms[1].Amount;


            MainWindow.game.Organisms[0].Amount -= MainWindow.game.Organisms[0].Amount;
            MainWindow.game.Organisms[1].Amount -= MainWindow.game.Organisms[1].Amount;

        }


        public void PlantSeeds()
        {
            foreach (var item in MainWindow.game.player.Inventory.Where(x => x.Name == "Seeds"))
                MainWindow.game.Organisms[0].Amount += item.Quantity;
     


            
        }
    }
}
