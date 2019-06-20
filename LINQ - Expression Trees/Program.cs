
namespace LINQ_ExpressionTrees
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

            var transformed = list
                .Select(x => int.Parse(x));


            // Print result
            Console.WriteLine(string.Join(" ", transformed));
        }
    }
}

