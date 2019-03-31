using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class DescribeProblemPage : ContentPage
    {
        public DescribeProblemPage()
        {
            InitializeComponent();
        }
        //返回按钮 Go Back
        void DPPbackButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        } 
        //取消按钮 cancel
        void DPPCancelButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        } 
        //Not Really按钮 Not really Button
        void DPPNotReallyButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        } 
        //Yes按钮 Yes Button
        void DPPYesButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //下一步按钮 Next Button
        void DPPNextButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        //Describe Problem Text Editor
        void DescribeProblemTextEditor(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void DescribeProblemTextEditor(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
    }
}
