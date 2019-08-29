﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Crosshelper.Views;
using SendBird;
using Xamarin.Forms;
using Crosshelper.Helpers;
using System;
using Crosshelper.Models;
using System.Windows.Input;

namespace Crosshelper.ViewModels
{
    public class MessageListViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<UserInfo> Users { get; set; } = new ObservableCollection<UserInfo>();
        public INavigation Navigation;
        #endregion
        public MessageListViewModel()
        {
            DataInit();
        }

        public void DataInit()
        {
            if (Users.Count > 0)
            {
                Users.Clear();
            }
            GroupChannelListQuery mQuery = GroupChannel.CreateMyGroupChannelListQuery();
            mQuery.IncludeEmpty = true;
            mQuery.Next((List<GroupChannel> list, SendBirdException e) => {
                if (e != null)
                {
                    // Error.
                    return;
                }
                foreach (GroupChannel channel in list)
                {
                    foreach (User user in channel.Members)
                    {
                        if (user.UserId != Settings.ChatID)
                        {
                            Users.Add(new UserInfo
                            {
                                ChatID = user.UserId,
                                FirstName = user.Nickname,
                                Icon = user.ProfileUrl,
                                Homeland = ((UserMessage)channel.LastMessage).Message,
                                Address = MilsecToDatetime(channel.LastMessage.CreatedAt).ToShortTimeString()//ToString()
                            });
                        }
                    }
                }
            });
            //Users.Add(new Models.User { ChatID = "cycbis_006", FirstName = "Thomas Wong" });
        }

        private DateTime MilsecToDatetime(long milsec)
        {
            var createtimestamp = DateTimeOffset.FromUnixTimeMilliseconds(milsec).UtcDateTime;
            createtimestamp = createtimestamp.ToLocalTime();
            return createtimestamp;
        }

        public async void ConnectToChannel(UserInfo user, List<string> users)
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
            await Task.Delay(2000);
            IsBusy = false;
            await Navigation.PushModalAsync(new NavigationPage(new ChatTestPage(user, group)));
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
            DataInit();
        }
    }
}
