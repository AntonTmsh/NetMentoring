using System.Collections.Generic;

namespace Net.Mentoring.Patterns.EventObserver
{
    internal class SampleData
    {
        private static decimal[] samplePrices = new decimal[] { 10.00m, 10.25m, 555.55m, 9.50m, 9.03m, 500.00m, 499.99m, 10.10m };
        private static string[] sampleStocks = new string[] { "MSFT", "MSFT", "GOOG", "MSFT", "MSFT", "GOOG", "GOOG", "MSFT" };
        public static IEnumerable<Stock> getNext()
        {
            for (int i = 0; i < samplePrices.Length; i++)
            {
                Stock s = new Stock
                {
                    Symbol = sampleStocks[i],
                    Price = samplePrices[i]
                };
                yield return s;
            }
        }

    }
}
