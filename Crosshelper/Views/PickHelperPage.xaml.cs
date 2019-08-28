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
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            HelperLabel hl = (HelperLabel)e.Item as HelperLabel;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new HelperProfilePage(hl));
        }

        public List<HelperLabel> Helpers { get; set; }//= new List<HelperLabel>();
        UserInfoHelper uih = new UserInfoHelper();
        BindingContextConverter cvt = new BindingContextConverter();

        public PickHelperPage(TopicInfo _topic)
        {
            InitializeComponent();
            if (_topic.Zipcode == "00000")
            {
                Helpers = cvt.BindingHelpersConvert(uih.GetExHelperList(_topic.TagID.ToString(), _topic.Language));
            }
            else
            {
                Helpers = cvt.BindingHelpersConvert(uih.GetHelperList(_topic.TagID.ToString(), _topic.Language, Settings.ZipCode));
            }
            BindingContext = this;
        }
    }
}
