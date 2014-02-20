using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class AutoEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> _enumerator = null;
        public AutoEnumerator(IEnumerator<T> enumerator)
        {
            if (enumerator == null) { throw new ArgumentNullException("enumerator"); }
            _enumerator = enumerator;
        }

        public T GetNext()
        {
            MoveNext();
            return Current;
        }

        #region IEnumerator<T> Members

        public T Current
        {
            get { return _enumerator.Current; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_enumerator != null)
            {
                _enumerator.Dispose();
                _enumerator = null;
            }
        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }

        #endregion
    }
}
