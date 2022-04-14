using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    public class Utility
    {
        public static Item SearchInventory(string ItemName, List<Item> list)
        {


            IEnumerable<Item> Search = list
                                .Where(n => n.Name.Contains(ItemName));

            System.Diagnostics.Debug.WriteLine("HERE IS ITEMS BEING PASSED: " + ItemName);
            foreach (Item x in Search)
            {
                if (x.Name != ItemName)
                {
                    return null;
                }

                return x;
                System.Diagnostics.Debug.WriteLine("HERE IS ITEMS BEING PASSED: " + x.Name);
            }
            return null;


        }
    }
}
