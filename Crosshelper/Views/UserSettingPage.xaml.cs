using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class UserSettingPage : ContentPage
    {
        void Handle_PaymentMethod(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PaymentPage());
        }

        void Handle_Promotion(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PromotionCodePage());
        }

        public UserSettingPage()
        {
            InitializeComponent();
            //commandcell.IconSource = ImageSource.FromUri(new Uri("https://static1.squarespace.com/static/59c15a448a02c7a81f7a90aa/t/59e67fa1e5dd5b9338707436/1508278185945/Google.png"));
        }
    }
}
