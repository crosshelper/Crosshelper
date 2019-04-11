using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class AddPaymentMethodPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_AddPyament(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(false);
        }

        public AddPaymentMethodPage()
        {
            InitializeComponent();
        }
    }
}
