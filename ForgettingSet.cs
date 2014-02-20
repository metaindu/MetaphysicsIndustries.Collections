
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
    public class ForgettingSet<T> : ICollection<T>
    {
        public ForgettingSet()
            : this(0.9f, 1)
        {
        }
        public ForgettingSet(float forgetFactor, float remindFactor)
            : this(forgetFactor, remindFactor, forgetFactor / 8)
        {
        }
        public ForgettingSet(float forgetFactor, float remindFactor, float limit)
        {
            if (forgetFactor <= 0 || forgetFactor >= 1 || float.IsNaN(forgetFactor)) { throw new ArgumentOutOfRangeException("forgetFactor", "forgetFactor must be greater than zero and less than one"); }
            if (remindFactor <= 0 || float.IsNaN(remindFactor)) { throw new ArgumentOutOfRangeException("remindFactor", "remindFactor must be greater than zero"); }
            if (limit <= 0 || float.IsNaN(limit)) { throw new ArgumentOutOfRangeException("limit", "limit must be greater than zero"); }

            _forgetFactor = forgetFactor;
            _remindFactor = remindFactor;
            _limit = limit;
        }

        float _forgetFactor;    //alpha
        float _remindFactor;    //beta
        float _limit;           //lambda

        Set<T> _set = new Set<T>();
        Dictionary<T, float> _memory = new Dictionary<T, float>();

        List<T> _Remind_toRemove = new List<T>();
        protected void Remind(T item)
        {
            _memory[item] += _remindFactor;

            _Remind_toRemove.Clear();
            foreach (T item2 in _set)
            {
                _memory[item2] *= _forgetFactor;
                if (_memory[item2] < _limit)
                {
                    _Remind_toRemove.Add(item2);
                }
            }

            Collection.RemoveRange<T, T>(this, _Remind_toRemove);
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            if (!_set.Contains(item))
            {
                _set.Add(item);
                _memory.Add(item, _remindFactor);
            }
            else
            {
                Remind(item);
            }
        }

        public void Clear()
        {
            _set.Clear();
            _memory.Clear();
        }

        public bool Contains(T item)
        {
            if (_set.Contains(item))
            {
                Remind(item);
                return true;
            }
            else
            {
                return false;
            }
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
            _memory.Remove(item);
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
