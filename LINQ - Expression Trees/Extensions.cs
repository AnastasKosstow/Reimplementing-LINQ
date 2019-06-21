
namespace LINQ_ExpressionTrees
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            if (source is null) throw new ArgumentNullException("source");

            foreach (var item in source)
                yield return func(item);
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            if (source is null) throw new ArgumentNullException("source");

            foreach (var item in source)
                if (func(item))
                    yield return item;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> result)
        {
            if (first is null) throw new ArgumentNullException("first collection");
            if (second is null) throw new ArgumentNullException("second collection");

            using (IEnumerator<TFirst> firstEnumerator = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> secondEnumerator = second.GetEnumerator())
                {
                    while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                        yield return result(firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> second)
        {
            // IEqualityComparer<TSource> comparer

            if (source is null) throw new ArgumentNullException("source");
            if (second is null) throw new ArgumentNullException("second");

            foreach (var item in source) yield return item;
            foreach (var item in second) yield return item;
        }

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

        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int skip)
        {
            if (source is null) throw new ArgumentNullException("source");

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (skip > 0)
                {
                    skip--;
                    enumerator.MoveNext();
                }

                while (enumerator.MoveNext()) yield return enumerator.Current;
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            // Can be simplified by using foreach instead of Enumerator
            // foreach (var item in source) count++;

            int count = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        count++;
                }
            }
            return count;
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null) throw new ArgumentNullException("source");

            var list = new List<TSource>();

            foreach (var item in source)
                list.Add(item);

            return list;
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null) throw new ArgumentNullException("source");

            int size = source.Count();
            var array = new TSource[size];

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                for (int index = 0; index < array.Length; index++)
                {
                    enumerator.MoveNext();
                    array[index] = enumerator.Current;
                }
            }
            return array;
        }
    }
}
