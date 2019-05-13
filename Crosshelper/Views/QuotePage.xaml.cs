using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class QuotePage : ContentPage
    {
        //public ReactiveCommand SelectPaymentCommand { get; private set; } = new ReactiveCommand();

        public QuotePage()
        {
            InitializeComponent();

        }
            //SelectPaymentCommand = new Command(SelectPayment);
            //SelectPayment.GestureRecognizers.Add(new TapGestureRecognizer

        void Handle_Cancel(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }


        void Handle_Accept(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }


        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectPaymentPage());
        }

    }
}
