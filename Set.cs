
/*****************************************************************************
 *                                                                           *
 *  Set.cs                                                                   *
 *  6 July 2006                                                              *
 *  Project: MetaphysicsIndustries.Collections assembly                      *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries                                  *
 *                                                                           *
 *  A generic class that represents a set of objects. An object can either   *
 *    be in a set or not in the set.                                         *
 *                                                                           *
 *  Converted from C++/CLI to C# on 6 May 2007                               *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MetaphysicsIndustries.Collections
{
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebuggerTypeProxy<>))]
    public class Set<T> : ICollection<T>, ISerializable
    {
        private IDictionary<T, bool> _dictionary = new Dictionary<T, bool>();

        public Set()
            : this(new T[0])
        {
        }

        public Set(IEnumerable<T> initialContents)
        {
            if (initialContents != null)
            {
                AddRange(initialContents);
            }
        }

        public Set(params T[] initialContents)
            : this((IEnumerable<T>)initialContents)
        {
        }

        public static Set<T> FromArray<U>(params U[] items)
            where U : T
        {
            return FromCollection(items);
        }

        public static Set<T> FromCollection<U>(IEnumerable<U> items)
            where U : T
        {
            Set<T> set = new Set<T>();
            set.AddRange(items);
            return set;
        }

        protected Set(SerializationInfo info, StreamingContext context)
        {
            List<T> list = new List<T>();
            int i;
            for (i = 0; i < info.MemberCount; i++)
            {
                list.Add((T)info.GetValue(i.ToString(), typeof(T)));
            }

            AddRange(list);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            T[] array = this.ToArray();
            int i;
            for (i = 0; i < array.Length; i++)
            {
                info.AddValue(i.ToString(), array[i]);
            }
        }

        //public static implicit operator T[](Set<T> s)
        //{
        //    return s.ToArray();
        //}

        //public void Dispose()
        //{
        //    //T[] r = new T[Count];
        //    //CopyTo(r, 0);
        //    //foreach (T t in r)
        //    //{
        //    //    Remove(t);
        //    //}
        //    //_dictionary.Clear();

        //    //if (_dictionary != null)
        //    //{
        //    //    Clear();
        //    //    _dictionary = null;
        //    //}
        //}

        public static Set<T> Union(params T[] items)
        {
            return Union((IEnumerable<T>)items);
        }
        public static Set<T> Union(IEnumerable<T> items)
        {
            return new Set<T>(items);
        }
        public static Set<T> Union(IEnumerable<T> a, params T[] b)
        {
            return Union(a, (IEnumerable<T>)b);
        }
        public static Set<T> Union(IEnumerable<T> a, IEnumerable<T> b)
        {
            Set<T> s = new Set<T>(a);

            s.AddRange(b);

            return s;
        }
        public static Set<T> Union(params IEnumerable<T>[] sets)
        {
            Set<T> s = new Set<T>();

            foreach (IEnumerable<T> set in sets)
            {
                s.AddRange(set);
            }

            return s;
        }

        //lots of potential performance problems here.
        //public static T[] Intersection(params T[][] sets)
        //{
        //    if (sets == null) { throw new ArgumentNullException("sets"); }
        //    if (sets.Length < 1)
        //    {
        //        return new T();
        //    }
        //    Set<T> set = new Set<T>(set[0]);
        //    int i;
        //    for (i = 1; i < sets.Length; i++)
        //    {
        //        set 
        //    }
        //}
        public static T[] Intersection(T[] a, T[] b)
        {
            return Intersection(new Set<T>(a), b).ToArray();
        }
        //public static Set<T> Intersection(Set<T> a, params T[] b)
        //{
        //    return Intersection(a, (IEnumerable<T>)b);
        //}
        public static Set<T> Intersection(Set<T> a, IEnumerable<T> b)
        {
            Set<T> s = new Set<T>();

            foreach (T t in b)
            {
                if (a.Contains(t))
                {
                    s.Add(t);
                }
            }

            return s;
        }

        //public static Set<T> Difference(Set<T> a, params T[] b)
        //{
        //    return Difference(a, (IEnumerable<T>)b);
        //}
        //public static Set<T> Difference(Set<T> a, IEnumerable<T> b)
        //{
        //    Set<T> s = new Set<T>(a);

        //    s.RemoveRange(b);

        //    return s;
        //}
        public static T[] Difference(T[] a, T[] b)
        {
            Set<T> set = new Set<T>(a);
            set.RemoveRange(b);
            return set.ToArray();
        }

        public U[] Extract<U>()
            where U : T
        {
            return Collection.Extract<T, U>(this);
        }

        public bool IsEmpty
        {
            get
            {
                return Count <= 0;
            }
        }

        #region ICollection Methods

        public void Add(T item)
        {
            _dictionary[item] = true;
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(T item)
        {
            return _dictionary.Keys.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _dictionary.Keys.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return _dictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _dictionary.IsReadOnly;
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) { return false; }

            return _dictionary.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dictionary.Keys.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion ICollection Members

        public T GetFirst()
        {
            if (Count < 1)
            {
                return default(T);
            }
            else
            {
                IEnumerator<T> enu = GetEnumerator();
                enu.MoveNext();
                //dispose?
                return enu.Current;
            }
        }
        
        public void AddRange(params T[] collection)
        {
            AddRange((IEnumerable<T>)collection);
        }
        public void AddRange<U>(IEnumerable<U> collection)
            where U : T
        {
            foreach (U t in collection)
            {
                if (t != null)
                {
                    Add(t);
                }
            }
        }

        public void RemoveRange(params T[] collection)
        {
            RemoveRange((IEnumerable<T>)collection);
        }
        public void RemoveRange<U>(IEnumerable<U> collection)
            where U : T
        {
            foreach (U t in collection)
            {
                Remove(t);
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            CopyTo(array, 0);
            return array;
        }
    }
}
