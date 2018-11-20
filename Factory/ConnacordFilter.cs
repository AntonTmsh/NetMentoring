using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class ConnacordFilter : IFilter
    {
        internal const int ConnacordAmountMin = 10;
        internal const int ConnacordAmountMax = 40;
        internal const string ConnacordType = "Future";
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t => (t.Type == ConnacordType & t.Amount > ConnacordAmountMin) && t.Amount < ConnacordAmountMax);
        }
    }
}
