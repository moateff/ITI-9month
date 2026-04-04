using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();

        int anton = 0, danik = 0;

        foreach (char c in s)
        {
            if (c == 'A') anton++;
            else danik++;
        }

        if (anton > danik)
            Console.WriteLine("Anton");
        else if (danik > anton)
            Console.WriteLine("Danik");
        else
            Console.WriteLine("Friendship");
    }
}