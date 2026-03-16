using System;

namespace Task3
{
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // Handle null values safely
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Use built-in case-insensitive comparison
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }
}