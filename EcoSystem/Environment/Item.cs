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
        public float Quantity { get; set; }

        public BitmapImage Image { get; set; }

       

    }
}
