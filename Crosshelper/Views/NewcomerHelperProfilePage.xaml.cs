using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomerHelperProfilePage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public NewcomerHelperProfilePage()
        {
            InitializeComponent();
        }
        //Top Ring&Menu button
        void NHPPBackButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void NHPPCancelButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Confirm
        void NHPPConfirm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
    }
}
