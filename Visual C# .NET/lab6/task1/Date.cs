using System;

namespace Task
{
    /// <summary>
    /// Struct Date
    /// </summary>
    public struct Date
    {
        /// <summary>
        /// Day
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="date"></param>
        /// <exception cref="ArgumentException"></exception>
        public Date(string date)
        {
            string[] parts = date.Split('/');
            Day = int.Parse(parts[0]);
            Month = int.Parse(parts[1]);
            Year = int.Parse(parts[2]);

            if (Day < 1 || Day > 31)
                throw new ArgumentException("Invalid day");
            if (Month < 1 || Month > 12)
                throw new ArgumentException("Invalid month");
            if (Year < 1)
                throw new ArgumentException("Invalid year");
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Date other)
        {
            return (Year == other.Year) && (Month == other.Month) && (Day == other.Day);
        }

        /// <summary>
        /// >
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator> (Date d1, Date d2)
        {
            return d1.Year > d2.Year || (d1.Year == d2.Year && d1.Month > d2.Month) || (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day > d2.Day);
        }
        
        /// <summary>
        /// <
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator< (Date d1, Date d2)
        {
            return d1.Year < d2.Year || (d1.Year == d2.Year && d1.Month < d2.Month) || (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day < d2.Day);
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Date Parse(string? date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            return new Date(date);
        }

        /// <summary>
        /// TryParse
        /// </summary>
        /// <param name="date"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(string? date, out Date result)
        {
            try
            {
                result = Parse(date);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }
    }
}