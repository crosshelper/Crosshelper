using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Crosshelper.Converters;
using Crosshelper.Helpers;
using Crosshelper.Models;
using SendBird;
using Xamarin.Forms;

namespace Crosshelper.Views
{

    public partial class HelperProfilePage : ContentPage, INotifyPropertyChanged
    {
        private HelperLabel _currenthelperlabel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await System.Threading.Tasks.Task.Delay(150);
            });
        }

        public HelperProfilePage()
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;
        }

        public HelperProfilePage(HelperLabel hl)
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;
            _currenthelperlabel = hl;
            Pageload(hl);
        }

        /// <loading>
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        /// <loading>

        UserInfoHelper uih = new UserInfoHelper();
        BindingContextConverter bcc = new BindingContextConverter();

        private void Pageload(HelperLabel hl)
        {
            HelperName.Text = hl.Name;
            HelperLanguage.Text = hl.Language;
            HelperRating.Text = hl.Rating;
            HelperTags.Text = uih.GetTagsByID(hl.HelperID);
            HelperBio.Text = hl.Bio;
            HelperPrice.Text = hl.Baseprice;
            HelperImage.Source = hl.ImageUrl;

            /*
            List<ReviewLabelContent> reviewsList = bcc.BindingReviewssConvert(uih.GetReviewsList(hl.HelperID));
            ReviewerName1.Text = reviewsList[0].ReviewerName;
            ReviewerRating1.Text = reviewsList[0].ReviewerRating;
            ReviewerContent1.Text = reviewsList[0].ReviewerContent;
            ReviewerName2.Text = reviewsList[1].ReviewerName;
            ReviewerRating2.Text = reviewsList[1].ReviewerRating;
            ReviewerContent2.Text = reviewsList[1].ReviewerContent;
            ReviewerName3.Text = reviewsList[2].ReviewerName;
            ReviewerRating3.Text = reviewsList[2].ReviewerRating;
            ReviewerContent3.Text = reviewsList[2].ReviewerContent;*/
        }

        async void ConnectToChannel(UserInfo user, List<string> users)
        {
            GroupChannel group = null;
            IsBusy = true;

            GroupChannel.CreateChannelWithUserIds(users, true, (GroupChannel groupChannel, SendBirdException e) => {
                if (e != null)
                {
                    // Error.
                    return;
                }
                group = groupChannel;
            });
            await Task.Delay(2000);
            IsLoading = false;
            IsBusy = false;
            await Navigation.PushModalAsync(new NavigationPage(new ChatTestPage(user, group)));
        }
        //Confirm
        async void Handle_GetHelp(object sender, EventArgs e)
        {
            IsLoading = true;
            if (Settings.IsLogin)
            {
                var user = new UserInfo() {
                    UserID = _currenthelperlabel.ChatID
                };
                List<string> users = new List<string>() {
                Settings.ChatID,
                _currenthelperlabel.ChatID
                };
                ConnectToChannel(user, users);
            }
        }
    }
}
