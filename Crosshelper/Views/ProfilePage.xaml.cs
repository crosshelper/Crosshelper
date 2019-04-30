using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProfilePage : ContentPage
    {
        void Handle_Saved(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(false);
        }
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_ResetPassword(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage());
        }

        async void Handle_ChangePhoto(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Upload Photo", "Cencel", null, "Take photo", "From album");
        }
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}
