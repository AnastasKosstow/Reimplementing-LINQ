
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> result)
        {
            if (first is null) throw new ArgumentNullException("first collection");
            if (second is null) throw new ArgumentNullException("second collection");

            return ZipIterator(first, second, result);
        }

        public static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> result)
        {
            using (IEnumerator<TFirst> firstEnumerator = first.GetEnumerator())
            using (IEnumerator<TSecond> secondEnumerator = second.GetEnumerator())
            {
                while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                    yield return result(firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
