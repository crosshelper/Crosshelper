using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PromotionCodePage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_AddPromotionCode(object sender, System.EventArgs e)
        {
            Navigation.PopAsync(false);
        }
        public PromotionCodePage()
        {
            InitializeComponent();
        }
    }
}
