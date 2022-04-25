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
        Ratio ratio = new Ratio();
        public void ConsumerRatio()
        {
                                  // Bat                          Guano beetle
            ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[7]);
                                 // Bat                          Dermestid beetle
            ratio.CheckRatio(MainWindow.game.Organisms[4], MainWindow.game.Organisms[6]);
                                //Hawk                          Bat
            ratio.CheckRatio(MainWindow.game.Organisms[5], MainWindow.game.Organisms[4]);
                               // Cotton Boll worm              cotton
            ratio.CheckRatio(MainWindow.game.Organisms[3], MainWindow.game.Organisms[1]);
                              // Corn Ear worm                  corn
            ratio.CheckRatio(MainWindow.game.Organisms[2], MainWindow.game.Organisms[0]);

        }
      

        public void CheckConsumerStatus()
        {
            if (Name == "Red-tailed hawk")
            {
                if (Amount >= 10)
                {   //Greater than 10
                    EntityStatus = Status.Unbalanced;
                }
                else if (Amount > 2 || Amount < 1)
                {   //Greater than 2 or Less than 1
                    EntityStatus = Status.Danger;
                }
                else if (Amount <= 2 && Amount >= 1)
                {   //Inbetween 2 and 1
                    EntityStatus = Status.Balanced;
                }
                System.Diagnostics.Debug.WriteLine($"STATUS UPDATE {EntityStatus}");
            }
            else if (Name == "Brazilian bat")
            {
                if (Amount <= 20 || Amount >= 55)
                {   //Less than 20 or Greater than 55
                    EntityStatus = Status.Unbalanced;
                }
                else if (Amount < 30 || Amount > 50)
                {     //Less than 30 or Greater than 5
                    EntityStatus = Status.Danger;
                }
                else if (Amount >= 30 && Amount <= 50)
                { //Inbetween 30 and 50
                    EntityStatus = Status.Balanced;
                }
                System.Diagnostics.Debug.WriteLine($"STATUS UPDATE {EntityStatus}");
            }
            else if (Name == "Corn earworm" || Name == "Cotton Bollworm")
            {
                if (Amount >= 50)
                {   //Greater than 50
                    EntityStatus = Status.Unbalanced;
                }
                else if (Amount < 10 || Amount > 40)
                {   //Less than 10 or Greater than 40
                    EntityStatus = Status.Danger;
                }
                else if (Amount >= 10 && Amount <= 40)
                {   //Inbetween 10 and 40
                    EntityStatus = Status.Balanced;
                }
                System.Diagnostics.Debug.WriteLine($"STATUS UPDATE {EntityStatus}");
            }
        }
    }
     
}
