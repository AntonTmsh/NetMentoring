using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var trade = new List<Trade> { new Trade(12, "Future", "test") };
            IFilterFactory factory;
            factory = new FilterFactory();
            IFilter filter = factory.CreateFilter("Connacord");
            filter.Match(trade);
        }
    }
}
