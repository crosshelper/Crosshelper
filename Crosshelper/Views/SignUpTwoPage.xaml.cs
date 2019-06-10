using System;
using Crosshelper.Helpers;
using WebSocketSharp;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpTwoPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        UserInfoHelper uih = new UserInfoHelper();
        private string Email, ContactNo = "";
        public SignUpTwoPage()
        {
            InitializeComponent();
        }

        void EmailCompleted(object sender, EventArgs e)
        {
            Email = ((Entry)sender).Text;
        }
        void ContactNumCompleted(object sender, EventArgs e)
        {
            ContactNo = ((Entry)sender).Text;
        }

        private string FName, LName;

        private bool GetRealName()
        {
            var IsNameValid = false;
            var name = NameEntry.Text;
            string[] sArray = name.Split(' ');
            //Regex.Split(str, "js", RegexOptions.IgnoreCase);
            FName = "";
            LName = "";
            if (sArray.Length == 2)
            {
                FName = sArray[0];
                LName = sArray[1];
                IsNameValid = true;
            }
            return IsNameValid;
        }

        void Handle_SignUp(object sender, EventArgs e)
        {
            if(GetRealName())
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
        }

        void Handle_SignUpAsHelper(object sender, EventArgs e)
        {

            (sender as Button).Text = "Click me again!";
        }
    }
}
