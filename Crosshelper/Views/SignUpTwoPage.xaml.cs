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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                FNameEntry.Focus();
            });
        }

        public SignUpTwoPage()
        {
            InitializeComponent();
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private string FName, LName;

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

        void Handle_CreateAccount(object sender, EventArgs e)
        {
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

            if (FNameEntry.Text == null
                && LNameEntry.Text == null)
            {
                DisplayAlert("Notice", "Please fill all required information box.", "OK");
            }
            else
            {

                Application.Current.MainPage = new MyTabbedPage();
            }

        }

    }
}
