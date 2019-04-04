using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PaymentPage : ContentPage
    {
        void Handle_AddPaymentMethod(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddPaymentMethodPage());
        }
        void Handle_EditPaymentMethod(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditPaymentPage());
        }

        public PaymentPage()
        {
            InitializeComponent();
        }
    }
}
