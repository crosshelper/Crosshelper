using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomerReviewPage : ContentPage
    {
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
    }
}