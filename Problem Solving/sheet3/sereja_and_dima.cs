using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int l = 0, r = n - 1;
        int sereja = 0, dima = 0;
        bool turn = true;   // true -> Sereja, false -> Dima

        while (l <= r)
        {
            int take;
            if (a[l] > a[r])
            {
                take = a[l];
                l++;
            }
            else
            {
                take = a[r];
                r--;
            }

            if (turn)
                sereja += take;
            else
                dima += take;

            turn = !turn;
        }

        Console.WriteLine($"{sereja} {dima}");
    }
}