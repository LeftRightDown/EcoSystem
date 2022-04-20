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
     
        public void DecomposerRatio()
        {
                                //dermstidBeetle            Bat
            Ratio.CheckRatio(MainWindow.game.Organisms[6], MainWindow.game.Organisms[4]);
                                //guanobeetle               Bat
            Ratio.CheckRatio(MainWindow.game.Organisms[7], MainWindow.game.Organisms[4]);

        }
    }
}
