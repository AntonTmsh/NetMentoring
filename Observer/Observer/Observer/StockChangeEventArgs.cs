﻿using System;

namespace Net.Mentoring.Patterns.EventObserver
{
    public class StockChangeEventArgs : EventArgs
    {
        public StockChangeEventArgs(Stock s)
        {
            Stock = s;
        }

        public Stock Stock { get; set; }
    }
}