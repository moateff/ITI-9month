using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split();
        int n = int.Parse(tokens[0]);
        int h = int.Parse(tokens[1]);

        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int width = 0;
        foreach (int height in a)
        {
            if (height > h)
                width += 2;
            else
                width += 1;
        }

        Console.WriteLine(width);
    }
}