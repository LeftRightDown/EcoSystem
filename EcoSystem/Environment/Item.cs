using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EcoSystem
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public BitmapImage PathImage { get; set; }

        public string PriceDetail { get { return Price.ToString("c"); } set => Price.ToString(); }
       
        
    }
}
