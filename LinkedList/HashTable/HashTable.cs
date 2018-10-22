using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        const double loadFactor = 0.72;
        int count;
        int maxItemsAtCurrentInnerArray;
        InnerArray<TKey, TValue> array;
        public HashTable() : this(10000)
        { }
        public HashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("capacity");
            }

            array = new InnerArray<TKey, TValue>(capacity);

            // when the count exceeds this value, the next Add will cause the
            // array to grow
            maxItemsAtCurrentInnerArray = (int)(capacity * loadFactor) + 1;
        }

        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            if (count >= maxItemsAtCurrentInnerArray)
            {
                InnerArray<TKey, TValue> newArray = new InnerArray<TKey, TValue>(array.Capacity * 2);

                foreach (ItemPair<TKey, TValue> item in array.Items)
                {
                    newArray.Add(item.Key, item.Value);
                }

                array = newArray;
                maxItemsAtCurrentInnerArray = (int)(array.Capacity * loadFactor) + 1;
            }

            array.Add(key, value);
            count++;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("key");
                }

                return value;
            }
            set
            {
                array.Update(key, value);
            }
        }


        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(object key, out object value)
        {
            throw new NotImplementedException();
        }
    }
}
