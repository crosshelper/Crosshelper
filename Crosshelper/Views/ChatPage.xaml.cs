﻿using Crosshelper.Helpers;
using Crosshelper.Models;
using Crosshelper.ViewModels;
using SendBird;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        ChatViewModel vm;
        static ChatPage instance = null;
        public static ChatPage CurrentActivity
        {
            get
            {
                return instance;
            }
        }
        public ChatPage(UserInfo user, GroupChannel channel)
        {
            InitializeComponent();

            BindingContext = vm = new ChatViewModel();
            vm.Channel = channel;
            //Page_Title.Text = user.FirstName;
            vm.Title = user.FirstName;
            vm.UserName = Settings.ChatID;
            vm.Load();
            instance = this;
        }

        public void ScrollDown(UserMessage m)
        {
            MessagesListView.ScrollTo(m, ScrollToPosition.End, true);
        }

        private void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void Handle_Canceled(object sender, System.EventArgs e)
        {
            //var tmppage = this.Parent as GetHelpPage;
            //tmppage.RefreshSelection();
            Navigation.PopModalAsync();
            //Navigation.PushAsync(new QuotePage());
        }
    }

}