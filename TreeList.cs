
/*****************************************************************************
 *                                                                           *
 *  TreeList.cs                                                              *
 *  6 October 2007                                                           *
 *  Project: MetaphysicsIndustries.Collections assembly                      *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2007 Metaphysics Industries                                  *
 *                                                                           *
 *  A binary tree that acts as a list. Insertions, deletions, and            *
 *    arbitrary access via list index all have O(log n) running time,        *
 *    which is about half-way between List and LinkedList. Nodes are         *
 *    interconnected, like a linked list, for more efficient sequential      *
 *    traversal.                                                             *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
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
