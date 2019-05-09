using System;
using System.Collections.Generic;
using System.Windows.Input;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ResetPasswordPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        public ICommand ResetCommand { get; private set; }

        Uac _ac;
        public string OldPwd { get; set; }
        public string NewPwd1 { get; set; }
        public string NewPwd2 { get; set; }
        UserInfoHelper uih = new UserInfoHelper();

        public ResetPasswordPage(Uac ac)
        {
            _ac = ac;
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            OldPwd = _ac.Pwd;
            ResetCommand = new Command(ResetPwd);
            BindingContext = this;
        }

        public void ResetPwd()
        {
            if (NewPwd1 == NewPwd2 && NewPwd1.Length > 7 && NewPwd1 != OldPwd)
            {
                _ac.Pwd = NewPwd2;
                uih.UpdateUac(_ac);
                Navigation.PopToRootAsync(false);
            }
            else
            {
                DisplayAlert("Not accessable input!", "Password reset error, please try again!", "OK");
            }
        }
    }
}
