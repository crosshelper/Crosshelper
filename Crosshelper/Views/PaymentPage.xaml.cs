using System;
using System.Collections.Generic;
using AiForms.Renderers;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PaymentPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PaymentInfo ptmp = e.Item as PaymentInfo;
            ((ListView)sender).SelectedItem = null;
            if(ptmp.CVV=="000")
            {
                Navigation.PushAsync(new AddPaymentMethodPage());
            }
            else
            {
                Navigation.PushAsync(new EditPaymentPage(ptmp));
            }
        }

        public List<PaymentInfo> PaymentsList { get; set; } = new List<PaymentInfo>();
        UserInfoHelper uih = new UserInfoHelper();

        public PaymentPage()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            PaymentsList = uih.GetPaymentsList(Settings.UserId);
            PaymentsList.Add(new PaymentInfo() { AccountNo = "Add a new payment", CVV = "000" });
        }

        protected override void OnAppearing()
        {
            RefreshData();
            BindingContext = this;
        }
    }
}
