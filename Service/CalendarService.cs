using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YCalendar_WPF.Interface;
using YCalendar_WPF.Models;

namespace YCalendar_WPF.Service
{
    /// <summary>
    /// Class that can be use to get the logic of a calendar and get all the dates and a lot of functionnality like Commands.
    /// </summary>
    public class CalendarService
    {
        public CalendarService() { }

        /// <summary>
        /// Méthode permettant de créer la liste des dates qui sont contenu dans tel mois et tel année
        /// </summary>
        /// <param name="month">Numéro du mois</param>
        /// <param name="year">Numéro de l'année</param>
        /// <returns></returns>
        public List<ICalendarDay> FromMonth(int month, int year)
        {
            int numberOfDay = DateTime.DaysInMonth(year, month);

            List<ICalendarDay> result = new List<ICalendarDay>();

            for (int i = 1; i <= numberOfDay; i++)
            {
                var nameDate = new DateTime(year, month, i).DayOfWeek.ToString();
                var date = new PlanningDay(i, nameDate);
                result.Add(date);
            }

            return result;
        }

        /// <summary>
        /// Méthode permettant de retourner une liste des dates depuis un format texte
        /// </summary>
        /// <param name="format">Texte représentant la date</param>
        /// <returns></returns>
        public List<ICalendarDay> FromStringFormat(string format)
        {
            var result = DateTime.Parse(format);
            return FromMonth(result.Month, result.Year);
        }

        #region ICommand
        /// <summary>
        /// Allow to go on the NextMonth
        /// </summary>
        public ICommand NextMonth { get; set; }

        /// <summary>
        /// Allow to go on the PreviousMonth
        /// </summary>
        public ICommand PreviousMonth { get; set; }

        /// <summary>
        /// Allow to select a date and do a specific action with it
        /// </summary>
        public ICommand SelectDate { get; set; }
        #endregion
    }
}
