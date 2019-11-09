
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int take)
        {
            if (source is null) throw new ArgumentNullException("source");

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (take > 0 && enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                    take--;
                }
            }
        }
    }
}
