using System;
using System.Collections.Generic;
using System.Windows.Input;
using AiForms.Renderers;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PaymentPage : ContentPage
    {
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
            ls.BeginRefresh();
            ls.ItemsSource = null;
            if(PaymentsList.Count>0)
            {
                PaymentsList.Clear();
            }
            PaymentsList = uih.GetPaymentsList(Settings.UserId);
            PaymentsList.Add(new PaymentInfo() { AccountNo = "Add a new payment", CVV = "000" });
            ls.ItemsSource = PaymentsList;
            ls.EndRefresh();
        }

        async void OnDeleteAsync(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            bool x = await DisplayAlert("Delete Confirm", "Delete this Payment ?", "Yes", "Cancel");
            if (x)
            {
                uih.DeleteMyPaymentByID((mi.CommandParameter as PaymentInfo).PaymentID);
                RefreshData();
            }
        }

        protected override void OnAppearing()
        {
            RefreshData();
            BindingContext = this;
        }
    }
}
