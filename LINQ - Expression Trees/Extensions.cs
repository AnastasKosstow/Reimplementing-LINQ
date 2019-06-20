
namespace LINQ_ExpressionTrees
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            if (source is null) throw new ArgumentNullException("source");

            foreach (var item in source)
                yield return func(item);
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            if (source is null) throw new ArgumentNullException("source");

            foreach (var item in source)
                if (func(item))
                    yield return item;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> result)
        {
            if (first is null) throw new ArgumentNullException("first collection");
            if (second is null) throw new ArgumentNullException("second collection");

            using (IEnumerator<TFirst> firstEnumerator = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> secondEnumerator = second.GetEnumerator())
                {
                    while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                        yield return result(firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            // Can be simplified by using foreach instead of Enumerator
            // foreach (var item in source) count++;

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
    }
}
