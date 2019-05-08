using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class GetHelpPage : ContentPage
    {
        public IList<HelperLabel> Helpers { get; private set; }
        public GetHelpPage()
        {
            InitializeComponent();

            Helpers = new List<HelperLabel>();
            Helpers.Add(new HelperLabel
            {
                Name = "Baboon",
                Rating = "★★★★★",
                Language = "Chinese",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Mike",
                Rating = "★★★★★",
                Language = "English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "David",
                Rating = "★★★★★",
                Language = "Japanese",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Jas",
                Rating = "★★★★★",
                Language = "Korean",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Duke",
                Rating = "★★★★★",
                Language = "German",
                Baseprice = "$40 starting cost",
                Location = "8 miles away",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                LocationIconUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/Icon/LocationPinIcon.png",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });


            BindingContext = this;
        }

        void Handle_Search(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }

        void Handle_PickProblem(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new DescribeProblemPage()));
        }
    }
}
