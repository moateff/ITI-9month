using System;
using Task;

namespace Task2
{
    public static class Program
    {
        public static void Execute()
        {
            var CustomersList = ListGenerators.CustomerList;
            var ProductList = ListGenerators.ProductList;

            Console.WriteLine("First out of stock product:");
            var firstOutOfStock =
                ProductList.FirstOrDefault(p => p.UnitsInStock == 0);

            Console.WriteLine(firstOutOfStock);


            Console.WriteLine("\nFirst product with price > 1000:");
            var product =
                ProductList.FirstOrDefault(p => p.UnitPrice > 1000);

            if (product != null)
                Console.WriteLine(product.ProductName);
            else
                Console.WriteLine("No product found");
            

            Console.WriteLine("\nSecond product with price > 5:");
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result =
                Arr.Where(x => x > 5).ElementAt(1);

            Console.WriteLine(result);
        }
    }
}