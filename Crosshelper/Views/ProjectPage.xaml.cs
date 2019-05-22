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
        //TODO:下拉刷新，删除listitem
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

        void Handle_CurrentItemTapped(object sender, ItemTappedEventArgs e)
        {
            TopicInfo _currentTopic = e.Item as TopicInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new DescribeProblemPage(_currentTopic));
        }

        void Handle_PastItemTapped(object sender, ItemTappedEventArgs e)
        {
            CaseInfo _currentCase = e.Item as CaseInfo;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new PastHistoryDetailPage(_currentCase));
        }

        //protected override void OnAppearing()
        //{

        //}
    }
}
