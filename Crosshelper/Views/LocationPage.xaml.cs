using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Crosshelper.Helpers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

namespace Crosshelper.Views
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();


            /*
            buttonGetGPS.Clicked += async (sender, args) =>
            {
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 1000;
                    labelGPS.Text = "Getting gps";

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);//locator.GetPositionAsync(TimeSpan.FromSeconds(3));  
                    if (position == null)
                    {
                        labelGPS.Text = "null gps :(";
                        return;
                    }
                    labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                        position.Timestamp, position.Latitude, position.Longitude,
                        position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

                }
                catch(Exception ex)
                {
                
                }
            };

            buttonTrack.Clicked += async (object sender, EventArgs e) =>
            {
                try
                {
                    if (CrossGeolocator.Current.IsListening)
                    {
                        await CrossGeolocator.Current.StopListeningAsync();
                        labelGPSTrack.Text = "Stopped tracking";
                        buttonTrack.Text = "Stop Tracking";
                    }
                    else
                    {
                        if (await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(3), 0))
                        {
                            labelGPSTrack.Text = "Started tracking";
                            buttonTrack.Text = "Track Movements";
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
                CrossGeolocator.Current.PositionError += CrossGeolocator_Current_PositionError;
            }
            catch
            {
            }
        }

        void CrossGeolocator_Current_PositionError(object sender, Plugin.Geolocator.Abstractions.PositionErrorEventArgs e)
        {

            labelGPSTrack.Text = "Location error: " + e.Error.ToString();
        }

        void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;
            labelGPSTrack.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
                CrossGeolocator.Current.PositionError -= CrossGeolocator_Current_PositionError;
            }
            catch
            {
            }
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
        //GeolocationHelper gh = new GeolocationHelper();
        void Handle_Clicked(object sender, System.EventArgs e)
        {

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
                    */
        }

        private async void Handle_GPS(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();

            //var Longitude = position.Longitude.ToString();
            //var Latitude = position.Latitude.ToString();

            //MyLocation.Text = Longitude + " , " + Latitude;

            Settings.CurrentLatitude = position.Latitude;
            Settings.CurrentLongitude = position.Longitude;

            try
            {
                string mapKey = null; //only needed on UWP
                var addresses = await locator.GetAddressesForPositionAsync(position, mapKey);
                var address = addresses.FirstOrDefault();

                if (address == null)
                    Addresslabel.Text = "No address found for position.";
                else
                    Addresslabel.Text = "Addresss: " + address.Locality + ", " + address.AdminArea + ", " + address.CountryCode + ", " + address.PostalCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get address: " + ex);
            }
            //Navigation.PopAsync();
        }

    }
}
