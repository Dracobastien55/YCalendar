using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCalendar_WPF.Service;

namespace YCalendar.ViewModels
{
    public class CalendarViewModel : ObservableObject
    {
        public ObservableCollection<DateTime> Dates { get; set; }

        public CalendarService Service { get; set; }

        public CalendarViewModel()
        {
            var date = DateTime.Now;
            Service = new CalendarService();
            Dates =  new ObservableCollection<DateTime>(Service.FromMonth(date.Month, date.Year));
        }
    }
}
