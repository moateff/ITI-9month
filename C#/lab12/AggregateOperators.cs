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
            var EnglishList = ListGenerators.EnglishList;

            Console.WriteLine("Count of Odd numbers:\n");
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var countOdd = Arr.Count(x => x % 2 == 1);

            Console.WriteLine(countOdd);
            

            Console.WriteLine("\nCount of orders per customer:\n");
            var ordersPerCustomer = CustomersList
                                    .Select(c => new
                                    {
                                        CustomerName = c.CompanyName,
                                        OrderCount = c.Orders.Count()
                                    });

            foreach (var pair in ordersPerCustomer)
            {
                Console.WriteLine($"{pair.CustomerName}: {pair.OrderCount}");
            }
        


            Console.WriteLine("\nCount of products per category:\n");
            var productsPerCategory = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductCount = g.Count()
                });


            foreach (var pair in productsPerCategory)
            {
                Console.WriteLine($"{pair.Category}: {pair.ProductCount}");
            }

            
            Console.WriteLine("\nThe total of the numbers in the array:\n");
            var total = Arr.Sum();
            Console.WriteLine(total);


            Console.WriteLine("\nThe total length of the words in the list:\n");
            var totalCharacters = EnglishList.Sum(w => w.Length);

            Console.WriteLine(totalCharacters);


            Console.WriteLine("\nTotal units in stock per category:\n");
            var totalUnits = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalUnitsInStock = g.Sum(p => p.UnitsInStock)
                });

            foreach (var item in totalUnits)
            {
                Console.WriteLine($"{item.Category}: {item.TotalUnitsInStock}");
            }


            Console.WriteLine("\nShortest word in the list:\n");
            var shortest = EnglishList.Min(w => w.Length);
            Console.WriteLine(shortest);


            Console.WriteLine("\nCheapest product per category:\n");
            var cheapestPerCategory = ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        CheapestPrice = g.Min(p => p.UnitsInStock)
                    });

            foreach (var item in cheapestPerCategory)
            {
                Console.WriteLine($"{item.Category}: {item.CheapestPrice}");
            }


            Console.WriteLine("\nCheapest product per category:\n");
            var result = from p in ProductList
                group p by p.Category into g
                let minPrice = g.Min(x => x.UnitPrice)
                from prod in g
                where prod.UnitPrice == minPrice
                select new { prod.ProductName, prod.Category, prod.UnitPrice };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} ({item.Category}): {item.UnitPrice:C}");
            }


            Console.WriteLine("\nLongest word in the list:\n");
            var longest = EnglishList.Max(w => w.Length);
            Console.WriteLine(longest);


            Console.WriteLine("\nMost expensive product per category:\n");
            var mostExpensivePerCategory  = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MostExpensivePrice = g.Max(p => p.UnitPrice)
                });

            foreach (var item in mostExpensivePerCategory)
            {
                Console.WriteLine($"{item.Category}: {item.MostExpensivePrice:C}");
            }


            Console.WriteLine("\nMost expensive products per category:\n");
            var expensivePerCategory = ProductList
                .GroupBy(p => p.Category)
                .SelectMany(g =>
                {
                    var maxPrice = g.Max(p => p.UnitPrice); // "let" equivalent
                    return g.Where(p => p.UnitPrice == maxPrice);
                })
                .Select(p => new { p.ProductName, p.Category, p.UnitPrice });

            foreach (var item in expensivePerCategory)
            {
                Console.WriteLine($"{item.ProductName} ({item.Category}): {item.UnitPrice:C}");
            }


            Console.WriteLine("\nAverage length of word in the list:\n");
            var average = EnglishList.Average(w => w.Length);
            Console.WriteLine(average);


            Console.WriteLine("\nAverage price per category:\n");
            var averagePerCategory = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    AveragePrice = g.Average(p => p.UnitPrice)
                });

            foreach (var item in averagePerCategory)
            {
                Console.WriteLine($"{item.Category}: {item.AveragePrice:C}");
            }
        }
    }
}