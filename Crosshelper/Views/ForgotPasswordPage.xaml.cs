using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ForgotPasswordPage : ContentPage
    {
        void Handle_Reset(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MyTabbedPage();
        }

        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        void Handle_Canceled(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage = new SignInPage();
        }
    }
}
