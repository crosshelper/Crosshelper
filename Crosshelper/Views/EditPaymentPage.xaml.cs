using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class EditPaymentPage : ContentPage
    {
        void Handle_SavePyament(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PaymentPage());
        }
        public EditPaymentPage()
        {
            InitializeComponent();
        }
    }
}
