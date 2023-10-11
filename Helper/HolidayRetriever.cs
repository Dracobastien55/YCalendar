using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCalendar_WPF.Helper
{
    /// <summary>
    /// Class that allow to retrieve all holidays in a year
    /// </summary>
    public class HolidayRetriever
    {
        /// <summary>
        /// Method for retrieve holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<DateTime> GetHolidays(int year)
        {
            List<DateTime> holidays = new List<DateTime>();

            // New Year's Day
            holidays.Add(new DateTime(year, 1, 1));

            // Independence Day
            holidays.Add(new DateTime(year, 7, 4));

            // Christmas Day
            holidays.Add(new DateTime(year, 12, 25));

            // Add other holidays here...

            // Toussaint Day
            holidays.Add(new DateTime(year, 11, 1));

            // Armistice Day
            holidays.Add(new DateTime(year, 11, 11));

            // Easter (date varies by year)
            holidays.Add(CalculateEaster(year));

            // Work party
            holidays.Add(new DateTime(year, 5, 8));

            return holidays;
        }

        // Helper method to calculate Easter Sunday's date
        private static DateTime CalculateEaster(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - 29 / (h + 1) * (21 - g) / 11);
            int day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            int month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
    }
}
