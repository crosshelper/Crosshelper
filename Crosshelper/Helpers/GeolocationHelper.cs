using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Crosshelper.Helpers
{
    public class GeolocationHelper
    {
        private bool done = false;
        private double latitude = 0;
        private double longitude = 0;

        /// <summary>
        /// Gets if geolocation is available on device
        /// </summary>
        public bool IsLocationAvailable()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        /// <summary>
        /// Gets if geolocation is enabled on device
        /// </summary>
        public bool IsGeolocationEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }

        /// <summary>
        /// Desired accuracy in meters
        /// </summary>
        double DesiredAccuracy { get; set; }

        /// <summary>
        /// Gets if device supports heading
        /// </summary>
        bool SupportsHeading { get; }


        public Task<Position> getLocation()
        {
            return Task<Position>.Run(() =>
            {
                while (!done) { }
                Position position = new Position
                {
                    Latitude = latitude,
                    Longitude = longitude
                };
                return position;
            });
        }

        public async Task<Position> GetCurrentLocation()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                //position = await locator.GetLastKnownLocationAsync();

                //if (position != null)
                //{
                    //got a cahched position, so let's use it.
                   // return position;
                //}

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    //return null;
                    position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
                }
                else
                {
                    position = await locator.GetLastKnownLocationAsync();

                }
                Settings.CurrentLatitude = position.Latitude;
                Settings.CurrentLongitude = position.Longitude;
                return position;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get location: " + ex);
            }
            return position;
        }

        public async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true);
            CrossGeolocator.Current.PositionChanged += PositionChanged;
            CrossGeolocator.Current.PositionError += PositionError;
        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {
            //If updating the UI, ensure you invoke on main thread
            var position = e.Position;
            Settings.CurrentLatitude = position.Latitude;
            Settings.CurrentLongitude = position.Longitude;
        }

        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            Console.WriteLine(e.Error);
            //Handle event here for errors
        }

        public async Task StopListening()
        {
            if (!CrossGeolocator.Current.IsListening)
                return;
            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PositionError;
        }
    }
}
