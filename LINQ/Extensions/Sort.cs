
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

            return source.Count() <= 20
                ? BubbleSort(array)
                : QuickSort(array, 0, array.Length - 1);
        }
    }
}
