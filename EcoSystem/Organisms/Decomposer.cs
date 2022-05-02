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
            //dermstidBeetle       1.3     Bat
            ratio.CheckRatio(MainWindow.game.Organisms[6], MainWindow.game.Organisms[4]);
            //guanobeetle       1.3       Bat
            ratio.CheckRatio(MainWindow.game.Organisms[7], MainWindow.game.Organisms[4]);

        }

    }
}
