using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal interface IExchange
    {
        //Adds Money points from Person instance depending on Item price
        float CurrencyAdd(float currency, float item);

        //Removes Money points from Person instance depending on Item price
        float CurrencySubtract(float currency, float item);
    }
}
