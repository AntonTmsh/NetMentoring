using System.Collections.Generic;

namespace Net.Mentoring.Patterns.DelegateObserver
{
    internal class SampleData
    {
        private static readonly decimal[] samplePrices =
            {10.00m, 10.25m, 555.55m, 9.50m, 9.03m, 500.00m, 499.99m, 10.10m};

        private static readonly string[] sampleStocks =
            {"MSFT", "MSFT", "GOOG", "MSFT", "MSFT", "GOOG", "GOOG", "MSFT"};

        public static IEnumerable<Stock> getNext()
        {
            for (var i = 0; i < samplePrices.Length; i++)
            {
                var s = new Stock
                {
                    Symbol = sampleStocks[i],
                    Price = samplePrices[i]
                };
                yield return s;
            }
        }
    }
}