using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Crosshelper.Models;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class LaunchingPage : ContentPage
    {
        List<User> _myItemsSource;
        public List<User> LaunchingItemsSource
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
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));
        }

        void Init()
        {
            LaunchingItemsSource = new List<User>()
            {
                new User() { Icon="https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/CH+logo2.png", FirstName = "Title1", LastName = "Test1", Address="this is the first page" },
                new User() { Icon="https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/CH+logo2.png", FirstName = "Title2", LastName = "Test2", Address="this is the second page" }
            };
        }

        void Handle_SignIn(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new NavigationPage(new TestPage()));
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));
        }

        void Handle_SignUp(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));

        }
    }
}
