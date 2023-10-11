using System;
using System.Collections.Generic;
using YCalendar_WPF.Service;

namespace YCalendar_WPF.Models
{
    /// <summary>
    /// Data Model of a calendar
    /// </summary>
    public class YCalendar
    {
        /// <summary>
        /// Represent the month of the calendar
        /// </summary>
        public int Month { get; set; } = 1;

        /// <summary>
        /// Represent the year of the calendar
        /// </summary>
        public int Year { get; set; } = 2000;

        public YCalendar(int month, int year)
        {
            Month = month;
            Year = year;
        }
    }
}
