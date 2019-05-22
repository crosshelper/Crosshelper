using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class FRequiredSignInPage : ContentPage
    {
        public FRequiredSignInPage()
        {
            InitializeComponent();
        }
        void Handle_SignIn(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage = new SignInPage();
            //Application.Current.MainPage = new NavigationPage(new SignInPage());
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));

        }

        void Handle_GetHelp(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }
    }
}
