
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
    public class ForgettingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public ForgettingDictionary()
        {
            throw new NotImplementedException();
        }

        float _forgetFactor;    //alpha
        float _remindFactor;    //beta
        float _limit;           //lambda

        Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        Dictionary<TKey, float> _memory = new Dictionary<TKey, float>();

        List<TKey> _Remind_removals = new List<TKey>();
        protected void Remind(TKey item)
        {
            _memory[item] += _remindFactor;

            _Remind_removals.Clear();
            foreach (TKey key in _dictionary.Keys)
            {
                _memory[key] *= _forgetFactor;
                if (_memory[key] < _limit)
                {
                    _Remind_removals.Add(key);
                }
            }

            foreach (TKey key in _Remind_removals)
            {
                Remove(key);
            }
        }

        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, value);
                _memory.Add(key, _remindFactor);
            }
            else
            {
                Remind(key);
            }
        }

        public bool ContainsKey(TKey key)
        {
            if (_dictionary.ContainsKey(key))
            {
                Remind(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool Remove(TKey key)
        {
            _memory.Remove(key);
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_dictionary.ContainsKey(key))
            {
                Remind(key);
            }

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
                if (_dictionary.ContainsKey(key))
                {
                    Remind(key);
                }

                return _dictionary[key];
            }
            set
            {
                if (_dictionary.ContainsKey(key))
                {
                    Remind(key);
                }

                _dictionary[key] = value;
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
