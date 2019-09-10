using System;
using System.Collections.Generic;
using Crosshelper.Helpers;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class SearchPage : ContentPage
    {
        void Handle_Canceled(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            TypeProblem _currentTag = e.Item as TypeProblem;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new DescribeProblemPage(_currentTag));
        }

        TagsHelper th = new TagsHelper();
        public IList<TypeProblem> TypeProblems { get; private set; } = new List<TypeProblem>();
        public SearchPage()
        {
            InitializeComponent();
            if (AppResources.Culture.Name == "zh-CN")
            {
                TypeProblems = th.GetzhTagList();
            }
            else
            {
                TypeProblems = th.GetTagList();
            }
            BindingContext = this;
        }
    }
}
