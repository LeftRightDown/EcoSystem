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

        //Code from Class 05 Demo
        
        //public void SetUp(Entity entity)
        //{
        //    counter = new Counter(GetRandomNumber());
        //    Run(entity);
        //}
        private int GetRandomNumber()
        {
            return new Random().Next(5, 10);
        }

        //private void Run(Entity entity)
        //{
        //    entity.Amount += IncrementCounter();
        //    //counter.ThresholdReached += c_ThresholdReached;
        //    Run(entity);
        //}
        public int IncrementCounter()
        {
            counter.Add(GetRandomNumber());
            return counter.Total;
        }

        public int DecrementCounter()
        {
            counter.Subtract(GetRandomNumber());
            return counter.Total;
        }

        //public void c_ThresholdReached(object sender, EventArgs e)
        //{
        //    if (true)
        //    {
                
        //    }
        //   SetUp();
        //}
    }
}

