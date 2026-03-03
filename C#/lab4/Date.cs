using System;

namespace Task
{
    public struct Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

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

        public bool Equals(Date other)
        {
            return (Year == other.Year) && (Month == other.Month) && (Day == other.Day);
        }
    }
}