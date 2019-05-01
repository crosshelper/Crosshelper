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
            Navigation.PopToRootAsync(false);
        }
        //返回按钮 Go Back
        void SUPGoBack(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //注册邮箱&密码输入框&再次输入 Sign up email&password&password again input box
        void SUPUnameCompleted(object sender, EventArgs e)
        {
            Uname = ((Entry)sender).Text;
        }
        void SUPEmailCompleted(object sender, EventArgs e)
        {
            Email = ((Entry)sender).Text;
        }
        void SUPContactNoCompleted(object sender, EventArgs e)
        {
            ContactNo = ((Entry)sender).Text;
        }
        void SUPPasswordCompleted(object sender, EventArgs e)
        {
            Pwd = ((Entry)sender).Text;
        }
        void SUPComfirmPasswordCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        //注册按钮 Sign Up
        void Handle_SignUp(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }
        void SUPSignUpAsHelper(object sender, EventArgs e)
        {
            uAccess.UserRegister(Uname,Email,ContactNo,Pwd);
            //(sender as Button).Text = "Click me again!";
        }
    }
}
