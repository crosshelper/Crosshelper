using System;

using Xamarin.Forms;

namespace Crosshelper.Models
{
    public class ProjectpageViewcellItem : ContentPage
    {
        public ProjectpageViewcellItem()
        {
        }

        public int PanelID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Language { get; set; }
        public string Baseprice { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Language;
        }
    }
}

