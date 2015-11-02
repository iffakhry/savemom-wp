using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace sm
{
    public partial class ResultKuis : PhoneApplicationPage
    {
        public ResultKuis()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ResultKuis_Loaded);
            textHasil.Text = "" + App.ViewModel.ItemsJumlah.First().Jumlah;
            
            App.ViewModel.ItemsJumlah.First().Jumlah = 0;
        }

        

        private void ResultKuis_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            if (App.ViewModel.ItemsJumlah.First().Jumlah == 1)
            {
                Uri uri = new Uri("Assets/Images/star.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar1.Source = imgSource;
            }

            if (App.ViewModel.ItemsJumlah.First().Jumlah == 2)
            {
                Uri uri = new Uri("Assets/Images/star.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar1.Source = imgSource;
                gambar2.Source = imgSource;

            }

            if (App.ViewModel.ItemsJumlah.First().Jumlah == 3)
            {
                Uri uri = new Uri("Assets/Images/star.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar1.Source = imgSource;
                gambar2.Source = imgSource;
                gambar3.Source = imgSource;
            }
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            namaStage.Text = "stage " + getS();
        }
    }
}