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
        public string Name;

        public string Type;
        //public enum Type {Producer, Consumer, Decomposer, Player, Vendor }
        public string Species;

        public int Amount;

        

        public string ImagePath;


        public event EventHandler<EventArgs> AmountChanged;



     
    }
}
