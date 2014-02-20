
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
    public partial class TreeList<T> : IList<T>, System.Collections.IList
    {
        protected class Enumerator : IEnumerator<T>
        {
            #region IEnumerator<T> Members

            public T Current
            {
                get { throw new Exception("The method or operation is not implemented."); }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion

            #region IEnumerator Members

            object System.Collections.IEnumerator.Current
            {
                get { throw new Exception("The method or operation is not implemented."); }
            }

            public bool MoveNext()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void Reset()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion
        }
    }
}
