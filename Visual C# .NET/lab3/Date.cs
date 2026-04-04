using System;

namespace Task
{
    public struct Date
    {
        public int Day;
        public int Month;
        public int Year;

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date(string date)
        {
            string[] parts = date.Split('/');
            Day = int.Parse(parts[0]);
            Month = int.Parse(parts[1]);
            Year = int.Parse(parts[2]);
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
}