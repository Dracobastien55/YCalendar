using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCalendar_WPF.Interface
{
    /// <summary>
    /// Interface that represent a day in a calendar
    /// </summary>
    public interface ICalendarDay
    {
        /// <summary>
        /// Represent a day
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Represent the name of the day like Monday, Tuesday
        /// </summary>
        public string NameDay { get; set; }

        /// <summary>
        /// Represent the boolean that indicate if the user have an activity this day
        /// </summary>
        public bool HasActivity { get; set; }

        /// <summary>
        /// Indicate if this day is an holiday
        /// </summary>
        public bool IsAnHoliday { get; set; }
    }
}
