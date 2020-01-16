
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
                                                               IEqualityComparer<TSource> comparer = null)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return _(); IEnumerable<TSource> _()
            {
                if (comparer is null) comparer = EqualityComparer<TSource>.Default;
                ISet<TSource> set = new HashSet<TSource>(comparer);

                foreach (var item in first)
                    if (set.Add(item)) yield return item;

                foreach (var item in second)
                    if (set.Add(item)) yield return item;
            }
        }
    }
}
