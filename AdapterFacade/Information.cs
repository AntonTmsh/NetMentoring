using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.AdapterFacade
{
    class Information<T> : IElements<T>
    {
        private readonly List<T> _list = new List<T>();

        public Information(List<T> list)
        {
            _list = list ?? throw new ArgumentNullException("Cannot create Information class");
        }

        public IEnumerable<T> GetElements()
        {
            return _list;
        }
    }
}
