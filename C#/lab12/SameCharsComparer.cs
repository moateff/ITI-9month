using System;

namespace Task5
{
    public class SameCharsComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null) return x == y;

            // Remove whitespace and sort characters
            var sortedX = String.Concat(x.Trim().ToLower().OrderBy(c => c));
            var sortedY = String.Concat(y.Trim().ToLower().OrderBy(c => c));

            return sortedX == sortedY;
        }

        public int GetHashCode(string obj)
        {
            if (obj == null) return 0;

            // Hash based on sorted characters without spaces
            var sorted = String.Concat(obj.Trim().ToLower().OrderBy(c => c));
            return sorted.GetHashCode();
        }
    }
}
