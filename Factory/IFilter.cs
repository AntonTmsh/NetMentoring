using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    public interface IFilter
    {
        IEnumerable<Trade> Match(IEnumerable<Trade> trades);
    }
}
