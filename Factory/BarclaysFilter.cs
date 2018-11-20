using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class BarclaysFilter : IFilter
    {
        internal const string BarclaysType = "Option";
        internal const string BarclaysSybType = "NyOption";
        internal const int BarclaysAmount = 50;
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Type == BarclaysType && t.SybType == BarclaysSybType && t.Amount > BarclaysAmount);
        }
    }
}
