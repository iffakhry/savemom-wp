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

namespace sm
{
    public partial class NewReminderPage : PhoneApplicationPage
    {
        public NewReminderPage()
        {
            InitializeComponent();
            DateTime saiki = DateTime.Now.AddMinutes(1);
            timeX.Value = saiki;
        }

        

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            DateTime saiki = DateTime.Now;
            if (timeX.Value.Value <= saiki)
            {
                MessageBox.Show("Pastikan jam sudah di set lebih dari jam sekarang");
            }
            else
            {
                string reminderName = Guid.NewGuid().ToString();
                Reminder reminder = new Reminder(reminderName);
                reminder.Title = this.txtTitle.Text;
                reminder.Content = this.txtContent.Text;

                reminder.BeginTime = new DateTime(saiki.Year, saiki.Month, saiki.Day, timeX.Value.Value.Hour, timeX.Value.Value.Minute, timeX.Value.Value.Second);
                reminder.RecurrenceType = RecurrenceInterval.Daily;
                reminder.ExpirationTime = reminder.BeginTime.AddSeconds(5.0);
                reminder.RecurrenceType = RecurrenceInterval.Daily;

                ScheduledActionService.Add(reminder);

                this.NavigationService.GoBack();
            }
        }

        private void batal_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}