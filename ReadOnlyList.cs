
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
