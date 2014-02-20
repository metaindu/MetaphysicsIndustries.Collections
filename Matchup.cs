
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
    public class Matchup<T1, T2> : IDictionary<T1,T2>
    {
        public Matchup()
        {
            _reverse = new ReverseMatchup(this);
        }

        //we can't use both IDictionary interfaces because the could result in 2x IDictionary<int,int>, for example.
        //instead, we'll expose on of the IDictionary interfaces, and provides an interlocutor for the reverse operation.

        private Dictionary<T1, T2> _d1 = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _d2 = new Dictionary<T2, T1>();

        private ReverseMatchup _reverse;

        protected class ReverseMatchup : IDictionary<T2, T1>
        {
            Matchup<T1, T2> _parent;
            public ReverseMatchup(Matchup<T1, T2> parent)
            {
                if (parent == null) { throw new ArgumentNullException("parent"); }
							
                _parent = parent;
            }

            #region IDictionary<T2,T1> Members

            public void Add(T2 key, T1 value)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public bool ContainsKey(T2 key)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public ICollection<T2> Keys
            {
                get { throw new Exception("The method or operation is not implemented."); }
            }

            public bool Remove(T2 key)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public bool TryGetValue(T2 key, out T1 value)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public ICollection<T1> Values
            {
                get { throw new Exception("The method or operation is not implemented."); }
            }

            public T1 this[T2 key]
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

            #region ICollection<KeyValuePair<T2,T1>> Members

            public void Add(KeyValuePair<T2, T1> item)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void Clear()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public bool Contains(KeyValuePair<T2, T1> item)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void CopyTo(KeyValuePair<T2, T1>[] array, int arrayIndex)
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

            public bool Remove(KeyValuePair<T2, T1> item)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion

            #region IEnumerable<KeyValuePair<T2,T1>> Members

            public IEnumerator<KeyValuePair<T2, T1>> GetEnumerator()
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
        }


        #region IDictionary<T1,T2> Members

        public void Add(T1 key, T2 value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ContainsKey(T1 key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICollection<T1> Keys
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool Remove(T1 key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICollection<T2> Values
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public T2 this[T1 key]
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

        #region ICollection<KeyValuePair<T1,T2>> Members

        public void Add(KeyValuePair<T1, T2> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable<KeyValuePair<T1,T2>> Members

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
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

        public T1 this[T2 index]
        {
            get { return _d2[index]; }
        }

        //public T2 this[T1 index]
        //{
        //    get { return _d1[index]; }
        //}

        public IDictionary<T2, T1> Reverse
        {
            get { return _reverse; }
        }
    }
}
