using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class LimitedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public LimitedDictionary(int maxCount)
        {
            if (maxCount < 1) { throw new ArgumentOutOfRangeException("maxCount must be greater than 1"); }

            throw new NotImplementedException("Comparer, etc.");

            _maxCount = maxCount;
        }

        int _maxCount;
        Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        public int MaxCount
        {
            get { return _maxCount; }
        }

        static Random _rand = new Random();
        protected void RemoveRandom()
        {
            int n = _rand.Next(Count);
            TKey key = default(TKey);
            foreach (TKey key2 in Keys)
            {
                n--;
                if (n < 0)
                {
                    key = key2;
                    break;
                }
            }

            Remove(key);
        }

        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            if (!ContainsKey(key) && Count>=MaxCount)
            {
                RemoveRandom();
            }

            _dictionary.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool Remove(TKey key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return _dictionary.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            (_dictionary as IDictionary<TKey, TValue>).Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (_dictionary as IDictionary<TKey, TValue>).Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            (_dictionary as IDictionary<TKey, TValue>).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return (_dictionary as IDictionary<TKey, TValue>).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return (_dictionary as IDictionary<TKey, TValue>).Remove(item);
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
