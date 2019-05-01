using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class CRequiredSignInPage : ContentPage
    {
        public CRequiredSignInPage()
        {
            InitializeComponent();
        }

        void Handle_SignIn(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new SignInPage(3);
        }

        void Handle_SignUp(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage = new SignUpPage();
            Navigation.PushAsync(new SignUpPage());
        }

    }
}
