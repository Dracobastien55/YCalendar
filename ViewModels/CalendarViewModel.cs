using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YCalendar_WPF.Helper;
using YCalendar_WPF.Interface;
using YCalendar_WPF.Models;
using YCalendar_WPF.Service;

namespace YCalendar_WPF.ViewModels
{
    public class CalendarViewModel : ObservableObject
    {

        #region Attributes
        private ObservableCollection<ICalendarDay> _dates;
        #endregion

        #region Properties
        /// <summary>
        /// Property bindable that represent the month
        /// </summary>
        public int Month
        {
            get { return Model.Month; }
            set 
            {
                SetProperty(Model.Month, value, Model, (source, val) => source.Month = val);
            }
        }

        /// <summary>
        /// Property bindable that represent the year
        /// </summary>
        public int Year
        {
            get { return Model.Year; }
            set 
            {
                SetProperty(Model.Year, value, Model, (source, val) => source.Year = val);
            }
        }

        /// <summary>
        /// Property that represent and show the dates of a calendar
        /// </summary>
        public ObservableCollection<ICalendarDay> Dates
        {
            get { return _dates;}
            set 
            {
                var listHoliday = HolidayRetriever.GetHolidays(Year);

                value.ToList().ForEach(element =>
                {
                    foreach (var day in listHoliday)
                    {
                        if(day.Month == Month && day.Day == element.Day)
                            element.IsAnHoliday = true;
                    }
                });

                SetProperty(ref _dates, value);
            }
        }

        /// <summary>
        /// Service that represent the business logic of the calendar
        /// </summary>
        public CalendarService Service { get; set; }

        /// <summary>
        /// Data model of a calendar
        /// </summary>
        public YCalendar Model { get; set; }

        #endregion

        #region Ctor
        public CalendarViewModel()
        {
            var date = DateTime.Now;
            Model = new YCalendar(date.Month, date.Year);
            Service = new CalendarService();
            Dates =  new ObservableCollection<ICalendarDay>(Service.FromMonth(date.Month, date.Year));

            Service.NextMonth = new RelayCommand(() =>
            {
                if (Month == 12)
                {
                    Month = 1;
                    Year += 1;
                }
                else  
                    Month++;

                Dates = new ObservableCollection<ICalendarDay>(Service.FromMonth(Month, Year));
            });

            Service.PreviousMonth = new RelayCommand(() =>
            {
                if (Month == 1)
                {
                    Month = 12;
                    Year -= 1;
                }
                else
                    Month--;

                Dates = new ObservableCollection<ICalendarDay>(Service.FromMonth(Month, Year));
            });

            Service.SelectDate = new RelayCommand<ICalendarDay>(element =>
            {
                element.HasActivity = !element.HasActivity;
            });
        }
        #endregion
    }
}
