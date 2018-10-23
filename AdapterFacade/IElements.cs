using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.AdapterFacade
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}
