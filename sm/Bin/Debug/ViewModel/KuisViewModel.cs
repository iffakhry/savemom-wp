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
    public class KuisViewModel : INotifyPropertyChanged
    {
        private int _idKuis;

        public int IdKuis
        {
            get
            {
                return _idKuis;
            }
            set
            {
                if (value != _idKuis)
                {
                    _idKuis = value;
                    NotifyPropertyChanged("IdKuis");
                }
            }
        }

        private string _pertanyaanKuis;

        public string PertanyaanKuis
        {
            get
            {
                return _pertanyaanKuis;
            }
            set
            {
                if (value != _pertanyaanKuis)
                {
                    _pertanyaanKuis = value;
                    NotifyPropertyChanged("PertanyaanKuis");
                }
            }
        }

        private string _pathGambarKuis;

        public string PathGambarKuis
        {
            get
            {
                return _pathGambarKuis;
            }
            set
            {
                if (value != _pathGambarKuis)
                {
                    _pathGambarKuis = value;
                    NotifyPropertyChanged("PathGambarKuis");
                }
            }
        }

        private string _jawabanA;

        public string JawabanA
        {
            get
            {
                return _jawabanA;
            }
            set
            {
                if (value != _jawabanA)
                {
                    _jawabanA = value;
                    NotifyPropertyChanged("JawabanA");
                }
            }
        }

        private string _jawabanB;

        public string JawabanB
        {
            get
            {
                return _jawabanB;
            }
            set
            {
                if (value != _jawabanB)
                {
                    _jawabanB = value;
                    NotifyPropertyChanged("JawabanB");
                }
            }
        }

        private string _jawabanC;

        public string JawabanC
        {
            get
            {
                return _jawabanC;
            }
            set
            {
                if (value != _jawabanC)
                {
                    _jawabanC = value;
                    NotifyPropertyChanged("JawabanC");
                }
            }
        }

        private string _jawabanD;

        public string JawabanD
        {
            get
            {
                return _jawabanD;
            }
            set
            {
                if (value != _jawabanD)
                {
                    _jawabanD = value;
                    NotifyPropertyChanged("JawabanD");
                }
            }
        }

        private string _jawabanBenar;

        public string JawabanBenar
        {
            get
            {
                return _jawabanBenar;
            }
            set
            {
                if (value != _jawabanBenar)
                {
                    _jawabanBenar = value;
                    NotifyPropertyChanged("JawabanBenar");
                }
            }
        }

        private bool _isTerjawab;

        public bool IsTerjawab
        {
            get
            {
                return _isTerjawab;
            }
            set
            {
                if (value != _isTerjawab)
                {
                    _isTerjawab = value;
                    NotifyPropertyChanged("IsTerjawab");
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