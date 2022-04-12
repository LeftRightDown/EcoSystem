using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    public class Persons: Entity, IExchange
    {
       public List<Item> Inventory;
       public float Currency { get; set; }

        public float CurrencyAdd(float currency, float item)
        {
            System.Diagnostics.Debug.WriteLine("BEFORE TOTAL" + currency + item);

            float sum = currency + item;
            System.Diagnostics.Debug.WriteLine("AFTER TOTAL" + sum);


            return sum;
        }

        //Removes Money points from Person instance depending on Item price
        public float CurrencySubtract(float currency, float item)
        {
            System.Diagnostics.Debug.WriteLine("BEFORE TOTAL" + currency + item);

            float sum = currency - item;
            System.Diagnostics.Debug.WriteLine("AFTER TOTAL" + currency + item);


            return sum;
        }

    }
}
