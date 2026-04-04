using System;

class Program
{
    static int Solve(string s, int k, char target)
    {
        int l = 0, cnt = 0, best = 0;

        for (int r = 0; r < s.Length; r++)
        {
            if (s[r] != target)
                cnt++;

            while (cnt > k)
            {
                if (s[l] != target)
                    cnt--;
                l++;
            }

            best = Math.Max(best, r - l + 1);
        }

        return best;
    }

    static void Main()
    {
        var first = Console.ReadLine().Split();
        int n = int.Parse(first[0]);
        int k = int.Parse(first[1]);

        string s = Console.ReadLine();

        int ans = Math.Max(Solve(s, k, 'a'), Solve(s, k, 'b'));
        Console.WriteLine(ans);
    }
}