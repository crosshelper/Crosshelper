using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ResetPasswordPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public ResetPasswordPage()
        {
            InitializeComponent();
        }
    }
}
