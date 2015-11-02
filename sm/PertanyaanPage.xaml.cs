using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.Windows.Data;
namespace sm
{
    public partial class PertanyaanPage : PhoneApplicationPage
    {
        public CollectionViewSource Source { get; set; }
        public PertanyaanPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PertanyaanPage_Loaded);
            App.setDataPertanyaan();
            DataContext = App.ViewModel;
            //Source = new CollectionViewSource();
            //Source.Source = App.ViewModel.ItemsPertanyaan;


        }


        private void PertanyaanPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataPertanyaanLoaded)
            {
                App.ViewModel.LoadDataPertanyaan();
            }
        }

        private void PertanyaanListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (PertanyaanListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailPertanyaan.xaml?selectedItem=" + PertanyaanListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            PertanyaanListBox.SelectedIndex = -1;
        }

        private void PertanyaanFavoritListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (PertanyaanFavoritListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailPertanyaan.xaml?selectedItem=" + PertanyaanFavoritListBox.SelectedIndex + "&fromFavorites=1", UriKind.Relative));

            // Reset selected index to -1 (no selection)
            PertanyaanFavoritListBox.SelectedIndex = -1;
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            //NavigationService.Navigate(new Uri("/FormCari.xaml", UriKind.Relative));
            string cariText = textCari.Text;
            textCari.Visibility = System.Windows.Visibility.Visible;

        }
    }
}