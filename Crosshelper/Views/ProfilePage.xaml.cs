using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProfilePage : ContentPage
    {
        void Handle_ResetPassword(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage());
        }
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}
