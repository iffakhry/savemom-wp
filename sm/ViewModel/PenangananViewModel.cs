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
    public class PenangananViewModel : INotifyPropertyChanged
    {
        private string _judulPenanganan;
        public string JudulPenanganan
        {
            get
            {
                return _judulPenanganan;
            }
            set
            {
                if (value != _judulPenanganan)
                {
                    _judulPenanganan = value;
                    NotifyPropertyChanged("JudulPenanganan");
                }
            }
        }

        private string _pertanyaan;

        public string Pertanyaan
        {
            get
            {
                return _pertanyaan;
            }
            set
            {
                if (value != _pertanyaan)
                {
                    _pertanyaan = value;
                    NotifyPropertyChanged("Pertanyaan");
                }
            }
        }


        private string _isiPenanganan;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string IsiPenanganan
        {
            get
            {
                return _isiPenanganan;
            }
            set
            {
                if (value != _isiPenanganan)
                {
                    _isiPenanganan = value;
                    NotifyPropertyChanged("IsiPenanganan");
                }
            }
        }

        private string _video;
        
        public string Video
        {
            get
            {
                return _video;
            }
            set
            {
                if (value != _video)
                {
                    _video = value;
                    NotifyPropertyChanged("Video");
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