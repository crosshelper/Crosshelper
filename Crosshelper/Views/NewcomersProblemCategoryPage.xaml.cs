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
                Rating = 55555,
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "Mike",

                Rating = 55555,
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });

            PanelContent.Add(new SearchpageViewcellItem
            {
                PanelID = 0,
                Name = "David",
                Rating = 55555,
                Language = "Language: Japanese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
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
