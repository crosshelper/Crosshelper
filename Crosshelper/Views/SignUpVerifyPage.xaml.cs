using System;
using Crosshelper.Helpers;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpVerifyPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        private string Uname = "";
        private string Pwd = "";
        private string Pwdc = "";

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                CodeEntry.Focus();
            });
        }

        public SignUpVerifyPage()
        {
            InitializeComponent();
        }
        //取消按钮 Cancel
        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
       

        UserAccess uac = new UserAccess();

        //注册按钮 Sign Up
        void Handle_Next(object sender, EventArgs e)
        {
           /* Uname = UnameEntry.Text;
            Pwd = PwdEntry.Text;
            Pwdc = PwdcEntry.Text;
            if (Uname.Length < 5 || Pwd.Length < 8 || Pwd != Pwdc)
            {
                DisplayAlert("No Access", "Try again!", "OK");
                return;
            }
            try
            {
                uac.UserRegister(Uname, Pwd);
                uac.SetChatID();
                Navigation.PushAsync(new SignUpTwoPage());
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex);
                return;
            }
            //Navigation.PushAsync(new SignUpTwoPage(Uname,Pwd)); */
            if (CodeEntry.Text == null)
            {
                DisplayAlert("Notice", "Please check your text code and make sure it's correct. ", "OK");

            }
            else
            {

                Navigation.PushAsync(new SignInPasswordPage());
            }
        }
        void Handle_CodeAgain(object sender, System.EventArgs e)
        {
            DisplayAlert("Notice", "Please check your text code and make sure it's correct. ", "OK");
            var time = 45;
            TmcodeAgain.Text = "Resent code in " + time + " second";
            TmcodeAgain.TextColor = Color.FromHex("#888888");
            //this.IsEnabled = false;

        }

    }
}
