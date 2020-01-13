namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int skip)
        {
            if (source is null) throw new ArgumentNullException("source");

            using var enumerator = source.GetEnumerator();

            while (skip > 0)
            {
                skip--;
                enumerator.MoveNext();
            }
            while (enumerator.MoveNext()) yield return enumerator.Current;
        }
    }
}