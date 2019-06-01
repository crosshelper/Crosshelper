using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Converters;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PickHelperPage : ContentPage
    {
        void Handle_Canceled(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HelperLabel hl = (HelperLabel)e.SelectedItem as HelperLabel;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new HelperProfilePage(hl));
        }

        public List<HelperLabel> Helpers { get; set; }//= new List<HelperLabel>();
        UserInfoHelper uih = new UserInfoHelper();
        BindingContextConverter cvt = new BindingContextConverter();

        public PickHelperPage(TopicInfo _topic)
        {
            InitializeComponent();
            Helpers = cvt.BindingHelpersConvert(uih.GetHelperList(_topic.TagID.ToString(), _topic.Language, Settings.ZipCode));//"1"));
            BindingContext = this;
        }
    }
}
