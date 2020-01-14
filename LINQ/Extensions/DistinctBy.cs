﻿
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public partial class Extensions 
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return _(); IEnumerable<TSource> _()
            {
                var knownKeys = new HashSet<TKey>();
                foreach (var element in source)
                    if (knownKeys.Add(keySelector(element)))
                    {
                        yield return element;
                    }
            }
        }
    }
}
