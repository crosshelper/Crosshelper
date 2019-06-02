using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : ContentPage
    {
        private List<CaseInfo> PastCaseInfoLabels { get; set; } = new List<CaseInfo>();
        UserInfoHelper uih = new UserInfoHelper();
        public ProjectPage()
        {
            InitializeComponent();
            PastCaseInfoLabels = uih.GetPastCaseInfoByUid(Settings.UserId);
            pastList.ItemsSource = PastCaseInfoLabels;
            BindingContext = this;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Action", mi.CommandParameter + "delete action", "OK");//(mi.CommandParameter as ListviewItem).Title
        }

        void Handle_PastItemTapped(object sender, ItemTappedEventArgs e)
        {
            CaseInfo _currentCase = e.Item as CaseInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new PastHistoryDetailPage(_currentCase));
        }
    }
}
