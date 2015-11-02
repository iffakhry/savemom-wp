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
    public partial class TipsPage : PhoneApplicationPage
    {
        public TipsPage()
        {
            InitializeComponent();
            App.setDataTips();
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(TipsPage_Loaded);
        }

        private void TipsPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataTipsLoaded)
            {
                App.ViewModel.LoadDataTips();
            }
        }

        private void TipsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (TipsListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailTips.xaml?selectedItem=" + TipsListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            TipsListBox.SelectedIndex = -1;
        }

        private void TipsFavoritListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (TipsFavoritListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailTips.xaml?selectedItem=" + TipsFavoritListBox.SelectedIndex + "&fromFavorites=1", UriKind.Relative));

            // Reset selected index to -1 (no selection)
            TipsFavoritListBox.SelectedIndex = -1;
        }
    }
}