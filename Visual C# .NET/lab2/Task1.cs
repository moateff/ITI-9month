using System;
using System.Runtime.ConstrainedExecution;

namespace Task1
{
    public class Program
    {
        public static void Execute()
        {   
            Console.Write("Enter the size of the array (N): ");
            int n = int.Parse(Console.ReadLine()!);

            int [] arr = new int[n];

            Console.WriteLine("Enter the array values:");
            for (int i = 0; i < n; i++)
            {   
                arr[i] = int.Parse(Console.ReadLine()!);
            }

            int maxDistance = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        int distance = j - i - 1;
                        if (distance > maxDistance)
                        {
                            maxDistance = distance;
                        }
                    }
                }
            }

            Console.WriteLine($"The longest distance between two equal cells is: {maxDistance}");
        }
    }
}