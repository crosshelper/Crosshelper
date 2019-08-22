using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class TrustedContactsPage : ContentPage
    {
        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FENo = FENo;
            _usr.SENo = SENo;
            uih.UpdateUserInfo(_usr);

            Navigation.PopAsync(false);
        }

        UserInfoHelper uih = new UserInfoHelper();
        public string FENo { get; set; }
        public string SENo { get; set; }
        UserInfo _usr;
        public TrustedContactsPage(UserInfo user)
        {
            InitializeComponent();
            _usr = user;
            FENo = user.FENo;
            SENo = user.SENo;
            BindingContext = this;
        }
    }
}
