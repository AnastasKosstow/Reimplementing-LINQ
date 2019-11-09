
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Sort<TSource>(this IEnumerable<TSource> source) where TSource : IComparable
        {
            if (source is null) throw new ArgumentNullException("source");

            TSource[] array = source.ToArray();

            if (source.Count() <= 20) return BubbleSort(array);
            else return Quicksort(array, 0, array.Length - 1);
        }
    }
}
