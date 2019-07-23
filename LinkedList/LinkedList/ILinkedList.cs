using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    interface ILinkedList<T>
    {
        int Length();
        void Add(T item);
        void AddAt(T item, int position);
        bool Remove(T item);
        bool RemoveAt(int position);
        T ElementAt(int position);
    }
}
