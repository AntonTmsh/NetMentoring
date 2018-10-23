using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Factory
{
    public class BOFA_Filter : IFilter
    {
        private readonly int bofaAmount = 70;
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Amount > bofaAmount);
        }
    }
}
