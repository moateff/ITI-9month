using System;

namespace Task1
{
    public class Program
    {
        public static void Execute()
        {
            Point3D P = new Point3D(10,10,10); 
            Console.WriteLine(P.ToString());

            Console.WriteLine("Enter Coordinates for P1: ");
            Point3D P1 = Point3D.ReadPoint();
            Console.WriteLine(P1);

            Console.WriteLine("Enter Coordinates for P2: ");
            Point3D P2 = Point3D.ReadPoint();
            Console.WriteLine(P2);

            Console.Write("Check if P1 equals P2 using '==' operator ? ");
            if (P1 == P2)
                Console.WriteLine("They are equal");
            else 
                System.Console.WriteLine("They are not equal");

            Console.Write("Check if P1 equals P2 using Equals method ? ");
            if (P1.Equals(P2))
                Console.WriteLine("They are equal");
            else 
                System.Console.WriteLine("They are not equal");
        }
    }

    public class Point3D(int x, int y, int z)
    {
        private int _x = x;
        private int _y = y;
        private int _z = z;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public int Z { get { return _z; } set { _z = value; } }

        public Point3D() : this(0, 0, 0) { }
        public Point3D(int value) : this(value, value, value) { }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            
            Point3D P = (Point3D)obj;
            return this._x == P._x && this._y == P._y && this._z == P._z;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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