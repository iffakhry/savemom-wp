using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Phone.Tasks;
using sm.ViewModel;

namespace sm
{
    public partial class PenangananPage : PhoneApplicationPage
    {
        private PenangananViewModel ourItem;
        bool status = false;
        bool status2 = false;
        string local = "Content/Videos/video.mp4";
        public PenangananPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                ourItem = App.ViewModel.ItemsPenanganan[index];
                DataContext = ourItem;
                local = App.ViewModel.ItemsPenanganan[index].Video;
            }
        }

        private void StatusGanti(object sender, EventArgs e)
        {
            
            if (mediaElement1.CurrentState == MediaElementState.Paused)
            {
                Uri uri = new Uri("Assets/Images/transport.play.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar.Source = imgSource;
                status2 = true;
            }

            if (mediaElement1.CurrentState == MediaElementState.Stopped)
            {
                Uri uri = new Uri("Assets/Images/transport.play.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar.Source = imgSource;
                status2 = false;
                status = false;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (status == false && status2 == false)
            {
                PlayVideo(local);
                Uri uri = new Uri("Assets/Images/transport.pause.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar.Source = imgSource;
                status = true;
            }
            else if (status == true && status2 == false)
            {

                Uri uri = new Uri("Assets/Images/transport.play.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar.Source = imgSource;
                mediaElement1.Pause();
                status2 = true;
            }
            else if (status == true && status2 == true)
            {
                Uri uri = new Uri("Assets/Images/transport.pause.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                gambar.Source = imgSource;
                mediaElement1.Play();
                status2 = false;

            }
        }



        public void PlayVideo(string aUrl)
        {
            mediaElement1.Stop();
            mediaElement1.Source = new Uri(aUrl, UriKind.RelativeOrAbsolute);
            mediaElement1.Play();
            mediaElement1.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(MediaElement_MediaFailed);

        }

        void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            var errorException = e.ErrorException;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string http = "http://video-js.zencoder.com/oceans-clip.mp4";
            PlayVideo(http);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();

            MediaPlayerLauncher mediaPlayerLauncher = new MediaPlayerLauncher();
            //mediaPlayerLauncher.Media = new Uri("video.mp4", UriKind.Absolute);
            mediaPlayerLauncher.Media = new Uri(@"video.mp4", UriKind.Absolute);


            mediaPlayerLauncher.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            mediaElement1.Play();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}