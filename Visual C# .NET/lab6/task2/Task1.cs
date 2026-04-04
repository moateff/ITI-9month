using System;

namespace Task1
{
    public class Program
    {
        public static void Execute()
        {
            Point3D[] points = new Point3D[5];

            points[0] = new Point3D(1, 2, 3);
            points[1] = new Point3D(4, 5, 6);
            points[2] = new Point3D(7, 8, 9);
            points[3] = new Point3D(1, 3, 4);
            points[4] = new Point3D(7, 8, 7);

            Point3D[] pointsCopy = (Point3D[])points.Clone();

            Console.WriteLine("Before sorting (user defined sort method):");

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i]);
            }

            Console.WriteLine("\nAfter sorting (user defined sort method):");

            SortPoint.Sort(points);

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i]);
            }

            Console.WriteLine("\nBefore sorting (built-in sort method):");

            for (int i = 0; i < pointsCopy.Length; i++)
            {
                Console.WriteLine(pointsCopy[i]);
            }

            Console.WriteLine("\nAfter sorting (built-in sort method):");

            Array.Sort(pointsCopy);

            for (int i = 0; i < pointsCopy.Length; i++)
            {
                Console.WriteLine(pointsCopy[i]);
            }
        }
    }

    public class Point3D(int x, int y, int z) : ICloneable, IComparable<Point3D>
    {
        private int _x = x;
        private int _y = y;
        private int _z = z;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public int Z { get { return _z; } set { _z = value; } }

        public Point3D() : this(0, 0, 0) { }
        public Point3D(int value) : this(value, value, value) { }
        public Point3D(Point3D p) : this(p.X, p.Y, p.Z) { }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Point3D other) return false;
            return this._x == other._x && this._y == other._y && this._z == other._z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y, _z);
        }

        public static bool operator > (Point3D p1, Point3D p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z) return false;
            if (p1.X == p2.X && p1.Y == p2.Y) return p1.Z > p2.Z; 
            if (p1.X == p2.X) return p1.Y > p2.Y;
            return p1.X > p2.X;
        }

        public static bool operator < (Point3D p1, Point3D p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z) return false;
            if (p1.X == p2.X && p1.Y == p2.Y) return p1.Z < p2.Z;
            if (p1.X == p2.X) return p1.Y < p2.Y;
            return p1.X < p2.X;
        }

        public int CompareTo(Point3D? other)
        {
            if (other == null) return 1;
            if (this > other) return 1;
            if (this < other) return -1;
            return 0;
        }

        public object Clone()
        {
            return new Point3D(this);
        }
        
        public static Point3D ReadPoint()
        {
            int x, y, z;
            do
            {
                Console.Write("X = ");
            } while (!(int.TryParse(Console.ReadLine()!, out x)));

            do
            {
                Console.Write("Y = ");
            } while (!(int.TryParse(Console.ReadLine()!, out y)));

            do
            {
                Console.Write("Z = ");
            } while (!(int.TryParse(Console.ReadLine()!, out z)));

            return new Point3D(x, y, z);
        }
    }
}