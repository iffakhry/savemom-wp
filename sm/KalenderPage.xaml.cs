using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;
using Microsoft.Phone.Tasks;

namespace sm
{
    public partial class KalenderPage : PhoneApplicationPage
    {
        public KalenderPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(KalenderPage_Loaded);
            Appointments appts = new Appointments();

            //Identify the method that runs after the asynchronous search completes.
            appts.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(Appointments_SearchCompleted);
            int tgl2, bln2, thn2;

            tgl2 = int.Parse(App.ViewModel.ItemsKalender[0].LineOne);
            bln2 = int.Parse(App.ViewModel.ItemsKalender[0].LineTwo);
            thn2 = int.Parse(App.ViewModel.ItemsKalender[0].LineThree);


            DateTime start = new DateTime(thn2, bln2, tgl2);
            DateTime end = start.AddDays(280);
            int max = 20;

            //Start the asynchronous search.
            appts.SearchAsync(start, end, max, "Appointments Test #1");
        }

        void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {
            try
            {
                //Bind the results to the user interface.
                AppointmentResultsData.DataContext = e.Results;
            }
            catch (System.Exception)
            {
                //No results
            }

            if (AppointmentResultsData.Items.Any())
            {
                AppointmentResultsLabel.Text = "";
            }
            else
            {
                AppointmentResultsLabel.Text = "Tidak ada catatan";
            }
        }

        public void KalenderPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataKalenderLoaded)
            {
                App.ViewModel.LoadDataKalender();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("x", out selectedIndex))
            {
                NavigationService.RemoveBackEntry();
            }

            this.RefreshReminderList();
        }

        private void RefreshReminderList()
        {
            //IEnumerable<Reminder> reminders = ScheduledActionService.GetActions<Reminder>();
            //this.AppointmentResultsLabel.ItemsSource = reminders;
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            SaveAppointmentTask SATask = new SaveAppointmentTask();
            SATask.StartTime = DateTime.Now.AddHours(1);
            SATask.EndTime = DateTime.Now.AddHours(2);

            //SATask.Subject = "F5debug App Subject";
            //SATask.Location = "F5debug Office";
            //SATask.Details = "This is a sample Appointment";

            SATask.Reminder = Microsoft.Phone.Tasks.Reminder.FifteenMinutes;
            //SATask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.OutOfOffice;

            SATask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;

            SATask.Show();
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            //Reminder selectedReminder = this.AppointmentResultsLabel.SelectedItem as Reminder;
            //if (selectedReminder != null)
            //{
            //    ScheduledActionService.Remove(selectedReminder.Name);
            //    this.RefreshReminderList();
            //}

        }

    }


}