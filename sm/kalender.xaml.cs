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
using Microsoft.Phone.Scheduler;


namespace sm
{
    public partial class kalender : PhoneApplicationPage
    {
        public kalender()
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

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    //ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBar1"]);
                    //AppBar1.IsVisible = true;
                    ApplicationBar.IsVisible = false;
                    break;

                case 1:
                    //ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBar2"]);
                    //AppBar1.IsVisible = false;
                    //ApplicationBar = ((ApplicationBar)Application.Current.Resources[""]);
                    ApplicationBar.IsVisible = true;
                    break;
            }
        }

        

        public void KalenderPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataKalenderLoaded)
            {
                App.ViewModel.LoadDataKalender();
            }
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
                AppointmentResultsLabel.Text = "Catatan";
            }
            else
            {
                AppointmentResultsLabel.Text = "Tidak ada catatan";
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
            IEnumerable<Reminder> reminders = ScheduledActionService.GetActions<Reminder>();
            this.lbReminders.ItemsSource = reminders;
        }

        private void btnAddNewReminder_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Perintah hapus");
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
        }

        private void btnRemoveSelectedReminder_Click(object sender, RoutedEventArgs e)
        {
            Reminder selectedReminder = this.lbReminders.SelectedItem as Reminder;
            if (selectedReminder != null)
            {
                ScheduledActionService.Remove(selectedReminder.Name);
                this.RefreshReminderList();
            }
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            Reminder selectedReminder = this.lbReminders.SelectedItem as Reminder;
            if (selectedReminder != null)
            {
                ScheduledActionService.Remove(selectedReminder.Name);
                this.RefreshReminderList();
            }
            
        }

        //private void Ganti(object sender, SelectionChangedEventArgs e)
        //{
        //    iconHapus.IsEnabled = true;
        //}
    }
}