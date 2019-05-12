using System;
using System.Collections.Generic;
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

        public PastHistoryDetailPage(CaseInfo currentCase)
        {
            _currentCase = currentCase;
            InitializeComponent();
            Emergency = "";
            CaseDate.Text = _currentCase.CaseDateTime.ToString();
            Language.Text = "";
            Description.Text = "";
            HelperImage.Source = "";
            HelperName.Text = "";
            HelperRating.Text = "";
            HelperLanguage.Text = "";
            ServiceFee.Text = "";
            EquipmentFee.Text = "";
            CycbisFee.Text = "";
            Tax.Text = "";
            Total.Text = "";
            PaymentNum.Text = "";
            CaseDateTime.Text = "";
        }
    }
}
