using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class BOFAFilter : IFilter
    {
        internal const int BofaAmount = 70;
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Amount > BofaAmount);
        }
    }
}
