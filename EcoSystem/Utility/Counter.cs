using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    public class Counter
    {
        //Counter code from MSDN:
        //https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events
   
        private int threshold; private int total;
        public event EventHandler ThresholdReached;
        public int Total { get => total; set => total = value; }
        public int Threshold { get => threshold; set => threshold = value; }

        public Counter(int passedThreshold) => threshold = passedThreshold;

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
                OnThresholdReached(EventArgs.Empty);
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            if (handler != null)
                handler(this, e);
        }
        
    }
}
