using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using sm.ViewModel;

namespace sm
{
    public partial class KuisPage : PhoneApplicationPage
    {
        KuisViewModel kwm = null;
        public KuisPage()
        {

            InitializeComponent();

            this.Loaded += new RoutedEventHandler(KuisPage_Loaded);
            kwm = App.ViewModel.ItemsKuis.Last();
            DataContext = kwm;
        }

        private void KuisPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (""+getX() != "0")
            {
                NavigationService.RemoveBackEntry();
            }
            
            if (!App.ViewModel.IsDataKuisLoaded)
            {
                App.ViewModel.LoadDataKuis();
            }

            if (!App.ViewModel.IsDataJumlahLoaded)
            {
                App.ViewModel.LoadDataJumlah();
            }
        }
        public int getX()
        {
            string jawabanUser = "";
            int x = 0;
            if (NavigationContext.QueryString.TryGetValue("x", out jawabanUser))
            {
                x = int.Parse(jawabanUser);
            }
            
            return (x);
        }

        public string getS()
        {
            string stage = "";
            string s = "";
            if (NavigationContext.QueryString.TryGetValue("s", out stage))
            {
                s = stage;
            }

            return (s);
        }

        private void JawabanA_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/BenarSalah.xaml?s="+getS()+"&selectedJawaban=A&indexKuis=" + (kwm.IdKuis - 1) + "&x=" + (getX() + 1), UriKind.Relative));
        }

        private void JawabanB_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BenarSalah.xaml?s=" + getS() + "&selectedJawaban=B&indexKuis=" + (kwm.IdKuis - 1) + "&x=" + (getX() + 1), UriKind.Relative));
        }

        private void JawabanC_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BenarSalah.xaml?s=" + getS() + "&selectedJawaban=C&indexKuis=" + (kwm.IdKuis - 1) + "&x=" + (getX() + 1), UriKind.Relative));
        }

        private void JawabanD_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BenarSalah.xaml?s=" + getS() + "&selectedJawaban=D&indexKuis=" + (kwm.IdKuis - 1) + "&x=" + (getX() + 1), UriKind.Relative));
        }
    }
}