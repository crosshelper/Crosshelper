using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProjectPage : ContentPage
    {
        private List<TopicInfo> TopicInfoLabels { get; set; } = new List<TopicInfo>();
        private List<CaseInfo> PastCaseInfoLabels { get; set; } = new List<CaseInfo>();
        UserInfoHelper uih = new UserInfoHelper();
        TopicInfoHelper tih = new TopicInfoHelper();

        public ProjectPage()
        {
            InitializeComponent();

            TopicInfoLabels = tih.GetMyTopicList(Settings.UserId);

            PastCaseInfoLabels = uih.GetPastCaseInfoByUid(Settings.UserId);

            currentList.ItemsSource = TopicInfoLabels;
            currentTab.Content = currentList;


            pastList.ItemsSource = PastCaseInfoLabels;
            pastTab.Content = pastList;
            BindingContext = this;
        }
        void Handle_CurrentItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TopicInfo _currentTopic = e.SelectedItem as TopicInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new DescribeProblemPage(_currentTopic));
        }
        void Handle_PastItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CaseInfo _currentCase = e.SelectedItem as CaseInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new PastHistoryDetailPage(_currentCase));
        }
    }
}
