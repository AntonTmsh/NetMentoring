using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Factory
{
    public class FilterFactory : IFilterFactory
    {
        public virtual IFilter CreateFilter(string filtername)
        {
            switch (filtername)
            {
                case "BOFA":
                    return new BOFA_Filter();
                case "Connacord":
                    return new Connacord_Filter();
                case "Barclays":
                    return new Barclays_Filter();
                default:
                    return new Default_Filter();
            }
        }
    }
}
