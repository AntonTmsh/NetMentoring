using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    public class DefaultFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades;
        }
    }
}
