
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null) throw new ArgumentNullException("source");

            var list = new List<TSource>();

            foreach (var item in source)
                list.Add(item);

            return list;
        }
    }
}
