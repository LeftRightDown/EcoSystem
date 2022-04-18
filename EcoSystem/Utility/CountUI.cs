using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
   public class CountUI
    {
        Counter counter;
        Entity entity;
        
        //Code from Class 05 Demo
        private void SetUp()
        {
            counter = new Counter(GetRandomNumber());
            Run();
        }
        private int GetRandomNumber()
        {
            return new Random().Next(5, 100);
        }

        private void Run()
        {
            entity.Amount += IncrementCounter();
            counter.ThresholdReached += c_ThresholdReached;
            Run();
        }
        private int IncrementCounter()
        {
         counter.Add(GetRandomNumber());
            return counter.Total;
        }

        public void c_ThresholdReached(object sender, EventArgs e)
        {
            if (true)
            {
                
            }
           SetUp();
        }
    }
}

