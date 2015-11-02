using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Nokia.Phone.HereLaunchers;
using System.Device.Location;

namespace sm
{
    public partial class PelayananTerdekat : PhoneApplicationPage
    {
        public PelayananTerdekat()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
            searchMap.SearchTerm = "Dokter";
            searchMap.Show();
            showMaps.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
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
            searchMap.SearchTerm = "Bidan";
            searchMap.Show();
            showMaps.Show();
        }
    }
}