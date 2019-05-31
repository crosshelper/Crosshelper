using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Crosshelper.Views;
using SendBird;
using Xamarin.Forms;
using Crosshelper.Helpers;

namespace Crosshelper.ViewModels
{
    public class MessageListViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<Models.User> Users { get; set; } = new ObservableCollection<Models.User>();
        public INavigation Navigation;
        #endregion
        //TODO:刷新真实user
        public MessageListViewModel()
        {
            GroupChannelListQuery mQuery = GroupChannel.CreateMyGroupChannelListQuery();
            mQuery.IncludeEmpty = true;
            mQuery.Next((List<GroupChannel> list, SendBirdException e) => {
                if (e != null)
                {
                    // Error.
                    return;
                }
                foreach(GroupChannel channel in list)
                {
                    foreach(User user in channel.Members)
                    {
                        if(user.UserId!=Settings.ChatID)
                        {
                            Users.Add(new Models.User
                            {
                                ChatID = user.UserId,
                                FirstName = user.Nickname,
                                Icon = user.ProfileUrl
                            });
                        }
                    }
                }
            });
            Users.Add(new Models.User { ChatID = "cycbis_006", FirstName = "Thomas Wong" });
        }

        public async void ConnectToChannel(Models.User user, List<string> users)
        {
            GroupChannel group = null;
            IsBusy = true;

            GroupChannel.CreateChannelWithUserIds(users, true, (GroupChannel groupChannel, SendBirdException e) => {
                if (e != null)
                {
                    // Error..
                    return;
                }
                group = groupChannel;
            });
            await Task.Delay(1000);
            IsBusy = false;
            await Navigation.PushModalAsync(new NavigationPage(new ChatPage(user, group)));
        }
    }
}
