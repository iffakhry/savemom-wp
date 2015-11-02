using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace sm
{
    public partial class StagePage : PhoneApplicationPage
    {
        public StagePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(StagePage_Loaded);
            App.setDataStage();
            DataContext = App.ViewModel.ItemsStage.Last();
        }

        private void StagePage_Loaded(object sender, RoutedEventArgs e)
        {
            //NavigationService.RemoveBackEntry();
            if (!App.ViewModel.IsDataStageLoaded)
            {
                App.ViewModel.LoadDataStage();
            }
        }

        private void Kuis1_Click(object sender, EventArgs e)
        {
            update(1);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=1", UriKind.Relative));
        }

        private void Kuis2_Click(object sender, EventArgs e)
        {
            update(2);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=2", UriKind.Relative));
        }

        private void Kuis3_Click(object sender, EventArgs e)
        {
            update(3);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=3", UriKind.Relative));
        }

        private void Kuis4_Click(object sender, EventArgs e)
        {
            update(4);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=4", UriKind.Relative));
        }

        private void Kuis5_Click(object sender, EventArgs e)
        {
            update(5);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=5", UriKind.Relative));
        }

        private void Kuis6_Click(object sender, EventArgs e)
        {
            update(6);
            NavigationService.Navigate(new Uri("/KuisPage.xaml?x=0&s=6", UriKind.Relative));
        }

        private void update(int id)
        {
            //App.ViewModel.UpdateDatabaseKuis();
            App.setDataKuis(id);
            App.ViewModel.LoadDataKuis();
            if (App.ViewModel.ItemsKuis.Count() < 3)
            {
                MessageBox.Show("Stok Pertanyaan Habis, Anda Luar Biasa!");
                return;
            }

        }
    }
}