using System;
using Task;

namespace Task4
{
    public static class Program
    {
        public static void Execute()
        {
            var CustomersList = ListGenerators.CustomerList;
            var ProductList = ListGenerators.ProductList;
            var EnglishList = ListGenerators.EnglishList;
            

            Console.WriteLine("Any word contains 'ei':\n");
            bool containsEi = EnglishList.Any(w => w.Contains("ei"));
            Console.WriteLine($"Any word contains 'ei': {containsEi}");


            Console.WriteLine("\nAny product with 0 units in stock:\n");
            var result1 = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0)) 
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });

            foreach (var group in result1)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($" - {product.ProductName} (Stock: {product.UnitsInStock})");
                }
            }


            Console.WriteLine("\nAll products in stock:\n");
            var result2 = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0)) // only categories where all products are in stock
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });

            foreach (var group in result2)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($" - {product.ProductName} (Stock: {product.UnitsInStock})");
                }
            }
        }
    }
}