using System;

class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        for (int i = 0; i < a.Length; i++)
        {
            char ca = char.ToLower(a[i]);
            char cb = char.ToLower(b[i]);

            if (ca < cb)
            {
                Console.WriteLine(-1);
                return;
            }
            else if (ca > cb)
            {
                Console.WriteLine(1);
                return;
            }
        }

        Console.WriteLine(0);
    }
}