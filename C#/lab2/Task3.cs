using System;
using System.Diagnostics;

namespace Task3
{
    public class Program
    {
        public static void Execute()
        {
            CountOnesMath(1, 100_000_000);
            CountOnesString(1, 100_000_000);
            CountOnesFast(8);
        }

        private static void CountOnesMath(int start, int end)
        {
            long count = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = start; i < end; i++)
            {
                int num = i;
                while (num > 0)
                {
                    if (num % 10 == 1) count++;
                    num /= 10;
                }
            }
            
            sw.Stop();
            Console.WriteLine($"Total 1's (math method): {count}, Time = {sw.ElapsedMilliseconds} ms");
        }

        private static void CountOnesString(int start, int end)
        {
            long count = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = start; i < end; i++)
            {
                string str = i.ToString();
                foreach (char c in str)
                {
                    if (c == '1') count++;
                }
            }
            
            sw.Stop();
            Console.WriteLine($"Total 1's (string method): {count}, Time = {sw.ElapsedMilliseconds} ms");
        }

        private static void CountOnesFast(int numOfDigits)
        {
            long count = 0;
            Stopwatch sw = Stopwatch.StartNew();

            count = numOfDigits * Convert.ToInt64(Math.Pow(10, numOfDigits - 1));

            sw.Stop();
            Console.WriteLine($"Total 1's (fast method): {count}, Time = {sw.ElapsedMilliseconds} ms");
        }
    }
}
