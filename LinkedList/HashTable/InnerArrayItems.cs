using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class InnerArrayItems<TKey, TValue>
    {
        LinkedList<ItemPair<TKey, TValue>> items;

        public void Add(TKey key, TValue value)
        {
            if (items == null)
            {
                items = new LinkedList<ItemPair<TKey, TValue>>();
            }
            else
            {
                // Multiple items might collide and exist in this list - but each
                // key should only be in the list once.
                foreach (ItemPair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        throw new ArgumentException("The collection already contains the key");
                    }
                }
            }

            // if we made it this far - add the item
            items.AddFirst(new ItemPair<TKey, TValue>(key, value));
        }

        internal bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        internal void Update(TKey key, TValue value)
        {
            bool updated = false;

            if (items != null)
            {
                // check each item in the list for the specified key 
                foreach (ItemPair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        // update the value
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }
            }

            if (!updated)
            {
                throw new ArgumentException("The collection does not contain the key");
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            bool found = false;

            if (items != null)
            {
                foreach (ItemPair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }
        public IEnumerable<ItemPair<TKey, TValue>> Items
        {
            get
            {
                if (items != null)
                {
                    foreach (ItemPair<TKey, TValue> item in items)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
