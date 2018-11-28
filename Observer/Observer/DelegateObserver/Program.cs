using System;

namespace Net.Mentoring.Patterns.DelegateObserver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var st = new StockTicker();
            var gf = new GoogleMonitor(st);
            var mf = new MicrosoftMonitor(st);

            foreach (var s in SampleData.getNext()) st.Stock = s;
            Console.ReadKey();
        }
    }
}