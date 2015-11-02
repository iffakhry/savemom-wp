using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace sm.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public int skor = 0;

        public MainViewModel()
        {
            this.ItemsJumlah = new ObservableCollection<JumlahViewModel>();
            this.ItemsTips = new ObservableCollection<TipsViewModel>();
            this.ItemsTipsFavorit = new ObservableCollection<TipsViewModel>();
            this.ItemsPertanyaan = new ObservableCollection<PertanyaanViewModel>();
            this.ItemsPertanyaanFavorit = new ObservableCollection<PertanyaanViewModel>();
            this.ItemsKalender = new ObservableCollection<KalenderViewModel>();
            this.ItemsPenanganan = new ObservableCollection<PenangananViewModel>();
            this.ItemsKuis = new ObservableCollection<KuisViewModel>();
            this.ItemsKuisTerjawab = new ObservableCollection<KuisViewModel>();
        }

        public ObservableCollection<PenangananViewModel> ItemsPenanganan { get; private set; }

        public ObservableCollection<TipsViewModel> ItemsTips { get; private set; }
        public ObservableCollection<KalenderViewModel> ItemsKalender { get; private set; }
        public ObservableCollection<TipsViewModel> ItemsTipsFavorit { get; private set; }
        public ObservableCollection<PertanyaanViewModel> ItemsPertanyaan { get; private set; }
        public ObservableCollection<PertanyaanViewModel> ItemsPertanyaanFavorit { get; private set; }
        public ObservableCollection<KuisViewModel> ItemsKuis { get; private set; }
        public ObservableCollection<KuisViewModel> ItemsKuisTerjawab { get; private set; }
        public ObservableCollection<JumlahViewModel> ItemsJumlah { get; private set; }

        public bool IsDataTipsLoaded
        {
            get;
            private set;
        }

        public bool IsDataKalenderLoaded
        {
            get;
            private set;
        }

        public bool IsDataJumlahLoaded
        {
            get;
            private set;

        }

        public bool IsDataPertanyaanLoaded
        {
            get;
            private set;
        }

        public bool IsDataKuisLoaded
        {
            get;
            private set;
        }

        public bool IsDataPenangananLoaded
        {
            get;
            private set;
        }

        public void LoadDataKuis()
        {
            ObservableCollection<KuisViewModel> AllTips;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbBelumTerjawab, System.IO.FileMode.Open);

                TextReader textReader = new StreamReader(fstream);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KuisViewModel>));
                AllTips = serializer.Deserialize(textReader) as ObservableCollection<KuisViewModel>;
                fstream.Close();
            }

            foreach (KuisViewModel oneSonnet in AllTips)
            {
                if (!oneSonnet.IsTerjawab)
                {
                    this.ItemsKuisTerjawab.Add(oneSonnet);
                }

                this.ItemsKuis.Add(oneSonnet);
            }

            this.IsDataKuisLoaded = true;
        }

        public void LoadDataJumlah()
        {
            JumlahViewModel jml = new JumlahViewModel(); ;
            jml.Jumlah = 0;
            ItemsJumlah.Add(jml);
            this.IsDataJumlahLoaded = true;

        }

        public void LoadDataKalender()
        {
            ObservableCollection<KalenderViewModel> AllKalender;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbKalender, System.IO.FileMode.Open);

                TextReader textReader = new StreamReader(fstream);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KalenderViewModel>));
                AllKalender = serializer.Deserialize(textReader) as ObservableCollection<KalenderViewModel>;
                fstream.Close();
            }

            foreach (KalenderViewModel oneSonnet in AllKalender)
            {
                this.ItemsKalender.Add(oneSonnet);

            }

            this.IsDataKalenderLoaded = true;
        }

        public void UpdateDatabaseKalender()
        {
            using (var isoStoreTerjawab = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStoreTerjawab.FileExists(App.dbKalender))
                {
                    IsolatedStorageFileStream fstream = isoStoreTerjawab.OpenFile(App.dbKalender, System.IO.FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KalenderViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, ItemsKalender);
                    textWriter.Close();
                    fstream.Close();
                }
                else
                {
                    isoStoreTerjawab.DeleteFile(App.dbKalender);
                    IsolatedStorageFileStream fstream = isoStoreTerjawab.OpenFile(App.dbKalender, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KalenderViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, ItemsKalender);
                    textWriter.Close();
                    fstream.Close();
                }
            }
        }

        public void LoadDataPenanganan()
        {
            XDocument xdoc = XDocument.Load("Content/PenangananData.xml");


            var dataEnum = xdoc.Descendants("Darurat");

            foreach (XElement e in dataEnum)
            {
                PenangananViewModel ivm = new PenangananViewModel();

                ivm.JudulPenanganan = (string)e.Element("Number").Value;
                ivm.Video = (string)e.Element("video").Value;
                ivm.Pertanyaan = (string)e.Element("pertanyaan").Value;
                
                int lineNum = 1;
                string sonnetBody = "";

                var bodyEnum = e.Element("Body").Descendants("Line");


                foreach (XElement line in bodyEnum)
                {
                    if (lineNum == 1)
                        ivm.IsiPenanganan = (string)line.Value;

                    if (lineNum < 13)
                        sonnetBody = sonnetBody + "\r\n" + line.Value;
                    else
                        sonnetBody = sonnetBody + "\r\n   " + line.Value;
                    lineNum++;
                }
                ivm.IsiPenanganan = sonnetBody;

                this.ItemsPenanganan.Add(ivm);
            }
            this.IsDataPenangananLoaded = true;
        }

        public void LoadDataTips()
        {
            ObservableCollection<TipsViewModel> AllTips;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbTips, System.IO.FileMode.Open);

                TextReader textReader = new StreamReader(fstream);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TipsViewModel>));
                AllTips = serializer.Deserialize(textReader) as ObservableCollection<TipsViewModel>;
                fstream.Close();
            }

            foreach (TipsViewModel oneSonnet in AllTips)
            {
                this.ItemsTips.Add(oneSonnet);

                if (oneSonnet.IsFavorite)
                    this.ItemsTipsFavorit.Add(oneSonnet);
            }

            this.IsDataTipsLoaded = true;
        }

        public void LoadDataPertanyaan()
        {
            ObservableCollection<PertanyaanViewModel> AllPertanyaan;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbPertanyaan, System.IO.FileMode.Open);

                TextReader textReader = new StreamReader(fstream);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PertanyaanViewModel>));
                AllPertanyaan = serializer.Deserialize(textReader) as ObservableCollection<PertanyaanViewModel>;
                fstream.Close();
            }

            foreach (PertanyaanViewModel oneSonnet in AllPertanyaan)
            {
                this.ItemsPertanyaan.Add(oneSonnet);

                if (oneSonnet.IsFavorite)
                    this.ItemsPertanyaanFavorit.Add(oneSonnet);
            }

            this.IsDataPertanyaanLoaded = true;

            //XDocument xdoc = XDocument.Load("Content/PertanyaanData.xml");


            //var dataEnum = xdoc.Descendants("Pertanyaan");

            //foreach (XElement e in dataEnum)
            //{
            //    //
            //    // Create an empty ItemViewModel
            //    //
            //    PertanyaanViewModel ivm = new PertanyaanViewModel();

            //    //
            //    // The main item shown in the ListBox is the number
            //    // of the sonnet in Roman numerals
            //    //
            //    ivm.JudulPertanyaan = (string)e.Element("Judul").Value;
            //    ivm.IntroPertanyaan = (string)e.Element("Number").Value;

            //    //
            //    // Now, we get an IEnumerable enabling the procesing
            //    // of each <Line> element in the <Body> tag
            //    //
            //    int lineNum = 1;
            //    string sonnetBody = "";

            //    var bodyEnum = e.Element("Body").Descendants("Line");


            //    foreach (XElement line in bodyEnum)
            //    {

            //        if (lineNum < 13)
            //            sonnetBody = sonnetBody + "\r\n" + line.Value;
            //        else
            //            sonnetBody = sonnetBody + "\r\n   " + line.Value;
            //        lineNum++;
            //    }
            //    ivm.IsiJawaban = sonnetBody;

            //    ivm.IsFavorite = (string)e.Element("Favorit").Value;
            //    bool cek = ivm.IsFavorite.Equals("True", StringComparison.Ordinal);
            //    if (cek)
            //    {
            //        this.ItemsPertanyaanFavorit.Add(ivm);
            //    }
            //    this.ItemsPertanyaan.Add(ivm);
            //    this.IsDataPertanyaanLoaded = true;
            //}
        }

        public void UpdateDatabasePertanyaan()
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStore.DeleteFile(App.dbPertanyaan);

                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbPertanyaan, FileMode.Create);

                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PertanyaanViewModel>));
                TextWriter textWriter = new StreamWriter(fstream);
                serializer.Serialize(textWriter, ItemsPertanyaan);
                textWriter.Close();
                fstream.Close();
            }
        }

        public void UpdateDatabaseTips()
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStore.DeleteFile(App.dbTips);
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbTips, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TipsViewModel>));
                TextWriter textWriter = new StreamWriter(fstream);
                serializer.Serialize(textWriter, ItemsTips);
                textWriter.Close();
                fstream.Close();
            }
        }

        public void UpdateDatabaseKuis()
        {
            using (var isoStoreTerjawab = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStoreTerjawab.FileExists(App.dbTerjawab))
                {
                    IsolatedStorageFileStream fstream = isoStoreTerjawab.OpenFile(App.dbTerjawab, System.IO.FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KuisViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, ItemsKuisTerjawab);
                    textWriter.Close();
                    fstream.Close();
                }
                else
                {
                    isoStoreTerjawab.DeleteFile(App.dbTerjawab);
                    IsolatedStorageFileStream fstream = isoStoreTerjawab.OpenFile(App.dbTerjawab, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KuisViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, ItemsKuisTerjawab);
                    textWriter.Close();
                    fstream.Close();
                }
            }

            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStore.DeleteFile(App.dbBelumTerjawab);
                IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbBelumTerjawab, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KuisViewModel>));
                TextWriter textWriter = new StreamWriter(fstream);
                serializer.Serialize(textWriter, ItemsKuis);
                textWriter.Close();
                fstream.Close();
            }
        }

        public void TambahPertanyaanFavorite(PertanyaanViewModel item)
        {
            this.ItemsPertanyaanFavorit.Add(item);
            NotifyPropertyChanged("FavoritesProperty");
        }

        public void HapusPertanyaanFavorite(PertanyaanViewModel item)
        {
            this.ItemsPertanyaanFavorit.Remove(item);
            NotifyPropertyChanged("FavoritesProperty");
        }

        public void TambahTipsFavorite(TipsViewModel item)
        {
            this.ItemsTipsFavorit.Add(item);
            NotifyPropertyChanged("FavoritesProperty");
        }

        public void HapusTipsFavorite(TipsViewModel item)
        {
            this.ItemsTipsFavorit.Remove(item);
            NotifyPropertyChanged("FavoritesProperty");
        }

        public void TambahKuisTerjawab(KuisViewModel item)
        {
            this.ItemsKuis.Remove(item);
            this.ItemsKuisTerjawab.Add(item);
            NotifyPropertyChanged("FavoritesProperty");
        }

        public void HapusKuisTerjawab(KuisViewModel item)
        {
            this.ItemsKuisTerjawab.Remove(item);
            this.ItemsKuis.Add(item);
            NotifyPropertyChanged("FavoritesProperty");
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