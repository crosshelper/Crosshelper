using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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
        //TODO:删除listitem
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

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;
                    RefreshData();
                    IsRefreshing = false;
                });
            }
        }

        private void RefreshData()
        {
            //currentList.BeginRefresh();
            currentList.ItemsSource = null;
            if (TopicInfoLabels.Count > 0)
            {
                TopicInfoLabels.Clear();
            }
            TopicInfoLabels = tih.GetMyTopicList(Settings.UserId);
            currentList.ItemsSource = TopicInfoLabels;
            //currentList.EndRefresh();
        }
    }
}
