﻿using Crosshelper.Helpers;
using Crosshelper.ViewModels;
using SendBird;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
        ChatViewModel vm;
        static ChatPage instance = null;
        public static ChatPage CurrentActivity
        {
            get
            {
                return instance;
            }
        }
        public ChatPage(Models.User user, GroupChannel channel)
        {
            InitializeComponent();
            BindingContext = vm = new ChatViewModel();
            vm.Channel = channel;
            //vm.Title = user.Nickname;
            vm.UserName = Settings.ChatID;
            vm.Load();
            instance = this;
        }

        public void ScrollDown(UserMessage m)
        {
            list.ScrollTo(m, ScrollToPosition.End, true);
        }
	}
}