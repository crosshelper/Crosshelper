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
using Crosshelper.PlacesBar;

namespace Crosshelper.Views
{
    public partial class LocationPage : ContentPage
    {
        string GooglePlacesApiKey = Properties.Resources.API_KEY;//Keys.ApiKey;  // Replace this with your api key

        public LocationPage()
        {
            InitializeComponent();

            search_bar.ApiKey = GooglePlacesApiKey;
            search_bar.Type = PlaceType.Address;
            search_bar.Components = new Components("country:us|country:uk"); // Restrict results to United States and United Kingdom
            search_bar.PlacesRetrieved += Search_Bar_PlacesRetrieved;
            search_bar.TextChanged += Search_Bar_TextChanged;
            search_bar.MinimumSearchText = 1;
            results_list.ItemSelected += Results_List_ItemSelected;
        }

        void Search_Bar_PlacesRetrieved(object sender, AutoCompleteResult result)
        {
            results_list.ItemsSource = result.AutoCompletePlaces;
            spinner.IsRunning = false;
            spinner.IsVisible = false;

            if (result.AutoCompletePlaces != null && result.AutoCompletePlaces.Count > 0)
                results_list.IsVisible = true;
        }

        void Search_Bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                results_list.IsVisible = false;
                spinner.IsVisible = true;
                spinner.IsRunning = true;
            }
            else
            {
                results_list.IsVisible = true;
                spinner.IsRunning = false;
                spinner.IsVisible = false;
            }
        }

        async void Results_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var prediction = (AutoCompletePrediction)e.SelectedItem;
            results_list.SelectedItem = null;

            var place = await Places.GetPlace(prediction.Place_ID, GooglePlacesApiKey);

            if (place != null)
            {
                Settings.CurrentLatitude = place.Latitude;
                Settings.CurrentLongitude = place.Longitude;
                await DisplayAlert(
                    place.Name, "You are here!", "OK");//string.Format("Lat: {0}\nLon: {1}", place.Latitude, place.Longitude), "OK");
            }
            await Navigation.PopModalAsync();
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
