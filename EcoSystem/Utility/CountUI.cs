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
        public void SetUp()
        {
            counter = new Counter(GetRandomNumber());
        }
        public static int GetRandomNumber()
        {
            return new Random().Next(5);
        }

        public int IncrementCounter()
        {
            SetUp();
            counter.Add(GetRandomNumber());
            return counter.Total;
        }

        public int DecrementCounter()
        {
            SetUp();
            counter.Subtract(GetRandomNumber());
            return counter.Total;
        }

     
    }
}

