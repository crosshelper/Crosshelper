using System;
using System.Collections.Generic;
using System.Windows.Input;
using Stripe;
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
            var options = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = "8764534657658792",
                    ExpYear = Convert.ToInt64("2022"),
                    ExpMonth = Convert.ToInt64("04"),
                    Cvc = "684",
                    Currency = "eur"
                }
            };


            var service = new TokenService();

            Token stripeToken = service.Create(options);

            var token = stripeToken;

            var checkToken = token.Id;

            var options2 = new ChargeCreateOptions
            {
                Amount = Convert.ToInt64("20.89"),//valor),
                Currency = "eur",
                Description = "Charge for ",
                SourceId = checkToken
            };
            var service1 = new ChargeService();

            try
            {
                Charge charge = service1.Create(options2);
            }
            catch (Exception ex)
            {
                DisplayAlert("teste", ex.Message, "ok");
            }

            Navigation.PopAsync();
        }


        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectPaymentPage());
        }

    }
}
