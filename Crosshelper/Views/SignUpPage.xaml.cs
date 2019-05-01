using System;
using Crosshelper.Helpers;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SignUpPage : ContentPage
    {
        UserAccess uAccess = new UserAccess();
        private string Uname, Pwd, Email, ContactNo;
        public SignUpPage()
        {
            InitializeComponent();
        }
        //取消按钮 Cancel
        void Handle_Canceled(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new SignInPage();
        }
        //注册邮箱&密码输入框&再次输入 Sign up email&password&password again input box
        void UnameCompleted(object sender, EventArgs e)
        {
            Uname = ((Entry)sender).Text;
        }
        void EmailCompleted(object sender, EventArgs e)
        {
            Email = ((Entry)sender).Text;
        }
        void ContactNumCompleted(object sender, EventArgs e)
        {
            ContactNo = ((Entry)sender).Text;
        }
        void PasswordCompleted(object sender, EventArgs e)
        {
            Pwd = ((Entry)sender).Text;
        }
        void PasswordComfirmCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        //注册按钮 Sign Up
        void Handle_SignUp(object sender, EventArgs e)
        {
            uAccess.UserRegister(Uname, Email, ContactNo, Pwd);
            //(sender as Button).Text = "Click me again!";
        }
        void Handle_SignUpAsHelper(object sender, EventArgs e)
        {

            (sender as Button).Text = "Click me again!";
        }
    }
}
