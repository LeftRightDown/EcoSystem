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


        //Universal Buy and Sell method for Each person child class
        void BuyandSell(string itemName, Persons Seller, Persons Buyer, List<Item> SellerList, List<Item> BuyerList);

        //void Sell(string itemName, Persons Seller, Persons Buyer, List<Item> SellerList, List<Item> BuyerList);


    }
}
