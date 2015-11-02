using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
namespace sm
{
    public partial class tentang : PhoneApplicationPage
    {
        public tentang()
        {
            InitializeComponent();
            this.textBlock1.Text = "Version 1.0\r\n\r\nSave Mom adalah aplikasi pertolongan pertama untuk ibu hamil yang bertujuan untuk meningkatkan angka keselamatan ibu hamil";
        }

        private void Crevion_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://facebook.com/crevion", UriKind.Absolute);
            task.Show();
        }
        private void Ptiik_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://ptiik.ub.ac.id", UriKind.Absolute);
            task.Show();
        }
    }
}