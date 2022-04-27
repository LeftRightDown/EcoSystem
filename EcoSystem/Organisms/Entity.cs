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
        Danger,
        Unbalanced
    }
    public class Entity
    {
        //Declarding properties of Entity class
        private int amount;

        public string Name;

        public string Type;

        public string Species;

        public Status EntityStatus;

        private int index;
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


        public BitmapImage ImagePath { get; set; } 

        public double FoodAmount;
        public event EventHandler<PopulationChangeEventArgs> PopulationChange;


        protected virtual void OnPopulationChange(PopulationChangeEventArgs e)
        {
            
            PopulationChange?.Invoke(this, e);
        }


        public void Entity_PopulationChanged(object sender, PopulationChangeEventArgs e)
        {
           
            System.Diagnostics.Debug.WriteLine($"Entity Class {Name} This is Where {Type} Population Changed {e.LastAmount}  {e.NewAmount}");
            if (e.LastAmount != e.NewAmount)
            {
                switch (Type)
                {
                    case "Producer":
                        if (Amount <= 100 || Amount >= 1000)
                        {   //Less Than 100 or Greater than 1000
                            EntityStatus = Status.Unbalanced;
                        }
                        else if (Amount < 200 || Amount > 400)
                        {   //Less than 200 or Greater than 400
                            EntityStatus = Status.Danger;
                        }
                        else if (Amount >= 200 && Amount <= 400)
                        {   // Inbetween 200 and 500
                            EntityStatus = Status.Balanced;
                        }
                        System.Diagnostics.Debug.WriteLine($"Entity Class {Name} STATUS UPDATE {EntityStatus}");
                        break;
                    case "Consumer":
                        if (Name == "Red-tailed hawk")
                        {
                            if (Amount >= 20)
                            {   //Greater than 20
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount > 8 || Amount < 1)
                            {   //Greater than 8 or Less than 1
                                EntityStatus = Status.Danger;
                            }
                            else if (Amount <= 8 && Amount >= 1)
                            {   //Inbetween 8 and 1
                                EntityStatus = Status.Balanced;
                            }
                            System.Diagnostics.Debug.WriteLine($"Entity Class {Name} STATUS UPDATE {EntityStatus}");
                        }
                        else if (Name == "Brazilian bat")
                        {
                            if (Amount <= 10 || Amount >= 100)
                            {   //Less than 10 or Greater than 100
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount < 20 || Amount > 80)
                            {     //Less than 20 or Greater than 80
                                EntityStatus = Status.Danger;
                            }
                            else if (Amount >= 20 && Amount <= 80)
                            { //Inbetween 20 and 80
                                EntityStatus = Status.Balanced;
                            }
                            System.Diagnostics.Debug.WriteLine($"Entity Class {Name} STATUS UPDATE {EntityStatus}");
                        }
                        else if (Name == "Corn earworm" || Name == "Cotton Bollworm")
                        {
                            if (Amount >= 300)
                            {   //Greater than 300
                                EntityStatus = Status.Unbalanced;
                            }
                            else if (Amount < 40 || Amount > 100)
                            {   //Less than 40 or Greater than 100
                                EntityStatus = Status.Danger;
                            }
                            else if (Amount >= 40 && Amount <= 100)
                            {   //Inbetween 40 and 100
                                EntityStatus = Status.Balanced;
                            }
                            System.Diagnostics.Debug.WriteLine($"Entity Class {Name} STATUS UPDATE {EntityStatus}");
                        }
                        break;
                    case "Decomposer":
                        if (Amount <= 10 || Amount >= 250)
                        {   //Greater than 40
                            EntityStatus = Status.Unbalanced;
                        }
                        else if (Amount < 30 || Amount > 100)
                        {   //Less than 10 or Greater than 100
                            EntityStatus = Status.Danger;
                        }
                        else if (Amount >= 30 && Amount <= 100)
                        {   //Inbetween 30 and 100
                            EntityStatus = Status.Balanced;
                        }
                        System.Diagnostics.Debug.WriteLine($"Entity Class {Name} STATUS UPDATE {EntityStatus}");
                        break;
                }
            }
        }
 
        //From Canvas Demo Page (Events)
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
}
