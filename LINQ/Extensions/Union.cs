
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> second)
        {
            // IEqualityComparer<TSource> comparer

            if (source is null) throw new ArgumentNullException("source");
            if (second is null) throw new ArgumentNullException("second");

            foreach (var item in source) yield return item;
            foreach (var item in second) yield return item;
        }
    }
}
