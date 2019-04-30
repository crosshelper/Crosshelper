using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Crosshelper.ViewModels
{
    public class HomeLandPickerViewModel
    {
        public HomeLandPickerViewModel()
        {
            homeLands = new List<string>();
            CreateHomelandsCollection();
        }
        private void CreateHomelandsCollection() 
        {
            homeLands.Add("China");
            homeLands.Add("USA");
            homeLands.Add("TaiWan");
        }
        readonly IList<string> homeLands;
        public ObservableCollection<string> Homelands { get; private set; }
        public INavigation Navigation { get; internal set; }
    }
}
