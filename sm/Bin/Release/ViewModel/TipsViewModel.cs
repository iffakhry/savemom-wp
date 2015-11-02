using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace sm.ViewModel
{
    public class TipsViewModel : INotifyPropertyChanged
    {
        private string _gambar;

        public string Gambar
        {
            get
            {
                return _gambar;
            }
            set
            {
                if (value != _gambar)
                {
                    _gambar = value;
                    NotifyPropertyChanged("Gambar");
                }
            }
        }

        private int _idTips;

        public int IdTips
        {
            get
            {
                return _idTips;
            }
            set
            {
                if (value != _idTips)
                {
                    _idTips = value;
                    NotifyPropertyChanged("IdTips");
                }
            }
        }

        private string _judulTips;

        public string JudulTips
        {
            get
            {
                return _judulTips;
            }
            set
            {
                if (value != _judulTips)
                {
                    _judulTips = value;
                    NotifyPropertyChanged("JudulTips");
                }
            }
        }

        private string _introTips;
        public string IntroTips
        {
            get
            {
                return _introTips;
            }
            set
            {
                if (value != _introTips)
                {
                    _introTips = value;
                    NotifyPropertyChanged("IntroTips");
                }
            }
        }

        private string _isiTips;

        public string IsiTips
        {
            get
            {
                return _isiTips;
            }
            set
            {
                if (value != _isiTips)
                {
                    _isiTips = value;
                    NotifyPropertyChanged("IsiTips");
                }
            }
        }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            set
            {
                if (value != _isFavorite)
                {
                    _isFavorite = value;
                    NotifyPropertyChanged("IsFavorite");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}