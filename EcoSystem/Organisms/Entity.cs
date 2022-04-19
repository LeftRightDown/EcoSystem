using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EcoSystem
{
        public enum Status
        {
            Balanced,
            Ok, 
            Unbalanced 
        }
    public class Entity
    {
        //Declaring Types
        Producer producer = new Producer();
        Consumer consumer = new Consumer();
        Decomposer decomposer = new Decomposer();

        //Declarding properties of Entity class
        private int amount;
        
        public string Name;

        public string Type;

        public string Species;

        public Status EntityStatus;

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

        
        public BitmapImage ImagePath;

        public int FoodAmount; 
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
                switch (Type)
                {
                    case "Producer":
                        if (Amount <= 100)
                        {
                            EntityStatus = Status.Unbalanced;
                        }
                        else if (Amount <= 300)
                        {
                            EntityStatus = Status.Ok;
                        }
                        else if (Amount >= 500)
                        {
                            EntityStatus = Status.Balanced;
                        }
                        break;
                    case "Consumer":
                        if (Name == "Red-tailed hawk")
                        {
                            if (Amount >= 10)
                            {
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount >= 5)
                            {
                                EntityStatus = Status.Ok;
                            }
                            else if (Amount <= 1)
                            {
                                EntityStatus = Status.Balanced;
                            }
                        }
                        else if (Name == "Brazilian bat")
                        {
                            if (Amount <= 10)
                            {
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount <= 20)
                            {
                                EntityStatus = Status.Ok;
                            }
                            else if (Amount <= 50)
                            {
                                EntityStatus = Status.Balanced;
                            }
                        }
                        else if (Name == "Corn earworm" || Name == "Cotton Bollworm")
                        {
                            if (Amount <= 10)
                            {
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount <= 20)
                            {
                                EntityStatus = Status.Ok;
                            }
                            else if (Amount <= 40)
                            {
                                EntityStatus = Status.Balanced;
                            }
                        }
                        break;
                    case "Decomposer":
                        if (Amount >= 15)
                        {
                            EntityStatus = Status.Unbalanced;
                        }
                        else if (Amount <= 10)
                        {
                            EntityStatus = Status.Ok;
                        }
                        else if (Amount <= 5)
                        {
                            EntityStatus = Status.Balanced;
                        }
                        break;
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
