using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();
        }

        public MyTabbedPage(String o)
        {
            InitializeComponent();
            //Pageload();

            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            //var position = await locator.GetPositionAsync();
            //var CurrentLongitude = position.Longitude.ToString();
            //var CurrentLatitude = position.Latitude.ToString();
            MessagingCenter.Subscribe<object>(this, "Hi", (obj) =>
            {
                CurrentPage = Children[2];
            });
        }

        void Pageload()
        {
            this.Children.RemoveAt(1);
           // this.Children.Insert(1, new NavigationPage((Page)Activator.CreateInstance(typeof(FavoritePage))));   
        }
    }
}
