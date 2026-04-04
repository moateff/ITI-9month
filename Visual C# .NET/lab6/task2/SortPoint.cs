using System;

namespace Task1
{
    public static class SortPoint
    {
        public static void Sort(Point3D[] points)
        {
            for (int i = 1; i < points.Length; i++)
            {
                Point3D key = points[i];
                int j = i - 1;
                while (j >= 0 && points[j] > key)
                {
                    points[j + 1] = points[j];
                    j--;
                }
                points[j + 1] = key;
            }
        }
    }
}