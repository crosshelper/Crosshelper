﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;
using System.Threading.Tasks;

namespace Crosshelper.Views
{
    public partial class UserSettingPage : ContentPage
    {
        void Handle_MyProfile(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage(currentUser));
        }
        void Handle_Mybackground(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyBackgroundPage(currentUser));
        }
        void Handle_PaymentMethod(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PaymentPage());
        }
        void Handle_Promotion(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PromotionCodePage());
        }
        void Handle_Language(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LanguageSettingPage());
        }
        void Handle_Safety(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TrustedContactsPage(currentUser));
        }
        void Handle_Privacy(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PrivacyPage());
        }
        void Handle_AgreementPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgreementPage());
        }
        void Handle_AboutUs(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NCAboutPage());
        }
        void Handle_PastCases(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProjectPage());
        }

        async void Handle_SignOut(object sender, System.EventArgs e)
        {
            Settings.IsLogin = false;
            await Task.Delay(1000);
            //Application.Current.MainPage.
            //await Navigation.PopModalAsync();
            Application.Current.MainPage = new LaunchingPage();
        }

        //SelectableItemsView

        private User currentUser;
        UserInfoHelper uih = new UserInfoHelper();
        public UserSettingPage()
        {
            InitializeComponent();
            currentUser = uih.GetUserInfoByID(Settings.UserId);
            UserCell.Title = currentUser.FirstName + " " + currentUser.LastName;
            //UserCell.Description = currentUser.LastName;
            UserCell.IconSource = currentUser.Icon;
        }

        protected override void OnAppearing()
        {
            currentUser = uih.GetUserInfoByID(Settings.UserId);
            UserCell.Title = currentUser.FirstName + " " + currentUser.LastName;
            UserCell.IconSource = currentUser.Icon; 
            //RefreshData();
        }
    }
}
