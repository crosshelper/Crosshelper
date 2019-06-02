using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicsPage : ContentPage
    {
        //public ObservableCollection<string> Items { get; set; }
        private List<TopicInfo> TopicInfoLabels { get; set; } = new List<TopicInfo>();
        TopicInfoHelper tih = new TopicInfoHelper();

        public TopicsPage()
        {
            InitializeComponent();
            TopicInfoLabels = tih.GetMyTopicList(Settings.UserId);
            MyListView.ItemsSource = TopicInfoLabels;
            BindingContext = this;
        }

        async void OnDeleteAsync(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            bool x =  await DisplayAlert("Delete Confirm", "Delete this Topic ?", "Yes", "Cancel");
            if(x)
            {
                tih.DeleteMyTopicByID((mi.CommandParameter as TopicInfo).TopicID);
                //TopicInfoLabels.Remove((mi.CommandParameter as TopicInfo));//.TopicID
                RefreshData();
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            TopicInfo _currentTopic = e.Item as TopicInfo;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushModalAsync(new NavigationPage(new DescribeProblemPage(_currentTopic)));
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            //Deselect Item
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
            MyListView.ItemsSource = null;
            if (TopicInfoLabels.Count > 0)
            {
                TopicInfoLabels.Clear();
            }
            TopicInfoLabels = tih.GetMyTopicList(Settings.UserId);
            MyListView.ItemsSource = TopicInfoLabels;
            //currentList.EndRefresh();
        }

    }
}
