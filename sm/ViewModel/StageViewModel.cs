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
    public class StageViewModel : INotifyPropertyChanged
    {
        private string _idStage;

        public string IdStage
        {
            get
            {
                return _idStage;
            }
            set
            {
                if (value != _idStage)
                {
                    _idStage = value;
                    NotifyPropertyChanged("IdStage");
                }
            }
        }

        private string _contentStage1;

        public string ContentStage1
        {
            get
            {
                return _contentStage1;
            }
            set
            {
                if (value != _contentStage1)
                {
                    _contentStage1 = value;
                    NotifyPropertyChanged("ContentStag1");
                }
            }
        }

        private string _contentStage2;

        public string ContentStage2
        {
            get
            {
                return _contentStage2;
            }
            set
            {
                if (value != _contentStage2)
                {
                    _contentStage2 = value;
                    NotifyPropertyChanged("ContentStage2");
                }
            }
        }

        private string _contentStage3;

        public string ContentStage3
        {
            get
            {
                return _contentStage3;
            }
            set
            {
                if (value != _contentStage3)
                {
                    _contentStage3 = value;
                    NotifyPropertyChanged("ContentStage3");
                }
            }
        }

        private string _contentStage4;

        public string ContentStage4
        {
            get
            {
                return _contentStage4;
            }
            set
            {
                if (value != _contentStage4)
                {
                    _contentStage4 = value;
                    NotifyPropertyChanged("ContentStage4");
                }
            }
        }

        private string _contentStage5;

        public string ContentStage5
        {
            get
            {
                return _contentStage5;
            }
            set
            {
                if (value != _contentStage5)
                {
                    _contentStage5 = value;
                    NotifyPropertyChanged("ContentStage5");
                }
            }
        }

        private string _contentStage6;

        public string ContentStage6
        {
            get
            {
                return _contentStage6;
            }
            set
            {
                if (value != _contentStage6)
                {
                    _contentStage6 = value;
                    NotifyPropertyChanged("ContentStage6");
                }
            }
        }


        private string _statusStage;

        public string StatusStage
        {
            get
            {
                return _statusStage;
            }
            set
            {
                if (value != _statusStage)
                {
                    _statusStage = value;
                    NotifyPropertyChanged("StatusStage");
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