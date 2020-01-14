
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return _(); IEnumerable<TSource> _()
            {
                using var enumeratorFirst = first.GetEnumerator();
                using var enumeratorSecond = second.GetEnumerator();

                while (enumeratorFirst.MoveNext())
                    yield return enumeratorFirst.Current;

                while (enumeratorSecond.MoveNext())
                    yield return enumeratorSecond.Current;
            }
        }
    }
}
