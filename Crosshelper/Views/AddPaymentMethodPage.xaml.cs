using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class AddPaymentMethodPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_AddPyament(object sender, System.EventArgs e)
        {
            _pinfo.AccountNo = "";
            _pinfo.CName = ""; 
            _pinfo.ExDate = new DateTime(2012,05,09);
            _pinfo.CVV = "";
            _pinfo.Zipcode = "";
            uih.UpdatePaymentInfo(_pinfo);
            Navigation.PopAsync(false);
        }

        PaymentInfo _pinfo = new PaymentInfo();
        UserInfoHelper uih = new UserInfoHelper();

        public AddPaymentMethodPage()
        {
            InitializeComponent();
        }
    }
}
