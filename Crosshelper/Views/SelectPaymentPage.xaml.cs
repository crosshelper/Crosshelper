using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SelectPaymentPage : ContentPage
    {
        public SelectPaymentPage()
        {
            InitializeComponent();
        }

        void Handle_SelectPayment(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void Handle_AddPayment(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddPaymentMethodPage());
        }
    }
}
