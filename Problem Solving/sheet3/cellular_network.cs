using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var first = Console.ReadLine().Split();
        int n = int.Parse(first[0]);
        int m = int.Parse(first[1]);

        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] b = Console.ReadLine().Split().Select(long.Parse).ToArray();

        int j = 0;
        long answer = 0;

        for (int i = 0; i < n; i++)
        {
            while (j + 1 < m &&
                   Math.Abs(b[j + 1] - a[i]) <= Math.Abs(b[j] - a[i]))
            {
                j++;
            }

            long dist = Math.Abs(b[j] - a[i]);
            if (dist > answer)
                answer = dist;
        }

        Console.WriteLine(answer);
    }
}