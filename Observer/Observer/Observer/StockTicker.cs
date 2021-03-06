﻿using System;

namespace Net.Mentoring.Patterns.EventObserver
{
    internal class StockTicker
    {
        private Stock _stock;

        public Stock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                OnStockChange(new StockChangeEventArgs(_stock));
            }
        }

        public event EventHandler<StockChangeEventArgs> StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e)
        {
            StockChange?.Invoke(this, e);
        }
    }
}