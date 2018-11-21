using System.Collections.Generic;

namespace Epam.NetMentoring.AdapterFacade
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}
