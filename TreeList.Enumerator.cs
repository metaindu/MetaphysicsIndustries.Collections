
/*****************************************************************************
 *                                                                           *
 *  TreeList.Enumerator.cs                                                   *
 *  6 October 2007                                                           *
 *  Project: MetaphysicsIndustries.Collections assembly                      *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2007 Metaphysics Industries                                  *
 *                                                                           *
 *  The default enumerator class for a TreeList.                             *
 *                                                                           *
 *****************************************************************************/

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
