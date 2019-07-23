using System.Collections.Generic;

namespace Epam.NetMentoring.AdapterFacade
{
    public interface IContainer<T>
    {
        IEnumerable<object> Items { get; }
        int Count { get; }
    }
}
