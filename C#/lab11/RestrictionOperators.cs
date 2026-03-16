using System;
using Task;

namespace Task1
{
    public static class Program
    {
        public static void Execute()
        {
            var CustomersList = ListGenerators.CustomerList;
            var ProductList = ListGenerators.ProductList;

            Console.WriteLine("Products with no units in stock:\n");

            var outOfStockProducts = ProductList.Where(p => p.UnitsInStock == 0);

            foreach (var p in outOfStockProducts)
            {
                Console.WriteLine(p.ProductName);
            }


            Console.WriteLine("\nProducts with units in stock and price > 3.00:\n");

            var products =
                ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }


            Console.WriteLine("\nStrings with length < index:\n");

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result =
                Arr.Where((name, index) => name.Length < index);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}