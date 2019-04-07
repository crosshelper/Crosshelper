using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class ProjectPage : ContentPage
    {
        public IList<ProjectpageViewcellItem> ProjectPanelContent { get; set; }
        public ProjectPage()
        {
            InitializeComponent();
            ProjectPanelContent = new List<ProjectpageViewcellItem>();

            ProjectPanelContent.Add(new ProjectpageViewcellItem
            {
                PanelID = 1,
                Rating = 55555,
                Language = "Chinese/English",
                Emergency = "Emergency",
                Date = "09/20/2018",
                Description = "I lost my langage at Pairs Charles de Gaulle Airport.But I can not speak French, and I dont  know how to find it.",
                Status = "Open",
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });


            listView.ItemsSource = ProjectPanelContent;
            listView.BackgroundColor = Color.Transparent;
            listView.SelectionMode = ListViewSelectionMode.None;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null) return;
            //((ListView)sender).SelectedItem = null;
        }

    }
    }
