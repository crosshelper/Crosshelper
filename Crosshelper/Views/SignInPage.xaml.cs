using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        //返回按钮 Go Back
        void SIPSignInGoBack(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //登入按钮 Sign In
        void SIPSignIn(object sender, EventArgs e)
        {
            //(sender as Button).Text = "Click me again!";
        }
        //第三次登入 Third party sign in
        void SIPGoogleSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void SIPWechatSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void SIPFaceBookSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //注册&忘记 New Account&Forgot
        void SIPCreateAccount(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void SIPForgotPassword(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //登入邮箱&密码输入框 Sign in email&password input box
        void SIPSignInEmailCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        void SIPSignInPasswordCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

    }
}
