using System;

namespace Net.Mentoring.Patterns.DelegateObserver
{
    internal class StockTicker
    {
        private Stock _stock;
        public Action<Stock> StockChange;

        public Stock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                StockChange?.Invoke(_stock);
            }
        }
    }
}