
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        private static IEnumerable<T> QuickSort<T>(T[] source, int left, int right) where T : IComparable
        {
            int leftIndex = left, rightIndex = right;
            T pivot = source[(left + right) / 2];

            while (leftIndex <= rightIndex)
            {
                while (source[leftIndex].CompareTo(pivot) < 0) leftIndex++;

                while (source[rightIndex].CompareTo(pivot) > 0) rightIndex--;

                if (leftIndex <= rightIndex)
                {
                    Swap(leftIndex, rightIndex, array: ref source);
                    leftIndex++;
                    rightIndex--;
                }
            }

            if (left < rightIndex)
                Quicksort(source, left, rightIndex);

            if (leftIndex < right)
                Quicksort(source, leftIndex, right);

            return source;
        }


        private static IEnumerable<T> BubbleSort<T>(T[] source) where T : IComparable
        {
            bool isSorted = false;

            for (int index = source.Length - 1; index >= 1; index--)
            {
                if (isSorted) break;
                isSorted = true;

                for (int innerIndex = 0; innerIndex < index; innerIndex++)
                {
                    if (source[innerIndex].CompareTo(source[innerIndex + 1]) > 0)
                    {
                        T temp = source[innerIndex];
                        source[innerIndex] = source[innerIndex + 1];
                        source[innerIndex + 1] = temp;
                        isSorted = false;
                    }
                }
            }
            return source;
        }


        private static void Swap<TSource>(int leftIndex, int rightIndex, ref TSource[] array) where TSource : IComparable
        {
            TSource temp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = temp;
        }
    }
}
