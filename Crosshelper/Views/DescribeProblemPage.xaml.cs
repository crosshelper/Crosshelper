using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Crosshelper.Models;
using Crosshelper.Helpers;

namespace Crosshelper.Views
{
    public partial class DescribeProblemPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            //var tmppage = this.Parent as GetHelpPage;
            //tmppage.RefreshSelection();
            Navigation.PopModalAsync();
            //Navigation.PushAsync(new QuotePage());
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
            DescriptionBox.Text = _currentTopic.Description;
            if(_currentTopic.Status == 1)
            {
                switchButton.IsToggled = true;
            }
            else
            {
                switchButton.IsToggled = false;
            }

            InitializeComponent();
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
            if(_currentTopic==null)
            {
                int status = 0;
                if(switchButton.IsToggled)
                    status = 1; 
                tih.ListMyTopic(_typeproblem.TagID, "95131", language, DescriptionBox.Text,status);
            }
            else
            {
                int status = 0;
                if (switchButton.IsToggled)
                    status = 1;
                tih.UpdateMyTopic("95131", language, DescriptionBox.Text, _currentTopic.TopicID, status);
            }
            Navigation.PushAsync(new PickHelperPage(_typeproblem,language));
        }

        //Describe Problem Text Editor
        void DescribeProblemEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
        private async void Handel_MyLocation(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();

            Settings.CurrentLongitude = position.Longitude;
            Settings.CurrentLatitude = position.Latitude;
            await Navigation.PushAsync(new LocationPage());
        }
        void Handle_Language(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignInPage());
        }
    }
}
