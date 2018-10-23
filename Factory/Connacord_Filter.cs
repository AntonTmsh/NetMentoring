using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Factory
{
    public class Connacord_Filter : IFilter
    {
        private readonly int connacordAmountMin = 10;
        private readonly int connacordAmountMax = 40;
        private readonly string connacordType = "Future";
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(t =>(t.Type == connacordType & t.Amount > connacordAmountMin) && t.Amount < connacordAmountMax);
        }
    }
}
