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

            return _(); IEnumerable<TSource> _()
            {
                using var enumerator = source.GetEnumerator();

                while (enumerator.MoveNext())
                    if (predicate(enumerator.Current))
                    {
                        yield return enumerator.Current;
                    }
            }
        }
    }
}