using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Crosshelper.Models
{
    public class PageTypeGroup : List<HelperLabel>
    {
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Subtitle { get; set; }

        public PageTypeGroup(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;

        }

        public static IList<PageTypeGroup> All { private get; set; }
    }
}
