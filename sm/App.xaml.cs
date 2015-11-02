using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using sm.Resources;
using sm.ViewModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace sm
{
    public partial class App : Application
    {
        public static string dbPertanyaan = "PertanyaanFavorit.xml";
        public static string dbTips = "TipsFavorit.xml";
        public static string dbScore = "Score.xml";
        public static string dbTerjawab = "Terjawab.xml";
        public static string dbBelumTerjawab = "BelumTerjawab.xml";
        public static string dbKalender = "dbKalender.xml";
        public static string dbStage = "StageDone.xml";

        private static MainViewModel viewModel = null;
        public int skor = 1;


        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

            // Standard XAML initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Language display initialization
            InitializeLanguage();

            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "phSwmCygc9F5EBHgz1MV";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "SQTI9mqq4pq5LZ3VtKOOPg";

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }
        public static void setDataPertanyaan()
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.FileExists(dbPertanyaan))
                {
                    IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbPertanyaan, System.IO.FileMode.Create);

                    ObservableCollection<PertanyaanViewModel> itemsFromXML = LoadDataBasePertanyaanFromXML();

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PertanyaanViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, itemsFromXML);
                    textWriter.Close();
                    fstream.Close();
                }
            }
        }

        public static void setDataStage()
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.FileExists(dbStage))
                {
                    IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbStage, System.IO.FileMode.Create);

                    ObservableCollection<StageViewModel> itemsFromXML = LoadDataBaseStageFromXML();

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<StageViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, itemsFromXML);
                    textWriter.Close();
                    fstream.Close();
                }
            }
        }

        public static void setDataKuis(int id)
        {

            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStore.DeleteFile(App.dbBelumTerjawab);
                if (!isoStore.FileExists(dbBelumTerjawab))
                {
                    IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbBelumTerjawab, System.IO.FileMode.Create);

                    ObservableCollection<KuisViewModel> itemsFromXML = LoadDataBaseKuisFromXML(id);

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<KuisViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, itemsFromXML);
                    textWriter.Close();
                    fstream.Close();
                }
            }
        }

        public static void setDataTips()
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.FileExists(dbTips))
                {
                    IsolatedStorageFileStream fstream = isoStore.OpenFile(App.dbTips, System.IO.FileMode.Create);

                    ObservableCollection<TipsViewModel> itemsFromXML = LoadDataBaseTipsFromXML();

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TipsViewModel>));
                    TextWriter textWriter = new StreamWriter(fstream);
                    serializer.Serialize(textWriter, itemsFromXML);
                    textWriter.Close();
                    fstream.Close();
                }
            }
        }

        public static ObservableCollection<PertanyaanViewModel> LoadDataBasePertanyaanFromXML()
        {
            ObservableCollection<PertanyaanViewModel> items = new ObservableCollection<PertanyaanViewModel>();
            XDocument xdoc = XDocument.Load("Content/PertanyaanData.xml");
            var dataEnum = xdoc.Descendants("Pertanyaan");
            int sonnetNumber = 1;
            foreach (XElement e in dataEnum)
            {
                PertanyaanViewModel ivm = new PertanyaanViewModel();

                ivm.JudulPertanyaan = (string)e.Element("Judul").Value;
                ivm.IntroPertanyaan = (string)e.Element("Number").Value;
                ivm.Gambar = (string)e.Element("Gambar").Value;
                int lineNum = 1;
                string sonnetBody = "";

                var bodyEnum = e.Element("Body").Descendants("Line");


                foreach (XElement line in bodyEnum)
                {

                    if (lineNum < 13)
                        sonnetBody = sonnetBody + "\r\n" + line.Value;
                    else
                        sonnetBody = sonnetBody + "\r\n   " + line.Value;
                    lineNum++;
                }
                ivm.IsiJawaban = sonnetBody;

                ivm.IsFavorite = false;

                ivm.IdPertanyaan = sonnetNumber;

                items.Add(ivm);

                sonnetNumber++;
            }

            return items;
        }

        public static ObservableCollection<StageViewModel> LoadDataBaseStageFromXML()
        {
            ObservableCollection<StageViewModel> items = new ObservableCollection<StageViewModel>();
            XDocument xdoc = XDocument.Load("Content/Stage.xml");
            var dataEnum = xdoc.Descendants("Stage");
            StageViewModel ivm = new StageViewModel();
            foreach (XElement e in dataEnum)
            {
                //ivm.IdStage = (string)e.Element("Id").Value;
                if ((string)e.Element("Id").Value == "1")
                {
                    ivm.ContentStage1 = (string)e.Element("Content").Value;
                }
                else if ((string)e.Element("Id").Value == "2")
                {
                    ivm.ContentStage2 = (string)e.Element("Content").Value;
                }
                else if ((string)e.Element("Id").Value == "3")
                {
                    ivm.ContentStage3 = (string)e.Element("Content").Value;
                }
                else if ((string)e.Element("Id").Value == "4")
                {
                    ivm.ContentStage4 = (string)e.Element("Content").Value;
                }
                else if ((string)e.Element("Id").Value == "5")
                {
                    ivm.ContentStage5 = (string)e.Element("Content").Value;
                }
                else
                {
                    ivm.ContentStage6 = (string)e.Element("Content").Value;
                }
                
            }
            items.Add(ivm);

            return items;
        }

        public static ObservableCollection<TipsViewModel> LoadDataBaseTipsFromXML()
        {
            ObservableCollection<TipsViewModel> items = new ObservableCollection<TipsViewModel>();
            XDocument xdoc = XDocument.Load("Content/TipsData.xml");
            var dataEnum = xdoc.Descendants("Tips");
            int sonnetNumber = 1;
            foreach (XElement e in dataEnum)
            {
                TipsViewModel ivm = new TipsViewModel();

                ivm.JudulTips = (string)e.Element("Judul").Value;
                ivm.Gambar = (string)e.Element("Gambar").Value;
                int lineNum = 1;
                string sonnetBody = "";

                var bodyEnum = e.Element("Body").Descendants("Line");


                foreach (XElement line in bodyEnum)
                {

                    if (lineNum < 13)
                        sonnetBody = sonnetBody + "\r\n" + line.Value;
                    else
                        sonnetBody = sonnetBody + "\r\n   " + line.Value;
                    lineNum++;
                }
                ivm.IsiTips = sonnetBody;

                ivm.IsFavorite = false;

                ivm.IdTips = sonnetNumber;

                items.Add(ivm);

                sonnetNumber++;
            }

            return items;
        }

        public static String[] LoadBantuanFromXML()
        {
            XDocument xdoc = XDocument.Load("Content/Bantuan.xml");
            var dataEnum = xdoc.Descendants("menu");
            string sonnetBody = "";
            String[] ban = new string[6];
            int ind = 0;
            foreach (XElement e in dataEnum)
            {
                //sonnetBody = sonnetBody + (string)e.Element("nama").Value;
                //ban[ind]=(string)e.Element

                var bodyEnum = e.Element("body").Descendants("line");


                foreach (XElement line in bodyEnum)
                {
                    sonnetBody = sonnetBody + "\n\t" + line.Value;
                }
                ban[ind] = sonnetBody;
                ind++;
                sonnetBody = "";
            }

            return ban;
        }

        public static ObservableCollection<KuisViewModel> LoadDataBaseKuisFromXML(int id)
        {
            ObservableCollection<KuisViewModel> items = new ObservableCollection<KuisViewModel>();
            XDocument xdoc = XDocument.Load("Content/KuisData.xml");
            var dataEnum = xdoc.Descendants("Kuis");
            int sonnetNumber = 1;
            foreach (XElement e in dataEnum)
            {
                if ((string)e.Element("Stage").Value == ""+id)
                {
                    KuisViewModel ivm = new KuisViewModel();
                    ivm.PertanyaanKuis = (string)e.Element("Number").Value;
                    ivm.JawabanA = (string)e.Element("A").Value;
                    ivm.JawabanB = (string)e.Element("B").Value;
                    ivm.JawabanC = (string)e.Element("C").Value;
                    ivm.JawabanD = (string)e.Element("D").Value;
                    ivm.JawabanBenar = (string)e.Element("Benar").Value;
                    ivm.IsTerjawab = false;
                    ivm.IdKuis = sonnetNumber;
                    items.Add(ivm);
                    sonnetNumber++;
                }   
            }
            return items;
        }


        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new TransitionFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Unregister the event so it doesn't get called again
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Only clear the stack for 'new' (forward) and 'refresh' navigations
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // For UI consistency, clear the entire page stack
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // do nothing
            }
        }

        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}