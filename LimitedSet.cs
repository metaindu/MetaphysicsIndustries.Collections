
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
