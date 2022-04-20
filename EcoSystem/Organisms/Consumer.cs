using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EcoSystem
{
    public class Consumer : Entity
    {

        public  void ConsumerRatio()
        {
                                  // Bat                          Guano beetle
            Ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[7]);
                                 // Bat                          Dermestid beetle
            Ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[6]);
                                //Hawk                          Bat
            Ratio.CheckRatio(MainWindow.game.Organisms[5], MainWindow.game.Organisms[4]);
                               // Cotton Boll worm              cotton
            Ratio.CheckRatio(MainWindow.game.Organisms[3], MainWindow.game.Organisms[1]);
                              // Corn Ear worm                  corn
            Ratio.CheckRatio(MainWindow.game.Organisms[2], MainWindow.game.Organisms[0]);

        }
      
    }
     
}
