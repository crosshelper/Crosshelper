using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class EditPaymentPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_SavePyament(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(false);
        }
        public EditPaymentPage()
        {
            InitializeComponent();
        }
    }
}
