using Crosshelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoogleSignInPage : ContentPage
    {
        public GoogleSignInPage()
        {
            InitializeComponent();
            BindingContext = new GoogleSignInViewModel();
            this.Title = "Home";
        }
    }
}
