
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return ConcatImpl(first, second);
        }
        private static IEnumerable<TSource> ConcatImpl<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (TSource item in first)
                yield return item;

            foreach (TSource item in second)
                yield return item;
        }
    }
}
