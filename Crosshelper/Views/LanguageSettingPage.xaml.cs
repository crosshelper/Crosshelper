using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crosshelper.Views
{
    public partial class LanguageSettingPage : ContentPage
    {
        public IList AppLanguageItems { get; }
        public LanguageSettingPage()
        {
            InitializeComponent();

            List<string> list = new List<string>
            {
                "Chinese",
                "English",
                "Spanish",
                "Korean",
                "Japanese",
                "French",
                "German",
                "Thai"
            };
            AppLanguageItems = list;
        }
    }
}
