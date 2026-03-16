using System;
using Task;

namespace Task5
{
    public static class Program
    {
        public static void Execute()
        {
            var CustomersList = ListGenerators.CustomerList;
            var ProductList = ListGenerators.ProductList;
            var EnglishList = ListGenerators.EnglishList;

            Console.WriteLine("Grouping numbers by remainder when divided by 5:\n");
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            var grouped1 = numbers
                .GroupBy(n => n % 5)       // group by remainder
                .OrderBy(g => g.Key);      // optional: order groups by remainder

            foreach (var group in grouped1)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
                foreach (var num in group)
                {
                    Console.WriteLine(num);
                }
            }


            Console.WriteLine("\nGrouping words by first letter:\n");
            var grouped2 = EnglishList
            .Where(w => !string.IsNullOrEmpty(w))
            .GroupBy(w => char.ToLower(w[0]))
            .OrderBy(g => g.Key);

            foreach (var group in grouped2)
            {
                Console.WriteLine($"Words starting with '{group.Key}':");
                foreach (var word in group)
                {
                    Console.WriteLine(word);
                }
            }

            
            Console.WriteLine("\nGrouping words by sorted characters without spaces:\n");
            string[] Arr = { "from", " form ", " salt", " last", " earn ", " near" };

            var grouped3 = Arr
                .GroupBy(w => w, new SameCharsComparer());

            foreach (var group in grouped3)
            {
                Console.WriteLine("Group:");
                foreach (var word in group)
                {
                    Console.WriteLine(word.Trim());
                }
                Console.WriteLine();
            }
        }
    }
}