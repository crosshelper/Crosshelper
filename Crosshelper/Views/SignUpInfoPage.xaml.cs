using System;
using System.Threading.Tasks;
using Crosshelper.Helpers;
using Crosshelper.Models;
using SendBird;
using WebSocketSharp;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpInfoPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        UserInfoHelper uih = new UserInfoHelper();
        
        KeyChainHelper kch = new KeyChainHelper();
        UserInfo usr = new UserInfo();
        private string Name = "";
        private string ProfileIcon = "";
        private string Email = "";

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                FNameEntry.Focus();
            });
        }

        public SignUpInfoPage(string contactNo, string pwd)
        {
            _currentNo = contactNo;
            _currentPassword = pwd;
            InitializeComponent();
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private string FName, LName;
        private string _currentNo = "";
        private string _currentPassword = "";

        private void ChatServerConnect()
        {
            SendBirdClient.Connect(Settings.ChatID, (User user, SendBirdException e) =>
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

                SendBirdClient.RegisterAPNSPushTokenForCurrentUser(SendBirdClient.GetPendingPushToken(), (SendBirdClient.PushTokenRegistrationStatus status, SendBirdException e1) =>
                {
                    if (e1 != null)
                    {
                        // Error.
                        return;
                    }

                    if (status == SendBirdClient.PushTokenRegistrationStatus.PENDING)
                    {
                        // Try registration after connection is established.
                    }
                });
            });
            Settings.IsLogin = true;
        }






        // private bool GetRealName()
        // {
        //var IsNameValid = false;
        // var name = NameEntry.Text;
        // string[] sArray = name.Split(' ');
        //Regex.Split(str, "js", RegexOptions.IgnoreCase);
        // FName = "";
        // LName = "";
        // if (sArray.Length == 2)
        // {
        //     FName = sArray[0];
        //    LName = sArray[1];
        //     IsNameValid = true;
        // }
        // return IsNameValid;
        //  }


        async void Handle_CreateAccount(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (FNameEntry.Text.IsNullOrEmpty() && LNameEntry.Text.IsNullOrEmpty())
=======
            /*
            if (GetRealName())
            {
                if(Email.IsNullOrEmpty() || ContactNo.IsNullOrEmpty())
                {
                    Email = "test@tert.com";
                    ContactNo = "0000000000";
                }
                uih.UpdateUserRealName(FName, LName);
                uAccess.UpdateEmailNo(Email, ContactNo);
                //Settings.IsLogin = uAccess.VerifyUser(Uname, Pwd);
                DisplayAlert("Congrats!", "You Have Done Sign Up, Sign In right now", "OK");
                Navigation.PopToRootAsync();
                //Application.Current.MainPage = new LaunchingPage();
            }
            else
            {
                DisplayAlert("Name not Valid","Name should be 'Donald Trump', Try again.","Got it!");
                return; 
            }
            */

            if (FNameEntry.Text.IsNullOrEmpty() && LNameEntry.Text.IsNullOrEmpty() && FlanPicker.SelectedItem.ToString().IsNullOrEmpty())
>>>>>>> 7013777... fix
            {
                await DisplayAlert("Notice", "Please fill all required information box.", "OK");
            }
            else
            {
                FName = FNameEntry.Text;
                LName = LNameEntry.Text;
                if (Email.IsNullOrEmpty())
                    Email = "cycbis@cycbis.com";
                uih.UpdateUserRealNameEmail(FName, LName, Email);
                uAccess.SetChatID();
                //uAccess.UpdateEmailNo(Email, ContactNo);
                //Settings.IsLogin = uAccess.VerifyUser(Uname, Pwd);
                //DisplayAlert("Congrats!", "You Have Done Sign Up, Sign In right now", "OK");
                //
                kch.SavetoSecureStorage("token_of_" + _currentNo, _currentPassword);
                //signInloading.Text = "Sign In Succeeded, Data Loading...";
                //signInloading.TextColor = Color.FromHex("#555555");
                //Settings.UserId = uAccess.CurrentUid.ToString();
                usr = uAccess.GetUserInfo(Convert.ToInt32(Settings.UserId));// uAccess.CurrentUid);
                Settings.ChatID = usr.ChatID;
                Name = usr.FirstName + " " + usr.LastName;
                ProfileIcon = usr.Icon;
                ChatServerConnect();
                await Task.Delay(3000);
                Settings.IsLogin = true;
                
                Application.Current.MainPage = new MyTabbedPage();
            }
        }
    }
}
