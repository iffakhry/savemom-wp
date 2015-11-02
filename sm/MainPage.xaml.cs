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
using Nokia.Phone.HereLaunchers;
using System.Device.Location;
using System.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using System.ComponentModel;
using Microsoft.Phone.Shell;


namespace sm
{ 
    public partial class MainPage : PhoneApplicationPage
    { 
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if ExtendedSplashscreen.xaml is on the backstack  and remove 
            if (NavigationService.BackStack.Count() == 1)
            {
                NavigationService.RemoveBackEntry();
            }

        }


       
        private void firstaidclick(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/DaftarPenanganan.xaml", UriKind.Relative));

        }

        private void kalenderclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/kalender.xaml", UriKind.Relative));
        }

        private void Bantuan_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BantuanPage.xaml", UriKind.Relative));
        }

        private void Tentang_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/tentang.xaml", UriKind.Relative));
        }

        private void Pertanyaan_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PertanyaanPage.xaml", UriKind.Relative));
        }

        private void Tips_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TipsPage.xaml", UriKind.Relative));
        }

        private void Kuis_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/IntroKuis.xaml", UriKind.Relative));
        }

        public void Kalender_click(object sender, RoutedEventArgs e)
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

        public void PelayananTerdekat_click(object sender, RoutedEventArgs e)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("No Connection");
            }
            else
            {
                //NavigationService.Navigate(new Uri("/PelayananTerdekat.xaml", UriKind.Relative));
                //menampilkan koordinat lokasi sesuai lokasi user~
                GeoCoordinateWatcher watcher; watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
                watcher.Start();
                //MessageBox.Show(watcher.Position.Location.Latitude.ToString() + " " + watcher.Position.Location.Longitude.ToString());
                //menampilkan peta~
                ExploremapsShowMapTask showMaps = new ExploremapsShowMapTask();
                showMaps.Location = new GeoCoordinate((Double)watcher.Position.Location.Latitude, (Double)watcher.Position.Location.Longitude);
                showMaps.Zoom = 40;

                //kategori rumahsakit~
                ExploremapsSearchPlacesTask searchMap = new ExploremapsSearchPlacesTask();
                searchMap.Location = new GeoCoordinate((Double)watcher.Position.Location.Latitude, (Double)watcher.Position.Location.Longitude);
                searchMap.SearchTerm = "Rumah Sakit";
                searchMap.Show();
                showMaps.Show();
            }
        }

        private void reminder_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReminderPage.xaml", UriKind.Relative));
        }

        private void call_click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = "119";
            phoneCallTask.DisplayName = "Panggilan Darurat";

            phoneCallTask.Show();
        }
    }
}