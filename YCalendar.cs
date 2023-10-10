using System;
using System.Collections.Generic;
using YCalendar_WPF.Service;

namespace YCalendar_WPF
{
    /// <summary>
    /// Classe répresentant le traitement du calendrier
    /// </summary>
    public class YCalendar
    {
        /// <summary>
        /// Liste représentant toutes les dates qui se trouves dans le calendrier du mois et de l'année qui ont été passées en paramètre
        /// </summary>
        public List<DateTime> Dates { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        /// <summary>
        /// Classe de service représentant la logique du calendrier
        /// </summary>
        public CalendarService Service { get; set; }

        public YCalendar() { 
            Service = new CalendarService();
            Dates = new List<DateTime>();
        }

        public YCalendar(int month, int year)
        {
            Service = new CalendarService();
            Month = month;
            Year = year;
            Dates = Service.FromMonth(month, year);
        }

        public YCalendar(string date)
        {
            Service = new CalendarService();
            Dates = Service.FromStringFormat(date);
        }
    }
}
