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
                                 // Corn                     Corn Ear Worm
            ratio.CheckRatio(MainWindow.game.Organisms[0], MainWindow.game.Organisms[2]);
                                //Cotton                    Cotton Bool Worm
            ratio.CheckRatio(MainWindow.game.Organisms[1], MainWindow.game.Organisms[3]);
        }
       
       public void CheckProducerStatus()
        {
            if (Amount <= 100 || Amount >= 600)
            {   //Less Than 100 or Greater than 600
                EntityStatus = Status.Unbalanced;
            }
            else if (Amount < 400 || Amount > 500)
            {   //Less than 400 or Greater than 500
                EntityStatus = Status.Danger;
            }
            else if (Amount <= 400 && Amount >= 500)
            {   // Inbetween 400 and 500
                EntityStatus = Status.Balanced;
            }
            System.Diagnostics.Debug.WriteLine($"STATUS UPDATE {EntityStatus}");
        } 
    }
}
