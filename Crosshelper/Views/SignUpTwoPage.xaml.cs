using System;
using Crosshelper.Helpers;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpTwoPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        private string Uname, Pwd, Email, ContactNo = "";
        public SignUpTwoPage(string uname, string pwd)
        {
            InitializeComponent();
            Uname = uname;
            Pwd = pwd;
        }

        void EmailCompleted(object sender, EventArgs e)
        {
            Email = ((Entry)sender).Text;
        }
        void ContactNumCompleted(object sender, EventArgs e)
        {
            ContactNo = ((Entry)sender).Text;
        }

        void Handle_SignUp(object sender, EventArgs e)
        {
            uAccess.UserRegister(Uname, Email, ContactNo, Pwd);
            Settings.IsLogin = uAccess.VerifyUser(Uname, Pwd);
            uAccess.SetChatID();
            DisplayAlert("Congrats!", "You Have Done Sign Up, Sign In right now", "OK");
            Navigation.PopToRootAsync();
            //Application.Current.MainPage = new LaunchingPage();
        }

        void Handle_SignUpAsHelper(object sender, EventArgs e)
        {

            (sender as Button).Text = "Click me again!";
        }
    }
}
