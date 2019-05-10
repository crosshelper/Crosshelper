using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Crosshelper.Views;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SendBird;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crosshelper.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Crosshelper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            SendBirdClient.Init(Crosshelper.Properties.Resources.APP_ID);
            //MainPage = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage))) {
            //BarBackgroundColor = Color.FromHex("#FF4E18"),
            //BarTextColor = Color.White };
            MainPage = new LaunchingPage();//SignInPage();
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
