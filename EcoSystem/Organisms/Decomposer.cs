using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EcoSystem
{
    public class Decomposer : Entity
    {
        Ratio ratio = new Ratio();
        public void DecomposerRatio()
        {
                                //dermstidBeetle            Bat
            ratio.CheckRatio(MainWindow.game.Organisms[6], MainWindow.game.Organisms[4]);
                                //guanobeetle               Bat
            ratio.CheckRatio(MainWindow.game.Organisms[7], MainWindow.game.Organisms[4]);

        }

        public void CheckDecomposerStatus()
        {
            if (Amount >= 25)
            {   //Greater than 25
                EntityStatus = Status.Unbalanced;
            }
            else if (Amount < 10 || Amount > 20)
            {   //Less than 10 or Greater than 20
                EntityStatus = Status.Danger;
            }
            else if (Amount >= 10 && Amount <= 20)
            {   //Inbetween 10 and 20
                EntityStatus = Status.Balanced;
            }
            System.Diagnostics.Debug.WriteLine($"STATUS UPDATE {EntityStatus}");
        }
    }
}
