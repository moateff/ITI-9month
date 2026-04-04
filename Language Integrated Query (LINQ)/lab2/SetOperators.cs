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

            Console.WriteLine("Unique category names:\n");
            var categories =
                ProductList.Select(p => p.Category).Distinct();

            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }

            
            Console.WriteLine("\nUnique products and customers names:\n");
            var uniqueLetters = ProductList
                        .Select(p => p.ProductName[0])
                        .Concat(CustomersList.Select(c => c.CompanyName[0]))
                        .Distinct();

            foreach (var c in uniqueLetters)
            {
                Console.WriteLine(c);
            }


            Console.WriteLine("\nCommon products and customers names:\n");
            var commonLetters = ProductList
                        .Select(p => p.ProductName[0])
                        .Intersect(
                            CustomersList.Select(c => c.CompanyName[0])
                        );

            foreach (var letter in commonLetters)
            {
                Console.WriteLine(letter);
            }


            Console.WriteLine("\nUnique products names:\n");
            var uniqueProducts = ProductList
                        .Select(p => p.ProductName[0])
                        .Except(
                            CustomersList.Select(c => c.CompanyName[0])
                        );
            
            foreach (var letter in uniqueProducts)
            {
                Console.WriteLine(letter);
            }


            Console.WriteLine("\nLast last three characters:\n");
            var lastThreeChars = ProductList
                        .Select(p => p.ProductName.Substring(p.ProductName.Length - 3))
                        .Concat(
                            CustomersList.Select(c => c.CompanyName.Substring(c.CompanyName.Length - 3))
                        );
            
            foreach (var letter in lastThreeChars)
            {
                Console.WriteLine(letter);
            }
        }
    }
}