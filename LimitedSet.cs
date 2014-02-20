using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class LimitedSet<T> : ICollection<T>
    {
        public LimitedSet(int maxCount)
        {
            if (maxCount < 1) {throw new ArgumentOutOfRangeException("maxCount must be greater than 1");}

            throw new NotImplementedException("Comparer, etc.");

            _maxCount = maxCount;
        }

        int _maxCount;
        Set<T> _set = new Set<T>();

        public int MaxCount
        {
            get { return _maxCount; }
        }

        static Random _rand = new Random();
        protected void RemoveRandom()
        {
            int n = _rand.Next(Count);
            T item = default(T);
            foreach (T item2 in this)
            {
                n--;
                if (n < 0)
                {
                    item = item2;
                    break;
                }
            }

            Remove(item);
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            if (!Contains(item))
            {
                RemoveRandom();
            }

            _set.Add(item);
        }

        public void Clear()
        {
            _set.Clear();
        }

        public bool Contains(T item)
        {
            return _set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _set.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _set.Count; }
        }

        public bool IsReadOnly
        {
            get { return _set.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return _set.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        #endregion
    }
}
