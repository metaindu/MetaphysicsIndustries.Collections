using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    delegate void CollectionNotification<T>(INotifyCollection<T> collection, T item);
}
