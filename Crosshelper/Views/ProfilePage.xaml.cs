using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProfilePage : ContentPage
    {
        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FirstName = FirstName;
            _usr.LastName = LastName;
            _ac.Email = Email;
            _ac.ContactNo = PhoneNumber;

            uih.UpdateUserInfo(_usr);
            uih.UpdateUac(_ac);

            Navigation.PopAsync(false);
        }
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_ResetPassword(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage(_ac));
        }

        async void Handle_ChangePhoto(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Upload Photo", "Cencel", null, "Take photo", "From album");
        }

        User _usr;
        Uac _ac;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        UserInfoHelper uih = new UserInfoHelper();

        public ProfilePage(User user)
        {
            InitializeComponent();
            _usr = user;
            NameCell.Title = user.FirstName + " " + user.LastName;
            NameCell.IconSource = user.Icon;
            FirstName = user.FirstName;
            LastName = user.LastName;
            _ac = uih.GetUacByID(user.UserID);
            Email = _ac.Email;
            PhoneNumber = _ac.ContactNo;
            BindingContext = this;
        }
    }
}
