﻿using Crosshelper.Helpers;
using Crosshelper.Models;
using Crosshelper.ViewModels;
using SendBird;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatTestPage : ContentPage
	{
        public ChatTestPage (UserInfo user, GroupChannel channel)
		{
			InitializeComponent ();
            ChatTestViewModel vvm;
            this.BindingContext = vvm = new ChatTestViewModel();
            vvm.Channel = channel;
            Titlelabel.Text = user.FirstName + " " + user.LastName;
            //vvm.Title = user.FirstName + " " + user.LastName;
            vvm.Load();
        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatTestViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                        ChatList?.ScrollToFirst();
                    });
                }
            }
        }

        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }
    }
}