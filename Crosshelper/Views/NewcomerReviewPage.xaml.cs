using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomerReviewPage : ContentPage
    {

        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public NewcomerReviewPage()
        {

            InitializeComponent();
        }
        //Top Ring&Menu button
        void NRPBackButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void NRPCancelButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Leave Review Text Editor
        void NRPLeaveReviewTextEditorChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void NRPLeaveReviewTextEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
        //Submit button
        void NRPSubmit(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Star Rating button
        void Handle_StarClickedOne(object sender, EventArgs e)
        {
            (sender as Button).Text = "★";
        }
        void Handle_StarClickedTwo(object sender, EventArgs e)
        {
            (sender as Button).Text = "★";
        }
        void Handle_StarClickedThree(object sender, EventArgs e)
        {
            (sender as Button).Text = "★";
        }
        void Handle_StarClickedFour(object sender, EventArgs e)
        {
            (sender as Button).Text = "★";
        }
        void Handle_StarClickedFive(object sender, EventArgs e)
        {
            (sender as Button).Text = "★";
        }
    }
}