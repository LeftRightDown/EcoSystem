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
            System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne} Amount 1 {entityTwo} Amount 2 ");
            if (entityTwo <= 0)
            {
                System.Diagnostics.Debug.WriteLine($"Ratio Class HERE {entityOne} {entityOne} ");
                return (0.00);
                
            }
            else
            System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne/ entityTwo} >= {entityOne} {entityOne} ");
            return (entityOne/entityTwo);
        }
        
        //Checks Ratio Between entity and food soruce from Canvas Page
        public void CheckRatio(Entity entityOne, Entity entityTwo)
        {
            if (GetRatio(entityOne.Amount, entityTwo.Amount) >= entityOne.FoodAmount)
            {
                
                System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount}Food bEFORE {entityOne.FoodAmount}");
                System.Diagnostics.Debug.WriteLine($"Ratio Class {entityTwo.Name} {entityTwo.Amount} Food bEFORE ");
                //enough food
                //Entity population is greater than 0
                if (entityOne.Amount > 0 && entityTwo.Amount > 0)
                {
                    //entity one plus random number
                    //entity two minus  random number
                    entityOne.Amount += count.IncrementCounter();
                    entityTwo.Amount -= count.DecrementCounter();
                   
                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount} Food aFTER {entityOne.FoodAmount}");
                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityTwo.Name} {entityTwo.Amount} Food aFTER ");
                }
                  //Entity population is less than 0
                else if (entityOne.Amount < 0 || entityTwo.Amount < 0)
                {
                    if(entityOne.Amount < 0)
                    {
                     entityOne.Amount += 1;
                     System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount} += 1");
                    }
                    else if(entityTwo.Amount < 0)
                    {
                        entityTwo.Amount += 1;
                        System.Diagnostics.Debug.WriteLine($"Ratio Class {entityTwo.Name} {entityTwo.Amount} += 1");
                    }
                }
                else if (entityOne.Amount == 0 || entityTwo.Amount == 0)
                {
                    entityOne.Amount = 0;
                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount} = 0 ");
                }
            }
            else
            {    //not enough food
                if (entityOne.Amount < 0 && entityTwo.Amount < 0)
                {
                    //entity one minus random number
                    entityOne.Amount -= count.DecrementCounter();
                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount}No Food bEFORE {entityOne.FoodAmount}"); 

                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount}No Food After aFTER {entityOne.FoodAmount}");
                }
                else if (entityOne.Amount < 0 || entityTwo.Amount < 0)
                {
                    if (entityOne.Amount < 0)
                    {
                        entityOne.Amount += 1;
                        System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount} += 1");
                    }
                    else if (entityTwo.Amount < 0)
                    {
                        entityTwo.Amount += 1;
                        System.Diagnostics.Debug.WriteLine($"Ratio Class {entityTwo.Name} {entityTwo.Amount} += 1");
                    }
                }
                else if (entityOne.Amount == 0 || entityTwo.Amount == 0)
                {
                    entityOne.Amount = 0;
                    System.Diagnostics.Debug.WriteLine($"Ratio Class {entityOne.Name} {entityOne.Amount} = 0 ");
                }
                
               
                
            }
        }
    }
}
