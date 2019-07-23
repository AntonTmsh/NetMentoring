using System;

namespace Net.Mentoring.Patterns.InterfaceObserver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var st = new StockTicker();
            st.Register(new GoogleMonitor());
            st.Register(new MicrosoftMonitor());

            foreach (var s in SampleData.getNext()) st.Stock = s;
            Console.ReadKey();
        }
    }
}