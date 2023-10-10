using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCalendar_WPF.Service
{
    public class CalendarService
    {
        public CalendarService() { }

        /// <summary>
        /// Méthode permettant de créer la liste des dates qui sont contenu dans tel mois et tel année
        /// </summary>
        /// <param name="month">Numéro du mois</param>
        /// <param name="year">Numéro de l'année</param>
        /// <returns></returns>
        public List<DateTime> FromMonth(int month, int year)
        {
            int numberOfDay = DateTime.DaysInMonth(year, month);
            List<DateTime> result = new List<DateTime>();

            for (int i = 1; i <= numberOfDay; i++)
            {
                var date = new DateTime(year, month, i);
                result.Add(date);
                Console.WriteLine(date.ToString("D"));
            }

            return result;
        }

        /// <summary>
        /// Méthode permettant de retourner une liste des dates depuis un format texte
        /// </summary>
        /// <param name="format">Texte représentant la date</param>
        /// <returns></returns>
        public List<DateTime> FromStringFormat(string format)
        {
            var result = DateTime.Parse(format);
            return FromMonth(result.Month, result.Year);
        }
    }
}
