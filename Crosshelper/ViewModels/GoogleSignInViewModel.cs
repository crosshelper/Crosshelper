using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Crosshelper.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Xamarin.Forms;
namespace Crosshelper.ViewModels
{
    public class GoogleSignInViewModel : INotifyPropertyChanged
    {
        public User User { get; set; } = new User();
        public string Name
        {
            get => User.FirstName;
            set => User.FirstName = value;
        }

        public string Email
        {
            get => User.Address;
            set => User.Address = value;
        }

        public Uri Picture
        {
            get => new Uri(User.Icon, UriKind.Absolute);
            set => User.Icon = value.ToString();
        }

        public bool IsLoggedIn { get; set; }

        public string Token { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;
        public event PropertyChangedEventHandler PropertyChanged;

        public GoogleSignInViewModel()
        {
            LoginCommand = new Command(LoginAsync);
            LogoutCommand = new Command(Logout);

            _googleClientManager = CrossGoogleClient.Current;

            IsLoggedIn = false;
        }

        public async void LoginAsync()
        {
            _googleClientManager.OnLogin += OnLoginCompleted;
            try
            {
                await _googleClientManager.LoginAsync();
            }
            catch (GoogleClientSignInNetworkErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInCanceledErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInvalidAccountErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInternalErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientNotInitializedErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientBaseException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }

        }


        private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                User.FirstName = googleUser.Name;
                User.Address = googleUser.Email;
                User.Icon = googleUser.Picture.ToString();
                var GivenName = googleUser.GivenName;
                var FamilyName = googleUser.FamilyName;

                // Log the current User email
                Debug.WriteLine(User.Address);//Email);
                IsLoggedIn = true;

                var token = CrossGoogleClient.Current.ActiveToken;
                Token = token;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            _googleClientManager.OnLogin -= OnLoginCompleted;

        }

        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _googleClientManager.Logout();
        }

        private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            //User.Email = "Offline";
            _googleClientManager.OnLogout -= OnLogoutCompleted;
        }
    }
}
