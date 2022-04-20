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

        //Checks Ratio Between entity and food soruce from Canvas Page
        public static void CheckRatio(Entity entityOne, Entity entityTwo)
        {
            //
            if (GetRatio(entityOne.Amount, entityTwo.Amount) >= entityOne.FoodAmount)
            {
                //enough food
                //entity one plus the amount needed to increase
                entityOne.Amount += entityOne.FoodAmount;
                //entity two minus the amount needed to increase
                entityTwo.Amount -= entityOne.FoodAmount;
               
            }
            else
            {
                //not enough food
                //entity one minus total amount needed to increase
                entityOne.Amount -= entityOne.FoodAmount;
                //entity two plus the total amount needed to increase
                entityTwo.Amount += entityTwo.FoodAmount;
                
               
                
            }
        }
    }
}
