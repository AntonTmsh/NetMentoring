using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class InnerArray<TKey, TValue>
    {
        InnerArrayItems<TKey, TValue>[] array;
        public InnerArray(int capacity)
        {
            array = new InnerArrayItems<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                array[i] = new InnerArrayItems<TKey, TValue>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            array[GetIndex(key)].Add(key, value);
        }

        public void Update(TKey key, TValue value)
        {
            if (value == null)
            {
                array[GetIndex(key)].Remove(key);
            }
            else
            {
                array[GetIndex(key)].Update(key, value);
            }

        }

        //public bool Remove(TKey key)
        //{
        //    return array[GetIndex(key)].Remove(key);
        //}

        public bool TryGetValue(TKey key, out TValue value)
        {
            return array[GetIndex(key)].TryGetValue(key, out value);
        }

        public IEnumerable<ItemPair<TKey, TValue>> Items
        {
            get
            {
                foreach (InnerArrayItems<TKey, TValue> item in array)
                {
                    foreach (ItemPair<TKey, TValue> pair in item.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }


        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}
