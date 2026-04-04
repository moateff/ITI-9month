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
            var EnglishList = ListGenerators.EnglishList;
            

            Console.WriteLine("First 3 orders for each customer in Washington:\n");
            var firstThreeOrders = CustomersList
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Take(3);

            foreach (var order in firstThreeOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, OrderDate: {order.OrderDate}, Total: {order.Total}");
            }



            Console.WriteLine("\nLast 2 orders for each customer in Washington:\n");
            var remainingOrders = CustomersList
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Skip(2);

            foreach (var order in remainingOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, OrderDate: {order.OrderDate}, Total: {order.Total}");
            }



            Console.WriteLine("\nNumbers greater than or equal to their index:\n");

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var result = Arr.TakeWhile((n, index) => n >= index);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\nNumbers not divisible by 3:\n");
            result = Arr.SkipWhile(n => n % 3 != 0);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\nNumbers not greater than or equal to their index:\n");
            result = Arr.SkipWhile((n, index) => n >= index);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
