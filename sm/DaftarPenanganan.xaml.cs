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
    public partial class DaftarPenanganan : PhoneApplicationPage
    {
        public DaftarPenanganan()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(Penanganan_Loaded);
        }

        private void Penanganan_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataPenangananLoaded)
            {
                App.ViewModel.LoadDataPenanganan();
            }
        }

        private void PenangananListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (PenangananListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/PenangananPage.xaml?selectedItem=" + PenangananListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            PenangananListBox.SelectedIndex = -1;
        }
    }
}