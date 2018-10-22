using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    //Requirements: 
    //If setter tries to set null, such element must be removed from the dictionary.Any.Net object can be used as a key or value.
    //If you try to add the object by a key which already exists in the hash table – throw an exception.
    //If you try to get an element by key which does not exit in the has table – throw an exceptoin.
    //Cover it with unit tests
    interface IHashTable<TKey, TValue>
    {
        bool Contains(object key);
        void Add(TKey key, TValue value);
        object this[object key] { get; set; }
        bool TryGet(object key, out object value);
    }
}
