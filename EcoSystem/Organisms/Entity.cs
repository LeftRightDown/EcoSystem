using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    public class Entity
    {
        //Declarding properties of Entity class
        public string Name { get; set; }

        //public string Type { get; set; }
        public enum Type {Producer, Consumer, Decomposer, Player, Vendor }
        public string Species { get; set; }

        public int Amount { get; set; }


    }
}
