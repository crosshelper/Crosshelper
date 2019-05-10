using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class CtestPage : ContentPage
    {
        public CtestPage()
        {
            InitializeComponent();
           
        }

        //第三次登入 Third party sign in
        void Handle_GoogleSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void Handle_WechatSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void Handle_FaceBookSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        void Handle_SignIn(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));
        }

        void Handle_SignUp(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SignInPage()));

        }
    }
}
