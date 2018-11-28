using System;
using InterfaceObserver;

namespace Net.Mentoring.Patterns.InterfaceObserver
{
    internal class MicrosoftMonitor : IAbstractObserver
    {
        public void Notify(Stock st)
        {
            CheckFilter(st);
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10.00m)
                Console.WriteLine("Microsoft has reached the target price: {0}", value.Price);
        }
    }
}