using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomersProblemCategoryPage : ContentPage
    {
        public IList<ProjectpageViewcellItem> Helpers { get; private set; }
        public NewcomersProblemCategoryPage()
        {
            InitializeComponent();
            Helpers = new List<ProjectpageViewcellItem>();
            Helpers.Add(new ProjectpageViewcellItem
            {
                PanelID = 0,
                HelperName = "Foothill car repair center",
                Rating = "★★★★☆",
                Language = "Language: Chinese/English",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });

            Helpers.Add(new ProjectpageViewcellItem
            {
                PanelID = 1,
                HelperName = "David&Lee business firm",
                Rating = "★★★☆☆",
                Language = "Language: Japanese/English",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });

            Helpers.Add(new ProjectpageViewcellItem
            {
                PanelID = 2,
                HelperName = "Emergency",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            Helpers.Add(new ProjectpageViewcellItem
            {
                PanelID = 3,
                HelperName = "David lawyer llc.",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });
            Helpers.Add(new ProjectpageViewcellItem
            {
                PanelID = 4,
                HelperName = "San Jose urgent care",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });

            BindingContext = this;

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage());
        }

        void DailyLifeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage());
        }

        void Handle_location(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CurrentLocationPage());
        }
    }
}
