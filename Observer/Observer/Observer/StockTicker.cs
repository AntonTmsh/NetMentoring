using System;

namespace Net.Mentoring.Patterns.EventObserver
{
    internal class StockTicker
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                this.OnStockChange(new StockChangeEventArgs(this.stock));
            }
        }

        public event EventHandler<StockChangeEventArgs> StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e)
        {
            if (StockChange != null)
            {
                StockChange(this, e);
            }
        }
    }
}
