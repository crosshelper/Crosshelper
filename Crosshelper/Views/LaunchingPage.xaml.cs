using System;
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

        public LaunchingPage()
        {
            InitializeComponent();
            Init();
            BindingContext = this;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
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

        }
    }
}
