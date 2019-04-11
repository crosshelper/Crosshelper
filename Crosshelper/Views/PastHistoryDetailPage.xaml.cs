using System;
using System.Collections.Generic;
using Crosshelper.Models;
using Xamarin.Forms;

namespace Crosshelper.Views
{
    public partial class PastHistoryDetailPage : ContentPage
    {
        public IList<ProjectpageViewcellItem> CaseDetail { get; set; }
        public PastHistoryDetailPage()
        {
           

            InitializeComponent();
            CaseDetail = new List<ProjectpageViewcellItem>();
            CaseDetail.Add(new ProjectpageViewcellItem
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
        }
    }
}
