﻿#pragma checksum "C:\Users\Singgih Saputra\Documents\Visual Studio 2012\Projects\FIX with splashscreen edit\sm iso\sm\sm\PertanyaanPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "01A2CB738CA41A9F12FEBBAE97349408"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace sm {
    
    
    public partial class PertanyaanPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox textCari;
        
        internal System.Windows.Controls.ListBox PertanyaanListBox;
        
        internal System.Windows.Controls.ListBox PertanyaanFavoritListBox;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/sm;component/PertanyaanPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.textCari = ((System.Windows.Controls.TextBox)(this.FindName("textCari")));
            this.PertanyaanListBox = ((System.Windows.Controls.ListBox)(this.FindName("PertanyaanListBox")));
            this.PertanyaanFavoritListBox = ((System.Windows.Controls.ListBox)(this.FindName("PertanyaanFavoritListBox")));
        }
    }
}

