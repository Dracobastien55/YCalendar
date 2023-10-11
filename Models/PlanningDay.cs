using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCalendar_WPF.Interface;

namespace YCalendar_WPF.Models
{
    /// <summary>
    /// Data model of a day in the calendar
    /// </summary>
    public class PlanningDay : ICalendarDay
    {
        public int Day { get; set; }

        public string NameDay { get; set; }

        public bool HasActivity { get; set; }

        public bool IsAnHoliday { get; set; }

        public PlanningDay() { }

        public PlanningDay(int day, string name) 
        { 
            Day = day;
            NameDay = name;
        }

    }
}
