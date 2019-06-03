using Crosshelper.Views;
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
            //MainPage = new NavigationPage((Page)Activator.CreateInstance(typeof(SignInPage))) {
            //BarBackgroundColor = Color.FromHex("#FF4E18"),
            //BarTextColor = Color.White };
            //if (CrossAutoLogin.Current.UserIsSaved) 
            //{ 
            //MainPage = new HomePage(); 
            //}
            //else
            MainPage = new MySplashScreen();//LaunchingPage();//SignInPage();
        }

        protected override void OnStart()
        {
            SendBirdClient.Init(Crosshelper.Properties.Resources.APP_ID);
            StripeConfiguration.SetApiKey("sk_live_XXXXXXXXXXXXXXX");
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
