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
    public partial class BantuanPage : PhoneApplicationPage
    {
        public BantuanPage()
        {
            InitializeComponent();

            FirstAid.Text = App.LoadBantuanFromXML()[0];
            Cari.Text = App.LoadBantuanFromXML()[1];
            Kalendar.Text = App.LoadBantuanFromXML()[2];
            Tip.Text = App.LoadBantuanFromXML()[3];
            Faq.Text = App.LoadBantuanFromXML()[4];
            Kuis.Text = App.LoadBantuanFromXML()[5];
        }
    }
}