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
using sm.ViewModel;

namespace sm
{
    public partial class BenarSalah : PhoneApplicationPage
    {
        private KuisViewModel ourItem;

        public BenarSalah()
        {

            InitializeComponent();
            this.Loaded += new RoutedEventHandler(BenarSalahPage_Loaded);
        }

        private void BenarSalahPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        public int getX()
        {
            string jawabanUser = "";
            int x = 0;
            if (NavigationContext.QueryString.TryGetValue("x", out jawabanUser))
            {
                x = int.Parse(jawabanUser);
            }
            
            return x;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string jawabanUser = "";
            if (NavigationContext.QueryString.TryGetValue("selectedJawaban", out jawabanUser))
            {
                string indexKuis = "";
                if (NavigationContext.QueryString.TryGetValue("indexKuis", out indexKuis))
                {
                    int index = int.Parse(indexKuis);
                    ourItem = App.ViewModel.ItemsKuis[index];
                    bool cek = jawabanUser.Equals(ourItem.JawabanBenar, StringComparison.Ordinal);
                    if (cek)
                    {
                        App.ViewModel.TambahKuisTerjawab(ourItem);
                        App.ViewModel.UpdateDatabaseKuis();
                        textResult.Text = "Selamat jawaban Anda benar";
                        Uri uri = new Uri("Assets/Images/true.png", UriKind.Relative);
                        BitmapImage imgSource = new BitmapImage(uri);
                        gambarBenarSalah.Source = imgSource;
                        App.ViewModel.ItemsJumlah.First().Jumlah = App.ViewModel.ItemsJumlah.First().Jumlah + 1;
                    }
                    else
                    {
                        App.ViewModel.TambahKuisTerjawab(ourItem);
                        App.ViewModel.UpdateDatabaseKuis();
                        jawabanBenar.Text = "Jawaban yang benar adalah " + this.getJawabanBenar();
                        textResult.Text = "Maaf, jawaban Anda salah.";
                        Uri uri = new Uri("Assets/Images/false.png", UriKind.Relative);
                        BitmapImage imgSource = new BitmapImage(uri);
                        gambarBenarSalah.Source = imgSource;
                    }
                }
            }
        }

        public string getJawabanBenar()
        {
            string jawaban = "";
            if ("A".Equals(ourItem.JawabanBenar, StringComparison.Ordinal))
            {
                jawaban = ourItem.JawabanA;
            }
            else if ("B".Equals(ourItem.JawabanBenar, StringComparison.Ordinal))
            {
                jawaban = ourItem.JawabanB;
            }
            else if ("C".Equals(ourItem.JawabanBenar, StringComparison.Ordinal))
            {
                jawaban = ourItem.JawabanC;
            }
            else if ("D".Equals(ourItem.JawabanBenar, StringComparison.Ordinal))
            {
                jawaban = ourItem.JawabanD;
            }
            return jawaban;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = getX();
            if (x == 3)
            {
                NavigationService.Navigate(new Uri("/ResultKuis.xaml?s=" + getS() , UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/KuisPage.xaml?s=" + getS() + "&x=" + x, UriKind.Relative));
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
    }
}