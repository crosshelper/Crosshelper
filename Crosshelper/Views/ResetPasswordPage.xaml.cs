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

        private void ResetPwd()
        {
            if (NewPwd1 == NewPwd2 && NewPwd2.Length > 7 && NewPwd1 != OldPwd)
            {
                _ac.Pwd = NewPwd2;
                uih.UpdateUac(_ac);
                DisplayAlert("Reset success!", "Your password updated, press 'OK' back to last page.", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Not accessable input!", "Not a valid password, please try again!", "OK");
            }
        }
    }
}
