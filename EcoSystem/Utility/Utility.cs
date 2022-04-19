using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EcoSystem
{
    public class Utility
    {
        //public static void PrintMain(string output)
        //{
        //    ((MainWindow)System.Windows.Application.Current.MainWindow)+= output;

        //}
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
        public static Brush GetStatusColor(Entity entity)
        {
            if (entity.EntityStatus == Status.Unbalanced)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (entity.EntityStatus == Status.Ok)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else if (entity.EntityStatus == Status.Balanced)
            {
                return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.Green);

        }

        public static void CheckRatio(Entity entityOne, Entity entityTwo)
        {
            if (Ratio.GetRatio(entityOne.Amount, entityTwo.Amount) >= entityOne.FoodAmount)
            {

            }
        }
    }
}

