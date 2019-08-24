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

namespace Crosshelper.Views
{
    public partial class DescribeProblemPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
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
            if(_currentTopic.Status == 1)
            {
                switchButton.IsToggled = true;
            }
            else
            {
                switchButton.IsToggled = false;
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
        //下一步按钮 Next Button
        void Handle_Next(object sender, EventArgs e)
        {
            string language = "English";
            var tih = new TopicInfoHelper();
            if (languagepicker.SelectedItem != null)
            {
                language = languagepicker.SelectedItem.ToString();
            }
            if (des.Text.IsNullOrEmpty())
            {
                DisplayAlert("No description","Describe your Question plsease!","OK");
                return;
            }
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            loading.IsVisible = true;
            if (_currentTopic==null)
            {
                int status = 0;
                Settings.ZipCode = "95131";
                if (switchButton.IsToggled)
                    status = 1;
                if (Settings.CurrentLongitude > 0)
                {
                    return;
                }
                SetCurrentZipCode();
                tih.ListMyTopic(_typeproblem.TagID, Settings.ZipCode, language, des.Text,status);
                _currentTopic = new TopicInfo
                {
                    TagID = _typeproblem.TagID,
                    Zipcode = "95131",
                    Language = language,
                    Description = des.Text,
                    Status = status
                };
                Navigation.PushModalAsync(new NavigationPage(new PickHelperPage(_currentTopic)));
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
                tih.UpdateMyTopic(Settings.ZipCode, language, des.Text, _currentTopic.TopicID, status);
                Navigation.PushModalAsync(new NavigationPage(new PickHelperPage(_currentTopic)));
            }

        }

        private async void SetCurrentZipCode()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = new Position(Settings.CurrentLatitude, Settings.CurrentLongitude);
            var addresses = await locator.GetAddressesForPositionAsync(position, null);
            var address = addresses.FirstOrDefault();
            Settings.ZipCode = address.PostalCode;
        }


        private async void Handel_MyLocation(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            if (position.Longitude > 0)
            {
                return;
            }
            Settings.CurrentLongitude = position.Longitude;
            Settings.CurrentLatitude = position.Latitude;

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
