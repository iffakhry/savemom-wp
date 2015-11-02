using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.ComponentModel;
using Microsoft.Phone.Shell;

namespace sm
{
    public partial class firstaid : PhoneApplicationPage
    {
        public firstaid()
        {
            InitializeComponent();
        }

        private void Penanganan_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DaftarPenanganan.xaml", UriKind.Relative));
        }

        private void Panggilan_Click(object sender, EventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = "119";
            phoneCallTask.DisplayName = "Panggilan Darurat";

            phoneCallTask.Show();
        }
    }
}