using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NCAboutPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public NCAboutPage()
        {
            InitializeComponent();
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(false);
        }
    }
}
