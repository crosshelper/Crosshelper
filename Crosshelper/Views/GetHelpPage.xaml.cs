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
                Bornin = "China",
                Rating = "★★★★★",
                Language = "Chinese",
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
                Rating = "★★★★★",
                Language = "English",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "David",
                Bornin = "Japan",
                Rating = "★★★★★",
                Language = "Japanese",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Jas",
                Bornin = "Korea",
                Rating = "★★★★★",
                Language = "Korean",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Duke",
                Bornin = "Germany",
                Rating = "★★★★★",
                Language = "German",
                Baseprice = "$40 starting cost",
                Location = "8 miles away from me",
                StatusColor = Color.FromHex("79B563"),
                StatusText = "Available",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"
            });

            BindingContext = this;
        }

        void Handle_PickProblem(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Navigation.PushAsync(new DescribeProblemPage());
        }
    }
}
