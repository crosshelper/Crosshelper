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

        void AddPayment()
        {
            Navigation.PushAsync(new AddPaymentMethodPage());
        }

        void EditPayment()
        {
            Navigation.PushAsync(new EditPaymentPage());
        }

        public List<PaymentInfo> Paymentlist { get; set; } = new List<PaymentInfo>();
        public List<Cell> PaymentCells { get; set; } = new List<Cell>();
        UserInfoHelper uih = new UserInfoHelper();

        public PaymentPage()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            Paymentlist = uih.GetPaymentsList(Settings.UserId);
            foreach(PaymentInfo ptmp in Paymentlist)
            {
                PaymentCells.Add(new CommandCell() { Title = ptmp.AccountNo, Command = new Command(EditPayment), CommandParameter = ptmp, });
            }
            PaymentCells.Add(new CommandCell() { Title = "Add Payment Method", Command = new Command(AddPayment)});

            pmsection.Add(PaymentCells);
        }

        protected override void OnAppearing()
        {
            pmsection.Clear();
            RefreshData();
        }
    }
}
