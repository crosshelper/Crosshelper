using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomerSettingPage : ContentPage
    {
        public NewcomerSettingPage()
        {
            //InitializeComponent();
            Button btn = new Button
            {
                Text = "test",
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Yellow,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            btn.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new SignUpPage());
            };
            Content = new StackLayout
            {
                Children = {
                    btn
                }
            };
        }
    }
    }

