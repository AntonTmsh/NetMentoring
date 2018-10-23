using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.AdapterFacade
{
    public interface IContainer<T>
    {
        IEnumerable<object> Items { get; }
        int Count { get; }
    }
}
