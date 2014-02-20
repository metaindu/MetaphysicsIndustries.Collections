
/*
 *  MetaphysicsIndustries.Collections
 *  Copyright (C) 2014 Metaphysics Industries, Inc., Richard Sartor
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MetaphysicsIndustries.Collections
{
    public class SparseMatrix<T> : ICollection<STuple<int, int, T>>
    {
        readonly Dictionary<STuple<int, int>, T> _dictionary = new Dictionary<STuple<int, int>, T>();


        #region IDictionary<int,int,T> Members

        public void Add(int x, int y, T value)
        {
            _dictionary.Add(new STuple<int, int>(x, y), value);
        }

        public bool ContainsKey(int x, int y)
        {
            return _dictionary.ContainsKey(new STuple<int, int>(x, y));
        }

        public ICollection<STuple<int, int>> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool Remove(int x, int y)
        {
            return _dictionary.Remove(new STuple<int, int>(x, y));
        }

        public bool TryGetValue(int x, int y, out T value)
        {
            return _dictionary.TryGetValue(new STuple<int, int>(x, y), out value);
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
                return _dictionary[new STuple<int, int>(x, y)];
            }
            set
            {
                _dictionary[new STuple<int, int>(x, y)] = value;
            }
        }

        #endregion

        #region ICollection<Tuple<int,int,T>> Members

        public void Add(STuple<int,int,T> item)
        {
            Add(item.Value1, item.Value2, item.Value3);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(STuple<int,int,T> item)
        {
            if (!ContainsKey(item.Value1, item.Value2)) return false;

            if (!this[item.Value1, item.Value2].Equals(item.Value3))
            {
                throw new NotImplementedException("is this correct? check ICollection<T> documentation");
                return false;
            }

            return true;
        }

        public void CopyTo(STuple<int,int,T>[] array, int arrayIndex)
        {
            foreach (STuple<int, int, T> item in this)
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

        public bool Remove(STuple<int,int,T> item)
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

        public IEnumerator<STuple<int,int,T>> GetEnumerator()
        {
            foreach (STuple<int, int> key in _dictionary.Keys)
            {
                yield return new STuple<int, int, T>(key.Value1, key.Value2, _dictionary[key]);
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
