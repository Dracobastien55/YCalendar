using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YCalendar_WPF.Converter
{
    public class IntToMonthNameConverter : IValueConverter
    {
        /// <summary>
        /// Converter for the number of a month to the name of this month
        /// </summary>
        /// <param name="value">The month</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Name of the month</returns>
        /// <exception cref="ArgumentException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value <= 0 && (int)value > 12)
                throw new ArgumentException("There are only 12 month in a year");

            //It's just to get the month
            var date = new DateTime(2000, (int)value, 1);
            // And return the name
            return date.ToString("MMMM").ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
