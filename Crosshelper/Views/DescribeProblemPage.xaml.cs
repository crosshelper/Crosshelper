using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Crosshelper.Models;
using Crosshelper.Helpers;
using System.Linq;
using WebSocketSharp;
using System.Threading.Tasks;

namespace Crosshelper.Views
{
    public partial class DescribeProblemPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(150);
                SetCurrentZipCode();
                await Task.Delay(200);
                if (DigitalBtn.IsToggled)
                {
                    MyLocationName.Text = Settings.ZipCode;
                }
                else
                {
                    MyLocationName.Text = "Not Selected";
                }
                
                await Task.Delay(200);
            });
        }
        
        private TypeProblem _typeproblem;
        private TopicInfo _currentTopic;

        public DescribeProblemPage(TypeProblem tmp)
        {
            _typeproblem = tmp;
            InitializeComponent();
        }

        public DescribeProblemPage(TopicInfo tmp)
        {
            _currentTopic = tmp;
            InitializeComponent();
            languagepicker.SelectedItem = _currentTopic.Language;
            des.Text = _currentTopic.Description;
            if (_currentTopic.Status == 1)
            {
                switchButton.IsToggled = true;
            }
            else
            {
                switchButton.IsToggled = false;
            }
        }

        void Handle_DigitalToggled(object sender, EventArgs e)
        {
            if (DigitalBtn.IsToggled)
            {
                MyLocationName.Text = Settings.ZipCode;
            }
            else
            {
                MyLocationName.Text = "Not Selected";
            }
        }

        //Not Really按钮 Not really Button
        void Handle_NotReally(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Yes按钮 Yes Button
        void Handle_Yes(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        int pageused = 0;
        //下一步按钮 Next Button
        void Handle_Next(object sender, EventArgs e)
        {
            
            if (MyLocationName.Text == "Not Selected")
            {
                DisplayAlert("Missing info", "Check all activities you need fill and try again.", "OK");
                return;
            }
            string language = "English";
            var tih = new TopicInfoHelper();
            if (languagepicker.SelectedItem != null)
            {
                language = languagepicker.SelectedItem.ToString();
            }
            if (des.Text.IsNullOrEmpty())
            {
                DisplayAlert("No description", "Describe your Question plsease!", "OK");
                return;
            }
            if (_currentTopic == null || pageused != 0)
            {
                int status = 0;
                //Settings.ZipCode = "95131";
                if (switchButton.IsToggled)
                    status = 1;
                if (Settings.CurrentLongitude > 0)
                {
                    return;
                }
                
                if (DigitalBtn.IsToggled)
                {
                    SetCurrentZipCode();
                    tih.ListMyTopic(_typeproblem.TagID, Settings.ZipCode, language, des.Text, status);

                    _currentTopic = new TopicInfo
                    {
                        TagID = _typeproblem.TagID,
                        Zipcode = MyLocationName.Text,
                        Language = language,
                        Description = des.Text,
                        Status = status
                    };
                    pageused++;
                    Navigation.PushAsync(new PickHelperPage(_currentTopic));
                }
                else
                {
                    tih.ListMyTopic(_typeproblem.TagID, "00000", language, des.Text, status);
                    _currentTopic = new TopicInfo
                    {
                        TagID = _typeproblem.TagID,
                        Zipcode = "00000",
                        Language = language,
                        Description = des.Text,
                        Status = status
                    };
                    pageused++;
                    Navigation.PushAsync(new PickHelperPage(_currentTopic));
                }                
            }
            else
            {
                if (Settings.CurrentLongitude > 0)
                {
                    return;
                }
                SetCurrentZipCode();
                int status = 0;
                if (switchButton.IsToggled)
                    status = 1;
                if (DigitalBtn.IsToggled)
                {
                    tih.UpdateMyTopic(Settings.ZipCode, language, des.Text, _currentTopic.TopicID, status);
                }
                else
                {
                    tih.UpdateMyTopic("00000", language, des.Text, _currentTopic.TopicID, status);
                }
                Navigation.PushAsync(new PickHelperPage(_currentTopic));
            }

        }

        private async void SetCurrentZipCode()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                //var temppp = await locator.GetPositionAsync();
                var position = new Position(Settings.CurrentLatitude, Settings.CurrentLongitude);
                var addresses = await locator.GetAddressesForPositionAsync(position, null);
                var address = addresses.FirstOrDefault();
                if (address.PostalCode.Length == 5)
                {
                    Settings.ZipCode = address.PostalCode;
                }
                else
                {

                    locator.DesiredAccuracy = 50;
                    var newposition = await locator.GetPositionAsync();
                    if (newposition.Longitude > 0)
                    {
                        return;
                    }
                    Settings.CurrentLongitude = newposition.Longitude;
                    Settings.CurrentLatitude = newposition.Latitude;

                    var newaddresses = await locator.GetAddressesForPositionAsync(newposition, null);
                    var newaddress = newaddresses.FirstOrDefault();
                    Settings.ZipCode = newaddress.PostalCode;
                }
            }
            catch (Exception e)
            {

            }
        }

        private async void Handel_MyLocation(object sender, EventArgs e)
        {
            if (!DigitalBtn.IsToggled)
            {
                return;
            }
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            if (position.Longitude > 0)
            {
                return;
            }
            Settings.CurrentLongitude = position.Longitude;
            Settings.CurrentLatitude = position.Latitude;
            //var p = new Position(Settings.CurrentLongitude, Settings.CurrentLatitude);
            var addresses = await locator.GetAddressesForPositionAsync(position, null);
            var address = addresses.FirstOrDefault();
            Settings.ZipCode = address.PostalCode;

            await Navigation.PushModalAsync(new NavigationPage(new LocationPage()));
        }
        void Handle_Language(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignInPage());
        }
    }
}