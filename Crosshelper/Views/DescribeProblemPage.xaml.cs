using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class DescribeProblemPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        public DescribeProblemPage()
        {
            InitializeComponent();
        }
        //Not Really按钮 Not really Button
        void Handle_NotReally(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        } 
        //Yes按钮 Yes Button
        void Handle_Yes(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //下一步按钮 Next Button
        void Handle_Next(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickHelperPage());
        }

        //Describe Problem Text Editor
        void DescribeProblemEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
        void Handle_Location(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void Handle_Language(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }
    }
}
