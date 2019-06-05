using System;
using System.Collections.Generic;
using Crosshelper.ViewModels;
using Crosshelper.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageListPage : ContentPage
    {
        MessageListViewModel vm;

        public delegate void GroupHandler(string foo);
        public MessageListPage()
        {
            InitializeComponent();
            BindingContext = vm = new MessageListViewModel();
            vm.Navigation = Navigation;
        }

        void LstView_ItemSelected(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var user = (Models.User)e.Item;
            List<string> users = new List<string>() {
                Settings.ChatID,
                user.ChatID
            };
            ((ListView)sender).SelectedItem = null;
            vm.ConnectToChannel(user, users);
        }

        protected override void OnAppearing()
        {
            vm.DataInit();
        }
    }
}
