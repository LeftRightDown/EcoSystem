using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EcoSystem
{
    public class Persons: Entity, IExchange
    {

        //Declaaring Persons Inventory
       public List<Item> Inventory;
        //Declaring  Persons Currency
       public float Currency { get; set; }

        public string currencyDetail { get { return Currency.ToString("c"); } set => Currency.ToString(); }
        //Declaring delegate for math input
        public delegate float CurrencyMath(float currency, float item);

        public float CurrencyAdd(float currency, float item)
        {
            System.Diagnostics.Debug.WriteLine("Persons Class BEFORE TOTAL" + currency + item);

            float sum = currency + item;
            System.Diagnostics.Debug.WriteLine("Persons Class AFTER TOTAL" + sum);


            return sum;
        }

        //Removes Money points from Person instance depending on Item price
        public float CurrencySubtract(float currency, float item)
        {
            System.Diagnostics.Debug.WriteLine("Persons Class BEFORE TOTAL" + currency + item);

            float sum = currency - item;
            System.Diagnostics.Debug.WriteLine("Persons Class AFTER TOTAL" + currency + item);


            return sum;
        }



        //Universal Buy and Sell method for Each person child class
        public void Buy(string itemName, Persons Seller, Persons Buyer, List<Item> SellerList, List<Item> BuyerList)
        {
            CurrencyMath Add = CurrencyAdd;
            CurrencyMath Subtract = CurrencySubtract;

            Item Results = Utility.SearchInventory(itemName, SellerList);
            if (Results.Name == itemName)
            {
                if (Buyer.Currency >= Results.Price)
                {
                   
                    BuyerList.Add(Results);
                    
                    System.Diagnostics.Debug.WriteLine("Persons Class BEFORE SELLER" + Seller.Currency);

                    Seller.Currency = Add(Seller.Currency, Results.Price);

                    System.Diagnostics.Debug.WriteLine("Persons Class AFTER SELLER" + Seller.Currency);
                    Buyer.Currency = Subtract(Buyer.Currency, Results.Price);
                }
                else if (Buyer.Currency < Results.Price)
                {
                    MessageBox.Show("Invalid Amount");
                }

            }
            
        }

        public void Sell(string itemName, Persons Seller, Persons Buyer, List<Item> SellerList, List<Item> BuyerList)
        {
            Item Results = Utility.SearchInventory(itemName, SellerList);
            if (Results == null)
            {
                MessageBox.Show("No Valid Item");
            }
            else if (Results.Name == itemName)
            {
                if (Buyer.Currency >= Results.Price)
                {
                    BuyerList.Add(Results);
                    SellerList.Remove(Results);
                    System.Diagnostics.Debug.WriteLine("Persons BEFORE SELLER" + Seller.Currency);

                    Seller.Currency = CurrencyAdd(Seller.Currency, Results.Price);

                    System.Diagnostics.Debug.WriteLine("Persons AFTER SELLER" + Seller.Currency);
                    Buyer.Currency = CurrencySubtract(Buyer.Currency, Results.Price);
                }
                else if (Buyer.Currency < Results.Price)
                {
                    MessageBox.Show("Invalid Amount");
                }

            }

        }
    }
}
