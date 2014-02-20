
/*****************************************************************************
 *                                                                           *
 *  ReadOnlyList.cs                                                          *
 *  29 March 2010                                                            *
 *  Project: MetaphysicsIndustries.Collections                               *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2010 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  An adapter that provides read-only access to a list of items.            *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class ReadOnlyList<T> : IEnumerable<T>
    {
        public ReadOnlyList(IList<T> list)
        {
            _list = list;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public virtual void CopyTo(T[] r, int i)
        {
            _list.CopyTo(r, i);
        }

        public virtual int IndexOf(T b)
        {
            return _list.IndexOf(b);
        }

        public virtual bool Contains(T b)
        {
            return _list.Contains(b);
        }

        public virtual int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public virtual T this[int index]
        {
            get
            {
                return _list[index];
            }
        }

        private IList<T> _list;

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
