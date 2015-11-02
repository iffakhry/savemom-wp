using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using sm.Resources;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Microsoft.Phone.Scheduler;

namespace sm
{
    public partial class KalenderReminder : PhoneApplicationPage
    {
        public KalenderReminder()
        {
            InitializeComponent();
        }

        private void Kalender_Click(object sender, RoutedEventArgs e)
        {
            using (var isoStoreTerjawab = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStoreTerjawab.FileExists(App.dbKalender))
                {
                    NavigationService.Navigate(new Uri("/FormKalender.xaml", UriKind.Relative));
                }
                else
                {
                    if (!App.ViewModel.IsDataKalenderLoaded)
                    {
                        App.ViewModel.LoadDataKalender();
                    }
                    NavigationService.Navigate(new Uri("/KalenderPage.xaml", UriKind.Relative));
                }
            }
        }

        private void Reminder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReminderPage.xaml", UriKind.Relative));
        }
    }
}