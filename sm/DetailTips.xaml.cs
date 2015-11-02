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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Diagnostics;

namespace sm
{
    public partial class DetailTips : PhoneApplicationPage
    {
        private TipsViewModel ourItem;
        private int tipsNumber;

        public DetailTips()
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
                    ourItem = App.ViewModel.ItemsTipsFavorit[index];
                }
                else
                    ourItem = App.ViewModel.ItemsTips[index];

                Uri uri2 = new Uri(ourItem.Gambar, UriKind.Relative);

                ImageSource imgSource2 = new BitmapImage(uri2);
                gambar.Source = imgSource2;

                tipsNumber = ourItem.IdTips;

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
            Debug.WriteLine("Toggle Favorite for :" + ourItem.JudulTips);

            ourItem.IsFavorite = !ourItem.IsFavorite;


            if (ourItem.IsFavorite)
            {
                Uri uri = new Uri("Assets/Images/favorite.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                FavoriteImage.Source = imgSource;

                //
                // Now we need to add it to the Favorites in the MainViewModel
                //
                App.ViewModel.TambahTipsFavorite(ourItem);
            }
            else
            {
                Uri uri = new Uri("", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                FavoriteImage.Source = imgSource;

                //
                // And, finally, we have to remove it from the Favorites in the MainViewModel
                //
                App.ViewModel.HapusTipsFavorite(ourItem);
            }

            App.ViewModel.UpdateDatabaseTips();
        }
    }
}