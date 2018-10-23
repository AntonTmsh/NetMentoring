using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Factory
{
    public class Barclays_Filter : IFilter
    {
        private readonly string barclaysType = "Option";
        private readonly string barclaysSybType = "NyOption";
        private readonly int barclaysAmount = 50;
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Type == barclaysType && t.SybType == barclaysSybType && t.Amount > barclaysAmount);
        }
    }
}
