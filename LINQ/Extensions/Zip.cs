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

            return _(); IEnumerable<TResult> _()
            {
                using var enumeratorFirst = first.GetEnumerator();
                using var enumeratorSecond = second.GetEnumerator();

                while (enumeratorFirst.MoveNext() && enumeratorSecond.MoveNext())
                    yield return result(enumeratorFirst.Current, enumeratorSecond.Current);
            }
        }
    }
}