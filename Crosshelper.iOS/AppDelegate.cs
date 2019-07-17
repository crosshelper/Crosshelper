using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Platform;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Plugin.GoogleClient;
using UIKit;
using Xamarin.Forms;

namespace Crosshelper.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            GoogleClientManager.Initialize();
            AiForms.Renderers.iOS.SettingsViewInit.Init(); //need to write here
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init();
            ImageCircleRenderer.Init();
            //PlacesClient.ProvideApiKey("AIzaSyBcxooWTNnHQJb10x0cgkijXn5fowDfUjE");
            LoadApplication(new App());
            return base.FinishedLaunching(app, options); 

        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return GoogleClientManager.OnOpenUrl(app, url, options);
        }
    }
}
