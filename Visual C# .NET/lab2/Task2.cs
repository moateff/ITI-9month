using System;

namespace Task2
{
    public class Program
    {
        public static void Execute()
        {
            String input = Console.ReadLine();
            Console.WriteLine(String.Join(" ", input.Split(' ').Reverse()));
        }
    }
}