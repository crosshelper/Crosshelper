using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;
using SendBird;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {

        public SignInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        //取消按钮 Canceled
        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
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
            Models.User usr = new Models.User();

            if (userAccess.VerifyUser(uNameEntry.Text, pwdEntry.Text))
            {
                signInTest.Text = "Sign in success";
                Settings.UserId = userAccess.CurrentUid.ToString();
                usr = userAccess.GetUserInfo(userAccess.CurrentUid);
                Settings.ChatID = usr.ChatID;
                Name = usr.FirstName + " " + usr.LastName;
                ChatServerConnect();
                Application.Current.MainPage = new MyTabbedPage();
            }
            else
            {
                signInTest.Text = "Sign in Faild";
            }
        }

        private string Name = "";

        private void ChatServerConnect()
        {
            SendBirdClient.Connect(Settings.ChatID, (SendBird.User user, SendBirdException e) =>
            {
                if (e != null)
                {
                    //MessageError = e.Message;
                    return;
                }

                SendBirdClient.UpdateCurrentUserInfo(Name, "", (SendBirdException e1) =>
                {
                    if (e1 != null)
                    {
                        //MessageError = e1.Message;
                        return;
                    }
                });
            });
            //MessageError = "Connected";
            Settings.IsLogin = true;
        }

        //第三次登入 Third party sign in
        void Handle_GoogleSignIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MyTabbedPage();
        }
        void Handle_FaceBookSignIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MyTabbedPage();
        }
        //创建和忘记 Create&Forgot
        void Handle_ForgotPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
        void Handle_CreateAccount(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
            //Navigation.PushAsync(new SignUpPage());
        }

    }
}

