using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public interface ISet<T> : ICollection<T>, ISet
    {
    }

    public interface ISet : System.Collections.IEnumerable
    {
    }
}
