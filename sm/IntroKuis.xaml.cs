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
    public partial class IntroKuis : PhoneApplicationPage
    {
        public IntroKuis()
        {
            InitializeComponent();
            App.setDataStage();
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(IntroKuisPage_Loaded);
        }

        private void IntroKuisPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (!App.ViewModel.IsDataStageLoaded)
            {
                App.ViewModel.LoadDataStage();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/StagePage.xaml?x=0", UriKind.Relative));
        }
    }
}