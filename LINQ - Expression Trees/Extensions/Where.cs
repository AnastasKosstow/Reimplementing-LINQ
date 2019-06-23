
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null) throw new ArgumentNullException("source");
            if (predicate is null) throw new ArgumentNullException("predicate");

            return WhereIterator(source, predicate);
        }

        public static IEnumerable<TSource> WhereIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }
    }
}
