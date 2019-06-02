using Plugin.Messaging;
using Xamarin.Forms;
using Crosshelper.Helpers;

namespace Crosshelper.Views
{
    public partial class NCAboutPage : ContentPage
    {
        private string supportsEmail, emailTitle, emailBody;
        public NCAboutPage()
        {
            InitializeComponent();

            supportsEmail = "bo.chen@cycbis.com";
            emailTitle = "[Supports Ticket] Feedback from Customer: " + Settings.ChatID;

            SubmitBtn.Clicked += async (sender, e) =>
            {
                try
                {
                    var emailTask = CrossMessaging.Current.EmailMessenger;
                    if (emailTask.CanSendEmail)
                    {
                        emailBody = emaileditor.Text;
                        emailTask.SendEmail(supportsEmail, emailTitle, emailBody);

                        /*var email = new EmailMessageBuilder()
                              .To("william.liang@cycbis.com")
                              .Cc("william.liang@cycbis.com")
                              .Bcc(new[] { "william.liang@cycbis.com", "william.liang@cycbis.com" })
                              .Subject("Xamarin Messaging Plugin")
                              .Body("Well hello there from Xam.Messaging.Plugin")
                              .Build();
                        emailTask.SendEmail(email);*/
                    }
                        
                    else
                    {
                        await DisplayAlert("Error", "This device can't send emails", "OK");
                    }
                }
                catch
                {
                    await DisplayAlert("Error", "Unable to perform action", "OK");
                }
            };
        }
    }
}
