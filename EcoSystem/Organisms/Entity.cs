using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EcoSystem
{
    
    public class Entity
    {
        private int amount;

        //Declarding properties of Entity class
        public string Name;

        public string Type;
       
        public string Species;

       
      public enum Status { Balanced ,Ok, Unbalanced }

        public Status EntityStatus;

        //{
        //    get { return status; }

        //    set
        //    {
        //        EntityStatus = Status.Balanced;
        //        EntityStatus = value;

        //    }
        //}
        public int Amount
        {
            get { return amount; }
            set
            {
                if (amount == value) return;
                int oldAmount = amount;
                amount = value;
                OnPopulationChange(new PopulationChangeEventArgs(oldAmount, amount));
            }
        }

        
        public string ImagePath;
        
        
        public event EventHandler<PopulationChangeEventArgs> PopulationChange;


        protected virtual void OnPopulationChange(PopulationChangeEventArgs e)
        {
            //have code that changes number
            PopulationChange?.Invoke(this, e);
        }


        public void Entity_PopulationChanged(object sender, PopulationChangeEventArgs e)
        {
            if (e.LastAmount > e.NewAmount)
            {
                if (Type == "Producer")
                {
                    if (Species == "Zea mays saccharata")
                    {
                        
                    }
                    else if (Species == "Gossypium hirsutum")
                    {

                    }
                }
                else if (Type == "Consumer")
                {
                    if (Species == "Helicoverpa zea")
                    {

                    }
                    else if (Species == "Tadarida brasiliensis")
                    {

                    }
                    else if (Species == "Buteo jamaicensis")
                    {

                    }
                }
                else if (Type == "Decomposer")
                {
                    if (Species == "Dermestes carnivora")
                    {

                    }
                    else if (Species == "Jacobsoniidae")
                    {

                    }
                }
            }     
        }
     
     
    }
    public class PopulationChangeEventArgs : EventArgs
    {
        public readonly int LastAmount;
        public readonly int NewAmount;

        public PopulationChangeEventArgs(int lastAmount, int newAmount)
        {
            LastAmount = lastAmount; NewAmount = newAmount;
        }
    }
}
