using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public abstract class BiDictionary<TKey, TValue> : IDictionary<TKey, TValue>//, IDictionary<TValue, TKey>
    {
        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ContainsKey(TKey key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICollection<TKey> Keys
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool Remove(TKey key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICollection<TValue> Values
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool IsReadOnly
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDictionary<TValue,TKey> Members

        public void Add(TValue key, TKey value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ContainsKey(TValue key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Remove(TValue key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool TryGetValue(TValue key, out TKey value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public TKey this[TValue key]
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TValue,TKey>> Members

        public void Add(KeyValuePair<TValue, TKey> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(KeyValuePair<TValue, TKey> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<TValue, TKey>[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Remove(KeyValuePair<TValue, TKey> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable<KeyValuePair<TValue,TKey>> Members

        //IEnumerator<KeyValuePair<TValue, TKey>> IEnumerable<KeyValuePair<TValue, TKey>>.GetEnumerator()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        #endregion
    }
}
