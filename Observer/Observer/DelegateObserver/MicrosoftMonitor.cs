using System;

namespace Net.Mentoring.Patterns.DelegateObserver
{
    internal class MicrosoftMonitor
    {
        public MicrosoftMonitor(StockTicker st)
        {
            st.StockChange += CheckFilter;
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10.00m)
                Console.WriteLine("Microsoft has reached the target price: {0}", value.Price);
        }
    }
}