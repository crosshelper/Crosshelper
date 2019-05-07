using Plugin.Messaging;
using Xamarin.Forms;


namespace Crosshelper.Views
{
    public partial class NCAboutPage : ContentPage
    {
        private string supportsEmail, emailTitle, emailBody;


        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        public NCAboutPage()
        {
            InitializeComponent();

            supportsEmail = "bo.chen@cycbis.com";
            emailTitle = "[SupportsTicket]Feedback from Customer";
            emailBody = emaileditor.Text;

            SubmitBtn.Clicked += async (sender, e) =>
            {
                try
                {
                    var emailTask = CrossMessaging.Current.EmailMessenger;
                    if (emailTask.CanSendEmail)
                        emailTask.SendEmail(supportsEmail, emailTitle, emailBody);
                    else
                        await DisplayAlert("Error", "This device can't send emails", "OK");
                }
                catch
                {
                    await DisplayAlert("Error", "Unable to perform action", "OK");
                }
                //Navigation.PopAsync(false);
            };
        }

        void Handle_Submit(object sender, System.EventArgs e)
        {

        }
    }
}
