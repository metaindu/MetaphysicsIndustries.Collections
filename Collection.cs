using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public static class Collection
    {
        public static void AddRange<T, U>(this ICollection<T> collection, params U[] items)
            where U : T
        {
            AddRange(collection, (IEnumerable<U>)items);
        }
        public static void AddRange<T, U>(this ICollection<T> collection, IEnumerable<U> items)
            where U : T
        {
            U[] temp;

            if (items is U[])
            {
                temp = (U[])items;
            }
            else
            {
                temp = Collection.ToArray<U>(items);
            }

            foreach (U item in temp)
            {
                collection.Add(item);
            }
        }

        public static void RemoveRange<T, U>(this ICollection<T> collection, params U[] items)
            where U : T
        {
            RemoveRange(collection, (IEnumerable<U>)items);
        }
        public static void RemoveRange<T, U>(this ICollection<T> collection, IEnumerable<U> items)
            where U : T
        {
            foreach (U item in items)
            {
                collection.Remove(item);
            }
        }

        public static void RemoveAll<T, U>(this ICollection<T> collection, U item)
            where U : T
        {
            T[] items = new T[collection.Count];
            foreach (T item2 in items)
            {
                if (item2.Equals(item))
                {
                    collection.Remove(item2);
                }
            }
        }

        public static T[] ToArray<T>(ICollection<T> collection)
        {
            T[] array = new T[collection.Count];
            collection.CopyTo(array, 0);
            return array;
        }

        public static T[] ToArray<T>(IEnumerable<T> collection)
        {
            if (collection is T[]) return (T[])collection;

            List<T> temp = new List<T>(collection);
            return temp.ToArray();
        }

        public static U[] Extract<T, U>(IEnumerable<T> collection)
            where U : T
        {
            List<U> list = new List<U>();
            foreach (T item in collection)
            {
                if (item is U)
                {
                    list.Add((U)item);
                }
            }
            return list.ToArray();
        }

        public static T GetFirst<T>(ICollection<T> collection)
        {
            if (collection.Count > 0)
            {
                foreach (T item in collection)
                {
                    return item;
                }
            }

            return default(T);
        }

        public static bool ContainsAll<T>(IEnumerable<T> collection, params T[] items)
        {
            Set<T> collection2 = new Set<T>(collection);

            foreach (T item in items)
            {
                if (!collection2.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public delegate U[] MapFunction<T, U>(T item);
        public static U[] Map<T, U>(T[] items, MapFunction<T, U> func)
        {
            if (items == null) { throw new ArgumentNullException("items"); }
            if (func == null) { throw new ArgumentNullException("func"); }

            List<U> list = new List<U>();
            foreach (T item in items)
            {
                list.AddRange(func(item));
            }
            return list.ToArray();
        }

        public static T[] Reverse<T>(IEnumerable<T> collection)
        {
            List<T> list = new List<T>(collection);
            list.Reverse();
            return list.ToArray();
        }

        public static T[] Filter<T>(ICollection<T> collection, Predicate<T> predicate)
        {
            List<T> list = new List<T>();
            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        //public delegate TReturn GatherFunc<TItem, TReturn>(TItem item)
        //    where TItem : class
        //    where TReturn : class, IEnumerable<TItem>;
        //public static TReturn Gather<TItem, TReturn>(TItem start, GatherFunc<TItem, TReturn> func)
        //    where TItem : class
        //    where TReturn : class, IEnumerable<TItem>
        //{
        //    return Gather<TItem, TReturn, GatherFunc<TItem, TReturn>>(start, GatherFuncProxy, func);
        //}
        //public delegate TReturn GatherFunc<TItem, TReturn, TParam>(TItem item, TParam param)
        //    where TItem : class
        //    where TReturn : class, IEnumerable<TItem>;
        //static TReturn GatherFuncProxy<TItem, TReturn>(TItem item, GatherFunc<TItem, TReturn> param)
        //    where TItem : class
        //    where TReturn : class, IEnumerable<TItem>
        //{
        //    return param(item);
        //}
        //public static TReturn Gather<TItem, TReturn, TParam>(TItem start, GatherFunc<TItem, TReturn, TParam> func, TParam param)
        //    where TItem : class
        //    where TReturn : class, IEnumerable<TItem>
        //{
        //    Set<TItem> processed = new Set<TItem>();
        //    Set<TItem> toProcess = new Set<TItem>();
        //    Set<TItem> toAdd = new Set<TItem>();
        //    toProcess.Add(start);

        //    while (toProcess.Count > 0)
        //    {
        //        foreach (TItem item in toProcess)
        //        {
        //            TReturn connections = func(item, param);
        //            toAdd.AddRange(connections);
        //        }

        //        processed.AddRange(toProcess);
        //        toProcess.Clear();

        //        foreach (TItem item in toAdd)
        //        {
        //            if (!processed.Contains(item))
        //            {
        //                toProcess.AddRange(item);
        //            }
        //        }

        //        toAdd.Clear();
        //    }

        //    return (TReturn)((IEnumerable<TItem>)processed.ToArray());
        //}



        public delegate TItem[] GatherFunc<TItem>(TItem item)
            where TItem : class;
        public static TItem[] Gather<TItem>(TItem start, GatherFunc<TItem> func)
            where TItem : class
        {
            return Gather<TItem, GatherFunc<TItem>>(start, GatherFuncProxy, func);
        }
        public delegate TItem[] GatherFunc<TItem, TParam>(TItem item, TParam param)
            where TItem : class;
        public static TItem[] GatherFuncProxy<TItem>(TItem item, GatherFunc<TItem> param)
            where TItem : class
        {
            return param(item);
        }
        public static TItem[] Gather<TItem, TParam>(TItem start, GatherFunc<TItem, TParam> func, TParam param)
            where TItem : class
        {
            Set<TItem> processed = new Set<TItem>();
            Set<TItem> toProcess = new Set<TItem>();
            Set<TItem> toAdd = new Set<TItem>();
            toProcess.Add(start);

            while (toProcess.Count > 0)
            {
                foreach (TItem item in toProcess)
                {
                    TItem[] connections = func(item, param);
                    toAdd.AddRange(connections);
                }

                processed.AddRange(toProcess);
                toProcess.Clear();

                foreach (TItem item in toAdd)
                {
                    if (!processed.Contains(item))
                    {
                        toProcess.AddRange(item);
                    }
                }

                toAdd.Clear();
            }

            return processed.ToArray();
        }
    }
}
