using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public interface IArray<T> : IArrayReadable<T>, IArrayWriteable<T>
    {
        //T this[int index]
        //{
        //    get;
        //    set;
        //}

        //int Length { get; }
    }

    public interface IArrayWriteable<T>
    {
        T this[int index]
        {
            set;
        }

        int Length { get; }
    }

    public interface IArrayReadable<T>
    {
        T this[int index]
        {
            get;
        }

        int Length { get; }
    }
}
