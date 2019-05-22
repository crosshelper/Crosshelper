﻿using Xamarin.Forms;

namespace Crosshelper.Models
{
    public class HelperLabel
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Language { get; set; }
        public string Baseprice { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string LocationIconUrl { get; set; }
        public string StatusText { get; set; }
        public Color StatusColor { get; set; }
        public string HelperID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
