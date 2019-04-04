using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class AddPaymentMethodPage : ContentPage
    {
        void Handle_AddPyament(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PaymentPage());
        }

        public AddPaymentMethodPage()
        {
            InitializeComponent();
        }
    }
}
