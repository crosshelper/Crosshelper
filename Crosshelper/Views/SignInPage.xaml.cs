using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;
using SendBird;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Crosshelper.Views
{
    public partial class SignInPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                PNumEntry.Focus();
            });
        }

        public SignInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
      
        KeyChainHelper kch = new KeyChainHelper();
        private string Name = "";
        private string ProfileIcon = "";

        //登入按钮 Sign In
        async void Handle_SignIn(object sender, EventArgs e)
        {
            /*  activity.IsEnabled = true;
              activity.IsRunning = true;
              activity.IsVisible = true;
              signInloading.Text = "Connecting...";
              signInloading.TextColor = Color.FromHex("#FF4E18");
              await Task.Delay(2000);

              if (Connectivity.NetworkAccess != NetworkAccess.Internet)
              {
                  await DisplayAlert("No Internet", "Try again later!", "OK");
                  return;
              }

              if (uNameEntry.Text.IsNullOrEmpty() || pwdEntry.Text.IsNullOrEmpty())
              {
                  await DisplayAlert("No user found", "Try again later!", "OK");
                  return;
              }

              RememberMe = savename.IsToggled;
              Username = uNameEntry.Text;
              UserAccess userAccess = new UserAccess();
              Models.User usr = new Models.User();

              if (userAccess.VerifyUser(uNameEntry.Text, pwdEntry.Text))
              {
                  kch.SavetoSecureStorage("token_of_" + Username, pwdEntry.Text);
                  signInloading.Text = "Sign In Succeeded, Data Loading...";
                  signInloading.TextColor = Color.FromHex("#555555");
                  Settings.UserId = userAccess.CurrentUid.ToString();
                  usr = userAccess.GetUserInfo(userAccess.CurrentUid);
                  Settings.ChatID = usr.ChatID;
                  Name = usr.FirstName + " " + usr.LastName;
                  ProfileIcon = usr.Icon;
                  ChatServerConnect();
                  await Task.Delay(3000);
                  //await Navigation.PushModalAsync(new MyTabbedPage());
                  Application.Current.MainPage = new MyTabbedPage();
              }
              else
              {
                  signInloading.Text = "Sign in Faild";
                  signInloading.TextColor = Color.FromHex("#555555");
                  activity.IsEnabled = false;
                  activity.IsRunning = false;
                  activity.IsVisible = false;
                  Settings.IsLogin = false;
              }
          } 

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

          protected override void OnAppearing()
          {
              base.OnAppearing();
              savename.IsToggled = RememberMe;
              if (RememberMe)
              {
                  uNameEntry.Text = Username;
              }
              */

            if (PNumEntry.Text == null)
            {
                await DisplayAlert("Notice", "Please enter your phone number and make sure it's correct and includes with area code.", "OK");

            }
            else
            {

                Navigation.PushAsync(new SignUpPage());

            }
        }
        //取消按钮 Canceled
        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void Handle_Privacy(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.cycbis.com/#/privacy"));
            //Navigation.PushModalAsync(new PrivacyPage());
        }
        void Handle_Terms(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.cycbis.com/#/terms"));
            //Navigation.PushModalAsync(new PrivacyPage());
        }
    }
}

