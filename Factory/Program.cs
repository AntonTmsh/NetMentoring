using System;

namespace Epam.NetMentoring.Factory
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var trades = TradeInitializer.TradeInitialize();
            var factory = new FilterFactory();
            IFilter filter = factory.CreateFilter(FilterFactory.ConnacordFilter);
            Console.WriteLine($"Created {FilterFactory.ConnacordFilter} filter");
            var filteredTrades = filter.Match(trades);
            foreach (var trade in filteredTrades)
            {
                Console.WriteLine($"Filtered trade amount: {trade.Amount}, type: {trade.Type}, sybType: {trade.SybType}");
            }
            Console.ReadKey();
        }
    }
}
