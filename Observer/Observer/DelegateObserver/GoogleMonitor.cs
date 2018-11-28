using System;

namespace Net.Mentoring.Patterns.DelegateObserver
{
    internal class GoogleMonitor
    {
        public GoogleMonitor(StockTicker st)
        {
            st.StockChange += CheckFilter;
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "GOOG") Console.WriteLine("Google's new price is: {0}", value.Price);
        }
    }
}