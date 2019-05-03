using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Crosshelper.Helpers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
        }

        private async void Handle_GPS(object sender, System.EventArgs e)
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cahched position, so let's use it.
                    Settings.CurrentLatitude = position.Latitude;
                    Settings.CurrentLongitude = position.Longitude;
                    //return position;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    //return null;
                }
                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(3), null, true);
                Settings.CurrentLatitude = position.Latitude;
                Settings.CurrentLongitude = position.Longitude;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get location: " + ex);
            }
            LongitudeLabel.Text = Settings.CurrentLongitude.ToString();
            LatitudeLabel.Text = Settings.CurrentLatitude.ToString();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //Position p = Task.Run(GetCurrentLocationAsync).Result;

            //Task.Yield();
            //Settings.CurrentLatitude = p.Latitude;
            //Settings.CurrentLongitude = p.Longitude;
            //LongitudeLabel.Text = Settings.CurrentLongitude.ToString();
            //LatitudeLabel.Text = Settings.CurrentLatitude.ToString();
        }


        private async Task<Position> GetCurrentLocationAsync()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

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

                var tokenSource2 = new CancellationTokenSource();
                tokenSource2.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get location: " + ex);
            }
            if (position == null)
                return null;
            //var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                    //position.Timestamp, position.Latitude, position.Longitude,
                    //position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
            //Debug.WriteLine(output);
            return position;
        }

    }
}
