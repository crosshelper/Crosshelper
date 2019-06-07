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
            this.SelectedTabColor = Color.FromHex("#FF4E18");
            InitializeComponent();
        }
        /*
        public MyTabbedPage(String o)
        {
            InitializeComponent();
            //Pageload();
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
        */
    }
}
