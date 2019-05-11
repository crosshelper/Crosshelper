using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crosshelper.Converters;
using Crosshelper.Helpers;
using Crosshelper.Models;
using SendBird;
using Xamarin.Forms;

namespace Crosshelper.Views
{

    public partial class HelperProfilePage : ContentPage
    {
        private HelperLabel _currenthelperlabel;

        public HelperProfilePage()
        {
            InitializeComponent();
        }

        public HelperProfilePage(HelperLabel hl)
        {
            InitializeComponent();
            _currenthelperlabel = hl;
            Pageload(hl);
        }

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

            List<ReviewLabelContent> reviewsList = bcc.BindingReviewssConvert(uih.GetReviewsList(hl.HelperID));
            ReviewerName1.Text = reviewsList[0].ReviewerName;
            ReviewerRating1.Text = reviewsList[0].ReviewerRating;
            ReviewerContent1.Text = reviewsList[0].ReviewerContent;
            ReviewerName2.Text = reviewsList[1].ReviewerName;
            ReviewerRating2.Text = reviewsList[1].ReviewerRating;
            ReviewerContent2.Text = reviewsList[1].ReviewerContent;
            ReviewerName3.Text = reviewsList[2].ReviewerName;
            ReviewerRating3.Text = reviewsList[2].ReviewerRating;
            ReviewerContent3.Text = reviewsList[2].ReviewerContent;
        }

        async void ConnectToChannel(Models.User user, List<string> users)
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
            await Task.Delay(3000);
            IsBusy = false;
            await Navigation.PushAsync(new ChatPage(user, group));
        }

        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        //Top Ring&Menu button
        void NHPPBackButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        void NHPPCancelButton(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }
        //Confirm
        void Handle_GetHelp(object sender, EventArgs e)
        {
            if (Settings.IsLogin)
            {
                var user = new Models.User() {
                    UserID = _currenthelperlabel.ChatID
                };
                List<string> users = new List<string>() {
                Settings.ChatID,
                _currenthelperlabel.ChatID
                };
                ConnectToChannel(user, users);
            }
        }

        void Handle_Like(object sender, System.EventArgs e)
        {

        }
    }
}
