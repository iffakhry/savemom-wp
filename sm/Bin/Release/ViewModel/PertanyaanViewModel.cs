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
    public class PertanyaanViewModel : INotifyPropertyChanged
    {
        private int _idPertanyaan;

        public int IdPertanyaan
        {
            get
            {
                return _idPertanyaan;
            }
            set
            {
                if (value != _idPertanyaan)
                {
                    _idPertanyaan = value;
                    NotifyPropertyChanged("IdPertanyaan");
                }
            }
        }

        private string _judulPertanyaan;

        public string JudulPertanyaan
        {
            get
            {
                return _judulPertanyaan;
            }
            set
            {
                if (value != _judulPertanyaan)
                {
                    _judulPertanyaan = value;
                    NotifyPropertyChanged("JudulPertanyaan");
                }
            }
        }

        private string _introPertanyaan;

        public string IntroPertanyaan
        {
            get
            {
                return _introPertanyaan;
            }
            set
            {
                if (value != _introPertanyaan)
                {
                    _introPertanyaan = value;
                    NotifyPropertyChanged("IntroPertanyaan");
                }
            }
        }

        private string _isiJawaban;

        public string IsiJawaban
        {
            get
            {
                return _isiJawaban;
            }
            set
            {
                if (value != _isiJawaban)
                {
                    _isiJawaban = value;
                    NotifyPropertyChanged("IsiJawaban");
                }
            }
        }

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