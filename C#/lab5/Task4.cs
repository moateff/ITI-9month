using System;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace Task4
{
    public class Program
    {
        public static void Execute()
        {   
            Console.WriteLine("Constructors:");
            Duration D1 = new Duration (1,10,15); 
            Console.WriteLine($"D1 = {D1}");   

            Duration D2 = new Duration (3600); 
            Console.WriteLine($"D2 = {D2}"); 
            
            Duration D3 = new Duration (7800); 
            Console.WriteLine($"D3 = {D3}");
            
            Duration D4 = new Duration (666); 
            Console.WriteLine($"D4 = {D4}");

            Console.WriteLine("");
            Console.WriteLine("Operations:");
            D3 = D1 + D2;
            Console.WriteLine($"D3 = D1 + D2 = {D3}");

            D3 = D1 + 7800;
            Console.WriteLine($"D3 = D1 + 7800 = {D3}");

            D3 = 666 + D3;
            Console.WriteLine($"D3 = 666 + D3 = {D3}");

            D3 = D1++;
            Console.WriteLine($"D3 = D1++ = {D3}");

            D3 = --D1;
            Console.WriteLine($"D3 = --D1 = {D3}");
            
            Console.WriteLine("");
            Console.WriteLine("Comparisons:");
            Console.WriteLine($"D1 = {D1}");   
            Console.WriteLine($"D2 = {D2}");
            Console.Write($"Check if D1 is greater than D2 ? ");      
            if (D1 > D2)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
            
            Console.Write($"Check if D1 is smaller than D2 ? ");      
            if (D1 < D2)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
            
            Console.WriteLine("");
            Console.WriteLine("Conversions:");
            Console.Write($"Check if D1 if it's truthy value ? ");   
            if (D1)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            DateTime Date = (DateTime)D1;
            Console.WriteLine($"D1 = {Date}");
            // Output: 1/1/0001 1:10:15 AM
        }
    }

    public class Duration
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private int _totalSeconds;
        public Duration(int hours, int minutes, int seconds)
        {
            if (hours < 0 || minutes < 0 || seconds < 0)
                throw new ArgumentException("Duration cannot be negative");

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _totalSeconds = _hours * 3600 + _minutes * 60 + _seconds;
        }

        public Duration(int totalSeconds) : this(totalSeconds / 3600, (totalSeconds % 3600) / 60, totalSeconds % 60)
        {
            if (totalSeconds < 0)
                throw new ArgumentException("Duration cannot be negative");
                
            _totalSeconds = totalSeconds;
        }

        public override string ToString()
        {
            return $"Hours: {_hours}, Minutes: {_minutes}, Seconds: {_seconds}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            
            Duration D = (Duration)obj;
            return this._totalSeconds == D._totalSeconds;
        }

        public static Duration operator+ (Duration d1, Duration d2)
        {
            return new Duration(d1._totalSeconds + d2._totalSeconds);
        }

        public static Duration operator- (Duration d1, Duration d2)
        {
            return new Duration(d1._totalSeconds - d2._totalSeconds);
        }

        public static Duration operator+ (Duration d1, int totalSeconds)
        {
            return new Duration(d1._totalSeconds + totalSeconds);
        }

        public static Duration operator- (Duration d1, int totalSeconds)
        {
            return new Duration(d1._totalSeconds - totalSeconds);
        }

        public static Duration operator+ (int totalSeconds, Duration d1)
        {
            return new Duration(totalSeconds + d1._totalSeconds);
        }

        public static Duration operator- (int totalSeconds, Duration d1)
        {
            return new Duration(totalSeconds - d1._totalSeconds);
        }

        public static Duration operator++ (Duration d1)
        {
            return new Duration(d1._totalSeconds + 60);
        }

        public static Duration operator-- (Duration d1)
        {
            return new Duration(d1._totalSeconds - 60);
        }

        public static bool operator> (Duration d1, Duration d2)
        {
            return d1._totalSeconds > d2._totalSeconds;
        }

        public static bool operator< (Duration d1, Duration d2)
        {
            return d1._totalSeconds < d2._totalSeconds;
        }

        public static implicit operator bool (Duration d1)
        {
            return d1._totalSeconds != 0;
        }

        public static explicit operator DateTime (Duration d1)
        {
            return new DateTime(1, 1, 1, d1._hours, d1._minutes, d1._seconds);
        }
    }
}