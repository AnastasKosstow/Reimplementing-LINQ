
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null) throw new ArgumentNullException("source");

            int count = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        count++;
                }
            }
            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null) throw new ArgumentNullException("source");
            if (predicate is null) throw new ArgumentNullException("predicate");

            int count = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        if (predicate(enumerator.Current))
                            count++;
                }
            }
            return count;
        }
    }
}
