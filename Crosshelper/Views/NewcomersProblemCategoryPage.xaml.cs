using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class NewcomersProblemCategoryPage : ContentPage
    {

        public IList<SearchpageViewcellItem> PanelContent { get; set; }
        public NewcomersProblemCategoryPage()
        {
            InitializeComponent();
            PanelContent = new List<SearchpageViewcellItem>();
            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 1,
                Name = "Baboon",
                Rating = "★★★★★",
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = ""
            });

            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "Foothill car repair center",
                Rating = "★★★★☆",
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom001.png"
            });

            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "David&Lee business firm",
                Rating = "★★★☆☆",
                Language = "Language: Japanese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom002.png"
            });
            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "Emergency",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom003.png"
            });
            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "David lawyer llc.",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom004.png"
            });
            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "San Jose urgent care",
                Rating = "★★★★★",
                Language = "Language: Japanese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "https://s3-us-west-1.amazonaws.com/image.cycbis.com/recommendation/recom005.png"
            });

            listView.ItemsSource = PanelContent;
            listView.BackgroundColor = Color.Transparent; 
            listView.SelectionMode = ListViewSelectionMode.None;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null) return;
            //((ListView)sender).SelectedItem = null;
        }

        void DailyLifeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage());
        }
    }
}
