
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
    /*
     *  TreeList
     * 
     *  A binary tree that acts as a list. Insertions, deletions, and
     *  arbitrary access via list index all have O(log n) running time,
     *  which is about half-way between List and LinkedList. Nodes are
     *  interconnected, like a linked list, for more efficient sequential
     *  traversal.
     * 
     */

    public partial class TreeList<T> : IList<T>, System.Collections.IList
    {
        public TreeList()
        {
        }
        public TreeList(IEnumerable<T> collection)
            : this()
        {
            foreach (T t in collection)
            {
                Add(t);
            }
        }



        #region IList<T> Members

        public int IndexOf(T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Insert(int index, T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveAt(int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public T this[int index]
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

        #region ICollection<T> Members

        public void Add(T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region System.Collections.IList Members

        public int Add(object value)
        {
            Add((T)value);
            return Count - 1;
        }

        public bool Contains(object value)
        {
            return Contains((T)value);
        }

        public int IndexOf(object value)
        {
            return IndexOf((T)value);
        }

        public void Insert(int index, object value)
        {
            Insert(index, (T)value);
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            Remove((T)value);
        }

        object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (T)value;
            }
        }

        #endregion

        #region System.Collections.ICollection Members

        public void CopyTo(Array array, int index)
        {
            CopyTo(array as T[], index);
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        #endregion

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T t in collection)
            {
                Add(t);
            }
        }

        public void AddRange(params T[] collection)
        {
            foreach (T t in collection)
            {
                Add(t);
            }
        }
    }
}
