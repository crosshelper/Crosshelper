using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SelectAddPaymentPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        void Handle_AddPyament(object sender, System.EventArgs e)
        {
            _pinfo.AccountNo = CardNumber;
            _pinfo.CName = CName;
            _pinfo.ExDate = ExDate.Date;
            _pinfo.CVV = CVV;
            _pinfo.Zipcode = Zip;
            _pinfo.Uid = Settings.UserId;
            uih.InsertPaymentInfo(_pinfo);
            Navigation.PopAsync(false);
        }

        public string CardNumber { get; set; }
        public DateTime ExDate { get; set; }
        public string CName { get; set; }
        public string CVV { get; set; }
        public string Zip { get; set; }

        PaymentInfo _pinfo = new PaymentInfo();
        UserInfoHelper uih = new UserInfoHelper();

        public SelectAddPaymentPage()
        {
            InitializeComponent();
            ExDate = DateTime.Today;
            BindingContext = this;
        }
    }
}
