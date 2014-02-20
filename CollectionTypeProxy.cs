using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class CollectionDebuggerTypeProxy<T>
    {
        public CollectionDebuggerTypeProxy(ICollection<T> collection)
        {
            if (collection == null) { throw new ArgumentNullException("collection"); }

            _collection = collection;
        }

        public T[] Items
        {
            get
            {
                T[] array = new T[_collection.Count];
                _collection.CopyTo(array, 0);
                return array;
            }
        }

        private ICollection<T> _collection;
    }
}
