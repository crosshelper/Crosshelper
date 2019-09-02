using System;
using Crosshelper.Helpers;
using Xamarin.Forms;

using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace Crosshelper.Views
{
    public partial class SignUpVerifyPage : ContentPage
    {
        private string _contactNo = "";
        private UserAccess userAccess = new UserAccess();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
                CodeEntry.Focus();
            });
        }

        public SignUpVerifyPage(string contactNo)
        {
            _contactNo = contactNo;
            InitializeComponent();
        }
        //取消按钮 Cancel
        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //注册按钮 Sign Up
        void Handle_Next(object sender, EventArgs e)
        {
            if (_contactNo.Remove(3) == "+86")
            {
                if (CodeEntry.Text == Settings.ChinaVerify)
                {
                    Navigation.PushAsync(new SignUpPasswordPage(_contactNo));
                }
                else
                {
                    DisplayAlert("Notice", "Please check your text code and make sure it's correct. ", "OK");
                }
            }
            else
            {
                try
                {
                    string accountSid = Crosshelper.Properties.Resources.TWILIO_TOKEN;
                    string authToken = Crosshelper.Properties.Resources.TWILIO_KEY;

                    TwilioClient.Init(accountSid, authToken);

                    var verificationCheck = VerificationCheckResource.Create(
                        to: _contactNo,//"+14159373912",
                        code: CodeEntry.Text, //"123456",
                        pathServiceSid: Crosshelper.Properties.Resources.TWILIO_SERVICEID
                    );

                    Console.WriteLine(verificationCheck.Status);

                    if (CodeEntry.Text == null || verificationCheck.Status != "approved")
                    {
                        DisplayAlert("Notice", "Please check your text code and make sure it's correct. ", "OK");
                    }
                    else
                    {
                        Navigation.PushAsync(new SignUpPasswordPage(_contactNo));
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        void Handle_CodeAgain(object sender, System.EventArgs e)
        {

            if (_contactNo.Remove(3)=="+86")
            {
                userAccess.SendverifyCodeYP(_contactNo.Substring(3),userAccess.GetVerificationCode());
            }
            else
            {
                userAccess.TwilioVerifyService(_contactNo);
                var time = 45;
                TmcodeAgain.Text = "Resent code in " + time + " second";
                TmcodeAgain.TextColor = Color.FromHex("#888888");
                //this.IsEnabled = false;
            }
        }
    }
}
