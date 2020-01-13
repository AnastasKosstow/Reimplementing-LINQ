namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null) throw new ArgumentNullException("source");

            int size = source.Count();
            var array = new TSource[size];

            using var enumerator = source.GetEnumerator();

            for (int index = 0; index < array.Length; index++)
            {
                enumerator.MoveNext();
                array[index] = enumerator.Current;
            }
            return array;
        }
    }
}