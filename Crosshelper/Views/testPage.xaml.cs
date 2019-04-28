using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class testPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new SignInPage();
        }

        public testPage()
        {
            InitializeComponent();
        }
    }
}
