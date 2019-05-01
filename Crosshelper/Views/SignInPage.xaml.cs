using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {
        private int parentPageIndex;
        public SignInPage(int i)
        {
            parentPageIndex = i;
            InitializeComponent();
        }

        public SignInPage()
        {
        }

        //取消按钮 Canceled
        void Handle_Canceled(object sender, EventArgs e)
        {

            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[parentPageIndex];
            //Application.
        }
        //登入邮箱&密码输入框 Sign in email&password input box
        void UsernameSignInCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        void PasswordSignInCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        //登入按钮 Sign In
        void Handle_SignIn(object sender, EventArgs e)
        {
            //(sender as Button).Text = "Click me again!";
            UserAccess userAccess = new UserAccess();

            Application.Current.MainPage = new MyTabbedPage("o");

            if (userAccess.VerifyUser(uNameEntry.Text, pwdEntry.Text))
            {
                signInTest.Text = "Sign in success";
            }
            else
            {
                signInTest.Text = "Sign in Faild";
            }
        }
        //第三次登入 Third party sign in
        void Handle_GoogleSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void Handle_WechatSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void Handle_FaceBookSignIn(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //创建和忘记 Create&Forgot
        void Handle_ForgotPassword(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ForgotPasswordPage();
        }
        void Handle_CreateAccount(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SignUpPage();
        }

    }
}

