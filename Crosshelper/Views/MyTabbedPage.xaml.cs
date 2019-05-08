using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
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

            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            //var position = await locator.GetPositionAsync();
            //var CurrentLongitude = position.Longitude.ToString();
            //var CurrentLatitude = position.Latitude.ToString();
            try 
            {
                if (IsLocationAvailable())
                {
                    
                }
            }
            catch(Exception e)
            { 

            }


            MessagingCenter.Subscribe<object>(this, "Hi", (obj) =>
            {
                CurrentPage = Children[2];
            });
        }

        public bool IsLocationAvailable()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        public MyTabbedPage(String o)
        {
            InitializeComponent();
            //Pageload();
        }
        void Pageload()
        {
            this.Children.RemoveAt(1);
            this.Children.Insert(1, new NavigationPage((Page)Activator.CreateInstance(typeof(FavoritePage))));   
        }
    }
}
