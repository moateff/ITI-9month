using System;
using System.Linq;

class Program {
    static void Main() {
        var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = tokens[0], k = tokens[1];

        int[] h = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = 0;
        for (int i = 0; i < k; i++)
            sum += h[i];

        int minSum = sum;
        int minIndex = 0;

        for (int i = k; i < n; i++) {
            sum = sum - h[i - k] + h[i];
            if (sum < minSum) {
                minSum = sum;
                minIndex = i - k + 1;
            }
        }

        // Convert to 1-based index
        Console.WriteLine(minIndex + 1);
    }
}