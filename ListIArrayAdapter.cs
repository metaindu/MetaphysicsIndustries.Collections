using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class ListIArrayAdapter<T> : IArray<T>
    {
        public ListIArrayAdapter(IList<T> list)
        {
            if (list == null) throw new ArgumentNullException("list");
            _list = list;
        }

        IList<T> _list;

        #region IArray<T> Members

        public T this[int index]
        {
            get            {                return _list[index];            }
            set            {                _list[index] = value;            }
        }

        public int Length
        {
            get { return _list.Count; }
        }

        #endregion
    }
}
