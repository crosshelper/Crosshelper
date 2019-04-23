using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProjectPage : ContentPage
    {

        public IList<ProjectpageViewcellItem> Project { get; set; }
        public ProjectPage()
        {
            InitializeComponent();
            Project = new List<ProjectpageViewcellItem>();
            Project.Add(new ProjectpageViewcellItem
            {
                PanelID = 1,
                Rating = "★★★★★",
                Language = "Chinese/English",
                Emergency = "Emergency",
                Date = "09/20/2018",
                Description = "I lost my langage at Pairs Charles de Gaulle Airport.But I can not speak French, and I dont  know how to find it.",
                Status = "Open",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            Project.Add(new ProjectpageViewcellItem
            {
                PanelID = 4124,
                Rating = "★★★★★",
                Language = "Chinese/English",
                Emergency = "Emergency",
                Date = "09/20/2018",
                Description = "I lost my langage at Pairs Charles de Gaulle Airport.But I can not speak French, and I dont  know how to find it.",
                Status = "Open",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });
            Project.Add(new ProjectpageViewcellItem
            {
                PanelID = 23,
                Rating = "★★★★★",
                Language = "Chinese/English",
                Emergency = "Emergency",
                Date = "09/20/2018",
                Description = "I lost my langage at Pairs Charles de Gaulle Airport.But I can not speak French, and I dont  know how to find it.",
                Status = "Open",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });
            currentList.ItemsSource = Project;
            currentTab.Content = currentList;

            pastList.ItemsSource = Project;
            pastTab.Content = pastList;
        }
        void Handle_CurrentItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PickHelperPage());
            //((ListView)sender).SelectedItem = null;
        }
        void Handle_PastItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PastHistoryDetailPage());
            //((ListView)sender).SelectedItem = null;
        }
    }
}
