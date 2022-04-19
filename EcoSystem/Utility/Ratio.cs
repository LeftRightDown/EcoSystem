using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    class Ratio
    {

        //Creates population ratio between entities (From Canvas Ratio page) 
        public static double GetRatio(int entityOne, int entityTwo)
        {
            return(entityOne/entityTwo);
        }

    }
}
