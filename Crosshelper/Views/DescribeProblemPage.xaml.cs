﻿using System;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                if (Settings.ZipCode.Length == 5)
                {
                    MyLocationName.Text = Settings.ZipCode;
                }
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
            if (_currentTopic == null)
            {
                int status = 0;
                //Settings.ZipCode = "95131";
                if (switchButton.IsToggled)
                    status = 1;
                if (Settings.CurrentLongitude > 0)
                {
                    return;
                }
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
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
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
