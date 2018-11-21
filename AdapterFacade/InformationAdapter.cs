using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.AdapterFacade
{
    public class InformationAdapter<T> : IContainer<T>
    {
        private IElements<T> _collection;

        public InformationAdapter(IElements<T> elements)
        {
            _collection = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        public IEnumerable<object> Items => _collection.GetElements().Cast<object>();

        public int Count => _collection.GetElements().Count<T>();
    }
}
