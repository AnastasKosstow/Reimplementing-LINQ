
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            if (source is null) throw new ArgumentNullException("source");
            if (func is null) throw new ArgumentNullException("func");

            return SelectIterator(source, func);
        }

        public static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            foreach (var item in source)
                yield return func(item);
        }
    }
}
