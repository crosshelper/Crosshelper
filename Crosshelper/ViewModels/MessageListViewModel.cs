using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Crosshelper.Views;
using SendBird;
using Xamarin.Forms;
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
            Users.Add(new Models.User { ChatID = "cycbis_001", FirstName = "Thomas", LastName = "Wong" });
            Users.Add(new Models.User { ChatID = "cycbis_002", FirstName = "Jim", LastName = "Green" });
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
