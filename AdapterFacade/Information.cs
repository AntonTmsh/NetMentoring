using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.AdapterFacade
{
    internal class Information<T> : IElements<T>
    {
        private readonly List<T> _list = new List<T>();

        public Information(List<T> list)
        {
            _list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public IEnumerable<T> GetElements()
        {
            return _list;
        }
    }
}
