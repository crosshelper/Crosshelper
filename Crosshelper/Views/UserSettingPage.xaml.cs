using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Crosshelper.Models;
using Crosshelper.Helpers;

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
        void Handle_SignOut(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new CtestPage();
        }

        private User currentUser;
        UserInfoHelper uih = new UserInfoHelper();
        public UserSettingPage()
        {
            InitializeComponent();
            currentUser = uih.GetUserInfoByID(Settings.UserId);
            UserCell.Title = currentUser.FirstName;
            UserCell.Description = currentUser.LastName;
            UserCell.IconSource = currentUser.Icon;
            //commandcell.IconSource = ImageSource.FromUri(new Uri("https://static1.squarespace.com/static/59c15a448a02c7a81f7a90aa/t/59e67fa1e5dd5b9338707436/1508278185945/Google.png"));
        }
    }
}
