using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    interface INotifyCollection<T> : ICollection<T>
    {
        event CollectionNotification<T> ItemAdded;
        event CollectionNotification<T> ItemRemoved;
    }
}
