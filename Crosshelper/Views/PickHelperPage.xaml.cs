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

        public PickHelperPage()
        {
            InitializeComponent();
            Helpers = cvt.BindingHelpersConvert(uih.GetHelperList("1"));
            //Helpers = new List<HelperLabel>();
            Helpers.Add(new HelperLabel
            {
                Name = "Baboon",
                Rating = "★★★★★",
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });
            BindingContext = this;
        }
    }
}
