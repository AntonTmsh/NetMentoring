using System;
using InterfaceObserver;

namespace Net.Mentoring.Patterns.InterfaceObserver
{
    internal class GoogleMonitor : IAbstractObserver
    {
        public void Notify(Stock st)
        {
            CheckFilter(st);
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "GOOG") Console.WriteLine("Google's new price is: {0}", value.Price);
        }
    }
}