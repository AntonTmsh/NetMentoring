using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Mentoring.Patterns.EventObserver
{ 
    public class StockChangeEventArgs : EventArgs
    {
        public StockChangeEventArgs(Stock s)
        {
            this.Stock = s;
        }
        public Stock Stock { get; set; }
    }

}
