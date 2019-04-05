using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class AgreementPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public AgreementPage()
        {
            InitializeComponent();
        }
    }
}
