using System;
using System.Collections.Generic;
using Crosshelper.Converters;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PastHistoryDetailPage : ContentPage
    {
        //Emergency,CaseDate,Language,Description,HelperImage,HelperName,HelperRating,HelperLanguage
        //ServiceFee,EquipmentFee,CycbisFee,Tax,Total,PaymentNum,CaseDateTime

        private CaseInfo _currentCase;
        public string Emergency { get; set; }

        UserInfoHelper uih = new UserInfoHelper();
        BindingContextConverter bcc = new BindingContextConverter();

        public PastHistoryDetailPage(CaseInfo currentCase)
        {
            _currentCase = currentCase;
            InitializeComponent();
            Emergency = _currentCase.CaseTypeLabelText;
            CaseDate.Text = _currentCase.CaseDateTime.ToString();
            Description.Text = _currentCase.CaseDescription;

            uih.GetHelperInfoByID(_currentCase.HelperID);
            UserPro helper = uih.GetHelperInfo();
            HelperImage.Source = helper.Icon;
            HelperName.Text = helper.FirstName;
            HelperRating.Text = bcc.StarNoToStarSign(helper.Rating);
            HelperLanguage.Text = helper.FLanguage + "/" + helper.SLanguage;

            ReceiptInfo _receipt = uih.GetReceiptByID(_currentCase.ReceiptID);
            ServiceFee.Text = _receipt.ServiceFee.ToString();
            EquipmentFee.Text = _receipt.EqFee.ToString();
            CycbisFee.Text = _receipt.Surcharge.ToString();
            Tax.Text = _receipt.Tax.ToString();
            Total.Text = (_receipt.EqFee+ _receipt.ServiceFee+ _receipt.Surcharge+ _receipt.Tax).ToString();

            PaymentNum.Text = _receipt.PaymentName;
            CaseDateTime.Text = _currentCase.CaseDateTime.ToString();
        }
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
