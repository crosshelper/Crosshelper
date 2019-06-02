using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;
using SendBird;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {
        //TODO:Auto signin
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
        async void Handle_SignIn(object sender, EventArgs e)
        {
            //(sender as Button).Text = "Click me again!";
            UserAccess userAccess = new UserAccess();
            Models.User usr = new Models.User();
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            if (userAccess.VerifyUser(uNameEntry.Text, pwdEntry.Text))
            {
                signInTest.Text = "Sign In Succeeded, Data Loading...";
                signInTest.TextColor = Color.FromHex("#FF4E18");
                Settings.UserId = userAccess.CurrentUid.ToString();
                usr = userAccess.GetUserInfo(userAccess.CurrentUid);
                Settings.ChatID = usr.ChatID;
                Name = usr.FirstName + " " + usr.LastName;
                ProfileIcon = usr.Icon;
                ChatServerConnect();
                await Task.Delay(3000);
                Application.Current.MainPage = new MyTabbedPage();

            }
            else
            {
                signInTest.Text = "Sign in Faild";
                activity.IsEnabled = false;
                activity.IsRunning = false;
                activity.IsVisible = false;
                Settings.IsLogin = false;
            }
        }

        private string Name = "";
        private string ProfileIcon = ""; 

        private void ChatServerConnect()
        {
            SendBirdClient.Connect(Settings.ChatID, (SendBird.User user, SendBirdException e) =>
            {
                if (e != null)
                {
                    return;
                }

                SendBirdClient.UpdateCurrentUserInfo(Name, ProfileIcon, (SendBirdException e1) =>
                {
                    if (e1 != null)
                    {
                        return;
                    }
                });
            });
            Settings.IsLogin = true;
        }

        //第三次登入 Third party sign in
        void Handle_GoogleSignIn(object sender, EventArgs e)
        {
            DisplayAlert("Sorry", "It will be suppported later.", "OK");
        }
        void Handle_FaceBookSignIn(object sender, EventArgs e)
        {
            DisplayAlert("Sorry", "It will be suppported later.", "OK");
        }
        //创建和忘记 Create&Forgot
        void Handle_ForgotPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
        void Handle_CreateAccount(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

    }
}

