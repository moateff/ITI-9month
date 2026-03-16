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


            Console.WriteLine("Product names:\n");
            var products =
                ProductList.Select(p => p.ProductName);

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            
            System.Console.WriteLine("\nWords to upper and lower case:\n");

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var results = words.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            foreach (var item in results)
            {
                Console.WriteLine($"Upper: {item.Upper}, Lower: {item.Lower}");
            }


            Console.WriteLine("\nProduct name, category and price:\n");
            var result = ProductList.Select(p => new
            {
                p.ProductName,
                p.Category,
                Price = p.UnitPrice
            });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} - {item.Category} - {item.Price}");
            }


            Console.WriteLine("\nNumbers and whether they are in place:\n");

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var answer = Arr.Select((num, index) => new
            {
                Number = num,
                InPlace = num == index
            });

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Number}: {item.InPlace}");
            }



            Console.WriteLine("\nPairs where a < b:\n");

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = numbersA
                .SelectMany(a => numbersB, (a, b) => new { A = a, B = b })
                .Where(pair => pair.A < pair.B);

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }


            Console.WriteLine("\nOrders with total < 500:\n");
            var orders = CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500);

            foreach (var o in orders)
            {
                Console.WriteLine($"OrderID: {o.OrderID}, Total: {o.Total}");
            }


            Console.WriteLine("\nOrders before 1998:\n");
            orders = CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year <= 1998);

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.OrderID} - {o.OrderDate}");
            }
        }
    }
}