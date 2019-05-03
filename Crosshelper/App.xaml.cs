using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Crosshelper.Views;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SendBird;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crosshelper.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Crosshelper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();



            SendBirdClient.Init(Crosshelper.Properties.Resources.APP_ID);
            //MainPage = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage))) {
            //BarBackgroundColor = Color.FromHex("#FF4E18"),
            //BarTextColor = Color.White };
            MainPage = new MyTabbedPage();
        }

        public bool IsLocationAvailable()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Task.Run(GetCurrentLocationAsync);
            //Position p = Task.Run(GetCurrentLocationAsync).Result;
            //Settings.CurrentLatitude = p.Latitude;
            //Settings.CurrentLongitude = p.Longitude;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async Task<Position> GetCurrentLocationAsync()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 1;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cahched position, so let's use it.
                    return position;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return null;
                }
                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location: " + ex);
            }
            if (position == null)
                return null;
            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                    position.Timestamp, position.Latitude, position.Longitude,
                    position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
            Debug.WriteLine(output);
            return position;
        }
    }
}
