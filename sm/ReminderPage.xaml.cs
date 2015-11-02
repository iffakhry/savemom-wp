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
    public partial class ReminderPage : PhoneApplicationPage
    {
        public ReminderPage()
        {
            InitializeComponent();
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

        private void tambah_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
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

    }
}