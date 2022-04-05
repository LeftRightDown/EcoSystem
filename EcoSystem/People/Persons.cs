using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    public class Persons: Entity
    {
       public List<Item> Inventory;
       public float Currency { get; set; }

    }
}
