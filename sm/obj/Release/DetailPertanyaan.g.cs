﻿#pragma checksum "C:\Users\Singgih Saputra\Documents\Visual Studio 2012\Projects\FIX with splashscreen edit\sm iso\sm\sm\DetailPertanyaan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C140E905FDA5DC105F9AB2726813223"
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
    
    
    public partial class DetailPertanyaan : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock ListTitle;
        
        internal System.Windows.Controls.Image FavoriteImage;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image gambar;
        
        internal System.Windows.Controls.TextBlock ContentText;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/sm;component/DetailPertanyaan.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ListTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ListTitle")));
            this.FavoriteImage = ((System.Windows.Controls.Image)(this.FindName("FavoriteImage")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.gambar = ((System.Windows.Controls.Image)(this.FindName("gambar")));
            this.ContentText = ((System.Windows.Controls.TextBlock)(this.FindName("ContentText")));
        }
    }
}

