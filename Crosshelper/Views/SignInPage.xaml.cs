using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        //返回按钮 Go Back
        void SignInGoBack(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //登入按钮 Sign In
        void SignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //第三次登入 Third party sign in
        void GoogleSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void WechatSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void FaceBookSignInIcon(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //注册&忘记 New Account&Forgot
        void CreateAccount(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void ForgotPassword(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //登入邮箱&密码输入框 Sign in email&password input box
        void SignInEmailCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        void SignInPasswordCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
    }
}
