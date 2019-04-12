using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class FavoritePage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new NewcomerHelperProfilePage());
        }
        public IList<HelperLabel> Helpers { get; private set; }
        public FavoritePage()
        {
            InitializeComponent();
            Helpers = new List<HelperLabel>();
            Helpers.Add(new HelperLabel
            {
                Name = "Baboon",
                Bornin = "China",
                Rating = 55555,
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Mike",
                Bornin = "China",
                Rating = 55555,
                Language = "Language: Chinese/English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });
            BindingContext = this;
        }
    }
}
