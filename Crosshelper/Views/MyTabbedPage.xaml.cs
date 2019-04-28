using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //tab1 = new PromotionCodePage().Content;
            //tab1.Content=new PromotionCodePage().Content;
        }

        public MyTabbedPage(String o)
        {
            InitializeComponent();
            Pageload();
        }
        void Pageload()
        {
            this.Children.RemoveAt(1);
            this.Children.Insert(1, new NavigationPage((Page)Activator.CreateInstance(typeof(FavoritePage))));   
        }
    }
}
