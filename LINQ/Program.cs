﻿
namespace LINQ
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            var secondCollection = new List<int> { 100, 200, 300 };

            var transformed = list
                .Select(x => int.Parse(x))
                .Where(x => x > 0);

            var union = transformed.Union(secondCollection);
            var sorted = transformed.Sort();

            // Print result
            Console.WriteLine(
            string.Join(" ", transformed) + "\n" + transformed.Count() + "\n" + "Sorted: " + string.Join(" ", sorted));
        }
    }
}
