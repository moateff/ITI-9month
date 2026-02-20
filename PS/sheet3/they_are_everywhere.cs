using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();

        int[] total = new int[256];
        int need = 0;

        foreach (char c in s)
        {
            if (total[c] == 0) need++;
            total[c]++;
        }

        int[] cnt = new int[256];
        int have = 0;

        int l = 0;
        int ans = n;

        for (int r = 0; r < n; r++)
        {
            if (cnt[s[r]] == 0) have++;
            cnt[s[r]]++;

            while (have == need)
            {
                ans = Math.Min(ans, r - l + 1);

                cnt[s[l]]--;
                if (cnt[s[l]] == 0)
                    have--;

                l++;
            }
        }

        Console.WriteLine(ans);
    }
}