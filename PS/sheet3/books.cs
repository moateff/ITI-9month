using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var first = Console.ReadLine().Split();
        int n = int.Parse(first[0]);
        long t = long.Parse(first[1]);

        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int l = 0;
        long sum = 0;
        int ans = 0;

        for (int r = 0; r < n; r++)
        {
            sum += a[r];

            while (sum > t)
            {
                sum -= a[l];
                l++;
            }

            ans = Math.Max(ans, r - l + 1);
        }

        Console.WriteLine(ans);
    }
}