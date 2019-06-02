using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crosshelper.Models;
using Crosshelper.Helpers;

namespace Crosshelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBackgroundPage : ContentPage
    {
        void Handle_Saved(object sender, System.EventArgs e)
        {
            _usr.FLanguage = FLanguage;
            _usr.SLanguage = SLanguage;
            uih.UpdateUserInfo(_usr);
            Navigation.PopAsync(false);
        }

        UserInfoHelper uih = new UserInfoHelper();
        public IList LanguageItems { get; }
        //FamiliarCountry
        //public ObservableCollection<HomeLandPickerItem> FamiliarCountryItemsSource { get; } = new ObservableCollection<FamiliarCountryPickerItem>();
        //public ObservableCollection<HomeLandPickerItem> FamiliarCountrySelectedItems { get; set; } = new ObservableCollection<FamiliarCountryPickerItem>();

        public string FLanguage { get; set; }
        public string SLanguage { get; set; }

        User _usr;

        public MyBackgroundPage(User user)
        {
            InitializeComponent();
            _usr = user;
            FLanguage = user.FLanguage;
            SLanguage = user.SLanguage;
            List<string> list = new List<string>
            {
                "English",
                "Spanish",
                "Chinese",
                "Korean",
                "Japanese",
                "French",
                "German",
                "Vietnamese"
            };
            LanguageItems = list;
            BindingContext = this;
        }

        public class HomeLandPickerItem
        {
            public string Name { get; set; }
        }
    }
}
