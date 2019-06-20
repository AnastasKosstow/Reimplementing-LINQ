
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
    }
}
