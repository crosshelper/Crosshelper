using Crosshelper.Views;
using Plugin.Multilingual;
using SendBird;
using Stripe;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Crosshelper
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
            StripeConfiguration.SetApiKey("sk_live_XXXXXXXXXXXXXXX");
            SendBirdClient.Init(Crosshelper.Properties.Resources.APP_ID);
            MainPage = new MySplashScreen();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
