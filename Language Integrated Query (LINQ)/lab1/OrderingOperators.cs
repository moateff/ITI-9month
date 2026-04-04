using System;
using Task;

namespace Task3
{
    public static class Program
    {
        public static void Execute()
        {
            var CustomersList = ListGenerators.CustomerList;
            var ProductList = ListGenerators.ProductList;


            Console.WriteLine("First product alphabetically:\n");
            var products = ProductList
                            .OrderBy(p => p.ProductName);

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName);
            }


            Console.WriteLine("\nWords in array ordered alphabetically (case insensitive):\n");

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = words
                        .OrderBy(w => w, StringComparer.OrdinalIgnoreCase); 
                        // new CaseInsensitiveComparer()

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }


            Console.WriteLine("\nProducts ordered by units in stock\n");
            products = ProductList
                    .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
            }


            Console.WriteLine("\nStrings with length then alphabetically\n");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            result = Arr
                    .OrderBy(d => d.Length)
                    .ThenBy(d => d);

            foreach (var d in result)
            {
                Console.WriteLine(d);
            }


            Console.WriteLine("\nWords with length then alphabetically (case insensitive):\n");
            result = words
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
                // new CaseInsensitiveComparer()

            foreach (var w in result)
            {
                Console.WriteLine(w);
            }


            Console.WriteLine("\nProducts ordered by category then price:\n");

            products = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
            }


            Console.WriteLine("\nWords with length then alphabetically (case insensitive):\n");
            result = words
                .OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
                // new CaseInsensitiveComparer()

            foreach (var w in result)
            {
                Console.WriteLine(w);
            }


            Console.WriteLine("\nNumbers with length > 1 and second digit is 'i':\n");
            var nums = Arr
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();

            foreach (var d in nums)
            {
                Console.WriteLine(d);
            }
        }
    }
}