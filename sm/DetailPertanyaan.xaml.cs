using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using sm.ViewModel;
using System.Diagnostics;

namespace sm
{
    public partial class DetailPertanyaan : PhoneApplicationPage
    {
        private PertanyaanViewModel ourItem;

        private int pertanyaanNumber;

        public DetailPertanyaan()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                string fromFavoritesFlag = "0";

                if (NavigationContext.QueryString.TryGetValue("fromFavorites", out fromFavoritesFlag))
                {
                    ourItem = App.ViewModel.ItemsPertanyaanFavorit[index];
                }
                else
                    ourItem = App.ViewModel.ItemsPertanyaan[index];

                Uri uri2 = new Uri(ourItem.Gambar, UriKind.Relative);

                ImageSource imgSource2 = new BitmapImage(uri2);
                gambar.Source = imgSource2;
                pertanyaanNumber = ourItem.IdPertanyaan;

                DataContext = ourItem;
                if (ourItem.IsFavorite)
                {
                    Uri uri = new Uri("Assets/Images/favorite.png", UriKind.Relative);

                    ImageSource imgSource = new BitmapImage(uri);

                    FavoriteImage.Source = imgSource;
                }

            }
        }

        private void toggleFavorite_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Toggle Favorite for :" + ourItem.JudulPertanyaan);

            ourItem.IsFavorite = !ourItem.IsFavorite;


            if (ourItem.IsFavorite)
            {
                Uri uri = new Uri("Assets/Images/favorite.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                FavoriteImage.Source = imgSource;

                //
                // Now we need to add it to the Favorites in the MainViewModel
                //
                App.ViewModel.TambahPertanyaanFavorite(ourItem);
            }
            else
            {
                Uri uri = new Uri("", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                FavoriteImage.Source = imgSource;

                //
                // And, finally, we have to remove it from the Favorites in the MainViewModel
                //
                App.ViewModel.HapusPertanyaanFavorite(ourItem);
            }

            App.ViewModel.UpdateDatabasePertanyaan();
        }
    }
}