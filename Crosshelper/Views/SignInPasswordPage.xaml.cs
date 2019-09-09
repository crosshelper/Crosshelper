using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Crosshelper.Helpers;
using Crosshelper.Models;
using SendBird;
using WebSocketSharp;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignInPasswordPage : ContentPage, INotifyPropertyChanged
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(150);
                pwdEntry.Focus();
            });
        }

        private string Name = "";
        private string ProfileIcon = "";
        UserInfo usr = new UserInfo();
        UserAccess userAccess = new UserAccess();
        KeyChainHelper kch = new KeyChainHelper();
        private string _currentNumber = "";

        /// <loading>
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        /// <loading>

        public bool RememberMe
        {
            get => Preferences.Get(nameof(RememberMe), false);
            set
            {
                Preferences.Set(nameof(RememberMe), value);
                if (!value)
                {
                    Preferences.Set(nameof(Username), string.Empty);
                }
                OnPropertyChanged(nameof(RememberMe));
            }
        }

        string username = Preferences.Get(nameof(Username), string.Empty);
        public string Username
        {
            get => username;
            set
            {
                username = value;
                if (RememberMe)
                {
                    Preferences.Set(nameof(Username), value);
                }
                OnPropertyChanged(nameof(RememberMe));
            }
        }

        public SignInPasswordPage(string currentNumber)
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;
            _currentNumber = currentNumber;
        }

        async void Handle_Next(object sender, EventArgs e)
        {
            if (pwdEntry.Text == null)
            {
                await DisplayAlert("Notice", "Please enter your current password and make sure it's least 8 characters. ", "OK");
                return;
            }

            /*activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            signInloading.Text = "Connecting...";
            signInloading.TextColor = Color.FromHex("#FF4E18");*/
            await Task.Delay(1000);

            RememberMe = true;
            Username = _currentNumber;

            if (userAccess.VerifyUser(_currentNumber, pwdEntry.Text))
            {
                //activity.IsEnabled = true;
                // activity.IsRunning = true;
                // activity.IsVisible = true;
                // SignInStatus.Text = "Connecting...";
                IsLoading = true;
                kch.SavetoSecureStorage("token_of_" + _currentNumber, pwdEntry.Text);
                //signInloading.Text = "Sign In Succeeded, Data Loading...";
                //signInloading.TextColor = Color.FromHex("#555555");
                Settings.UserId = userAccess.CurrentUid.ToString();
                usr = userAccess.GetUserInfo(userAccess.CurrentUid);
                Settings.ChatID = usr.ChatID;
                if(usr.FirstName.IsNullOrEmpty() || usr.LastName.IsNullOrEmpty() || usr.FLanguage.IsNullOrEmpty())
                await Navigation.PushAsync(new SignUpInfoPage("",""));
                Name = usr.FirstName + " " + usr.LastName;
                ProfileIcon = usr.Icon;
                ChatServerConnect();
                await Task.Delay(3000);
                Settings.IsLogin = true;
                Application.Current.MainPage = new MyTabbedPage();
            }
            else
            {
                await DisplayAlert("Notice", "Please enter your current password and make sure it's least 8 characters. ", "OK");
                Settings.IsLogin = false;
            }
        }

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

        void Handle_forgotPwd(object sender, System.EventArgs e)
        {
            if (_currentNumber.Remove(3) == "+86")
            {
                userAccess.SendverifyCodeYP(_currentNumber.Substring(3), userAccess.GetVerificationCode());
                Navigation.PushAsync(new ResetPWDVerifyPage(_currentNumber));
            }
            else
            {
                userAccess.TwilioVerifyService(_currentNumber);
                Navigation.PushAsync(new ResetPWDVerifyPage(_currentNumber));
            }
        }
        void Handle_Privacy(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.cycbis.com/#/privacy"));
            //Navigation.PushModalAsync(new PrivacyPage());
        }
        void Handle_Terms(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.cycbis.com/#/terms"));
            //Navigation.PushModalAsync(new PrivacyPage());
        }
    }
}
