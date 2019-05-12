using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class QuotePage : ContentPage
    {

        public QuotePage()
        {
            InitializeComponent();
        }

        void Handle_Cancel(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void Handle_Accept(object sender, System.EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
