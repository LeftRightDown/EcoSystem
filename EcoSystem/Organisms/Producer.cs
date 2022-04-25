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
        Ratio Ratio = new Ratio();
        public void ProducerRatio()
      {
                                // Corn                     Corn Ear Worm
            Ratio.CheckRatio(MainWindow.game.Organisms[0], MainWindow.game.Organisms[2]);
                                //Cotton                    Cotton Bool Worm
            Ratio.CheckRatio(MainWindow.game.Organisms[1], MainWindow.game.Organisms[3]);
      }
        
    }
}
