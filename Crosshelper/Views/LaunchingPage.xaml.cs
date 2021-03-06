﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Crosshelper.Models;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Crosshelper.Views
{
    public partial class LaunchingPage : ContentPage
    {

        public LaunchingPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);
            InitializeComponent();
            Init();
            BindingContext = this;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
        }

        List<UserInfo> _myItemsSource;
        public List<UserInfo> LaunchingItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }

        void Init()
        {
            LaunchingItemsSource = new List<UserInfo>()
            {
                new UserInfo() { Icon="https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/CH+logo2.png", FirstName = "Title1", LastName = "Test1", Address="this is the first page" },
                new UserInfo() { Icon="https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/CH+logo2.png", FirstName = "Title2", LastName = "Test2", Address="this is the second page" }
            };
        }


        void Handle_GetStarted(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new Xamarin.Forms.NavigationPage( new SignInPage()));
            //Navigation.PushModalAsync(new NavigationPage(new SignInPage()));

        }
    }
}
