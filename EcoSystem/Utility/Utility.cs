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
        //public static void PrintLog(string output)
        //{
        //    ((MainWindow)System.Windows.Application.Current.MainWindow).LogTxt.Text += output;

        //}

        //Checks Persons Inventory
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
                System.Diagnostics.Debug.WriteLine("HERE IS ITEMS BEING PASSED: " + x.Name);
                return x;
                
            }
            return null;
        }
        //Returns color based on status indicator of entity
        public static Brush GetStatusColor(Entity entity)
        {
            if (entity.EntityStatus == Status.Unbalanced)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (entity.EntityStatus == Status.Danger)
            {
                return new SolidColorBrush(Colors.LightGoldenrodYellow);
            }
            else if (entity.EntityStatus == Status.Balanced)
            {
                return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.Green);

        }

  
    }
}

