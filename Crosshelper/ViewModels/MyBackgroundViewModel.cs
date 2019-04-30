using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Crosshelper.Views;
using Xamarin.Forms;

namespace Crosshelper.ViewModels
{
    public class MyBackgroundViewModel
    {
        public MyBackgroundViewModel()
        {
            homeLands = new List<string>();
            CreateMonkeyCollection();
            //CommandPick1 = new Command(Pick);
        }

        private void CreateMonkeyCollection()
        {
            homeLands.Add("China");
            homeLands.Add("USA");
            homeLands.Add("TaiWan");
            Homelands = new ObservableCollection<string>(homeLands);
        }

        async void Pick()
        {
         //  await Navigation.PushAsync(new HomeLandPickerPage());
        }
        public INavigation Navigation { get; set; }
        //public ICommand CommandPick1 { get; set; }

        readonly IList<string> homeLands;
        public ObservableCollection<string> Homelands { get; private set; }

        readonly IList<string> selectedCountry;
        public ObservableCollection<string> SelectedCountry { get; private set; }
        //public IList<string> SelectedCountry { get; set; }



    }
}
