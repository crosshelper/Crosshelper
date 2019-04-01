using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PickHelperPage : ContentPage
    {
        public IList<HelperLabel> Helpers { get; private set; }
        public PickHelperPage()
        {
            InitializeComponent();

            Helpers = new List<HelperLabel>();
            Helpers.Add(new HelperLabel
            {
                Name = "Baboon",
                Bornin = "China",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "Africa & Asia",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Mike",
                Bornin = "China",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "Central & South America",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "David",
                Bornin = "Japan",
                Rating = 5,
                Language = "Japanese/English",
                Baseprice = "40",
                Location = "Central and East Africa",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Jas",
                Bornin = "Korea",
                Rating = 5,
                Language = "Korean/English",
                Baseprice = "40",
                Location = "Central & South America",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Jack",
                Bornin = "China",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "Brazil",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Duke",
                Bornin = "Germany",
                Rating = 5,
                Language = "German/English",
                Baseprice = "40",
                Location = "South America",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Bill",
                Bornin = "Germany",
                Rating = 5,
                Language = "German/English",
                Baseprice = "40",
                Location = "Japan",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Marry",
                Bornin = "Russia",
                Rating = 5,
                Language = "Russian/English",
                Baseprice = "40",
                Location = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Christ",
                Bornin = "Duby",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "Borneo",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Leon",
                Bornin = "Iraq",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "Vietnam, Laos",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Portrait_of_a_Douc.jpg/159px-Portrait_of_a_Douc.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Ada",
                Bornin = "Korea",
                Rating = 5,
                Language = "Korean/English",
                Baseprice = "40",
                Location = "Vietnam",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Cuc.Phuong.Primate.Rehab.center.jpg/320px-Cuc.Phuong.Primate.Rehab.center.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Bob",
                Bornin = "Japan",
                Rating = 5,
                Language = "Japanese/English",
                Baseprice = "40",
                Location = "China",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Golden_Snub-nosed_Monkeys%2C_Qinling_Mountains_-_China.jpg/165px-Golden_Snub-nosed_Monkeys%2C_Qinling_Mountains_-_China.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Fury",
                Bornin = "Sweeden",
                Rating = 5,
                Language = "Chinese/English",
                Baseprice = "40",
                Location = "China",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/RhinopitecusBieti.jpg/320px-RhinopitecusBieti.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Leo",
                Bornin = "Russia",
                Rating = 5,
                Language = "Russian/English",
                Baseprice = "40",
                Location = "Vietnam",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg/320px-Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Nick",
                Bornin = "Mexico",
                Rating = 5,
                Language = "Spanish/English",
                Baseprice = "40",
                Location = "Indonesia",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Thomas%27s_langur_Presbytis_thomasi.jpg/142px-Thomas%27s_langur_Presbytis_thomasi.jpg"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Juliya",
                Bornin = "France",
                Rating = 5,
                Language = "Franch/English",
                Baseprice = "40",
                Location = "Sri Lanka",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Semnopithèque_blanchâtre_mâle.JPG/192px-Semnopithèque_blanchâtre_mâle.JPG"
            });

            Helpers.Add(new HelperLabel
            {
                Name = "Joserph",
                Bornin = "Italy",
                Rating = 5,
                Language = "Italian/English",
                Baseprice = "40",
                Location = "Ethiopia",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Gelada-Pavian.jpg/320px-Gelada-Pavian.jpg"
            });

            BindingContext = this;
        }
    }
}
