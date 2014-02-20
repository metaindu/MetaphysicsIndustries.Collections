using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MetaphysicsIndustries.Collections
{
    public class SparseMatrix<T> : ICollection<Tuple<int, int, T>>
    {
        Dictionary<Pair<int>, T> _dictionary = new Dictionary<Pair<int>, T>();


        #region IDictionary<int,T> Members

        public void Add(int x, int y, T value)
        {
            _dictionary.Add(new Pair<int>(x, y), value);
        }

        public bool ContainsKey(int x, int y)
        {
            return _dictionary.ContainsKey(new Pair<int>(x, y));
        }

        public ICollection<Pair<int>> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool Remove(int x, int y)
        {
            return _dictionary.Remove(new Pair<int>(x, y));
        }

        public bool TryGetValue(int x, int y, out T value)
        {
            return _dictionary.TryGetValue(new Pair<int>(x, y), out value);
        }

        public ICollection<T> Values
        {
            get { return _dictionary.Values; }
        }

        public T this[int x, int y]
        {
            get
            {
                //maybe we should check that it exists in the dictionary
                //if not, return null
                //that retains the 2D array feel
                return _dictionary[new Pair<int>(x, y)];
            }
            set
            {
                _dictionary[new Pair<int>(x, y)] = value;
            }
        }

        #endregion

        #region ICollection<Tuple<int,int,T>> Members

        public void Add(Tuple<int,int,T> item)
        {
            Add(item.Value1, item.Value2, item.Value3);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(Tuple<int,int,T> item)
        {
            if (!ContainsKey(item.Value1, item.Value2)) return false;

            if (!this[item.Value1, item.Value2].Equals(item.Value3))
            {
                throw new NotImplementedException("is this correct? check ICollection<T> documentation");
                return false;
            }

            return true;
        }

        public void CopyTo(Tuple<int,int,T>[] array, int arrayIndex)
        {
            foreach (Tuple<int, int, T> item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Tuple<int,int,T> item)
        {
            if (!Contains(item))
            //!this[item.Value1, item.Value2].Equals(item.Value3)
            {
                throw new NotImplementedException("What do we do here? need to check ICollection<T> documentation");
            }

            return Remove(item.Value1, item.Value2);
        }

        #endregion

        #region IEnumerable<KeyValuePair<int,T>> Members

        public IEnumerator<Tuple<int,int,T>> GetEnumerator()
        {
            foreach (Pair<int> key in _dictionary.Keys)
            {
                yield return new Tuple<int, int, T>(key.First, key.Second, _dictionary[key]);
            }

            yield break;
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
