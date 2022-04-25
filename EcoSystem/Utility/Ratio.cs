using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    class Ratio
    {
         CountUI count = new CountUI();
       
        //Creates population ratio between entities (From Canvas Ratio page) 
        public static double GetRatio(int entityOne, int entityTwo)
        {
            return(entityOne/entityTwo);
        }
        
        //Checks Ratio Between entity and food soruce from Canvas Page
        public void CheckRatio(Entity entityOne, Entity entityTwo)
        {
            

            if (GetRatio(entityOne.Amount, entityTwo.Amount) >= entityOne.FoodAmount)
            {
                
                System.Diagnostics.Debug.WriteLine($"{entityOne.Amount}Food bEFORE");
                //enough food
                if (entityOne.Amount >= 0 && entityTwo.Amount >= 0)
                {
                    //entity one plus random number
                    //entity two minus  random number
                    entityOne.Amount += count.IncrementCounter();
                    entityTwo.Amount -= count.DecrementCounter();
                   
                    System.Diagnostics.Debug.WriteLine($"{entityOne.Amount} Food aFTER");
                }
                else
                {
                    entityOne.Amount += 1;
                    System.Diagnostics.Debug.WriteLine($"{entityOne.Amount} += 1");
                }
              
               
            }
            else
            {
                if (entityOne.Amount >= 0 && entityTwo.Amount >= 0)
                {
                    //not enough food
                    entityOne.Amount -= count.DecrementCounter();
                    System.Diagnostics.Debug.WriteLine($"{entityOne.Amount}No Food bEFORE");
                    //entity one minus random number
                    

                    System.Diagnostics.Debug.WriteLine($"{entityOne.Amount}No Food After aFTER");
                }
                else
                {
                    entityOne.Amount = 0;
                    System.Diagnostics.Debug.WriteLine($"{entityOne.Amount} += 1");
                }
                
               
                
            }
        }
    }
}
