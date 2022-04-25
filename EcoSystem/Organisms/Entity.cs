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

        public double FoodAmount;
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
                PopulationStatus();
            }
        }

        private void PopulationStatus()
        {
            switch (Type)
            {
                case "Producer":
                    producer.CheckProducerStatus();
                    break;
                case "Consumer":
                    consumer.CheckConsumerStatus();
                    break;
                case "Decomposer":
                    decomposer.CheckDecomposerStatus();
                    break;
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
