using System;
using Crosshelper.Helpers;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpTwoPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        private string Uname, Pwd, Email, ContactNo;
        public SignUpTwoPage()
        {
            InitializeComponent();
        }

        void EmailCompleted(object sender, EventArgs e)
        {
            Email = ((Entry)sender).Text;
        }
        void ContactNumCompleted(object sender, EventArgs e)
        {
            ContactNo = ((Entry)sender).Text;
        }


        void Handle_SignUp(object sender, EventArgs e)
        {
            uAccess.UserRegister(Uname, Email, ContactNo, Pwd);
            Application.Current.MainPage = new MyTabbedPage();
            //(sender as Button).Text = "Click me again!";
        }

        void Handle_SignUpAsHelper(object sender, EventArgs e)
        {

            (sender as Button).Text = "Click me again!";
        }
    }
}
