using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;
using sm.ViewModel;

namespace sm
{
    public partial class FormKalender : PhoneApplicationPage
    {
        public FormKalender()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int theDate = tanggalx.Value.Value.Day;
            int theMonth = tanggalx.Value.Value.Month;
            int theYear = tanggalx.Value.Value.Year;
            //string xxx [] =tanggalx.Value.ToString().Split("-");
            KalenderViewModel simpanKalender = new KalenderViewModel();
            //simpanKalender.LineOne = tanggal.Text;
            //simpanKalender.LineTwo = bulan.Text;
            //simpanKalender.LineThree = tahun.Text;
            simpanKalender.LineOne = "" + theDate;
            simpanKalender.LineTwo = "" + theMonth;
            simpanKalender.LineThree = "" + theYear;
            App.ViewModel.ItemsKalender.Add(simpanKalender);
            App.ViewModel.UpdateDatabaseKalender();
            NavigationService.Navigate(new Uri("/KalenderPage.xaml", UriKind.Relative));
            //App.ViewModel.ItemsKalender.Remove(simpanKalender);
            string reminderName = Guid.NewGuid().ToString();
            // use guid for reminder name, since reminder names must be unique
            Reminder reminder = new Reminder(reminderName);
            // NOTE: setting the Title property is supported for reminders 
            // in contrast to alarms where setting the Title property is not supported
            reminder.Title = "Minum 'Fe'";
            reminder.Content = "Saatnya Minum 'Fe'";


            //NOTE: the value of BeginTime must be after the current time
            //set the BeginTime time property in order to specify when the reminder should be shown
            TimeSpan ts = new TimeSpan(08, 00, 0);
            DateTime sta = DateTime.Now;
            reminder.BeginTime = new DateTime(sta.Year, sta.Month, sta.Day, 8, 0, 0);
            reminder.RecurrenceType = RecurrenceInterval.Daily;
            // NOTE: ExpirationTime must be after BeginTime
            // the value of the ExpirationTime property specifies when the schedule of the reminder expires
            // very useful for recurring reminders, ex:
            // show reminder every day at 5PM but stop after 10 days from now
            int tgl3, bln3, thn3;
            //tgl3 = int.Parse(tanggal.Text);
            //bln3 = int.Parse(bulan.Text);
            //thn3 = int.Parse(tahun.Text);
            //DateTime skrg = new DateTime(thn3, bln3, tgl3);
            DateTime skrg = new DateTime(theYear, theMonth, theDate);
            reminder.ExpirationTime = skrg.AddDays(280);
            reminder.RecurrenceType = RecurrenceInterval.Daily;

            // NOTE: another difference from alerts
            // you can set a navigation uri that is passed to the application when it is launched from the reminder
            //reminder.NavigationUri = navigationUri;
            ScheduledActionService.Add(reminder);
            if (!App.ViewModel.IsDataKalenderLoaded)
            {
                App.ViewModel.LoadDataKalender();
            }
        }

        private void batal_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void simpan_Click(object sender, EventArgs e)
        {

            int theDate = tanggalx.Value.Value.Day;
            int theMonth = tanggalx.Value.Value.Month;
            int theYear = tanggalx.Value.Value.Year;


            KalenderViewModel simpanKalender = new KalenderViewModel();
            simpanKalender.LineOne = "" + theDate;
            simpanKalender.LineTwo = "" + theMonth;
            simpanKalender.LineThree = "" + theYear;
            App.ViewModel.ItemsKalender.Add(simpanKalender);
            App.ViewModel.UpdateDatabaseKalender();
            NavigationService.Navigate(new Uri("/KalenderPage.xaml?x=1", UriKind.Relative));
            string reminderName = Guid.NewGuid().ToString();
            Reminder reminder = new Reminder(reminderName);
            reminder.Title = "Minum Zat Besi";
            reminder.Content = "Saatnya Minum Zat Besi";
            DateTime sta = DateTime.Now;
            reminder.BeginTime = new DateTime(sta.Year, sta.Month, sta.Day, 20, 0, 0);
            reminder.RecurrenceType = RecurrenceInterval.Daily;
            DateTime skrg = new DateTime(theYear, theMonth, theDate);
            reminder.ExpirationTime = skrg.AddDays(90);
            reminder.RecurrenceType = RecurrenceInterval.Daily;

            string reminderName1 = Guid.NewGuid().ToString();
            Reminder reminder1 = new Reminder(reminderName1);
            DateTime skrg1 = new DateTime(theYear, theMonth, theDate);
            reminder1.Title = "Bayi memasuki masa Aterem";
            reminder1.Content = "Persiapkan untuk menyambut buah hati Anda\nJangan lupa periksakan kehamilan setiap minggu\nKenali tanda-tanda persalinan\nTetap jaga kondisi tubuh";
            DateTime sta1 = skrg1.AddDays(266);
            reminder1.BeginTime = new DateTime(sta1.Year, sta1.Month, sta1.Day, 20, 0, 0);
            reminder1.RecurrenceType = RecurrenceInterval.Daily;
            
            reminder1.ExpirationTime = skrg1.AddDays(280);
            ScheduledActionService.Add(reminder);
            ScheduledActionService.Add(reminder1);
            if (!App.ViewModel.IsDataKalenderLoaded)
            {
                App.ViewModel.LoadDataKalender();
            }
        }
    }
}
