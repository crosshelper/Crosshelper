using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProjectPage : ContentPage
    {
        private List<CaseInfo> CaseInfoLabels { get; set; } = new List<CaseInfo>();
        private List<CaseInfo> PastCaseInfoLabels { get; set; } = new List<CaseInfo>();
        UserInfoHelper uih = new UserInfoHelper();

        public ProjectPage()
        {
            InitializeComponent();
            CaseInfoLabels = uih.GetCaseInfoByUid(Settings.UserId);
            PastCaseInfoLabels = uih.GetPastCaseInfoByUid(Settings.UserId);

            currentList.ItemsSource = CaseInfoLabels;
            currentTab.Content = currentList;
            pastList.ItemsSource = PastCaseInfoLabels;
            pastTab.Content = pastList;
            BindingContext = this;
        }
        void Handle_CurrentItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CaseInfo _currentCase = e.SelectedItem as CaseInfo;
            //((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new PastHistoryDetailPage(_currentCase));
        }
        void Handle_PastItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CaseInfo _currentCase = e.SelectedItem as CaseInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new PastHistoryDetailPage(_currentCase));
        }
    }
}
